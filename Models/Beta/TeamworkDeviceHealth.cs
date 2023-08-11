using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Beta
{
    public class AdminAgentSoftwareUpdateStatus
    {
        public string? softwareFreshness { get; set; }
        public string? currentVersion { get; set; }
        public object? availableVersion { get; set; }
    }

    public class CommunicationSpeakerHealth
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class ComputeHealth
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class Connection
    {
        public string? connectionStatus { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }

    public class ContentCameraHealth
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class DisplayHealthCollection
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class ExchangeConnection
    {
        public string? connectionStatus { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }

    public class HardwareHealth
    {
        public ComputeHealth computeHealth { get; set; }
        public HdmiIngestHealth hdmiIngestHealth { get; set; }
    }

    public class HdmiIngestHealth
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class LoginStatus
    {
        public ExchangeConnection exchangeConnection { get; set; }
        public TeamsConnection teamsConnection { get; set; }
        public SkypeConnection skypeConnection { get; set; }
    }

    public class MicrophoneHealth
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class OperatingSystemSoftwareUpdateStatus
    {
        public string? softwareFreshness { get; set; }
        public string? currentVersion { get; set; }
        public object? availableVersion { get; set; }
    }

    public class PeripheralsHealth
    {
        public RoomCameraHealth roomCameraHealth { get; set; }
        public ContentCameraHealth contentCameraHealth { get; set; }
        public SpeakerHealth speakerHealth { get; set; }
        public CommunicationSpeakerHealth communicationSpeakerHealth { get; set; }
        public List<DisplayHealthCollection> displayHealthCollection { get; set; }
        public MicrophoneHealth microphoneHealth { get; set; }
    }

    public class RoomCameraHealth
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class TeamworkDeviceHealth
    {
        [JsonProperty("@odata.context")]
        public string? odatacontext { get; set; }
        public string? id { get; set; }
        public DateTime? createdDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
        public object? createdBy { get; set; }
        public object? lastModifiedBy { get; set; }
        public Connection connection { get; set; }
        public LoginStatus loginStatus { get; set; }
        public PeripheralsHealth peripheralsHealth { get; set; }
        public SoftwareUpdateHealth softwareUpdateHealth { get; set; }
        public HardwareHealth hardwareHealth { get; set; }
    }

    public class SkypeConnection
    {
        public string? connectionStatus { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }

    public class SoftwareUpdateHealth
    {
        public object? companyPortalSoftwareUpdateStatus { get; set; }
        public object? firmwareSoftwareUpdateStatus { get; set; }
        public object? partnerAgentSoftwareUpdateStatus { get; set; }
        public AdminAgentSoftwareUpdateStatus adminAgentSoftwareUpdateStatus { get; set; }
        public TeamsClientSoftwareUpdateStatus teamsClientSoftwareUpdateStatus { get; set; }
        public OperatingSystemSoftwareUpdateStatus operatingSystemSoftwareUpdateStatus { get; set; }
    }

    public class SpeakerHealth
    {
        public bool? isOptional { get; set; }
        public Connection connection { get; set; }
    }

    public class TeamsClientSoftwareUpdateStatus
    {
        public string? softwareFreshness { get; set; }
        public string? currentVersion { get; set; }
        public object? availableVersion { get; set; }
    }

    public class TeamsConnection
    {
        public string? connectionStatus { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }
}
