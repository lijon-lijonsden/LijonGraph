using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models
{
    internal class ODataRooms
    {
        [JsonProperty(@"@odata.nextLink")]
        public string PagingUrl { get; set; }

        [JsonProperty("value")]
        public IEnumerable<Microsoft.Graph.Room> Rooms { get; set; }
    }
}
