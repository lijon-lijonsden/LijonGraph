using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Beta
{
    public class CurrentUser
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string userIdentityType { get; set; }
    }

    public class HardwareDetail
    {
        public string serialNumber { get; set; }
        public string uniqueId { get; set; }
        public List<string> macAddresses { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
    }

    public class LastModifiedBy
    {
        public object application { get; set; }
        public object device { get; set; }
        public User user { get; set; }
    }

    public class TeamworkDeviceRoot
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }

        [JsonProperty("@odata.count")]
        public int odatacount { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string PagingUrl { get; set; }
        [JsonProperty("value")]
        public List<TeamworkDevice> TeamworkDevices { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string userIdentityType { get; set; }
    }

    public class TeamworkDevice
    {
        public string id { get; set; }
        public string deviceType { get; set; }
        public object notes { get; set; }
        public string companyAssetTag { get; set; }
        public string healthStatus { get; set; }
        public string activityState { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public object createdBy { get; set; }
        public LastModifiedBy lastModifiedBy { get; set; }
        public HardwareDetail hardwareDetail { get; set; }
        public CurrentUser currentUser { get; set; }
    }
}
