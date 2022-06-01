using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]
    public class EmailActivityUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getEmailActivityUserDetail"; }

        [FieldOrder(10)]
        public string ReportRefreshDate { get; set; }
        [FieldOrder(20)]
        public string UserPrincipalName { get; set; }
        [FieldOrder(30)]
        public string DisplayName { get; set; }
        [FieldOrder(40)]
        public string IsDeleted { get; set; }
        [FieldOrder(50)]
        public string DeletedDate { get; set; }
        [FieldOrder(60)]
        public string LastActivityDate { get; set; }
        [FieldOrder(70)]
        public string SendCount { get; set; }
        [FieldOrder(80)]
        public string Receive_Count { get; set; }
        [FieldOrder(90)]
        public string ReadCount { get; set; }
        [FieldOrder(100)]
        public string AssignedProducts { get; set; }
        [FieldOrder(110)]
        public string ReportPeriod { get; set; }
        [FieldOrder(120)]
        [FieldOptional()]
        public string placeholder1 { get; set; }
        [FieldOrder(130)]
        [FieldOptional()]
        public string placeholder2 { get; set; }
        [FieldOrder(140)]
        [FieldOptional()]
        public string placeholder3 { get; set; }
        [FieldOrder(150)]
        [FieldOptional()]
        public string placeholder4 { get; set; }
    }
}
