using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]

    public class TeamsUserActivityUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getTeamsUserActivityUserDetail"; }

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
        public string AssignedProducts { get; set; }
        [FieldOrder(8)]
        public string TeamChatMessageCount { get; set; }
        [FieldOrder(9)]
        public string PrivateChatMessageCount { get; set; }
        [FieldOrder(10)]
        public string CallCount { get; set; }
        [FieldOrder(11)]
        public string MeetingCount { get; set; }

        [FieldOrder(12)]
        public string placeholder14 { get; set; }

        [FieldOrder(13)]
        public string placeholder15 { get; set; }

        [FieldOrder(14)]
        public string placeholder1 { get; set; }
        [FieldOrder(15)]
        public string placeholder2 { get; set; }
        [FieldOrder(16)]
        public string placeholder3 { get; set; }
        [FieldOrder(17)]
        public string placeholder4 { get; set; }
        [FieldOrder(18)]
        public string placeholder5 { get; set; }

        [FieldOrder(19)]
        public string placeholder6 { get; set; }

        [FieldOrder(20)]
        public string placeholder7 { get; set; }

        [FieldOrder(21)]
        public string placeholder8 { get; set; }
        [FieldOrder(22)]
        public string placeholder9 { get; set; }
        [FieldOrder(23)]
        public string placeholder10 { get; set; }
        [FieldOrder(24)]
        public string placeholder11 { get; set; }
        [FieldOrder(25)]
        public string placeholder12 { get; set; }
        [FieldOrder(26)]

        public string HasOtherAction { get; set; }
        [FieldOrder(27)]
        public string placeholder61 { get; set; }

        [FieldOrder(28)]
        public string placeholder62 { get; set; }

        [FieldOrder(29)]
        public string placeholder63 { get; set; }

        [FieldOrder(30)]
        public string placeholder64 { get; set; }

        [FieldOrder(31)]
        public string placeholder65 { get; set; }

        [FieldOrder(32)]
        public string placeholder66 { get; set; }

        [FieldOrder(33)]
        public string ReportPeriod { get; set; }
        [FieldOrder(34)]
        [FieldOptional()]
        public string placeholder67 { get; set; }
        [FieldOrder(35)]
        [FieldOptional()]
        public string placeholder68 { get; set; }
        [FieldOrder(36)]
        [FieldOptional()]
        public string placeholder69 { get; set; }
        [FieldOrder(37)]
        [FieldOptional()]
        public string placeholder70 { get; set; }
    }
}
