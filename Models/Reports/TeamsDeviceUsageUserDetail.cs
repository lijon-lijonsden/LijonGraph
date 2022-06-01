using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]

    public class TeamsDeviceUsageUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getTeamsDeviceUsageUserDetail"; }

        [FieldOrder(1)]
        public string ReportRefreshDate { get; set; }
        [FieldOrder(2)]
        public string UserId { get; set; }
        [FieldOrder(3)]
        public string UserPrincipalName { get; set; }
        [FieldOrder(4)]
        public string LastActivityDate { get; set; }
        [FieldOrder(5)]
        public string IsDeleted { get; set; }
        [FieldOrder(6)]
        public string DeletedDate { get; set; }
        [FieldOrder(7)]
        public string UsedWeb { get; set; }
        [FieldOrder(8)]
        public string UsedWindowsPhone { get; set; }
        [FieldOrder(9)]
        public string UsedIOS { get; set; }
        [FieldOrder(10)]
        public string UsedMac { get; set; }
        [FieldOrder(11)]
        public string UsedAndroidPhone { get; set; }
        [FieldOrder(12)]
        public string UsedWindows { get; set; }
        [FieldOrder(13)]
        public string ReportPeriod { get; set; }
        [FieldOrder(100)]
        [FieldOptional()]
        public string placeholder1 { get; set; }
        [FieldOrder(110)]
        [FieldOptional()]
        public string placeholder2 { get; set; }
        [FieldOrder(120)]
        [FieldOptional()]
        public string placeholder3 { get; set; }
        [FieldOrder(130)]
        [FieldOptional()]
        public string placeholder4 { get; set; }
    }
}
