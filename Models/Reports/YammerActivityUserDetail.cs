using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]

    public class YammerActivityUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getYammerActivityUserDetail"; }

        [FieldOrder(1)]
        public string Report_Refresh_Date { get; set; }
        [FieldOrder(2)]
        public string UserPrincipalName { get; set; }
        [FieldOrder(3)]
        public string DisplayName { get; set; }
        [FieldOrder(4)]
        public string UserState { get; set; }
        [FieldOrder(5)]
        public string StateChangeDate { get; set; }
        [FieldOrder(6)]
        public string LastActivityDate { get; set; }
        [FieldOrder(7)]
        public string PostedCount { get; set; }
        [FieldOrder(8)]
        public string ReadCount { get; set; }
        [FieldOrder(9)]
        public string LikedCount { get; set; }
        [FieldOrder(10)]
        public string AssignedProducts { get; set; }
        [FieldOrder(11)]
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
