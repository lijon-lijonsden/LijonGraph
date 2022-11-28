using Azure.Identity;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Contracts
{
    public interface IWorkSpaceanalytics
    {
        Task<ClientSecretCredential> GetAccessToken(string tenantId, string clientId, string clientSecret);
        Task<Azure.Response<IReadOnlyList<T>>> GetModelFromAnalytics<T>(ClientSecretCredential credential, string workspaceId, string query, QueryTimeRange? timeRange = null);
    }
}
