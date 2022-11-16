using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Beta
{
    public class BetaDeviceUrl
    {
        public static string Uri { get; } = @"https://graph.microsoft.com/beta/devices?$expand=registeredOwners($select=userPrincipalName)&$select=deviceId,managementType";
    }

    public class RegisteredOwner
    {
        [JsonProperty("@odata.type")]
        public string odatatype { get; set; }
        public string userPrincipalName { get; set; }
        public string id { get; set; }
    }

    public class BetaDevicesRoot
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string odatanextLink { get; set; }
        [JsonProperty("value")]
        public List<Device> device { get; set; }
    }

    public class Device
    {
        public string deviceId { get; set; }
        public string managementType { get; set; }
        public string id { get; set; }
        public List<RegisteredOwner> registeredOwners { get; set; }
    }

}
