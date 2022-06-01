using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]

    public class SkypeForBusinessDeviceUsageUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getSkypeForBusinessDeviceUsageUserDetail"; }

        [FieldOrder(1)]
        public string ReportRefreshDate { get; set; }
        [FieldOrder(2)]
        public string UserPrincipalName { get; set; }
        [FieldOrder(3)]
        public string LastActivityDate { get; set; }
        [FieldOrder(4)]
        public string UsedWindows { get; set; }
        [FieldOrder(5)]
        public string UsedWindowsPhone { get; set; }
        [FieldOrder(6)]
        public string UsedAndroidPhone { get; set; }
        [FieldOrder(7)]
        public string UsedIPhone { get; set; }
        [FieldOrder(8)]
        public string UsedIPad { get; set; }
        [FieldOrder(9)]
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
