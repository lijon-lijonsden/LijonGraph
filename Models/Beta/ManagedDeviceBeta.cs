﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Beta
{
    public class ManagedDeviceBeta
    {
        public string odatacontext { get; set; }
        public List<string> roleScopeTagIds { get; set; }
        public string id { get; set; }
        public string deviceHealthAttestationState { get; set; }
        public string totalStorageSpaceInBytes { get; set; }
        public string freeStorageSpaceInBytes { get; set; }
        public string udid { get; set; }
        public string iccid { get; set; }
        public string ethernetMacAddress { get; set; }
        public string physicalMemoryInBytes { get; set; }
        public string processorArchitecture { get; set; }
        public string userPrincipalName { get; set; }
        public string operatingSystem { get; set; }
        public string deviceName { get; set; }
        public string managedDeviceName { get; set; }
        public string azureADDeviceId { get; set; }
        public string userId { get; set; }
        public string? deviceType { get; set; }
        public string? complianceState { get; set; }
        public string? jailBroken { get; set; }
        public string? managementAgent { get; set; }
        public string? osVersion { get; set; }
        public bool? azureADRegistered { get; set; }
        public string? deviceEnrollmentType { get; set; }
        public string? lostModeState { get; set; }
        public string? emailAddress { get; set; }
        public string? azureActiveDirectoryDeviceId { get; set; }
        public string? deviceRegistrationState { get; set; }
        public string? deviceCategoryDisplayName { get; set; }
        public bool? isSuperVised { get; set; }
        public bool? isEncrypted { get; set; }
        public string? model { get; set; }
        public string? manufacturer { get; set; }
        public string? imei { get; set; }
        public DateTime? complianceGracePeriodExpirationDateTime { get; set; }
        public string? serialNumber { get; set; }
        public string? phoneNumber { get; set; }
        public string? androidSecurityPatchLevel { get; set; }
        public string? userDisplayName { get; set; }
        public string? wifiMacAddress { get; set; }
        public string? subscriberCarrier { get; set; }
        public string? meid { get; set; }
        public DateTime? managementCertificateExpirationDate { get; set; }
        public string? notes { get; set; }
        public string? joinType { get; set; }
        public string? ownerType { get; set; }
        public string? managedDeviceOwnerType { get; set; }
        public string? managementState { get; set; }
        public DateTime? enrolledDateTime { get; set; }
        public DateTime? lastSyncDateTime { get; set; }
        public bool? isSupervised { get; set; }
        public bool? aadRegistered { get; set; }
        public object? enrollmentProfileName { get; set; }
        public DateTime? retireAfterDateTime { get; set; }
        public DateTime? preferMdmOverGroupPolicyAppliedDateTime { get; set; }
        public bool? autopilotEnrolled { get; set; }
        public int? windowsActiveMalwareCount { get; set; }
        public int? windowsRemediatedMalwareCount { get; set; }
        public bool? bootstrapTokenEscrowed { get; set; }
        public bool? deviceFirmwareConfigurationInterfaceManaged { get; set; }
        public string? skuFamily { get; set; }
        public int? skuNumber { get; set; }
    }
}
