using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    [DelimitedRecord(",")]

    public class SkypeForBusinessActivityUserDetail : IGraphReport
    {
        public string GetServiceEndpoint() { return "reports/getSkypeForBusinessActivityUserDetail"; }

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
        public string Total_PeerToPeerSessionCount { get; set; }
        [FieldOrder(7)]
        public string Total_OrganizedConferenceCount { get; set; }
        [FieldOrder(8)]
        public string Total_ParticipatedConferenceCount { get; set; }
        [FieldOrder(9)]
        public string PeerToPeer_LastActivityDate { get; set; }
        [FieldOrder(10)]
        public string OrganizedConference_LastActivityDate { get; set; }
        [FieldOrder(11)]
        public string ParticipatedConference_LastActivityDate { get; set; }
        [FieldOrder(12)]
        public string PeerToPeer_IMCount { get; set; }
        [FieldOrder(13)]
        public string PeerToPeer_AudioCount { get; set; }
        [FieldOrder(14)]
        public string PeerToPeer_AudioMinutes { get; set; }
        [FieldOrder(15)]
        public string PeerToPeer_VideoCount { get; set; }
        [FieldOrder(16)]
        public string PeerToPeer_VideoMinutes { get; set; }
        [FieldOrder(17)]
        public string PeerToPeer_AppSharingCount { get; set; }
        [FieldOrder(18)]
        public string PeerToPeer_FileTransferCount { get; set; }
        [FieldOrder(19)]
        public string OrganizedConference_IMCount { get; set; }
        [FieldOrder(20)]
        public string OrganizedConference_AudioVideoCount { get; set; }
        [FieldOrder(21)]
        public string OrganizedConference_AudioVideoMinutes { get; set; }
        [FieldOrder(22)]
        public string OrganizedConference_AppSharingCount { get; set; }
        [FieldOrder(23)]
        public string OrganizedConference_WebCount { get; set; }
        [FieldOrder(24)]
        public string OrganizedConference_DialInOut3rdPartyCount { get; set; }
        [FieldOrder(25)]
        public string OrganizedConference_DialInOutMicrosoftCount { get; set; }
        [FieldOrder(26)]
        public string OrganizedConference_DialInMicrosoftMinutes { get; set; }
        [FieldOrder(27)]
        public string OrganizedConference_DialOutMicrosoftMinutes { get; set; }
        [FieldOrder(28)]
        public string ParticipatedConference_IMCount { get; set; }
        [FieldOrder(29)]
        public string ParticipatedConference_AudioVideoCount { get; set; }
        [FieldOrder(30)]
        public string ParticipatedConference_AudioVideoMinutes { get; set; }
        [FieldOrder(31)]
        public string ParticipatedConference_AppSharingCount { get; set; }
        [FieldOrder(32)]
        public string ParticipatedConference_WebCount { get; set; }
        [FieldOrder(33)]
        public string ParticipatedConference_DialInOut3rdPartyCount { get; set; }
        [FieldOrder(34)]
        public string AssignedProducts { get; set; }
        [FieldOrder(35)]
        public string Repor_Period { get; set; }
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
