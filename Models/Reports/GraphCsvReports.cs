using System;
using System.Collections.Generic;
using System.Text;

namespace LijonGraph.Models.Reports.CSV
{
    public class GraphCsvReports
    {
        public TeamsUserActivityUserDetail[] TeamsUserActivityUserDetail { get; set; }
        public TeamsDeviceUsageUserDetail[] TeamsDeviceUsageUserDetail { get; set; }
        public YammerActivityUserDetail[] YammerActivityUserDetail { get; set; }
        public SkypeForBusinessActivityUserDetail[] SkypeForBusinessActivityUserDetail { get; set; }
        public SkypeForBusinessDeviceUsageUserDetail[] SkypeForBusinessDeviceUsageUserDetail { get; set; }
        public SharePointActivityUserDetail[] SharePointActivityUserDetail { get; set; }
        public EmailActivityUserDetail[] EmailActivityUserDetail { get; set; }
        public Office365ActivationsUserDetail[] Office365ActivationsUserDetail { get; set; }
        public OneDriveActivityUserDetail[] OneDriveActivityUserDetail { get; set; }
    }

    public class GraphCsvReport
    {
        public TeamsUserActivityUserDetail TeamsUserActivityUserDetail { get; set; }
        public TeamsDeviceUsageUserDetail TeamsDeviceUsageUserDetail { get; set; }
        public YammerActivityUserDetail YammerActivityUserDetail { get; set; }
        public SkypeForBusinessActivityUserDetail SkypeForBusinessActivityUserDetail { get; set; }
        public SkypeForBusinessDeviceUsageUserDetail SkypeForBusinessDeviceUsageUserDetail { get; set; }
        public SharePointActivityUserDetail SharePointActivityUserDetail { get; set; }
        public EmailActivityUserDetail EmailActivityUserDetail { get; set; }
        public Office365ActivationsUserDetail Office365ActivationsUserDetail { get; set; }
        public OneDriveActivityUserDetail OneDriveActivityUserDetail { get; set; }
    }
}
