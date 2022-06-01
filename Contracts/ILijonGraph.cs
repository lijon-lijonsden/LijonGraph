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
    }
}
