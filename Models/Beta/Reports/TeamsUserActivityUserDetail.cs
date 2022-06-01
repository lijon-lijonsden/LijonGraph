using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Beta.Reports
{
    public class TeamsReportData
    {
        public string ReportRefreshDate { get; set; }
        public string UserPrincipalName { get; set; }
        public string LastActivityDate { get; set; }
        public bool IsDeleted { get; set; }
        public object DeletedDate { get; set; }
        public List<string> AssignedProducts { get; set; }
        public int TeamChatMessageCount { get; set; }
        public int PrivateChatMessageCount { get; set; }
        public int CallCount { get; set; }
        public int MeetingCount { get; set; }
        public int MeetingsOrganizedCount { get; set; }
        public int MeetingsAttendedCount { get; set; }
        public int AdHocMeetingsOrganizedCount { get; set; }
        public int AdHocMeetingsAttendedCount { get; set; }
        public int ScheduledOneTimeMeetingsOrganizedCount { get; set; }
        public int ScheduledOneTimeMeetingsAttendedCount { get; set; }
        public int ScheduledRecurringMeetingsOrganizedCount { get; set; }
        public int ScheduledRecurringMeetingsAttendedCount { get; set; }
        public string AudioDuration { get; set; }
        public string VideoDuration { get; set; }
        public string ScreenShareDuration { get; set; }
        public bool HasOtherAction { get; set; }
        public bool IsLicensed { get; set; }
        public string ReportPeriod { get; set; }
    }

    public class TeamsUserActivityUserDetail
    {
        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }

        [JsonProperty("value")]
        public List<TeamsReportData> ReportData { get; set; }
    }
}
