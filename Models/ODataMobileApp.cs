using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models
{
    public class ODataMobileApp
    {
        [JsonProperty(@"@odata.nextLink")]
        public string PagingUrl { get; set; }

        [JsonProperty("value")]
        public List<Microsoft.Graph.MobileApp> MobileApps { get; set; }
    }
}
