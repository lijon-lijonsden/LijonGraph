using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Beta
{
    public class OdataManagedDevice
    {
        [JsonProperty(@"@odata.nextLink")]
        public string PagingUrl { get; set; }

        [JsonProperty("value")]
        public List<ManagedDeviceBeta> ManagedDevices { get; set; }
    }
}
