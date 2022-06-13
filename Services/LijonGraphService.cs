using LijonGraph.Contracts;
using LijonGraph.Models;
using LijonGraph.Models.Beta.Reports;
using LijonGraph.Models.Reports.CSV;
using FileHelpers;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static LijonGraph.ServiceEnums.ServiceEnums;
using Client = LijonGraph.LijonHttpServices;

namespace LijonGraph.Services
{
    public class LijonGraphService : ILijonGraph
    {
        private static string BaseUrl = "https://graph.microsoft.com/v1.0";
        private static string[] Scopes = new string[] { "https://graph.microsoft.com/.default" };

        public LijonGraphService(string baseUrl = null, string[] scopes = null)
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
                BaseUrl = baseUrl;

            if (scopes != null)
                Scopes = scopes;
        }

        public class ApiException : Exception
        {
            public int StatusCode { get; set; }
            public string Content { get; set; }
        }

        public async Task<string> CollectAccessToken(string clientId, string clientSecret, string authority, string tenant, string[] scopes = null)
        {
            if (scopes != null)
                Scopes = scopes;

            IConfidentialClientApplication app;

            app = ConfidentialClientApplicationBuilder.Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority(new Uri(authority))
            .Build();

            AuthenticationResult result = null;
            result = await app.AcquireTokenForClient(Scopes).ExecuteAsync();

            return result?.AccessToken;
        }

        private static async Task<T> GetPage<T>(string uri, string accesstoken, CancellationToken cancellationToken, int maxAmountOfTries = 5)
        {
            var response = await Client.GetHttp<T>(uri, accesstoken, cancellationToken);
            var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return Client.DeserializeJsonFromStream<T>(stream);

            int retries = 0;

            while (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                ++retries;

                var retryAfter = response.Headers?.RetryAfter?.Delta;
                if (retryAfter == null)
                    retryAfter = new TimeSpan(0, 0, 100);

                Thread.Sleep((int)retryAfter.Value.TotalMilliseconds);

                if (response.IsSuccessStatusCode)
                    return Client.DeserializeJsonFromStream<T>(stream);
            }

            var content = await Client.StreamToStringAsync(stream);

            throw new ApiException
            {
                StatusCode = (int)response.StatusCode,
                Content = content
            };
        }

        public async Task<IEnumerable<SubscribedSku>> GetSubscribedSkus(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null)
        {
            if (string.IsNullOrEmpty(accesstoken))
                throw new ArgumentNullException();

            var model = new List<SubscribedSku>();

            string nextUri = $"{BaseUrl}/subscribedSkus{query}";

            if (query?.Contains("top=") == false && collectAll == true)
            {
                if (query == "")
                    nextUri = $"{nextUri}?$top=999";
                else
                    nextUri = $"{nextUri} &$top=999";
            }

            do
            {
                try
                {

                    var skuResponse = await GetPage<OdataSubskribedSku>($"{nextUri}", accesstoken, cancellationToken);

                    foreach (var users in skuResponse?.SubScribedSkus)
                        model.Add(users);

                    nextUri = collectAll == false ? null : skuResponse?.PagingUrl;
                }
                catch (ApiException ex)
                {
                    switch (ex.StatusCode)
                    {
                        case 404:
                            throw new HttpRequestException($"Resource not found");
                        case 401:
                            throw new UnauthorizedAccessException($"Client is not authorized for this request");
                        case 403:
                            throw new UnauthorizedAccessException($"Client is not allowed this resource");
                        default:
                            throw new Exception($"{ex.StatusCode}");
                    }
                }

            } while (string.IsNullOrEmpty(nextUri) == false);

            return model;
        }

        public async Task<T[]> GetReport<T>(string token, DateTime date, CancellationToken cancellationToken) where T : class, IGraphReport, new()
        {
            var instance = new T();

            var thisDay = "";
            var thisMonth = "";

            if (date.Day.ToString().Count() > 1)
                thisDay = date.Day.ToString();
            else
                thisDay = $"0{date.Day.ToString()}";

            if (date.Month.ToString().Count() > 1)
                thisMonth = date.Month.ToString();
            else
                thisMonth = $"0{date.Month.ToString()}";

            var thisDate = $"{date.Year}-{thisMonth}-{thisDay}";

            Console.WriteLine($"Collecting for date {thisDate}");

            var uri = $"{BaseUrl}/{instance.GetServiceEndpoint()}(date={thisDate})";

            if (date < DateTime.Now.AddYears(-50))
                uri = $"{BaseUrl}/{instance.GetServiceEndpoint()}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=none");

            int tries = 0;
            while (true)
            {
                if (tries++ >= 10)
                    throw new TimeoutException($"Timed out at {nameof(GetReport)}");

                var response = await client.GetAsync(uri);

                if (response == null)
                    return null;

                if (response.IsSuccessStatusCode)
                {
                    string file = "";

                    using (var webClient = new WebClient())
                        file = webClient.DownloadString(response.RequestMessage.RequestUri.AbsoluteUri);

                    var userDetail = new FileHelperEngine<T>();
                    userDetail.Options.IgnoreFirstLines = 1;

                    return userDetail.ReadString(file);
                }
                else if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    if (int.TryParse(response.Headers.RetryAfter.ToString(), out int retryAfter) == false)
                    {
                        retryAfter = 60;
                    }

                    await Task.Delay(1000 * retryAfter);
                    Console.WriteLine("Throttled");
                    continue;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<TeamsReportData>> GetTeamsReportBeta<T>(string accesstoken, DateTime date, CancellationToken cancellationToken, bool collectAll = true, string query = null)
        {
            string nextUri = "";
            string betaBase = "https://graph.microsoft.com/beta";

            var model = new List<TeamsReportData>();

            var thisDay = "";
            var thisMonth = "";

            if (date.Day.ToString().Count() > 1)
                thisDay = date.Day.ToString();
            else
                thisDay = $"0{date.Day.ToString()}";

            if (date.Month.ToString().Count() > 1)
                thisMonth = date.Month.ToString();
            else
                thisMonth = $"0{date.Month.ToString()}";

            var thisDate = $"{date.Year}-{thisMonth}-{thisDay}";

            Console.WriteLine($"Collecting for date {thisDate}");
            nextUri = $"{betaBase}/reports/getTeamsUserActivityUserDetail(date={thisDate})?$format=application/json";

            do
            {
                try
                {
                    var reportResponse = await GetPage<Models.Beta.Reports.TeamsUserActivityUserDetail>($"{nextUri}", accesstoken, cancellationToken);

                    foreach (var users in reportResponse.ReportData)
                        model.Add(users);

                    nextUri = collectAll == false ? null : reportResponse?.OdataNextLink;
                }
                catch (ApiException ex)
                {
                    switch (ex.StatusCode)
                    {
                        case 404:
                            throw new HttpRequestException($"Resource not found");
                        case 401:
                            throw new UnauthorizedAccessException($"Client is not authorized for this request");
                        case 403:
                            throw new UnauthorizedAccessException($"Client is not allowed this resource");
                        default:
                            throw new Exception($"Service returnd status {ex.StatusCode}");
                    }
                }

            } while (string.IsNullOrEmpty(nextUri) == false);

            return model;
        }

        public async Task<IEnumerable<Device>> GetDevices(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null)
        {
            if (string.IsNullOrEmpty(accesstoken))
                throw new ArgumentNullException();

            var model = new List<Device>();

            string nextUri = $"{BaseUrl}/devices{query}";

            if (query?.Contains("top=") == false && collectAll == true)
            {
                if (query == "")
                    nextUri = $"{nextUri}?$top=999";
                else
                    nextUri = $"{nextUri} &$top=999";
            }

            do
            {
                try
                {

                    var devicesReponse = await GetPage<OdataDevice>($"{nextUri}", accesstoken, cancellationToken);

                    foreach (var device in devicesReponse.Devices)
                        model.Add(device);

                    nextUri = collectAll == false ? null : devicesReponse?.PagingUrl;
                }
                catch (ApiException ex)
                {
                    switch (ex.StatusCode)
                    {
                        case 404:
                            throw new HttpRequestException($"Resource not found");
                        case 401:
                            throw new UnauthorizedAccessException($"Client is not authorized for this request");
                        case 403:
                            throw new UnauthorizedAccessException($"Client is not allowed this resource");
                        default:
                            throw new Exception($"Service returnd status {ex.StatusCode}");
                    }
                }

            } while (string.IsNullOrEmpty(nextUri) == false);


            return model;
        }

        public async Task<IEnumerable<ManagedDevice>> GetManagedDevices(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null)
        {
            if (string.IsNullOrEmpty(accesstoken))
                throw new ArgumentNullException();

            var model = new List<ManagedDevice>();

            string nextUri = $"{BaseUrl}/deviceManagement/managedDevices{query}";

            if (query?.Contains("top=") == false && collectAll == true)
            {
                if (query == "")
                    nextUri = $"{nextUri}?$top=999";
                else
                    nextUri = $"{nextUri} &$top=999";
            }

            do
            {
                try
                {

                    var managedDevicesResponse = await GetPage<OdataManagedDevice>($"{nextUri}", accesstoken, cancellationToken);

                    foreach (var devices in managedDevicesResponse.ManagedDevices)
                        model.Add(devices);

                    nextUri = collectAll == false ? null : managedDevicesResponse?.PagingUrl;
                }
                catch (ApiException ex)
                {
                    switch (ex.StatusCode)
                    {
                        case 404:
                            throw new HttpRequestException($"Resource not found");
                        case 401:
                            throw new UnauthorizedAccessException($"Client is not authorized for this request");
                        case 403:
                            throw new UnauthorizedAccessException($"Client is not allowed this resource");
                        default:
                            throw new Exception($"Service returnd status {ex.StatusCode}");
                    }
                }

            } while (string.IsNullOrEmpty(nextUri) == false);

            return model;
        }

        public async Task<IEnumerable<ManagedDevice>> GetManagedDevicesConfigured(string accesstoken, CancellationToken cancellationToken, string[] selectProperties = null, string[] expandProperties = null, bool sampleCall = false)
        {
            var thisQuery = "";

            if (selectProperties != null && expandProperties != null)
                thisQuery += "?";

            bool queryAdded = false;
            bool collectAll = true;

            if (selectProperties != null)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$select=";
                else
                    thisQuery = $"{thisQuery} &$select=";

                for (int i = 0; i < selectProperties.Length; i++)
                {
                    if (i == 0)
                        thisQuery = $"{thisQuery}{selectProperties[i]}";
                    else
                        thisQuery = $"{thisQuery},{selectProperties[i]}";
                }
            }

            if (expandProperties != null)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$expand=";
                else
                    thisQuery = $"{thisQuery} &$expand=";

                for (int i = 0; i < expandProperties.Length; i++)
                {
                    if (i == 0)
                        thisQuery = $"{thisQuery}{expandProperties[i]}";
                    else
                        thisQuery = $"{thisQuery},{expandProperties[i]}";
                }
            }

            if (sampleCall)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$top=5";
                else
                    thisQuery = $"{thisQuery} &$top=5";

                collectAll = false;
            }

            var result = await GetManagedDevices(accesstoken, cancellationToken, query: thisQuery, collectAll: collectAll);

            if (result == null)
                return null;

            var returnModel = new List<ManagedDevice>();
            returnModel = result.ToList();

            return returnModel;
        }

        public async Task<IEnumerable<User>> GetUsers(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null)
        {
            if (string.IsNullOrEmpty(accesstoken))
                throw new ArgumentNullException();

            var model = new List<User>();

            string nextUri = $"{BaseUrl}/users{query}";

            if (query?.Contains("top=") == false && collectAll == true)
            {
                if (query == "")
                    nextUri = $"{nextUri}?$top=999";
                else
                    nextUri = $"{nextUri} &$top=999";
            }

            do
            {
                try
                {

                    var usersResponse = await GetPage<OdataUser>($"{nextUri}", accesstoken, cancellationToken);

                    foreach (var users in usersResponse?.Users)
                        model.Add(users);

                    nextUri = collectAll == false ? null : usersResponse?.PagingUrl;
                }
                catch (ApiException ex)
                {
                    switch (ex.StatusCode)
                    {
                        case 404:
                            throw new HttpRequestException($"Resource not found");
                        case 401:
                            throw new UnauthorizedAccessException($"Client is not authorized for this request");
                        case 403:
                            throw new UnauthorizedAccessException($"Client is not allowed this resource");
                        default:
                            throw new Exception($"Service returnd status {ex.StatusCode}");
                    }
                }

            } while (string.IsNullOrEmpty(nextUri) == false);

            return model;
        }

        public async Task<IEnumerable<User>> GetActiveUsers(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null)
        {
            var thisQuery = "$filter=AccountEnabled eq true";

            if (string.IsNullOrEmpty(query))
                thisQuery = $"?{thisQuery}";
            else
                thisQuery = $"&{thisQuery}";

            return await GetUsers(accesstoken, cancellationToken, collectAll, thisQuery);
        }

        public async Task<IEnumerable<User>> GetUsersConfigured(string accesstoken, CancellationToken cancellationToken,
            AccountEnabled accountEnabled = AccountEnabled.All,
            ShowGuests showGuests = ShowGuests.All,
            string[] selectProperties = null,
            string[] expandProperties = null,
            bool sampleCall = false)
        {
            var thisQuery = "";

            bool queryAdded = false;

            bool collectAll = true;

            switch (accountEnabled)
            {
                case (AccountEnabled.EnabledOnly):
                    thisQuery = $"{thisQuery}$filter=AccountEnabled eq true";
                    queryAdded = true;
                    break;
                case (AccountEnabled.DisabledOnly):
                    thisQuery = $"{thisQuery}$filter=AccountEnabled eq false";
                    queryAdded = true;
                    break;
                default:
                    break;
            }

            if (selectProperties != null)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$select=";
                else
                    thisQuery = $"{thisQuery} &$select=";

                for (int i = 0; i < selectProperties.Length; i++)
                {
                    if (i == 0)
                        thisQuery = $"{thisQuery}{selectProperties[i]}";
                    else
                        thisQuery = $"{thisQuery},{selectProperties[i]}";
                }
            }

            if (expandProperties != null)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$expand=";
                else
                    thisQuery = $"{thisQuery} &$expand=";

                for (int i = 0; i < expandProperties.Length; i++)
                {
                    if (i == 0)
                        thisQuery = $"{thisQuery}{expandProperties[i]}";
                    else
                        thisQuery = $"{thisQuery},{expandProperties[i]}";
                }
            }

            if (sampleCall)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$top=5";
                else
                    thisQuery = $"{thisQuery} &$top=5";

                collectAll = false;
            }

            var result = await GetUsers(accesstoken, cancellationToken, query: thisQuery, collectAll: collectAll);

            if (result == null)
                return null;

            var returnModel = new List<User>();
            returnModel = result.ToList();

            switch (showGuests)
            {
                case (ShowGuests.GuestsOnly):
                    returnModel = result.Where(o => o.UserPrincipalName.Contains("#EXT#"))?.ToList();
                    break;
                case (ShowGuests.NoGuests):
                    returnModel = result.Where(o => o.UserPrincipalName.Contains("#EXT#") == false)?.ToList();
                    break;
                default:
                    break;
            }

            return returnModel;
        }

        public async Task<IEnumerable<Device>> GetDevicesConfigured(string accesstoken, CancellationToken cancellationToken,
            string[] selectProperties = null,
            string[] expandProperties = null,
            bool sampleCall = false)
        {
            var thisQuery = "";
            bool queryAdded = false;
            bool collectAll = true;

            if (selectProperties != null)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$select=";
                else
                    thisQuery = $"{thisQuery} &$select=";

                for (int i = 0; i < selectProperties.Length; i++)
                {
                    if (i == 0)
                        thisQuery = $"{thisQuery}{selectProperties[i]}";
                    else
                        thisQuery = $"{thisQuery},{selectProperties[i]}";
                }
            }

            if (expandProperties != null)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$expand=";
                else
                    thisQuery = $"{thisQuery} &$expand=";

                for (int i = 0; i < expandProperties.Length; i++)
                {
                    if (i == 0)
                        thisQuery = $"{thisQuery}{expandProperties[i]}";
                    else
                        thisQuery = $"{thisQuery},{expandProperties[i]}";
                }
            }

            if (sampleCall)
            {
                if (!queryAdded)
                    thisQuery = $"{thisQuery}?$top=5";
                else
                    thisQuery = $"{thisQuery} &$top=5";

                collectAll = false;
            }

            var result = await GetDevices(accesstoken, cancellationToken, query: thisQuery, collectAll: collectAll);

            if (result == null)
                return null;

            var returnModel = new List<Device>();
            returnModel = result.ToList();


            return returnModel;
        }


        public async Task<GraphCsvReports> GetUsageData(string accessToken, DateTime date, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("No accesstoken supplied");

            //Possible JSON beta endpoint
            //var teamsBeta = await GetTeamsReportBeta<TeamsReportData>(accessToken, DateTime.UtcNow.AddDays(-5), cancellationToken);

            var teamsActivityUserDetail = await GetReport<Models.Reports.CSV.TeamsUserActivityUserDetail>(accessToken, date, cancellationToken);
            var teamsDeviceUsageUserDetail = await GetReport<Models.Reports.CSV.TeamsDeviceUsageUserDetail>(accessToken, date, cancellationToken);
            var oneDriveActivityUserDetail = await GetReport<Models.Reports.CSV.OneDriveActivityUserDetail>(accessToken, date, cancellationToken);
            var emailActivityUserDetail = await GetReport<Models.Reports.CSV.EmailActivityUserDetail>(accessToken, date, cancellationToken);
            var yeammerActivityUserDetail = await GetReport<Models.Reports.CSV.YammerActivityUserDetail>(accessToken, date, cancellationToken);
            var officeActivationUserDetail = await GetReport<Models.Reports.CSV.Office365ActivationsUserDetail>(accessToken, new DateTime(), cancellationToken);

            GraphCsvReports model = new GraphCsvReports();

            model.TeamsDeviceUsageUserDetail = teamsDeviceUsageUserDetail;
            model.TeamsUserActivityUserDetail = teamsActivityUserDetail;
            model.OneDriveActivityUserDetail = oneDriveActivityUserDetail;
            model.EmailActivityUserDetail = emailActivityUserDetail;
            model.YammerActivityUserDetail = yeammerActivityUserDetail;
            model.Office365ActivationsUserDetail = officeActivationUserDetail;

            return model;
        }
    }
}
