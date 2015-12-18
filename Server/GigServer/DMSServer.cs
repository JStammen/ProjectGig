using OpenSource.UPnP;
using GigServer;
using System;
using System.Threading;

namespace GigServer
{
    public static class Settings
    {
        public static string DeviceName = "DMSServer";
        public static string[] MusicDir = { @"D:\ServerMusic" };
        public static bool Verbose = false;
    }

    public class DMSServerDevice
    {
        public DMSServerDevice server;
        public DMSConnectionManager CM;
        public DMSContentDirectory CD;
        public DMSAVTransport AVT;
        public DMSContentHandler CH;
        public UPnPDevice device;

        public DMSServerDevice()
        {
            device = UPnPDevice.CreateRootDevice(1800, 1.0, "\\");
            device.FriendlyName = Settings.DeviceName +" (" + Environment.MachineName + ")";
            device.Manufacturer = "ProjectGig";
            device.ManufacturerURL = "https://github.com/ProjectGig/";
            device.ModelName = "DMS Music Server";
            device.ModelDescription = "A server to host music files";
            device.ModelNumber = "X1";
            device.DeviceURN = "urn:schemas-upnp-org:device:MediaServer:1";
            device.Major = 1;
            device.Minor = 0;
            device.HasPresentation = false; // No web UI

            CM = new DMSConnectionManager();
            CM.External_GetCurrentConnectionIDs = new DMSConnectionManager.Delegate_GetCurrentConnectionIDs(CM.GetCurrentConnectionIDs);
            CM.External_GetCurrentConnectionInfo = new DMSConnectionManager.Delegate_GetCurrentConnectionInfo(CM.GetCurrentConnectionInfo);
            CM.External_GetProtocolInfo = new DMSConnectionManager.Delegate_GetProtocolInfo(CM.GetProtocolInfo);
            device.AddService(CM);

            CD = new DMSContentDirectory();
            CD.External_Browse = new DMSContentDirectory.Delegate_Browse(CD.Browse);
            CD.External_CreateObject = new DMSContentDirectory.Delegate_CreateObject(CD.CreateObject);
            CD.External_CreateReference = new DMSContentDirectory.Delegate_CreateReference(CD.CreateReference);
            CD.External_DeleteResource = new DMSContentDirectory.Delegate_DeleteResource(CD.DeleteResource);
            CD.External_DestroyObject = new DMSContentDirectory.Delegate_DestroyObject(CD.DestroyObject);
            CD.External_ExportResource = new DMSContentDirectory.Delegate_ExportResource(CD.ExportResource);
            CD.External_GetSearchCapabilities = new DMSContentDirectory.Delegate_GetSearchCapabilities(CD.GetSearchCapabilities);
            CD.External_GetSortCapabilities = new DMSContentDirectory.Delegate_GetSortCapabilities(CD.GetSortCapabilities);
            CD.External_GetSystemUpdateID = new DMSContentDirectory.Delegate_GetSystemUpdateID(CD.GetSystemUpdateID);
            CD.External_GetTransferProgress = new DMSContentDirectory.Delegate_GetTransferProgress(CD.GetTransferProgress);
            CD.External_ImportResource = new DMSContentDirectory.Delegate_ImportResource(CD.ImportResource);
            CD.External_Search = new DMSContentDirectory.Delegate_Search(CD.Search);
            CD.External_StopTransferResource = new DMSContentDirectory.Delegate_StopTransferResource(CD.StopTransferResource);
            CD.External_UpdateObject = new DMSContentDirectory.Delegate_UpdateObject(CD.UpdateObject);
            device.AddService(CD);

            AVT = new DMSAVTransport();
            AVT.External_GetCurrentTransportActions = new DMSAVTransport.Delegate_GetCurrentTransportActions(AVT.GetCurrentTransportActions);
            AVT.External_GetDeviceCapabilities = new DMSAVTransport.Delegate_GetDeviceCapabilities(AVT.GetDeviceCapabilities);
            AVT.External_GetMediaInfo = new DMSAVTransport.Delegate_GetMediaInfo(AVT.GetMediaInfo);
            AVT.External_GetPositionInfo = new DMSAVTransport.Delegate_GetPositionInfo(AVT.GetPositionInfo);
            AVT.External_GetTransportInfo = new DMSAVTransport.Delegate_GetTransportInfo(AVT.GetTransportInfo);
            AVT.External_GetTransportSettings = new DMSAVTransport.Delegate_GetTransportSettings(AVT.GetTransportSettings);
            AVT.External_Next = new DMSAVTransport.Delegate_Next(AVT.Next);
            AVT.External_Pause = new DMSAVTransport.Delegate_Pause(AVT.Pause);
            AVT.External_Play = new DMSAVTransport.Delegate_Play(AVT.Play);
            AVT.External_Previous = new DMSAVTransport.Delegate_Previous(AVT.Previous);
            AVT.External_Record = new DMSAVTransport.Delegate_Record(AVT.Record);
            AVT.External_Seek = new DMSAVTransport.Delegate_Seek(AVT.Seek);
            AVT.External_SetAVTransportURI = new DMSAVTransport.Delegate_SetAVTransportURI(AVT.SetAVTransportURI);
            AVT.External_SetNextAVTransportURI = new DMSAVTransport.Delegate_SetNextAVTransportURI(AVT.SetNextAVTransportURI);
            AVT.External_SetPlayMode = new DMSAVTransport.Delegate_SetPlayMode(AVT.SetPlayMode);
            AVT.External_SetRecordQualityMode = new DMSAVTransport.Delegate_SetRecordQualityMode(AVT.SetRecordQualityMode);
            AVT.External_Stop = new DMSAVTransport.Delegate_Stop(AVT.Stop);
            device.AddService(AVT);

            CH = new DMSContentHandler(CM.GetUPnPService());

            // Setting the initial value of evented variables
            CM.Evented_SourceProtocolInfo = "http-get:*:audio/mp3:*";
            CM.Evented_SinkProtocolInfo = "";
            CM.Evented_CurrentConnectionIDs = "";
            CD.Evented_ContainerUpdateIDs = "";
            CD.Evented_SystemUpdateID = 0;
            CD.Evented_TransferIDs = "";
        }

        public void Start()
        {
            device.StartDevice();
        }

        public void Stop()
        {
            device.StopDevice();
        }

        public string GetFriendlyName()
        {
            return device.FriendlyName;
        }

        public string GetModelName()
        {
            return device.ModelNumber;
        }
    }
}
