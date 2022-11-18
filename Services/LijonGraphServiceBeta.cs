using LijonGraph.Contracts;
using LijonGraph.Models.Batch;
using LijonGraph.Models.Beta;
using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static LijonGraph.LijonHttpServices;
using Client = LijonGraph.LijonHttpServices;

namespace LijonGraph.Services
{
    public class LijonGraphServiceBeta : ILijonGraphBeta
    {
        private static string BaseUrl = "https://graph.microsoft.com/beta";
        private static string[] Scopes = new string[] { "https://graph.microsoft.com/.default" };

        public LijonGraphServiceBeta(string baseUrl = null, string[] scopes = null)
        {
            if (string.IsNullOrEmpty(baseUrl) == false)
                BaseUrl = baseUrl;

            if (scopes != null)
                Scopes = scopes;
        }

        public async Task<IEnumerable<Models.Beta.ManagedDeviceBeta>> GetManagedDevicesConfigured(string accesstoken, CancellationToken cancellationToken, string[] selectProperties = null, string[] expandProperties = null, bool sampleCall = false)
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

            var returnModel = new List<Models.Beta.ManagedDeviceBeta>();
            returnModel = result.ToList();

            return returnModel;
        }

        public async Task<IEnumerable<Models.Beta.ManagedDeviceBeta>> GetManagedDevices(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null)
        {
            if (string.IsNullOrEmpty(accesstoken))
                throw new ArgumentNullException();

            var model = new List<Models.Beta.ManagedDeviceBeta>();

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

                    var managedDevicesResponse = await GetPage<Models.Beta.OdataManagedDevice>($"{nextUri}", accesstoken, cancellationToken);

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

        public async Task<List<LijonGraph.Models.Beta.Device>> GetDeviceAndOwners(string accessToken, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException();

            var betaDevices = new List<LijonGraph.Models.Beta.Device>();
            string nextUri = $"{Models.Beta.BetaDeviceUrl.Uri}";

            do
            {
                try
                {
                    var deviceResponse = await GetPage<LijonGraph.Models.Beta.BetaDevicesRoot>($"{nextUri}", accessToken, cancellationToken);

                    foreach (var device in deviceResponse.device)
                        betaDevices.Add(device);

                    nextUri = deviceResponse?.odatanextLink;
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

            return betaDevices;

        }

      

        public async Task<T> BatchBeta<T>(string accessToken, CancellationToken canccelationToken, BatchRequest request)
        {
            string uri = $"{BaseUrl}/$batch";

            using (HttpClient client = new HttpClient())
            {
                var serialized = JsonConvert.SerializeObject(request);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.PostAsJsonAsync<BatchRequest>(@$"{uri}", request);

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var deserializedContent = JsonConvert.DeserializeObject<T>(content);

                    return deserializedContent;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine();

                    throw new Exception(content);
                }
            }
        }


        public async Task<RoleScopeTags> GetRoleScopeTags(string accessToken, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException();

            var model = new RoleScopeTags();

            string nextUri = $"{BaseUrl}/deviceManagement/roleScopeTags";

            try
            {
                var tagResponse = await GetPage<RoleScopeTags>($"{nextUri}", accessToken, cancellationToken);
                model = tagResponse;
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

            return model;
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

        public async Task<List<LijonGraph.Models.Beta.ManagedDevicesBetaExpanded>> GetManagedDeviceRoleTag(string accesstoken, CancellationToken cancellationToken, string[] ids)
        {
            if (string.IsNullOrEmpty(accesstoken))
                throw new ArgumentNullException();

            var model = new List<ManagedDevicesBetaExpanded>();

            string id = "";
            string baseUri = $"{BaseUrl}/deviceManagement/managedDevices";
            string query = @"?$select=roleScopeTagIds,id,userprincipalname,operatingSystem,deviceName,managedDeviceName,azureADDeviceId";

            try
            {
                foreach (var deviceId in ids)
                {
                    var managedDevicesResponse = await GetPage<Models.Beta.ManagedDevicesBetaExpanded>($"{baseUri}/{id}{query}", accesstoken, cancellationToken);
                    model.Add(managedDevicesResponse);
                }
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

            return model;
        }
    }
}
