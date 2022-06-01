using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]
    public class OneDriveActivityCount : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getOneDriveActivityUserCounts"; }

        [FieldOrder(1)]
        public string RefreshDate;
        [FieldOrder(2)]
        public string ViewedOrEdited;
        [FieldOrder(3)]
        public string Synced { get; set; }
        [FieldOrder(4)]
        public string SharedInternally;
        [FieldOrder(5)]
        public string SharedExternally { get; set; }
        [FieldOrder(6)]
        public string ReportDate { get; set; }
        [FieldOrder(7)]
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
