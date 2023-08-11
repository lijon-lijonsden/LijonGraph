using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models
{
    public class OdataEvents
    {
        [JsonProperty(@"@odata.nextLink")]
        public string PagingUrl { get; set; }

        [JsonProperty("value")]
        public IEnumerable<Microsoft.Graph.Event> Events { get; set; }
    }
}
