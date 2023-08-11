using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models
{
    public class ODataAttendanceRecord
    {
        [JsonProperty(@"@odata.nextLink")]
        public string PagingUrl { get; set; }

        [JsonProperty("value")]
        public List<Microsoft.Graph.AttendanceRecord> Records { get; set; }
    }
}
