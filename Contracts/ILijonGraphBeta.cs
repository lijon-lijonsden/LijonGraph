using LijonGraph.Models.Batch;
using LijonGraph.Models.Beta;
using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LijonGraph.ServiceEnums.ServiceEnums;
using SubscribedSku = Microsoft.Graph.SubscribedSku;
using User = Microsoft.Graph.User;

namespace LijonGraph.Contracts
{
    public interface ILijonGraphBeta
    {
        Task<RoleScopeTags> GetRoleScopeTags(string accessToken, CancellationToken cancellationToken);
        Task<List<LijonGraph.Models.Beta.Device>> GetDeviceAndOwners(string accessToken, CancellationToken cancellationToken);
        Task<List<LijonGraph.Models.Beta.ManagedDevicesBetaExpanded>> GetManagedDeviceRoleTag(string accesstoken, CancellationToken cancellationToken, string[] ids);
        Task<T> BatchBeta<T>(string accessToken, CancellationToken canccelationToken, BatchRequest request);
        Task<IEnumerable<Models.Beta.ManagedDeviceBeta>> GetManagedDevicesConfigured(string accesstoken, CancellationToken cancellationToken,
        string[] selectProperties = null,
        string[] expandProperties = null,
        bool sampleCall = false);
    }
}
