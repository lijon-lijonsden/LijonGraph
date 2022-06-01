using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]
    public class OneDriveActivityUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getOneDriveActivityUserDetail"; }

        [FieldOrder(1)]
        public string ReportRefreshDate { get; set; }
        [FieldOrder(2)]
        public string UserPrincipalName { get; set; }
        [FieldOrder(3)]
        public string IsDeleted { get; set; }
        [FieldOrder(4)]
        public string DeletedDate { get; set; }
        [FieldOrder(5)]
        public string LastActivityDate { get; set; }
        [FieldOrder(6)]
        public string ViewedOrEditedFileCount { get; set; }
        [FieldOrder(7)]
        public string SyncedFileCount { get; set; }
        [FieldOrder(8)]
        public string SharedInternallyFileCount { get; set; }
        [FieldOrder(9)]
        public string SharedExternallyFileCount { get; set; }
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
