using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models
{
    public class OdataAttendanceReports
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }
        [JsonProperty("value")]
        public List<Value> Reports { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public int totalParticipantCount { get; set; }
        public DateTime meetingStartDateTime { get; set; }
        public DateTime meetingEndDateTime { get; set; }
        public List<object> attendanceRecords { get; set; }
    }

}
