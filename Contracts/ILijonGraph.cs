using LijonGraph.Models.Reports;
using LijonGraph.Models.Reports.CSV;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LijonGraph.ServiceEnums.ServiceEnums;

namespace LijonGraph.Contracts
{
    public interface ILijonGraph
    {
        Task<IEnumerable<Microsoft.Graph.MeetingAttendanceReport>> GetAttendanceReports(string azureToken, string roomId, CancellationToken cancellationToken);
        Task<OnlineMeeting> GetOnlineMeeting(string accesstoken, string meetingOrganizerId, string joinWebUrl, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<IEnumerable<AttendanceRecord>> GetAttendanceRecords(string accesstoken, string meetingOrganizerId, string onlineMeetingId, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<IEnumerable<Event>> GetEventsForPrincipal(string accesstoken, string principalId, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<IEnumerable<Room>> GetRooms(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<string> CollectAccessToken(string clientId, string clientSecret, string authority, string tenant, string[] scopes = null);
        Task<IEnumerable<User>> GetUsers(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<IEnumerable<Device>> GetDevices(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<IEnumerable<ManagedDevice>> GetManagedDevices(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<IEnumerable<ManagedDevice>> GetManagedDevicesConfigured(string accesstoken, CancellationToken cancellationToken,
                string[] selectProperties = null,
                string[] expandProperties = null,
                bool sampleCall = false);
        Task<IEnumerable<Device>> GetDevicesConfigured(string accesstoken, CancellationToken cancellationToken,
            string[] selectProperties = null,
            string[] expandProperties = null,
            bool sampleCall = false);
        Task<IEnumerable<User>> GetActiveUsers(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<IEnumerable<User>> GetUsersConfigured(string accesstoken, CancellationToken cancellationToken,
            AccountEnabled accountEnabled = AccountEnabled.All,
            ShowGuests showGuests = ShowGuests.All,
            string[] selectProperties = null,
            string[] expandProperties = null,
            bool sampleCall = false);
        Task<IEnumerable<SubscribedSku>> GetSubscribedSkus(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null);
        Task<GraphCsvReports> GetUsageData(string accessToken, DateTime date, CancellationToken cancellationToken);
        Task<IEnumerable<MobileApp>> GetMobileApps(string accesstoken, CancellationToken cancellationToken, bool collectAll = true, string query = null);

    }
}
