using Azure;
using Azure.Identity;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Services
{
    public class WorkspaceAnalytics : LijonGraph.Contracts.IWorkSpaceanalytics
    {
		public async Task<ClientSecretCredential> GetAccessToken(string tenantId, string clientId, string clientSecret)
        {
            var credential = new ClientSecretCredential(tenantId, 
                clientId: clientId, 
                clientSecret: clientSecret);

            return credential;
        }

        public async Task<Azure.Response<IReadOnlyList<T>>> GetModelFromAnalytics<T>(ClientSecretCredential credential, string workspaceId, string query, QueryTimeRange? timeRange = null)
        {
            var client = new LogsQueryClient(credential);

            if (timeRange == null)
                timeRange = new QueryTimeRange(TimeSpan.FromDays(10));

            if (query == null)
                throw new ArgumentNullException("query needed");

            if (workspaceId == null)
                throw new ArgumentNullException("workspaceId needed");

            var response = await client.QueryWorkspaceAsync<T>(
                workspaceId,
                query,
                (QueryTimeRange)timeRange);

            return response;
        }
    }
}
