using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]
    public class Office365ActivationsUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getOffice365ActivationsUserDetail"; }

        [FieldOrder(1)]
        public string ReportRefreshDate { get; set; }
        [FieldOrder(2)]
        public string UserPrincipalName { get; set; }
        [FieldOrder(3)]
        public string DisplayName { get; set; }
        [FieldOrder(4)]
        public string ProductType { get; set; }
        [FieldOrder(5)]
        public string LastActivatedDate { get; set; }
        [FieldOrder(6)]
        public string Windows { get; set; }
        [FieldOrder(7)]
        public string Mac { get; set; }
        [FieldOrder(8)]
        public string Windows10Mobile { get; set; }
        [FieldOrder(9)]
        public string IOS { get; set; }
        [FieldOrder(10)]
        public string Android { get; set; }
        [FieldOrder(11)]
        public string ActivatedOnSharedComputer { get; set; }
        [FieldOrder(12)]
        [FieldOptional()]
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
