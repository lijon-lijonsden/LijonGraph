using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models
{
    public class UsageData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateStamp { get; set; }
        public int? TeamsTeamChatMessageCount { get; set; }
        public int? TeamsPrivateChatMessageCount { get; set; }
        public int? TeamsCallCount { get; set; }
        public int? TeamsMeetingCount { get; set; }
        public bool? TeamsHasOtherAction { get; set; }
        public bool? TeamsUsedWeb { get; set; }
        public bool? TeamsUsedWindowsPhone { get; set; }
        public bool? TeamsUsedIos { get; set; }
        public bool? TeamsUsedMac { get; set; }
        public bool? TeamsUsedAndroidPhone { get; set; }
        public bool? TeamsUsedWindows { get; set; }
        public int? OutlookSendCount { get; set; }
        public int? OutlookReceiveCount { get; set; }
        public int? OutlookReadCount { get; set; }
        public string OfficeActivationProductType { get; set; }
        public int? OfficeActivationWindows { get; set; }
        public int? OfficeActivationMac { get; set; }
        public int? OfficeActivationWindows10Mobile { get; set; }
        public int? OfficeActivationIos { get; set; }
        public int? OfficeActivationAndroid { get; set; }
        public int? OneDriveViewedOrEditedFileCount { get; set; }
        public int? OneDriveSharedInternallyFileCount { get; set; }
        public int? OneDriveSharedExternallyFileCount { get; set; }
        public int? SharePointViewedOrEditedFileCount { get; set; }
        public int? SharePointSharedInternallyFileCount { get; set; }
        public int? SharePointSharedExternallyFileCount { get; set; }
        public int? SharePointVisitedPageCount { get; set; }
        public int? SkypeTotalPeerToPeerSessionCount { get; set; }
        public int? SkypeTotalOrganizedConferenceCount { get; set; }
        public int? SkypeTotalParticipatedConferenceCount { get; set; }
        public string SkypePeerToPeerLastActivityDate { get; set; }
        public int? SkypePeerToPeerImcount { get; set; }
        public int? SkypePeerToPeerAudioCount { get; set; }
        public int? SkypePeerToPeerAudioMinutes { get; set; }
        public int? SkypePeerToPeerVideoCount { get; set; }
        public int? SkypePeerToPeerVideoMinutes { get; set; }
        public int? SkypePeerToPeerAppSharingCount { get; set; }
        public int? SkypePeerToPeerFileTransferCount { get; set; }
        public int? SkypeOrganizedConferenceImcount { get; set; }
        public int? SkypeOrganizedConferenceAudioVideoCount { get; set; }
        public int? SkypeOrganizedConferenceAudioVideoMinutes { get; set; }
        public int? SkypeOrganizedConferenceAppSharingCount { get; set; }
        public int? SkypeOrganizedConferenceWebCount { get; set; }
        public int? SkypeParicipatedConferenceImcount { get; set; }
        public int? SkypeParticipatedConferenceAudioVideoCount { get; set; }
        public int? SkypeParticipatedConferenceAudioVideoMinutes { get; set; }
        public int? SkypeParticipatedConferenceAppSharingCount { get; set; }
        public bool? SkypeUsedWindows { get; set; }
        public bool? SkypeUsedWindowsPhone { get; set; }
        public bool? SkypeUsedAndroidPhone { get; set; }
        public bool? SkypeUsedIphone { get; set; }
        public bool? SkypeUsedIpad { get; set; }
        public int? YammerPostedCount { get; set; }
        public int? YammerReadCount { get; set; }
        public int? YammerLikedCount { get; set; }
    }
}
