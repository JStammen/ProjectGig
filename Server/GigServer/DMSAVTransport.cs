using OpenSource.UPnP;
using System;
using System.Net;

namespace GigServer
{
    /// <summary>
    /// Transparent DeviceSide UPnP Service
    /// </summary>
    public class DMSAVTransport : IUPnPService
    {
        // Place your declarations above this line

        #region [DO NOT MODIFY]
        //{{{{{ Begin Code Block

        private _DvAVTransport _S;
        public static string URN = "urn:schemas-upnp-org:service:AVTransport:1";
        public double VERSION
        {
           get
           {
               return(double.Parse(_S.GetUPnPService().Version));
           }
        }

        public enum Enum_RecordMediumWriteStatus
        {
            WRITABLE,
            PROTECTED,
            NOT_WRITABLE,
            UNKNOWN,
            NOT_IMPLEMENTED,
        }
        public Enum_RecordMediumWriteStatus RecordMediumWriteStatus
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_RecordMediumWriteStatus.WRITABLE:
                     v = "WRITABLE";
                     break;
                  case Enum_RecordMediumWriteStatus.PROTECTED:
                     v = "PROTECTED";
                     break;
                  case Enum_RecordMediumWriteStatus.NOT_WRITABLE:
                     v = "NOT_WRITABLE";
                     break;
                  case Enum_RecordMediumWriteStatus.UNKNOWN:
                     v = "UNKNOWN";
                     break;
                  case Enum_RecordMediumWriteStatus.NOT_IMPLEMENTED:
                     v = "NOT_IMPLEMENTED";
                     break;
               }
               _S.SetStateVariable("RecordMediumWriteStatus",v);
            }
            get
            {
               Enum_RecordMediumWriteStatus RetVal = 0;
               string v = (string)_S.GetStateVariable("RecordMediumWriteStatus");
               switch(v)
               {
                  case "WRITABLE":
                     RetVal = Enum_RecordMediumWriteStatus.WRITABLE;
                     break;
                  case "PROTECTED":
                     RetVal = Enum_RecordMediumWriteStatus.PROTECTED;
                     break;
                  case "NOT_WRITABLE":
                     RetVal = Enum_RecordMediumWriteStatus.NOT_WRITABLE;
                     break;
                  case "UNKNOWN":
                     RetVal = Enum_RecordMediumWriteStatus.UNKNOWN;
                     break;
                  case "NOT_IMPLEMENTED":
                     RetVal = Enum_RecordMediumWriteStatus.NOT_IMPLEMENTED;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_TransportStatus
        {
            OK,
            ERROR_OCCURRED,
            _VENDOR_DEFINED_,
        }
        public Enum_TransportStatus TransportStatus
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_TransportStatus.OK:
                     v = "OK";
                     break;
                  case Enum_TransportStatus.ERROR_OCCURRED:
                     v = "ERROR_OCCURRED";
                     break;
                  case Enum_TransportStatus._VENDOR_DEFINED_:
                     v = " vendor-defined ";
                     break;
               }
               _S.SetStateVariable("TransportStatus",v);
            }
            get
            {
               Enum_TransportStatus RetVal = 0;
               string v = (string)_S.GetStateVariable("TransportStatus");
               switch(v)
               {
                  case "OK":
                     RetVal = Enum_TransportStatus.OK;
                     break;
                  case "ERROR_OCCURRED":
                     RetVal = Enum_TransportStatus.ERROR_OCCURRED;
                     break;
                  case " vendor-defined ":
                     RetVal = Enum_TransportStatus._VENDOR_DEFINED_;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_TransportState
        {
            STOPPED,
            PAUSED_PLAYBACK,
            PAUSED_RECORDING,
            PLAYING,
            RECORDING,
            TRANSITIONING,
            NO_MEDIA_PRESENT,
        }
        public Enum_TransportState TransportState
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_TransportState.STOPPED:
                     v = "STOPPED";
                     break;
                  case Enum_TransportState.PAUSED_PLAYBACK:
                     v = "PAUSED_PLAYBACK";
                     break;
                  case Enum_TransportState.PAUSED_RECORDING:
                     v = "PAUSED_RECORDING";
                     break;
                  case Enum_TransportState.PLAYING:
                     v = "PLAYING";
                     break;
                  case Enum_TransportState.RECORDING:
                     v = "RECORDING";
                     break;
                  case Enum_TransportState.TRANSITIONING:
                     v = "TRANSITIONING";
                     break;
                  case Enum_TransportState.NO_MEDIA_PRESENT:
                     v = "NO_MEDIA_PRESENT";
                     break;
               }
               _S.SetStateVariable("TransportState",v);
            }
            get
            {
               Enum_TransportState RetVal = 0;
               string v = (string)_S.GetStateVariable("TransportState");
               switch(v)
               {
                  case "STOPPED":
                     RetVal = Enum_TransportState.STOPPED;
                     break;
                  case "PAUSED_PLAYBACK":
                     RetVal = Enum_TransportState.PAUSED_PLAYBACK;
                     break;
                  case "PAUSED_RECORDING":
                     RetVal = Enum_TransportState.PAUSED_RECORDING;
                     break;
                  case "PLAYING":
                     RetVal = Enum_TransportState.PLAYING;
                     break;
                  case "RECORDING":
                     RetVal = Enum_TransportState.RECORDING;
                     break;
                  case "TRANSITIONING":
                     RetVal = Enum_TransportState.TRANSITIONING;
                     break;
                  case "NO_MEDIA_PRESENT":
                     RetVal = Enum_TransportState.NO_MEDIA_PRESENT;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_A_ARG_TYPE_SeekMode
        {
            ABS_TIME,
            REL_TIME,
            ABS_COUNT,
            REL_COUNT,
            TRACK_NR,
            CHANNEL_FREQ,
            TAPE_INDEX,
            FRAME,
        }
        public Enum_A_ARG_TYPE_SeekMode A_ARG_TYPE_SeekMode
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_A_ARG_TYPE_SeekMode.ABS_TIME:
                     v = "ABS_TIME";
                     break;
                  case Enum_A_ARG_TYPE_SeekMode.REL_TIME:
                     v = "REL_TIME";
                     break;
                  case Enum_A_ARG_TYPE_SeekMode.ABS_COUNT:
                     v = "ABS_COUNT";
                     break;
                  case Enum_A_ARG_TYPE_SeekMode.REL_COUNT:
                     v = "REL_COUNT";
                     break;
                  case Enum_A_ARG_TYPE_SeekMode.TRACK_NR:
                     v = "TRACK_NR";
                     break;
                  case Enum_A_ARG_TYPE_SeekMode.CHANNEL_FREQ:
                     v = "CHANNEL_FREQ";
                     break;
                  case Enum_A_ARG_TYPE_SeekMode.TAPE_INDEX:
                     v = "TAPE-INDEX";
                     break;
                  case Enum_A_ARG_TYPE_SeekMode.FRAME:
                     v = "FRAME";
                     break;
               }
               _S.SetStateVariable("A_ARG_TYPE_SeekMode",v);
            }
            get
            {
               Enum_A_ARG_TYPE_SeekMode RetVal = 0;
               string v = (string)_S.GetStateVariable("A_ARG_TYPE_SeekMode");
               switch(v)
               {
                  case "ABS_TIME":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.ABS_TIME;
                     break;
                  case "REL_TIME":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.REL_TIME;
                     break;
                  case "ABS_COUNT":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.ABS_COUNT;
                     break;
                  case "REL_COUNT":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.REL_COUNT;
                     break;
                  case "TRACK_NR":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.TRACK_NR;
                     break;
                  case "CHANNEL_FREQ":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.CHANNEL_FREQ;
                     break;
                  case "TAPE-INDEX":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.TAPE_INDEX;
                     break;
                  case "FRAME":
                     RetVal = Enum_A_ARG_TYPE_SeekMode.FRAME;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_PlaybackStorageMedium
        {
            UNKNOWN,
            DV,
            MINI_DV,
            VHS,
            W_VHS,
            S_VHS,
            D_VHS,
            VHSC,
            VIDEO8,
            HI8,
            CD_ROM,
            CD_DA,
            CD_R,
            CD_RW,
            VIDEO_CD,
            SACD,
            MD_AUDIO,
            MD_PICTURE,
            DVD_ROM,
            DVD_VIDEO,
            DVD_R,
            DVD_RW,
            DVD_minus_RW,
            DVD_RAM,
            DVD_AUDIO,
            DAT,
            LD,
            HDD,
            MICRO_MV,
            NETWORK,
            NONE,
            NOT_IMPLEMENTED,
            _VENDOR_DEFINED_,
        }
        public Enum_PlaybackStorageMedium PlaybackStorageMedium
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_PlaybackStorageMedium.UNKNOWN:
                     v = "UNKNOWN";
                     break;
                  case Enum_PlaybackStorageMedium.DV:
                     v = "DV";
                     break;
                  case Enum_PlaybackStorageMedium.MINI_DV:
                     v = "MINI-DV";
                     break;
                  case Enum_PlaybackStorageMedium.VHS:
                     v = "VHS";
                     break;
                  case Enum_PlaybackStorageMedium.W_VHS:
                     v = "W-VHS";
                     break;
                  case Enum_PlaybackStorageMedium.S_VHS:
                     v = "S-VHS";
                     break;
                  case Enum_PlaybackStorageMedium.D_VHS:
                     v = "D-VHS";
                     break;
                  case Enum_PlaybackStorageMedium.VHSC:
                     v = "VHSC";
                     break;
                  case Enum_PlaybackStorageMedium.VIDEO8:
                     v = "VIDEO8";
                     break;
                  case Enum_PlaybackStorageMedium.HI8:
                     v = "HI8";
                     break;
                  case Enum_PlaybackStorageMedium.CD_ROM:
                     v = "CD-ROM";
                     break;
                  case Enum_PlaybackStorageMedium.CD_DA:
                     v = "CD-DA";
                     break;
                  case Enum_PlaybackStorageMedium.CD_R:
                     v = "CD-R";
                     break;
                  case Enum_PlaybackStorageMedium.CD_RW:
                     v = "CD-RW";
                     break;
                  case Enum_PlaybackStorageMedium.VIDEO_CD:
                     v = "VIDEO-CD";
                     break;
                  case Enum_PlaybackStorageMedium.SACD:
                     v = "SACD";
                     break;
                  case Enum_PlaybackStorageMedium.MD_AUDIO:
                     v = "MusicDir-AUDIO";
                     break;
                  case Enum_PlaybackStorageMedium.MD_PICTURE:
                     v = "MusicDir-PICTURE";
                     break;
                  case Enum_PlaybackStorageMedium.DVD_ROM:
                     v = "DVD-ROM";
                     break;
                  case Enum_PlaybackStorageMedium.DVD_VIDEO:
                     v = "DVD-VIDEO";
                     break;
                  case Enum_PlaybackStorageMedium.DVD_R:
                     v = "DVD-R";
                     break;
                  case Enum_PlaybackStorageMedium.DVD_RW:
                     v = "DVD+RW";
                     break;
                  case Enum_PlaybackStorageMedium.DVD_minus_RW:
                     v = "DVD-RW";
                     break;
                  case Enum_PlaybackStorageMedium.DVD_RAM:
                     v = "DVD-RAM";
                     break;
                  case Enum_PlaybackStorageMedium.DVD_AUDIO:
                     v = "DVD-AUDIO";
                     break;
                  case Enum_PlaybackStorageMedium.DAT:
                     v = "DAT";
                     break;
                  case Enum_PlaybackStorageMedium.LD:
                     v = "LD";
                     break;
                  case Enum_PlaybackStorageMedium.HDD:
                     v = "HDD";
                     break;
                  case Enum_PlaybackStorageMedium.MICRO_MV:
                     v = "MICRO-MV";
                     break;
                  case Enum_PlaybackStorageMedium.NETWORK:
                     v = "NETWORK";
                     break;
                  case Enum_PlaybackStorageMedium.NONE:
                     v = "NONE";
                     break;
                  case Enum_PlaybackStorageMedium.NOT_IMPLEMENTED:
                     v = "NOT_IMPLEMENTED";
                     break;
                  case Enum_PlaybackStorageMedium._VENDOR_DEFINED_:
                     v = " vendor-defined ";
                     break;
               }
               _S.SetStateVariable("PlaybackStorageMedium",v);
            }
            get
            {
               Enum_PlaybackStorageMedium RetVal = 0;
               string v = (string)_S.GetStateVariable("PlaybackStorageMedium");
               switch(v)
               {
                  case "UNKNOWN":
                     RetVal = Enum_PlaybackStorageMedium.UNKNOWN;
                     break;
                  case "DV":
                     RetVal = Enum_PlaybackStorageMedium.DV;
                     break;
                  case "MINI-DV":
                     RetVal = Enum_PlaybackStorageMedium.MINI_DV;
                     break;
                  case "VHS":
                     RetVal = Enum_PlaybackStorageMedium.VHS;
                     break;
                  case "W-VHS":
                     RetVal = Enum_PlaybackStorageMedium.W_VHS;
                     break;
                  case "S-VHS":
                     RetVal = Enum_PlaybackStorageMedium.S_VHS;
                     break;
                  case "D-VHS":
                     RetVal = Enum_PlaybackStorageMedium.D_VHS;
                     break;
                  case "VHSC":
                     RetVal = Enum_PlaybackStorageMedium.VHSC;
                     break;
                  case "VIDEO8":
                     RetVal = Enum_PlaybackStorageMedium.VIDEO8;
                     break;
                  case "HI8":
                     RetVal = Enum_PlaybackStorageMedium.HI8;
                     break;
                  case "CD-ROM":
                     RetVal = Enum_PlaybackStorageMedium.CD_ROM;
                     break;
                  case "CD-DA":
                     RetVal = Enum_PlaybackStorageMedium.CD_DA;
                     break;
                  case "CD-R":
                     RetVal = Enum_PlaybackStorageMedium.CD_R;
                     break;
                  case "CD-RW":
                     RetVal = Enum_PlaybackStorageMedium.CD_RW;
                     break;
                  case "VIDEO-CD":
                     RetVal = Enum_PlaybackStorageMedium.VIDEO_CD;
                     break;
                  case "SACD":
                     RetVal = Enum_PlaybackStorageMedium.SACD;
                     break;
                  case "MusicDir-AUDIO":
                     RetVal = Enum_PlaybackStorageMedium.MD_AUDIO;
                     break;
                  case "MusicDir-PICTURE":
                     RetVal = Enum_PlaybackStorageMedium.MD_PICTURE;
                     break;
                  case "DVD-ROM":
                     RetVal = Enum_PlaybackStorageMedium.DVD_ROM;
                     break;
                  case "DVD-VIDEO":
                     RetVal = Enum_PlaybackStorageMedium.DVD_VIDEO;
                     break;
                  case "DVD-R":
                     RetVal = Enum_PlaybackStorageMedium.DVD_R;
                     break;
                  case "DVD+RW":
                     RetVal = Enum_PlaybackStorageMedium.DVD_RW;
                     break;
                  case "DVD-RW":
                     RetVal = Enum_PlaybackStorageMedium.DVD_minus_RW;
                     break;
                  case "DVD-RAM":
                     RetVal = Enum_PlaybackStorageMedium.DVD_RAM;
                     break;
                  case "DVD-AUDIO":
                     RetVal = Enum_PlaybackStorageMedium.DVD_AUDIO;
                     break;
                  case "DAT":
                     RetVal = Enum_PlaybackStorageMedium.DAT;
                     break;
                  case "LD":
                     RetVal = Enum_PlaybackStorageMedium.LD;
                     break;
                  case "HDD":
                     RetVal = Enum_PlaybackStorageMedium.HDD;
                     break;
                  case "MICRO-MV":
                     RetVal = Enum_PlaybackStorageMedium.MICRO_MV;
                     break;
                  case "NETWORK":
                     RetVal = Enum_PlaybackStorageMedium.NETWORK;
                     break;
                  case "NONE":
                     RetVal = Enum_PlaybackStorageMedium.NONE;
                     break;
                  case "NOT_IMPLEMENTED":
                     RetVal = Enum_PlaybackStorageMedium.NOT_IMPLEMENTED;
                     break;
                  case " vendor-defined ":
                     RetVal = Enum_PlaybackStorageMedium._VENDOR_DEFINED_;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_TransportPlaySpeed
        {
            _1,
            _VENDOR_DEFINED_,
        }
        public Enum_TransportPlaySpeed TransportPlaySpeed
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_TransportPlaySpeed._1:
                     v = "1";
                     break;
                  case Enum_TransportPlaySpeed._VENDOR_DEFINED_:
                     v = " vendor-defined ";
                     break;
               }
               _S.SetStateVariable("TransportPlaySpeed",v);
            }
            get
            {
               Enum_TransportPlaySpeed RetVal = 0;
               string v = (string)_S.GetStateVariable("TransportPlaySpeed");
               switch(v)
               {
                  case "1":
                     RetVal = Enum_TransportPlaySpeed._1;
                     break;
                  case " vendor-defined ":
                     RetVal = Enum_TransportPlaySpeed._VENDOR_DEFINED_;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_CurrentPlayMode
        {
            NORMAL,
            SHUFFLE,
            REPEAT_ONE,
            REPEAT_ALL,
            RANDOM,
            DIRECT_1,
            INTRO,
        }
        public Enum_CurrentPlayMode CurrentPlayMode
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_CurrentPlayMode.NORMAL:
                     v = "NORMAL";
                     break;
                  case Enum_CurrentPlayMode.SHUFFLE:
                     v = "SHUFFLE";
                     break;
                  case Enum_CurrentPlayMode.REPEAT_ONE:
                     v = "REPEAT_ONE";
                     break;
                  case Enum_CurrentPlayMode.REPEAT_ALL:
                     v = "REPEAT_ALL";
                     break;
                  case Enum_CurrentPlayMode.RANDOM:
                     v = "RANDOM";
                     break;
                  case Enum_CurrentPlayMode.DIRECT_1:
                     v = "DIRECT_1";
                     break;
                  case Enum_CurrentPlayMode.INTRO:
                     v = "INTRO";
                     break;
               }
               _S.SetStateVariable("CurrentPlayMode",v);
            }
            get
            {
               Enum_CurrentPlayMode RetVal = 0;
               string v = (string)_S.GetStateVariable("CurrentPlayMode");
               switch(v)
               {
                  case "NORMAL":
                     RetVal = Enum_CurrentPlayMode.NORMAL;
                     break;
                  case "SHUFFLE":
                     RetVal = Enum_CurrentPlayMode.SHUFFLE;
                     break;
                  case "REPEAT_ONE":
                     RetVal = Enum_CurrentPlayMode.REPEAT_ONE;
                     break;
                  case "REPEAT_ALL":
                     RetVal = Enum_CurrentPlayMode.REPEAT_ALL;
                     break;
                  case "RANDOM":
                     RetVal = Enum_CurrentPlayMode.RANDOM;
                     break;
                  case "DIRECT_1":
                     RetVal = Enum_CurrentPlayMode.DIRECT_1;
                     break;
                  case "INTRO":
                     RetVal = Enum_CurrentPlayMode.INTRO;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_CurrentRecordQualityMode
        {
            _0_EP,
            _1_LP,
            _2_SP,
            _0_BASIC,
            _1_MEDIUM,
            _2_HIGH,
            NOT_IMPLEMENTED,
            _VENDOR_DEFINED_,
        }
        public Enum_CurrentRecordQualityMode CurrentRecordQualityMode
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_CurrentRecordQualityMode._0_EP:
                     v = "0:EP";
                     break;
                  case Enum_CurrentRecordQualityMode._1_LP:
                     v = "1:LP";
                     break;
                  case Enum_CurrentRecordQualityMode._2_SP:
                     v = "2:SP";
                     break;
                  case Enum_CurrentRecordQualityMode._0_BASIC:
                     v = "0:BASIC";
                     break;
                  case Enum_CurrentRecordQualityMode._1_MEDIUM:
                     v = "1:MEDIUM";
                     break;
                  case Enum_CurrentRecordQualityMode._2_HIGH:
                     v = "2:HIGH";
                     break;
                  case Enum_CurrentRecordQualityMode.NOT_IMPLEMENTED:
                     v = "NOT_IMPLEMENTED";
                     break;
                  case Enum_CurrentRecordQualityMode._VENDOR_DEFINED_:
                     v = " vendor-defined ";
                     break;
               }
               _S.SetStateVariable("CurrentRecordQualityMode",v);
            }
            get
            {
               Enum_CurrentRecordQualityMode RetVal = 0;
               string v = (string)_S.GetStateVariable("CurrentRecordQualityMode");
               switch(v)
               {
                  case "0:EP":
                     RetVal = Enum_CurrentRecordQualityMode._0_EP;
                     break;
                  case "1:LP":
                     RetVal = Enum_CurrentRecordQualityMode._1_LP;
                     break;
                  case "2:SP":
                     RetVal = Enum_CurrentRecordQualityMode._2_SP;
                     break;
                  case "0:BASIC":
                     RetVal = Enum_CurrentRecordQualityMode._0_BASIC;
                     break;
                  case "1:MEDIUM":
                     RetVal = Enum_CurrentRecordQualityMode._1_MEDIUM;
                     break;
                  case "2:HIGH":
                     RetVal = Enum_CurrentRecordQualityMode._2_HIGH;
                     break;
                  case "NOT_IMPLEMENTED":
                     RetVal = Enum_CurrentRecordQualityMode.NOT_IMPLEMENTED;
                     break;
                  case " vendor-defined ":
                     RetVal = Enum_CurrentRecordQualityMode._VENDOR_DEFINED_;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_RecordStorageMedium
        {
            UNKNOWN,
            DV,
            MINI_DV,
            VHS,
            W_VHS,
            S_VHS,
            D_VHS,
            VHSC,
            VIDEO8,
            HI8,
            CD_ROM,
            CD_DA,
            CD_R,
            CD_RW,
            VIDEO_CD,
            SACD,
            MD_AUDIO,
            MD_PICTURE,
            DVD_ROM,
            DVD_VIDEO,
            DVD_R,
            DVD_RW,
            DVD_minus_RW,
            DVD_RAM,
            DVD_AUDIO,
            DAT,
            LD,
            HDD,
            MICRO_MV,
            NETWORK,
            NONE,
            NOT_IMPLEMENTED,
            _VENDOR_DEFINED_,
        }
        public Enum_RecordStorageMedium RecordStorageMedium
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_RecordStorageMedium.UNKNOWN:
                     v = "UNKNOWN";
                     break;
                  case Enum_RecordStorageMedium.DV:
                     v = "DV";
                     break;
                  case Enum_RecordStorageMedium.MINI_DV:
                     v = "MINI-DV";
                     break;
                  case Enum_RecordStorageMedium.VHS:
                     v = "VHS";
                     break;
                  case Enum_RecordStorageMedium.W_VHS:
                     v = "W-VHS";
                     break;
                  case Enum_RecordStorageMedium.S_VHS:
                     v = "S-VHS";
                     break;
                  case Enum_RecordStorageMedium.D_VHS:
                     v = "D-VHS";
                     break;
                  case Enum_RecordStorageMedium.VHSC:
                     v = "VHSC";
                     break;
                  case Enum_RecordStorageMedium.VIDEO8:
                     v = "VIDEO8";
                     break;
                  case Enum_RecordStorageMedium.HI8:
                     v = "HI8";
                     break;
                  case Enum_RecordStorageMedium.CD_ROM:
                     v = "CD-ROM";
                     break;
                  case Enum_RecordStorageMedium.CD_DA:
                     v = "CD-DA";
                     break;
                  case Enum_RecordStorageMedium.CD_R:
                     v = "CD-R";
                     break;
                  case Enum_RecordStorageMedium.CD_RW:
                     v = "CD-RW";
                     break;
                  case Enum_RecordStorageMedium.VIDEO_CD:
                     v = "VIDEO-CD";
                     break;
                  case Enum_RecordStorageMedium.SACD:
                     v = "SACD";
                     break;
                  case Enum_RecordStorageMedium.MD_AUDIO:
                     v = "MusicDir-AUDIO";
                     break;
                  case Enum_RecordStorageMedium.MD_PICTURE:
                     v = "MusicDir-PICTURE";
                     break;
                  case Enum_RecordStorageMedium.DVD_ROM:
                     v = "DVD-ROM";
                     break;
                  case Enum_RecordStorageMedium.DVD_VIDEO:
                     v = "DVD-VIDEO";
                     break;
                  case Enum_RecordStorageMedium.DVD_R:
                     v = "DVD-R";
                     break;
                  case Enum_RecordStorageMedium.DVD_RW:
                     v = "DVD+RW";
                     break;
                  case Enum_RecordStorageMedium.DVD_minus_RW:
                     v = "DVD-RW";
                     break;
                  case Enum_RecordStorageMedium.DVD_RAM:
                     v = "DVD-RAM";
                     break;
                  case Enum_RecordStorageMedium.DVD_AUDIO:
                     v = "DVD-AUDIO";
                     break;
                  case Enum_RecordStorageMedium.DAT:
                     v = "DAT";
                     break;
                  case Enum_RecordStorageMedium.LD:
                     v = "LD";
                     break;
                  case Enum_RecordStorageMedium.HDD:
                     v = "HDD";
                     break;
                  case Enum_RecordStorageMedium.MICRO_MV:
                     v = "MICRO-MV";
                     break;
                  case Enum_RecordStorageMedium.NETWORK:
                     v = "NETWORK";
                     break;
                  case Enum_RecordStorageMedium.NONE:
                     v = "NONE";
                     break;
                  case Enum_RecordStorageMedium.NOT_IMPLEMENTED:
                     v = "NOT_IMPLEMENTED";
                     break;
                  case Enum_RecordStorageMedium._VENDOR_DEFINED_:
                     v = " vendor-defined ";
                     break;
               }
               _S.SetStateVariable("RecordStorageMedium",v);
            }
            get
            {
               Enum_RecordStorageMedium RetVal = 0;
               string v = (string)_S.GetStateVariable("RecordStorageMedium");
               switch(v)
               {
                  case "UNKNOWN":
                     RetVal = Enum_RecordStorageMedium.UNKNOWN;
                     break;
                  case "DV":
                     RetVal = Enum_RecordStorageMedium.DV;
                     break;
                  case "MINI-DV":
                     RetVal = Enum_RecordStorageMedium.MINI_DV;
                     break;
                  case "VHS":
                     RetVal = Enum_RecordStorageMedium.VHS;
                     break;
                  case "W-VHS":
                     RetVal = Enum_RecordStorageMedium.W_VHS;
                     break;
                  case "S-VHS":
                     RetVal = Enum_RecordStorageMedium.S_VHS;
                     break;
                  case "D-VHS":
                     RetVal = Enum_RecordStorageMedium.D_VHS;
                     break;
                  case "VHSC":
                     RetVal = Enum_RecordStorageMedium.VHSC;
                     break;
                  case "VIDEO8":
                     RetVal = Enum_RecordStorageMedium.VIDEO8;
                     break;
                  case "HI8":
                     RetVal = Enum_RecordStorageMedium.HI8;
                     break;
                  case "CD-ROM":
                     RetVal = Enum_RecordStorageMedium.CD_ROM;
                     break;
                  case "CD-DA":
                     RetVal = Enum_RecordStorageMedium.CD_DA;
                     break;
                  case "CD-R":
                     RetVal = Enum_RecordStorageMedium.CD_R;
                     break;
                  case "CD-RW":
                     RetVal = Enum_RecordStorageMedium.CD_RW;
                     break;
                  case "VIDEO-CD":
                     RetVal = Enum_RecordStorageMedium.VIDEO_CD;
                     break;
                  case "SACD":
                     RetVal = Enum_RecordStorageMedium.SACD;
                     break;
                  case "MusicDir-AUDIO":
                     RetVal = Enum_RecordStorageMedium.MD_AUDIO;
                     break;
                  case "MusicDir-PICTURE":
                     RetVal = Enum_RecordStorageMedium.MD_PICTURE;
                     break;
                  case "DVD-ROM":
                     RetVal = Enum_RecordStorageMedium.DVD_ROM;
                     break;
                  case "DVD-VIDEO":
                     RetVal = Enum_RecordStorageMedium.DVD_VIDEO;
                     break;
                  case "DVD-R":
                     RetVal = Enum_RecordStorageMedium.DVD_R;
                     break;
                  case "DVD+RW":
                     RetVal = Enum_RecordStorageMedium.DVD_RW;
                     break;
                  case "DVD-RW":
                     RetVal = Enum_RecordStorageMedium.DVD_minus_RW;
                     break;
                  case "DVD-RAM":
                     RetVal = Enum_RecordStorageMedium.DVD_RAM;
                     break;
                  case "DVD-AUDIO":
                     RetVal = Enum_RecordStorageMedium.DVD_AUDIO;
                     break;
                  case "DAT":
                     RetVal = Enum_RecordStorageMedium.DAT;
                     break;
                  case "LD":
                     RetVal = Enum_RecordStorageMedium.LD;
                     break;
                  case "HDD":
                     RetVal = Enum_RecordStorageMedium.HDD;
                     break;
                  case "MICRO-MV":
                     RetVal = Enum_RecordStorageMedium.MICRO_MV;
                     break;
                  case "NETWORK":
                     RetVal = Enum_RecordStorageMedium.NETWORK;
                     break;
                  case "NONE":
                     RetVal = Enum_RecordStorageMedium.NONE;
                     break;
                  case "NOT_IMPLEMENTED":
                     RetVal = Enum_RecordStorageMedium.NOT_IMPLEMENTED;
                     break;
                  case " vendor-defined ":
                     RetVal = Enum_RecordStorageMedium._VENDOR_DEFINED_;
                     break;
               }
               return(RetVal);
           }
        }
        static public string Enum_RecordMediumWriteStatus_ToString(Enum_RecordMediumWriteStatus en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_RecordMediumWriteStatus.WRITABLE:
                    RetVal = "WRITABLE";
                    break;
                case Enum_RecordMediumWriteStatus.PROTECTED:
                    RetVal = "PROTECTED";
                    break;
                case Enum_RecordMediumWriteStatus.NOT_WRITABLE:
                    RetVal = "NOT_WRITABLE";
                    break;
                case Enum_RecordMediumWriteStatus.UNKNOWN:
                    RetVal = "UNKNOWN";
                    break;
                case Enum_RecordMediumWriteStatus.NOT_IMPLEMENTED:
                    RetVal = "NOT_IMPLEMENTED";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_RecordMediumWriteStatus
        {
            get
            {
                string[] RetVal = new string[5]{"NOT_IMPLEMENTED","UNKNOWN","NOT_WRITABLE","PROTECTED","WRITABLE"};
                return(RetVal);
            }
        }
        static public string Enum_TransportStatus_ToString(Enum_TransportStatus en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_TransportStatus.OK:
                    RetVal = "OK";
                    break;
                case Enum_TransportStatus.ERROR_OCCURRED:
                    RetVal = "ERROR_OCCURRED";
                    break;
                case Enum_TransportStatus._VENDOR_DEFINED_:
                    RetVal = " vendor-defined ";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_TransportStatus
        {
            get
            {
                string[] RetVal = new string[3]{" vendor-defined ","ERROR_OCCURRED","OK"};
                return(RetVal);
            }
        }
        static public string Enum_TransportState_ToString(Enum_TransportState en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_TransportState.STOPPED:
                    RetVal = "STOPPED";
                    break;
                case Enum_TransportState.PAUSED_PLAYBACK:
                    RetVal = "PAUSED_PLAYBACK";
                    break;
                case Enum_TransportState.PAUSED_RECORDING:
                    RetVal = "PAUSED_RECORDING";
                    break;
                case Enum_TransportState.PLAYING:
                    RetVal = "PLAYING";
                    break;
                case Enum_TransportState.RECORDING:
                    RetVal = "RECORDING";
                    break;
                case Enum_TransportState.TRANSITIONING:
                    RetVal = "TRANSITIONING";
                    break;
                case Enum_TransportState.NO_MEDIA_PRESENT:
                    RetVal = "NO_MEDIA_PRESENT";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_TransportState
        {
            get
            {
                string[] RetVal = new string[7]{"NO_MEDIA_PRESENT","TRANSITIONING","RECORDING","PLAYING","PAUSED_RECORDING","PAUSED_PLAYBACK","STOPPED"};
                return(RetVal);
            }
        }
        static public string Enum_A_ARG_TYPE_SeekMode_ToString(Enum_A_ARG_TYPE_SeekMode en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_A_ARG_TYPE_SeekMode.ABS_TIME:
                    RetVal = "ABS_TIME";
                    break;
                case Enum_A_ARG_TYPE_SeekMode.REL_TIME:
                    RetVal = "REL_TIME";
                    break;
                case Enum_A_ARG_TYPE_SeekMode.ABS_COUNT:
                    RetVal = "ABS_COUNT";
                    break;
                case Enum_A_ARG_TYPE_SeekMode.REL_COUNT:
                    RetVal = "REL_COUNT";
                    break;
                case Enum_A_ARG_TYPE_SeekMode.TRACK_NR:
                    RetVal = "TRACK_NR";
                    break;
                case Enum_A_ARG_TYPE_SeekMode.CHANNEL_FREQ:
                    RetVal = "CHANNEL_FREQ";
                    break;
                case Enum_A_ARG_TYPE_SeekMode.TAPE_INDEX:
                    RetVal = "TAPE-INDEX";
                    break;
                case Enum_A_ARG_TYPE_SeekMode.FRAME:
                    RetVal = "FRAME";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_A_ARG_TYPE_SeekMode
        {
            get
            {
                string[] RetVal = new string[8]{"FRAME","TAPE-INDEX","CHANNEL_FREQ","TRACK_NR","REL_COUNT","ABS_COUNT","REL_TIME","ABS_TIME"};
                return(RetVal);
            }
        }
        static public string Enum_PlaybackStorageMedium_ToString(Enum_PlaybackStorageMedium en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_PlaybackStorageMedium.UNKNOWN:
                    RetVal = "UNKNOWN";
                    break;
                case Enum_PlaybackStorageMedium.DV:
                    RetVal = "DV";
                    break;
                case Enum_PlaybackStorageMedium.MINI_DV:
                    RetVal = "MINI-DV";
                    break;
                case Enum_PlaybackStorageMedium.VHS:
                    RetVal = "VHS";
                    break;
                case Enum_PlaybackStorageMedium.W_VHS:
                    RetVal = "W-VHS";
                    break;
                case Enum_PlaybackStorageMedium.S_VHS:
                    RetVal = "S-VHS";
                    break;
                case Enum_PlaybackStorageMedium.D_VHS:
                    RetVal = "D-VHS";
                    break;
                case Enum_PlaybackStorageMedium.VHSC:
                    RetVal = "VHSC";
                    break;
                case Enum_PlaybackStorageMedium.VIDEO8:
                    RetVal = "VIDEO8";
                    break;
                case Enum_PlaybackStorageMedium.HI8:
                    RetVal = "HI8";
                    break;
                case Enum_PlaybackStorageMedium.CD_ROM:
                    RetVal = "CD-ROM";
                    break;
                case Enum_PlaybackStorageMedium.CD_DA:
                    RetVal = "CD-DA";
                    break;
                case Enum_PlaybackStorageMedium.CD_R:
                    RetVal = "CD-R";
                    break;
                case Enum_PlaybackStorageMedium.CD_RW:
                    RetVal = "CD-RW";
                    break;
                case Enum_PlaybackStorageMedium.VIDEO_CD:
                    RetVal = "VIDEO-CD";
                    break;
                case Enum_PlaybackStorageMedium.SACD:
                    RetVal = "SACD";
                    break;
                case Enum_PlaybackStorageMedium.MD_AUDIO:
                    RetVal = "MusicDir-AUDIO";
                    break;
                case Enum_PlaybackStorageMedium.MD_PICTURE:
                    RetVal = "MusicDir-PICTURE";
                    break;
                case Enum_PlaybackStorageMedium.DVD_ROM:
                    RetVal = "DVD-ROM";
                    break;
                case Enum_PlaybackStorageMedium.DVD_VIDEO:
                    RetVal = "DVD-VIDEO";
                    break;
                case Enum_PlaybackStorageMedium.DVD_R:
                    RetVal = "DVD-R";
                    break;
                case Enum_PlaybackStorageMedium.DVD_RW:
                    RetVal = "DVD+RW";
                    break;
                case Enum_PlaybackStorageMedium.DVD_minus_RW:
                    RetVal = "DVD-RW";
                    break;
                case Enum_PlaybackStorageMedium.DVD_RAM:
                    RetVal = "DVD-RAM";
                    break;
                case Enum_PlaybackStorageMedium.DVD_AUDIO:
                    RetVal = "DVD-AUDIO";
                    break;
                case Enum_PlaybackStorageMedium.DAT:
                    RetVal = "DAT";
                    break;
                case Enum_PlaybackStorageMedium.LD:
                    RetVal = "LD";
                    break;
                case Enum_PlaybackStorageMedium.HDD:
                    RetVal = "HDD";
                    break;
                case Enum_PlaybackStorageMedium.MICRO_MV:
                    RetVal = "MICRO-MV";
                    break;
                case Enum_PlaybackStorageMedium.NETWORK:
                    RetVal = "NETWORK";
                    break;
                case Enum_PlaybackStorageMedium.NONE:
                    RetVal = "NONE";
                    break;
                case Enum_PlaybackStorageMedium.NOT_IMPLEMENTED:
                    RetVal = "NOT_IMPLEMENTED";
                    break;
                case Enum_PlaybackStorageMedium._VENDOR_DEFINED_:
                    RetVal = " vendor-defined ";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_PlaybackStorageMedium
        {
            get
            {
                string[] RetVal = new string[33]{" vendor-defined ","NOT_IMPLEMENTED","NONE","NETWORK","MICRO-MV","HDD","LD","DAT","DVD-AUDIO","DVD-RAM","DVD-RW","DVD+RW","DVD-R","DVD-VIDEO","DVD-ROM","MusicDir-PICTURE","MusicDir-AUDIO","SACD","VIDEO-CD","CD-RW","CD-R","CD-DA","CD-ROM","HI8","VIDEO8","VHSC","D-VHS","S-VHS","W-VHS","VHS","MINI-DV","DV","UNKNOWN"};
                return(RetVal);
            }
        }
        static public string Enum_TransportPlaySpeed_ToString(Enum_TransportPlaySpeed en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_TransportPlaySpeed._1:
                    RetVal = "1";
                    break;
                case Enum_TransportPlaySpeed._VENDOR_DEFINED_:
                    RetVal = " vendor-defined ";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_TransportPlaySpeed
        {
            get
            {
                string[] RetVal = new string[2]{" vendor-defined ","1"};
                return(RetVal);
            }
        }
        static public string Enum_CurrentPlayMode_ToString(Enum_CurrentPlayMode en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_CurrentPlayMode.NORMAL:
                    RetVal = "NORMAL";
                    break;
                case Enum_CurrentPlayMode.SHUFFLE:
                    RetVal = "SHUFFLE";
                    break;
                case Enum_CurrentPlayMode.REPEAT_ONE:
                    RetVal = "REPEAT_ONE";
                    break;
                case Enum_CurrentPlayMode.REPEAT_ALL:
                    RetVal = "REPEAT_ALL";
                    break;
                case Enum_CurrentPlayMode.RANDOM:
                    RetVal = "RANDOM";
                    break;
                case Enum_CurrentPlayMode.DIRECT_1:
                    RetVal = "DIRECT_1";
                    break;
                case Enum_CurrentPlayMode.INTRO:
                    RetVal = "INTRO";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_CurrentPlayMode
        {
            get
            {
                string[] RetVal = new string[7]{"INTRO","DIRECT_1","RANDOM","REPEAT_ALL","REPEAT_ONE","SHUFFLE","NORMAL"};
                return(RetVal);
            }
        }
        static public string Enum_CurrentRecordQualityMode_ToString(Enum_CurrentRecordQualityMode en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_CurrentRecordQualityMode._0_EP:
                    RetVal = "0:EP";
                    break;
                case Enum_CurrentRecordQualityMode._1_LP:
                    RetVal = "1:LP";
                    break;
                case Enum_CurrentRecordQualityMode._2_SP:
                    RetVal = "2:SP";
                    break;
                case Enum_CurrentRecordQualityMode._0_BASIC:
                    RetVal = "0:BASIC";
                    break;
                case Enum_CurrentRecordQualityMode._1_MEDIUM:
                    RetVal = "1:MEDIUM";
                    break;
                case Enum_CurrentRecordQualityMode._2_HIGH:
                    RetVal = "2:HIGH";
                    break;
                case Enum_CurrentRecordQualityMode.NOT_IMPLEMENTED:
                    RetVal = "NOT_IMPLEMENTED";
                    break;
                case Enum_CurrentRecordQualityMode._VENDOR_DEFINED_:
                    RetVal = " vendor-defined ";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_CurrentRecordQualityMode
        {
            get
            {
                string[] RetVal = new string[8]{" vendor-defined ","NOT_IMPLEMENTED","2:HIGH","1:MEDIUM","0:BASIC","2:SP","1:LP","0:EP"};
                return(RetVal);
            }
        }
        static public string Enum_RecordStorageMedium_ToString(Enum_RecordStorageMedium en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_RecordStorageMedium.UNKNOWN:
                    RetVal = "UNKNOWN";
                    break;
                case Enum_RecordStorageMedium.DV:
                    RetVal = "DV";
                    break;
                case Enum_RecordStorageMedium.MINI_DV:
                    RetVal = "MINI-DV";
                    break;
                case Enum_RecordStorageMedium.VHS:
                    RetVal = "VHS";
                    break;
                case Enum_RecordStorageMedium.W_VHS:
                    RetVal = "W-VHS";
                    break;
                case Enum_RecordStorageMedium.S_VHS:
                    RetVal = "S-VHS";
                    break;
                case Enum_RecordStorageMedium.D_VHS:
                    RetVal = "D-VHS";
                    break;
                case Enum_RecordStorageMedium.VHSC:
                    RetVal = "VHSC";
                    break;
                case Enum_RecordStorageMedium.VIDEO8:
                    RetVal = "VIDEO8";
                    break;
                case Enum_RecordStorageMedium.HI8:
                    RetVal = "HI8";
                    break;
                case Enum_RecordStorageMedium.CD_ROM:
                    RetVal = "CD-ROM";
                    break;
                case Enum_RecordStorageMedium.CD_DA:
                    RetVal = "CD-DA";
                    break;
                case Enum_RecordStorageMedium.CD_R:
                    RetVal = "CD-R";
                    break;
                case Enum_RecordStorageMedium.CD_RW:
                    RetVal = "CD-RW";
                    break;
                case Enum_RecordStorageMedium.VIDEO_CD:
                    RetVal = "VIDEO-CD";
                    break;
                case Enum_RecordStorageMedium.SACD:
                    RetVal = "SACD";
                    break;
                case Enum_RecordStorageMedium.MD_AUDIO:
                    RetVal = "MusicDir-AUDIO";
                    break;
                case Enum_RecordStorageMedium.MD_PICTURE:
                    RetVal = "MusicDir-PICTURE";
                    break;
                case Enum_RecordStorageMedium.DVD_ROM:
                    RetVal = "DVD-ROM";
                    break;
                case Enum_RecordStorageMedium.DVD_VIDEO:
                    RetVal = "DVD-VIDEO";
                    break;
                case Enum_RecordStorageMedium.DVD_R:
                    RetVal = "DVD-R";
                    break;
                case Enum_RecordStorageMedium.DVD_RW:
                    RetVal = "DVD+RW";
                    break;
                case Enum_RecordStorageMedium.DVD_minus_RW:
                    RetVal = "DVD-RW";
                    break;
                case Enum_RecordStorageMedium.DVD_RAM:
                    RetVal = "DVD-RAM";
                    break;
                case Enum_RecordStorageMedium.DVD_AUDIO:
                    RetVal = "DVD-AUDIO";
                    break;
                case Enum_RecordStorageMedium.DAT:
                    RetVal = "DAT";
                    break;
                case Enum_RecordStorageMedium.LD:
                    RetVal = "LD";
                    break;
                case Enum_RecordStorageMedium.HDD:
                    RetVal = "HDD";
                    break;
                case Enum_RecordStorageMedium.MICRO_MV:
                    RetVal = "MICRO-MV";
                    break;
                case Enum_RecordStorageMedium.NETWORK:
                    RetVal = "NETWORK";
                    break;
                case Enum_RecordStorageMedium.NONE:
                    RetVal = "NONE";
                    break;
                case Enum_RecordStorageMedium.NOT_IMPLEMENTED:
                    RetVal = "NOT_IMPLEMENTED";
                    break;
                case Enum_RecordStorageMedium._VENDOR_DEFINED_:
                    RetVal = " vendor-defined ";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_RecordStorageMedium
        {
            get
            {
                string[] RetVal = new string[33]{" vendor-defined ","NOT_IMPLEMENTED","NONE","NETWORK","MICRO-MV","HDD","LD","DAT","DVD-AUDIO","DVD-RAM","DVD-RW","DVD+RW","DVD-R","DVD-VIDEO","DVD-ROM","MusicDir-PICTURE","MusicDir-AUDIO","SACD","VIDEO-CD","CD-RW","CD-R","CD-DA","CD-ROM","HI8","VIDEO8","VHSC","D-VHS","S-VHS","W-VHS","VHS","MINI-DV","DV","UNKNOWN"};
                return(RetVal);
            }
        }
        public delegate void OnStateVariableModifiedHandler(DMSAVTransport sender);
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_SeekMode;
        public event OnStateVariableModifiedHandler OnStateVariableModified_NextAVTransportURI;
        public event OnStateVariableModifiedHandler OnStateVariableModified_PossiblePlaybackStorageMedia;
        public event OnStateVariableModifiedHandler OnStateVariableModified_RecordStorageMedium;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_InstanceID;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentTrack;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentTrackDuration;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentPlayMode;
        public event OnStateVariableModifiedHandler OnStateVariableModified_TransportStatus;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentRecordQualityMode;
        public event OnStateVariableModifiedHandler OnStateVariableModified_TransportState;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentTrackURI;
        public event OnStateVariableModifiedHandler OnStateVariableModified_PlaybackStorageMedium;
        public event OnStateVariableModifiedHandler OnStateVariableModified_AVTransportURI;
        public event OnStateVariableModifiedHandler OnStateVariableModified_AbsoluteCounterPosition;
        public event OnStateVariableModifiedHandler OnStateVariableModified_AVTransportURIMetaData;
        public event OnStateVariableModifiedHandler OnStateVariableModified_LastChange;
        public event OnStateVariableModifiedHandler OnStateVariableModified_NextAVTransportURIMetaData;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentTransportActions;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_SeekTarget;
        public event OnStateVariableModifiedHandler OnStateVariableModified_AbsoluteTimePosition;
        public event OnStateVariableModifiedHandler OnStateVariableModified_RecordMediumWriteStatus;
        public event OnStateVariableModifiedHandler OnStateVariableModified_RelativeTimePosition;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentTrackMetaData;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentMediaDuration;
        public event OnStateVariableModifiedHandler OnStateVariableModified_TransportPlaySpeed;
        public event OnStateVariableModifiedHandler OnStateVariableModified_RelativeCounterPosition;
        public event OnStateVariableModifiedHandler OnStateVariableModified_NumberOfTracks;
        public event OnStateVariableModifiedHandler OnStateVariableModified_PossibleRecordQualityModes;
        public event OnStateVariableModifiedHandler OnStateVariableModified_PossibleRecordStorageMedia;
        public System.String NextAVTransportURI
        {
            get
            {
               return((System.String)_S.GetStateVariable("NextAVTransportURI"));
            }
            set
            {
               _S.SetStateVariable("NextAVTransportURI", value);
            }
        }
        public System.String PossiblePlaybackStorageMedia
        {
            get
            {
               return((System.String)_S.GetStateVariable("PossiblePlaybackStorageMedia"));
            }
            set
            {
               _S.SetStateVariable("PossiblePlaybackStorageMedia", value);
            }
        }
        public System.UInt32 A_ARG_TYPE_InstanceID
        {
            get
            {
               return((System.UInt32)_S.GetStateVariable("A_ARG_TYPE_InstanceID"));
            }
            set
            {
               _S.SetStateVariable("A_ARG_TYPE_InstanceID", value);
            }
        }
        public System.UInt32 CurrentTrack
        {
            get
            {
               return((System.UInt32)_S.GetStateVariable("CurrentTrack"));
            }
            set
            {
               _S.SetStateVariable("CurrentTrack", value);
            }
        }
        public System.String CurrentTrackDuration
        {
            get
            {
               return((System.String)_S.GetStateVariable("CurrentTrackDuration"));
            }
            set
            {
               _S.SetStateVariable("CurrentTrackDuration", value);
            }
        }
        public System.String CurrentTrackURI
        {
            get
            {
               return((System.String)_S.GetStateVariable("CurrentTrackURI"));
            }
            set
            {
               _S.SetStateVariable("CurrentTrackURI", value);
            }
        }
        public System.String AVTransportURI
        {
            get
            {
               return((System.String)_S.GetStateVariable("AVTransportURI"));
            }
            set
            {
               _S.SetStateVariable("AVTransportURI", value);
            }
        }
        public System.Int32 AbsoluteCounterPosition
        {
            get
            {
               return((System.Int32)_S.GetStateVariable("AbsoluteCounterPosition"));
            }
            set
            {
               _S.SetStateVariable("AbsoluteCounterPosition", value);
            }
        }
        public System.String AVTransportURIMetaData
        {
            get
            {
               return((System.String)_S.GetStateVariable("AVTransportURIMetaData"));
            }
            set
            {
               _S.SetStateVariable("AVTransportURIMetaData", value);
            }
        }
        public System.String Evented_LastChange
        {
            get
            {
               return((System.String)_S.GetStateVariable("LastChange"));
            }
            set
            {
               _S.SetStateVariable("LastChange", value);
            }
        }
        public System.String NextAVTransportURIMetaData
        {
            get
            {
               return((System.String)_S.GetStateVariable("NextAVTransportURIMetaData"));
            }
            set
            {
               _S.SetStateVariable("NextAVTransportURIMetaData", value);
            }
        }
        public System.String CurrentTransportActions
        {
            get
            {
               return((System.String)_S.GetStateVariable("CurrentTransportActions"));
            }
            set
            {
               _S.SetStateVariable("CurrentTransportActions", value);
            }
        }
        public System.String A_ARG_TYPE_SeekTarget
        {
            get
            {
               return((System.String)_S.GetStateVariable("A_ARG_TYPE_SeekTarget"));
            }
            set
            {
               _S.SetStateVariable("A_ARG_TYPE_SeekTarget", value);
            }
        }
        public System.String AbsoluteTimePosition
        {
            get
            {
               return((System.String)_S.GetStateVariable("AbsoluteTimePosition"));
            }
            set
            {
               _S.SetStateVariable("AbsoluteTimePosition", value);
            }
        }
        public System.String RelativeTimePosition
        {
            get
            {
               return((System.String)_S.GetStateVariable("RelativeTimePosition"));
            }
            set
            {
               _S.SetStateVariable("RelativeTimePosition", value);
            }
        }
        public System.String CurrentTrackMetaData
        {
            get
            {
               return((System.String)_S.GetStateVariable("CurrentTrackMetaData"));
            }
            set
            {
               _S.SetStateVariable("CurrentTrackMetaData", value);
            }
        }
        public System.String CurrentMediaDuration
        {
            get
            {
               return((System.String)_S.GetStateVariable("CurrentMediaDuration"));
            }
            set
            {
               _S.SetStateVariable("CurrentMediaDuration", value);
            }
        }
        public System.Int32 RelativeCounterPosition
        {
            get
            {
               return((System.Int32)_S.GetStateVariable("RelativeCounterPosition"));
            }
            set
            {
               _S.SetStateVariable("RelativeCounterPosition", value);
            }
        }
        public System.UInt32 NumberOfTracks
        {
            get
            {
               return((System.UInt32)_S.GetStateVariable("NumberOfTracks"));
            }
            set
            {
               _S.SetStateVariable("NumberOfTracks", value);
            }
        }
        public System.String PossibleRecordQualityModes
        {
            get
            {
               return((System.String)_S.GetStateVariable("PossibleRecordQualityModes"));
            }
            set
            {
               _S.SetStateVariable("PossibleRecordQualityModes", value);
            }
        }
        public System.String PossibleRecordStorageMedia
        {
            get
            {
               return((System.String)_S.GetStateVariable("PossibleRecordStorageMedia"));
            }
            set
            {
               _S.SetStateVariable("PossibleRecordStorageMedia", value);
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_SeekMode
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekMode")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekMode")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_SeekMode
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekMode")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekMode")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_NextAVTransportURI
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURI")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURI")).Accumulator = value;
            }
        }
        public double ModerationDuration_NextAVTransportURI
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURI")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURI")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_PossiblePlaybackStorageMedia
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossiblePlaybackStorageMedia")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossiblePlaybackStorageMedia")).Accumulator = value;
            }
        }
        public double ModerationDuration_PossiblePlaybackStorageMedia
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossiblePlaybackStorageMedia")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossiblePlaybackStorageMedia")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_RecordStorageMedium
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordStorageMedium")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordStorageMedium")).Accumulator = value;
            }
        }
        public double ModerationDuration_RecordStorageMedium
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordStorageMedium")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordStorageMedium")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_InstanceID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_InstanceID")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_InstanceID")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_InstanceID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_InstanceID")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_InstanceID")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentTrack
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrack")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrack")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentTrack
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrack")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrack")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentTrackDuration
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackDuration")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackDuration")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentTrackDuration
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackDuration")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackDuration")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentPlayMode
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentPlayMode")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentPlayMode")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentPlayMode
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentPlayMode")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentPlayMode")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_TransportStatus
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportStatus")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportStatus")).Accumulator = value;
            }
        }
        public double ModerationDuration_TransportStatus
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportStatus")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportStatus")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentRecordQualityMode
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentRecordQualityMode")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentRecordQualityMode")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentRecordQualityMode
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentRecordQualityMode")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentRecordQualityMode")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_TransportState
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportState")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportState")).Accumulator = value;
            }
        }
        public double ModerationDuration_TransportState
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportState")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportState")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentTrackURI
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackURI")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackURI")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentTrackURI
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackURI")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackURI")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_PlaybackStorageMedium
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PlaybackStorageMedium")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PlaybackStorageMedium")).Accumulator = value;
            }
        }
        public double ModerationDuration_PlaybackStorageMedium
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PlaybackStorageMedium")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PlaybackStorageMedium")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_AVTransportURI
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURI")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURI")).Accumulator = value;
            }
        }
        public double ModerationDuration_AVTransportURI
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURI")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURI")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_AbsoluteCounterPosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteCounterPosition")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteCounterPosition")).Accumulator = value;
            }
        }
        public double ModerationDuration_AbsoluteCounterPosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteCounterPosition")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteCounterPosition")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_AVTransportURIMetaData
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURIMetaData")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURIMetaData")).Accumulator = value;
            }
        }
        public double ModerationDuration_AVTransportURIMetaData
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURIMetaData")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AVTransportURIMetaData")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_LastChange
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("LastChange")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("LastChange")).Accumulator = value;
            }
        }
        public double ModerationDuration_LastChange
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("LastChange")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("LastChange")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_NextAVTransportURIMetaData
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURIMetaData")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURIMetaData")).Accumulator = value;
            }
        }
        public double ModerationDuration_NextAVTransportURIMetaData
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURIMetaData")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NextAVTransportURIMetaData")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentTransportActions
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTransportActions")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTransportActions")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentTransportActions
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTransportActions")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTransportActions")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_SeekTarget
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekTarget")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekTarget")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_SeekTarget
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekTarget")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekTarget")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_AbsoluteTimePosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteTimePosition")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteTimePosition")).Accumulator = value;
            }
        }
        public double ModerationDuration_AbsoluteTimePosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteTimePosition")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("AbsoluteTimePosition")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_RecordMediumWriteStatus
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordMediumWriteStatus")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordMediumWriteStatus")).Accumulator = value;
            }
        }
        public double ModerationDuration_RecordMediumWriteStatus
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordMediumWriteStatus")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RecordMediumWriteStatus")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_RelativeTimePosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeTimePosition")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeTimePosition")).Accumulator = value;
            }
        }
        public double ModerationDuration_RelativeTimePosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeTimePosition")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeTimePosition")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentTrackMetaData
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackMetaData")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackMetaData")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentTrackMetaData
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackMetaData")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentTrackMetaData")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentMediaDuration
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentMediaDuration")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentMediaDuration")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentMediaDuration
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentMediaDuration")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentMediaDuration")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_TransportPlaySpeed
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportPlaySpeed")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportPlaySpeed")).Accumulator = value;
            }
        }
        public double ModerationDuration_TransportPlaySpeed
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportPlaySpeed")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("TransportPlaySpeed")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_RelativeCounterPosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeCounterPosition")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeCounterPosition")).Accumulator = value;
            }
        }
        public double ModerationDuration_RelativeCounterPosition
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeCounterPosition")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("RelativeCounterPosition")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_NumberOfTracks
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NumberOfTracks")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NumberOfTracks")).Accumulator = value;
            }
        }
        public double ModerationDuration_NumberOfTracks
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NumberOfTracks")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("NumberOfTracks")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_PossibleRecordQualityModes
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordQualityModes")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordQualityModes")).Accumulator = value;
            }
        }
        public double ModerationDuration_PossibleRecordQualityModes
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordQualityModes")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordQualityModes")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_PossibleRecordStorageMedia
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordStorageMedia")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordStorageMedia")).Accumulator = value;
            }
        }
        public double ModerationDuration_PossibleRecordStorageMedia
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordStorageMedia")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("PossibleRecordStorageMedia")).ModerationPeriod = value;
            }
        }
        public delegate void Delegate_GetCurrentTransportActions(System.UInt32 InstanceID, out System.String Actions);
        public delegate void Delegate_GetDeviceCapabilities(System.UInt32 InstanceID, out System.String PlayMedia, out System.String RecMedia, out System.String RecQualityModes);
        public delegate void Delegate_GetMediaInfo(System.UInt32 InstanceID, out System.UInt32 NrTracks, out System.String MediaDuration, out System.String CurrentURI, out System.String CurrentURIMetaData, out System.String NextURI, out System.String NextURIMetaData, out DMSAVTransport.Enum_PlaybackStorageMedium PlayMedium, out DMSAVTransport.Enum_RecordStorageMedium RecordMedium, out DMSAVTransport.Enum_RecordMediumWriteStatus WriteStatus);
        public delegate void Delegate_GetPositionInfo(System.UInt32 InstanceID, out System.UInt32 Track, out System.String TrackDuration, out System.String TrackMetaData, out System.String TrackURI, out System.String RelTime, out System.String AbsTime, out System.Int32 RelCount, out System.Int32 AbsCount);
        public delegate void Delegate_GetTransportInfo(System.UInt32 InstanceID, out DMSAVTransport.Enum_TransportState CurrentTransportState, out DMSAVTransport.Enum_TransportStatus CurrentTransportStatus, out DMSAVTransport.Enum_TransportPlaySpeed CurrentSpeed);
        public delegate void Delegate_GetTransportSettings(System.UInt32 InstanceID, out DMSAVTransport.Enum_CurrentPlayMode PlayMode, out DMSAVTransport.Enum_CurrentRecordQualityMode RecQualityMode);
        public delegate void Delegate_Next(System.UInt32 InstanceID);
        public delegate void Delegate_Pause(System.UInt32 InstanceID);
        public delegate void Delegate_Play(System.UInt32 InstanceID, DMSAVTransport.Enum_TransportPlaySpeed Speed);
        public delegate void Delegate_Previous(System.UInt32 InstanceID);
        public delegate void Delegate_Record(System.UInt32 InstanceID);
        public delegate void Delegate_Seek(System.UInt32 InstanceID, DMSAVTransport.Enum_A_ARG_TYPE_SeekMode Unit, System.String Target);
        public delegate void Delegate_SetAVTransportURI(System.UInt32 InstanceID, System.String CurrentURI, System.String CurrentURIMetaData);
        public delegate void Delegate_SetNextAVTransportURI(System.UInt32 InstanceID, System.String NextURI, System.String NextURIMetaData);
        public delegate void Delegate_SetPlayMode(System.UInt32 InstanceID, DMSAVTransport.Enum_CurrentPlayMode NewPlayMode);
        public delegate void Delegate_SetRecordQualityMode(System.UInt32 InstanceID, DMSAVTransport.Enum_CurrentRecordQualityMode NewRecordQualityMode);
        public delegate void Delegate_Stop(System.UInt32 InstanceID);

        public Delegate_GetCurrentTransportActions External_GetCurrentTransportActions = null;
        public Delegate_GetDeviceCapabilities External_GetDeviceCapabilities = null;
        public Delegate_GetMediaInfo External_GetMediaInfo = null;
        public Delegate_GetPositionInfo External_GetPositionInfo = null;
        public Delegate_GetTransportInfo External_GetTransportInfo = null;
        public Delegate_GetTransportSettings External_GetTransportSettings = null;
        public Delegate_Next External_Next = null;
        public Delegate_Pause External_Pause = null;
        public Delegate_Play External_Play = null;
        public Delegate_Previous External_Previous = null;
        public Delegate_Record External_Record = null;
        public Delegate_Seek External_Seek = null;
        public Delegate_SetAVTransportURI External_SetAVTransportURI = null;
        public Delegate_SetNextAVTransportURI External_SetNextAVTransportURI = null;
        public Delegate_SetPlayMode External_SetPlayMode = null;
        public Delegate_SetRecordQualityMode External_SetRecordQualityMode = null;
        public Delegate_Stop External_Stop = null;

        public void RemoveStateVariable_A_ARG_TYPE_SeekMode()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekMode"));
        }
        public void RemoveStateVariable_NextAVTransportURI()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("NextAVTransportURI"));
        }
        public void RemoveStateVariable_PossiblePlaybackStorageMedia()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("PossiblePlaybackStorageMedia"));
        }
        public void RemoveStateVariable_RecordStorageMedium()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("RecordStorageMedium"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_InstanceID()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_InstanceID"));
        }
        public void RemoveStateVariable_CurrentTrack()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentTrack"));
        }
        public void RemoveStateVariable_CurrentTrackDuration()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentTrackDuration"));
        }
        public void RemoveStateVariable_CurrentPlayMode()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentPlayMode"));
        }
        public void RemoveStateVariable_TransportStatus()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("TransportStatus"));
        }
        public void RemoveStateVariable_CurrentRecordQualityMode()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentRecordQualityMode"));
        }
        public void RemoveStateVariable_TransportState()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("TransportState"));
        }
        public void RemoveStateVariable_CurrentTrackURI()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentTrackURI"));
        }
        public void RemoveStateVariable_PlaybackStorageMedium()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("PlaybackStorageMedium"));
        }
        public void RemoveStateVariable_AVTransportURI()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("AVTransportURI"));
        }
        public void RemoveStateVariable_AbsoluteCounterPosition()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("AbsoluteCounterPosition"));
        }
        public void RemoveStateVariable_AVTransportURIMetaData()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("AVTransportURIMetaData"));
        }
        public void RemoveStateVariable_LastChange()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("LastChange"));
        }
        public void RemoveStateVariable_NextAVTransportURIMetaData()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("NextAVTransportURIMetaData"));
        }
        public void RemoveStateVariable_CurrentTransportActions()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentTransportActions"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_SeekTarget()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekTarget"));
        }
        public void RemoveStateVariable_AbsoluteTimePosition()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("AbsoluteTimePosition"));
        }
        public void RemoveStateVariable_RecordMediumWriteStatus()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("RecordMediumWriteStatus"));
        }
        public void RemoveStateVariable_RelativeTimePosition()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("RelativeTimePosition"));
        }
        public void RemoveStateVariable_CurrentTrackMetaData()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentTrackMetaData"));
        }
        public void RemoveStateVariable_CurrentMediaDuration()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentMediaDuration"));
        }
        public void RemoveStateVariable_TransportPlaySpeed()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("TransportPlaySpeed"));
        }
        public void RemoveStateVariable_RelativeCounterPosition()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("RelativeCounterPosition"));
        }
        public void RemoveStateVariable_NumberOfTracks()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("NumberOfTracks"));
        }
        public void RemoveStateVariable_PossibleRecordQualityModes()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("PossibleRecordQualityModes"));
        }
        public void RemoveStateVariable_PossibleRecordStorageMedia()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("PossibleRecordStorageMedia"));
        }
        public void RemoveAction_GetCurrentTransportActions()
        {
             _S.GetUPnPService().RemoveMethod("GetCurrentTransportActions");
        }
        public void RemoveAction_GetDeviceCapabilities()
        {
             _S.GetUPnPService().RemoveMethod("GetDeviceCapabilities");
        }
        public void RemoveAction_GetMediaInfo()
        {
             _S.GetUPnPService().RemoveMethod("GetMediaInfo");
        }
        public void RemoveAction_GetPositionInfo()
        {
             _S.GetUPnPService().RemoveMethod("GetPositionInfo");
        }
        public void RemoveAction_GetTransportInfo()
        {
             _S.GetUPnPService().RemoveMethod("GetTransportInfo");
        }
        public void RemoveAction_GetTransportSettings()
        {
             _S.GetUPnPService().RemoveMethod("GetTransportSettings");
        }
        public void RemoveAction_Next()
        {
             _S.GetUPnPService().RemoveMethod("Next");
        }
        public void RemoveAction_Pause()
        {
             _S.GetUPnPService().RemoveMethod("Pause");
        }
        public void RemoveAction_Play()
        {
             _S.GetUPnPService().RemoveMethod("Play");
        }
        public void RemoveAction_Previous()
        {
             _S.GetUPnPService().RemoveMethod("Previous");
        }
        public void RemoveAction_Record()
        {
             _S.GetUPnPService().RemoveMethod("Record");
        }
        public void RemoveAction_Seek()
        {
             _S.GetUPnPService().RemoveMethod("Seek");
        }
        public void RemoveAction_SetAVTransportURI()
        {
             _S.GetUPnPService().RemoveMethod("SetAVTransportURI");
        }
        public void RemoveAction_SetNextAVTransportURI()
        {
             _S.GetUPnPService().RemoveMethod("SetNextAVTransportURI");
        }
        public void RemoveAction_SetPlayMode()
        {
             _S.GetUPnPService().RemoveMethod("SetPlayMode");
        }
        public void RemoveAction_SetRecordQualityMode()
        {
             _S.GetUPnPService().RemoveMethod("SetRecordQualityMode");
        }
        public void RemoveAction_Stop()
        {
             _S.GetUPnPService().RemoveMethod("Stop");
        }
        public System.Net.IPEndPoint GetCaller()
        {
             return(_S.GetUPnPService().GetCaller());
        }
        public System.Net.IPEndPoint GetReceiver()
        {
             return(_S.GetUPnPService().GetReceiver());
        }

        private class _DvAVTransport
        {
            private DMSAVTransport Outer = null;
            private UPnPService S;
            internal _DvAVTransport(DMSAVTransport n)
            {
                Outer = n;
                S = BuildUPnPService();
            }
            public UPnPService GetUPnPService()
            {
                return(S);
            }
            public void SetStateVariable(string VarName, object VarValue)
            {
               S.SetStateVariable(VarName,VarValue);
            }
            public object GetStateVariable(string VarName)
            {
               return(S.GetStateVariable(VarName));
            }
            protected UPnPService BuildUPnPService()
            {
                UPnPStateVariable[] RetVal = new UPnPStateVariable[30];
                RetVal[0] = new UPnPModeratedStateVariable("A_ARG_TYPE_SeekMode", typeof(System.String), false);
                RetVal[0].AllowedStringValues = new string[8]{"ABS_TIME", "REL_TIME", "ABS_COUNT", "REL_COUNT", "TRACK_NR", "CHANNEL_FREQ", "TAPE-INDEX", "FRAME"};
                RetVal[0].AddAssociation("Seek", "Unit");
                RetVal[1] = new UPnPModeratedStateVariable("NextAVTransportURI", typeof(System.String), false);
                RetVal[1].AddAssociation("GetMediaInfo", "NextURI");
                RetVal[1].AddAssociation("SetNextAVTransportURI", "NextURI");
                RetVal[2] = new UPnPModeratedStateVariable("PossiblePlaybackStorageMedia", typeof(System.String), false);
                RetVal[2].AddAssociation("GetDeviceCapabilities", "PlayMedia");
                RetVal[3] = new UPnPModeratedStateVariable("RecordStorageMedium", typeof(System.String), false);
                RetVal[3].AllowedStringValues = new string[33]{"UNKNOWN", "DV", "MINI-DV", "VHS", "W-VHS", "S-VHS", "D-VHS", "VHSC", "VIDEO8", "HI8", "CD-ROM", "CD-DA", "CD-R", "CD-RW", "VIDEO-CD", "SACD", "MusicDir-AUDIO", "MusicDir-PICTURE", "DVD-ROM", "DVD-VIDEO", "DVD-R", "DVD+RW", "DVD-RW", "DVD-RAM", "DVD-AUDIO", "DAT", "LD", "HDD", "MICRO-MV", "NETWORK", "NONE", "NOT_IMPLEMENTED", " vendor-defined "};
                RetVal[3].AddAssociation("GetMediaInfo", "RecordMedium");
                RetVal[4] = new UPnPModeratedStateVariable("A_ARG_TYPE_InstanceID", typeof(System.UInt32), false);
                RetVal[4].AddAssociation("GetCurrentTransportActions", "InstanceID");
                RetVal[4].AddAssociation("GetDeviceCapabilities", "InstanceID");
                RetVal[4].AddAssociation("GetMediaInfo", "InstanceID");
                RetVal[4].AddAssociation("GetPositionInfo", "InstanceID");
                RetVal[4].AddAssociation("GetTransportInfo", "InstanceID");
                RetVal[4].AddAssociation("GetTransportSettings", "InstanceID");
                RetVal[4].AddAssociation("Next", "InstanceID");
                RetVal[4].AddAssociation("Pause", "InstanceID");
                RetVal[4].AddAssociation("Play", "InstanceID");
                RetVal[4].AddAssociation("Previous", "InstanceID");
                RetVal[4].AddAssociation("Record", "InstanceID");
                RetVal[4].AddAssociation("Seek", "InstanceID");
                RetVal[4].AddAssociation("SetAVTransportURI", "InstanceID");
                RetVal[4].AddAssociation("SetNextAVTransportURI", "InstanceID");
                RetVal[4].AddAssociation("SetPlayMode", "InstanceID");
                RetVal[4].AddAssociation("SetRecordQualityMode", "InstanceID");
                RetVal[4].AddAssociation("Stop", "InstanceID");
                RetVal[5] = new UPnPModeratedStateVariable("CurrentTrack", typeof(System.UInt32), false);
                RetVal[5].SetRange((System.UInt32)(0),(System.UInt32)(4294967295),(System.UInt32)1);
                RetVal[5].AddAssociation("GetPositionInfo", "Track");
                RetVal[6] = new UPnPModeratedStateVariable("CurrentTrackDuration", typeof(System.String), false);
                RetVal[6].AddAssociation("GetPositionInfo", "TrackDuration");
                RetVal[7] = new UPnPModeratedStateVariable("CurrentPlayMode", typeof(System.String), false);
                RetVal[7].DefaultValue = UPnPService.CreateObjectInstance(typeof(System.String),"NORMAL");
                RetVal[7].AllowedStringValues = new string[7]{"NORMAL", "SHUFFLE", "REPEAT_ONE", "REPEAT_ALL", "RANDOM", "DIRECT_1", "INTRO"};
                RetVal[7].AddAssociation("GetTransportSettings", "PlayMode");
                RetVal[7].AddAssociation("SetPlayMode", "NewPlayMode");
                RetVal[8] = new UPnPModeratedStateVariable("TransportStatus", typeof(System.String), false);
                RetVal[8].AllowedStringValues = new string[3]{"OK", "ERROR_OCCURRED", " vendor-defined "};
                RetVal[8].AddAssociation("GetTransportInfo", "CurrentTransportStatus");
                RetVal[9] = new UPnPModeratedStateVariable("CurrentRecordQualityMode", typeof(System.String), false);
                RetVal[9].AllowedStringValues = new string[8]{"0:EP", "1:LP", "2:SP", "0:BASIC", "1:MEDIUM", "2:HIGH", "NOT_IMPLEMENTED", " vendor-defined "};
                RetVal[9].AddAssociation("GetTransportSettings", "RecQualityMode");
                RetVal[9].AddAssociation("SetRecordQualityMode", "NewRecordQualityMode");
                RetVal[10] = new UPnPModeratedStateVariable("TransportState", typeof(System.String), false);
                RetVal[10].AllowedStringValues = new string[7]{"STOPPED", "PAUSED_PLAYBACK", "PAUSED_RECORDING", "PLAYING", "RECORDING", "TRANSITIONING", "NO_MEDIA_PRESENT"};
                RetVal[10].AddAssociation("GetTransportInfo", "CurrentTransportState");
                RetVal[11] = new UPnPModeratedStateVariable("CurrentTrackURI", typeof(System.String), false);
                RetVal[11].AddAssociation("GetPositionInfo", "TrackURI");
                RetVal[12] = new UPnPModeratedStateVariable("PlaybackStorageMedium", typeof(System.String), false);
                RetVal[12].AllowedStringValues = new string[33]{"UNKNOWN", "DV", "MINI-DV", "VHS", "W-VHS", "S-VHS", "D-VHS", "VHSC", "VIDEO8", "HI8", "CD-ROM", "CD-DA", "CD-R", "CD-RW", "VIDEO-CD", "SACD", "MusicDir-AUDIO", "MusicDir-PICTURE", "DVD-ROM", "DVD-VIDEO", "DVD-R", "DVD+RW", "DVD-RW", "DVD-RAM", "DVD-AUDIO", "DAT", "LD", "HDD", "MICRO-MV", "NETWORK", "NONE", "NOT_IMPLEMENTED", " vendor-defined "};
                RetVal[12].AddAssociation("GetMediaInfo", "PlayMedium");
                RetVal[13] = new UPnPModeratedStateVariable("AVTransportURI", typeof(System.String), false);
                RetVal[13].AddAssociation("GetMediaInfo", "CurrentURI");
                RetVal[13].AddAssociation("SetAVTransportURI", "CurrentURI");
                RetVal[14] = new UPnPModeratedStateVariable("AbsoluteCounterPosition", typeof(System.Int32), false);
                RetVal[14].AddAssociation("GetPositionInfo", "AbsCount");
                RetVal[15] = new UPnPModeratedStateVariable("AVTransportURIMetaData", typeof(System.String), false);
                RetVal[15].AddAssociation("GetMediaInfo", "CurrentURIMetaData");
                RetVal[15].AddAssociation("SetAVTransportURI", "CurrentURIMetaData");
                RetVal[16] = new UPnPModeratedStateVariable("LastChange", typeof(System.String), true);
                RetVal[17] = new UPnPModeratedStateVariable("NextAVTransportURIMetaData", typeof(System.String), false);
                RetVal[17].AddAssociation("GetMediaInfo", "NextURIMetaData");
                RetVal[17].AddAssociation("SetNextAVTransportURI", "NextURIMetaData");
                RetVal[18] = new UPnPModeratedStateVariable("CurrentTransportActions", typeof(System.String), false);
                RetVal[18].AddAssociation("GetCurrentTransportActions", "Actions");
                RetVal[19] = new UPnPModeratedStateVariable("A_ARG_TYPE_SeekTarget", typeof(System.String), false);
                RetVal[19].AddAssociation("Seek", "Target");
                RetVal[20] = new UPnPModeratedStateVariable("AbsoluteTimePosition", typeof(System.String), false);
                RetVal[20].AddAssociation("GetPositionInfo", "AbsTime");
                RetVal[21] = new UPnPModeratedStateVariable("RecordMediumWriteStatus", typeof(System.String), false);
                RetVal[21].AllowedStringValues = new string[5]{"WRITABLE", "PROTECTED", "NOT_WRITABLE", "UNKNOWN", "NOT_IMPLEMENTED"};
                RetVal[21].AddAssociation("GetMediaInfo", "WriteStatus");
                RetVal[22] = new UPnPModeratedStateVariable("RelativeTimePosition", typeof(System.String), false);
                RetVal[22].AddAssociation("GetPositionInfo", "RelTime");
                RetVal[23] = new UPnPModeratedStateVariable("CurrentTrackMetaData", typeof(System.String), false);
                RetVal[23].AddAssociation("GetPositionInfo", "TrackMetaData");
                RetVal[24] = new UPnPModeratedStateVariable("CurrentMediaDuration", typeof(System.String), false);
                RetVal[24].AddAssociation("GetMediaInfo", "MediaDuration");
                RetVal[25] = new UPnPModeratedStateVariable("TransportPlaySpeed", typeof(System.String), false);
                RetVal[25].AllowedStringValues = new string[2]{"1", " vendor-defined "};
                RetVal[25].AddAssociation("GetTransportInfo", "CurrentSpeed");
                RetVal[25].AddAssociation("Play", "Speed");
                RetVal[26] = new UPnPModeratedStateVariable("RelativeCounterPosition", typeof(System.Int32), false);
                RetVal[26].AddAssociation("GetPositionInfo", "RelCount");
                RetVal[27] = new UPnPModeratedStateVariable("NumberOfTracks", typeof(System.UInt32), false);
                RetVal[27].SetRange((System.UInt32)(0),(System.UInt32)(4294967295),null);
                RetVal[27].AddAssociation("GetMediaInfo", "NrTracks");
                RetVal[28] = new UPnPModeratedStateVariable("PossibleRecordQualityModes", typeof(System.String), false);
                RetVal[28].AddAssociation("GetDeviceCapabilities", "RecQualityModes");
                RetVal[29] = new UPnPModeratedStateVariable("PossibleRecordStorageMedia", typeof(System.String), false);
                RetVal[29].AddAssociation("GetDeviceCapabilities", "RecMedia");

                UPnPService S = new UPnPService(1, "urn:upnp-org:serviceId:AVTransport", URN, true, this);
                for(int i=0;i<RetVal.Length;++i)
                {
                   S.AddStateVariable(RetVal[i]);
                }
                S.AddMethod("GetCurrentTransportActions");
                S.AddMethod("GetDeviceCapabilities");
                S.AddMethod("GetMediaInfo");
                S.AddMethod("GetPositionInfo");
                S.AddMethod("GetTransportInfo");
                S.AddMethod("GetTransportSettings");
                S.AddMethod("Next");
                S.AddMethod("Pause");
                S.AddMethod("Play");
                S.AddMethod("Previous");
                S.AddMethod("Record");
                S.AddMethod("Seek");
                S.AddMethod("SetAVTransportURI");
                S.AddMethod("SetNextAVTransportURI");
                S.AddMethod("SetPlayMode");
                S.AddMethod("SetRecordQualityMode");
                S.AddMethod("Stop");
                return(S);
            }

            public void GetCurrentTransportActions(System.UInt32 InstanceID, out System.String Actions)
            {
                if (Outer.External_GetCurrentTransportActions != null)
                {
                    Outer.External_GetCurrentTransportActions(InstanceID, out Actions);
                }
                else
                {
                    Sink_GetCurrentTransportActions(InstanceID, out Actions);
                }
            }
            public void GetDeviceCapabilities(System.UInt32 InstanceID, out System.String PlayMedia, out System.String RecMedia, out System.String RecQualityModes)
            {
                if (Outer.External_GetDeviceCapabilities != null)
                {
                    Outer.External_GetDeviceCapabilities(InstanceID, out PlayMedia, out RecMedia, out RecQualityModes);
                }
                else
                {
                    Sink_GetDeviceCapabilities(InstanceID, out PlayMedia, out RecMedia, out RecQualityModes);
                }
            }
            public void GetMediaInfo(System.UInt32 InstanceID, out System.UInt32 NrTracks, out System.String MediaDuration, out System.String CurrentURI, out System.String CurrentURIMetaData, out System.String NextURI, out System.String NextURIMetaData, out System.String PlayMedium, out System.String RecordMedium, out System.String WriteStatus)
            {
                Enum_PlaybackStorageMedium e_PlayMedium;
                Enum_RecordStorageMedium e_RecordMedium;
                Enum_RecordMediumWriteStatus e_WriteStatus;
                if (Outer.External_GetMediaInfo != null)
                {
                    Outer.External_GetMediaInfo(InstanceID, out NrTracks, out MediaDuration, out CurrentURI, out CurrentURIMetaData, out NextURI, out NextURIMetaData, out e_PlayMedium, out e_RecordMedium, out e_WriteStatus);
                }
                else
                {
                    Sink_GetMediaInfo(InstanceID, out NrTracks, out MediaDuration, out CurrentURI, out CurrentURIMetaData, out NextURI, out NextURIMetaData, out e_PlayMedium, out e_RecordMedium, out e_WriteStatus);
                }
                switch(e_PlayMedium)
                {
                    case Enum_PlaybackStorageMedium.UNKNOWN:
                        PlayMedium = "UNKNOWN";
                        break;
                    case Enum_PlaybackStorageMedium.DV:
                        PlayMedium = "DV";
                        break;
                    case Enum_PlaybackStorageMedium.MINI_DV:
                        PlayMedium = "MINI-DV";
                        break;
                    case Enum_PlaybackStorageMedium.VHS:
                        PlayMedium = "VHS";
                        break;
                    case Enum_PlaybackStorageMedium.W_VHS:
                        PlayMedium = "W-VHS";
                        break;
                    case Enum_PlaybackStorageMedium.S_VHS:
                        PlayMedium = "S-VHS";
                        break;
                    case Enum_PlaybackStorageMedium.D_VHS:
                        PlayMedium = "D-VHS";
                        break;
                    case Enum_PlaybackStorageMedium.VHSC:
                        PlayMedium = "VHSC";
                        break;
                    case Enum_PlaybackStorageMedium.VIDEO8:
                        PlayMedium = "VIDEO8";
                        break;
                    case Enum_PlaybackStorageMedium.HI8:
                        PlayMedium = "HI8";
                        break;
                    case Enum_PlaybackStorageMedium.CD_ROM:
                        PlayMedium = "CD-ROM";
                        break;
                    case Enum_PlaybackStorageMedium.CD_DA:
                        PlayMedium = "CD-DA";
                        break;
                    case Enum_PlaybackStorageMedium.CD_R:
                        PlayMedium = "CD-R";
                        break;
                    case Enum_PlaybackStorageMedium.CD_RW:
                        PlayMedium = "CD-RW";
                        break;
                    case Enum_PlaybackStorageMedium.VIDEO_CD:
                        PlayMedium = "VIDEO-CD";
                        break;
                    case Enum_PlaybackStorageMedium.SACD:
                        PlayMedium = "SACD";
                        break;
                    case Enum_PlaybackStorageMedium.MD_AUDIO:
                        PlayMedium = "MusicDir-AUDIO";
                        break;
                    case Enum_PlaybackStorageMedium.MD_PICTURE:
                        PlayMedium = "MusicDir-PICTURE";
                        break;
                    case Enum_PlaybackStorageMedium.DVD_ROM:
                        PlayMedium = "DVD-ROM";
                        break;
                    case Enum_PlaybackStorageMedium.DVD_VIDEO:
                        PlayMedium = "DVD-VIDEO";
                        break;
                    case Enum_PlaybackStorageMedium.DVD_R:
                        PlayMedium = "DVD-R";
                        break;
                    case Enum_PlaybackStorageMedium.DVD_RW:
                        PlayMedium = "DVD+RW";
                        break;
                    case Enum_PlaybackStorageMedium.DVD_minus_RW:
                        PlayMedium = "DVD-RW";
                        break;
                    case Enum_PlaybackStorageMedium.DVD_RAM:
                        PlayMedium = "DVD-RAM";
                        break;
                    case Enum_PlaybackStorageMedium.DVD_AUDIO:
                        PlayMedium = "DVD-AUDIO";
                        break;
                    case Enum_PlaybackStorageMedium.DAT:
                        PlayMedium = "DAT";
                        break;
                    case Enum_PlaybackStorageMedium.LD:
                        PlayMedium = "LD";
                        break;
                    case Enum_PlaybackStorageMedium.HDD:
                        PlayMedium = "HDD";
                        break;
                    case Enum_PlaybackStorageMedium.MICRO_MV:
                        PlayMedium = "MICRO-MV";
                        break;
                    case Enum_PlaybackStorageMedium.NETWORK:
                        PlayMedium = "NETWORK";
                        break;
                    case Enum_PlaybackStorageMedium.NONE:
                        PlayMedium = "NONE";
                        break;
                    case Enum_PlaybackStorageMedium.NOT_IMPLEMENTED:
                        PlayMedium = "NOT_IMPLEMENTED";
                        break;
                    case Enum_PlaybackStorageMedium._VENDOR_DEFINED_:
                        PlayMedium = " vendor-defined ";
                        break;
                    default:
                        PlayMedium = "";
                        break;
                }
                switch(e_RecordMedium)
                {
                    case Enum_RecordStorageMedium.UNKNOWN:
                        RecordMedium = "UNKNOWN";
                        break;
                    case Enum_RecordStorageMedium.DV:
                        RecordMedium = "DV";
                        break;
                    case Enum_RecordStorageMedium.MINI_DV:
                        RecordMedium = "MINI-DV";
                        break;
                    case Enum_RecordStorageMedium.VHS:
                        RecordMedium = "VHS";
                        break;
                    case Enum_RecordStorageMedium.W_VHS:
                        RecordMedium = "W-VHS";
                        break;
                    case Enum_RecordStorageMedium.S_VHS:
                        RecordMedium = "S-VHS";
                        break;
                    case Enum_RecordStorageMedium.D_VHS:
                        RecordMedium = "D-VHS";
                        break;
                    case Enum_RecordStorageMedium.VHSC:
                        RecordMedium = "VHSC";
                        break;
                    case Enum_RecordStorageMedium.VIDEO8:
                        RecordMedium = "VIDEO8";
                        break;
                    case Enum_RecordStorageMedium.HI8:
                        RecordMedium = "HI8";
                        break;
                    case Enum_RecordStorageMedium.CD_ROM:
                        RecordMedium = "CD-ROM";
                        break;
                    case Enum_RecordStorageMedium.CD_DA:
                        RecordMedium = "CD-DA";
                        break;
                    case Enum_RecordStorageMedium.CD_R:
                        RecordMedium = "CD-R";
                        break;
                    case Enum_RecordStorageMedium.CD_RW:
                        RecordMedium = "CD-RW";
                        break;
                    case Enum_RecordStorageMedium.VIDEO_CD:
                        RecordMedium = "VIDEO-CD";
                        break;
                    case Enum_RecordStorageMedium.SACD:
                        RecordMedium = "SACD";
                        break;
                    case Enum_RecordStorageMedium.MD_AUDIO:
                        RecordMedium = "MusicDir-AUDIO";
                        break;
                    case Enum_RecordStorageMedium.MD_PICTURE:
                        RecordMedium = "MusicDir-PICTURE";
                        break;
                    case Enum_RecordStorageMedium.DVD_ROM:
                        RecordMedium = "DVD-ROM";
                        break;
                    case Enum_RecordStorageMedium.DVD_VIDEO:
                        RecordMedium = "DVD-VIDEO";
                        break;
                    case Enum_RecordStorageMedium.DVD_R:
                        RecordMedium = "DVD-R";
                        break;
                    case Enum_RecordStorageMedium.DVD_RW:
                        RecordMedium = "DVD+RW";
                        break;
                    case Enum_RecordStorageMedium.DVD_minus_RW:
                        RecordMedium = "DVD-RW";
                        break;
                    case Enum_RecordStorageMedium.DVD_RAM:
                        RecordMedium = "DVD-RAM";
                        break;
                    case Enum_RecordStorageMedium.DVD_AUDIO:
                        RecordMedium = "DVD-AUDIO";
                        break;
                    case Enum_RecordStorageMedium.DAT:
                        RecordMedium = "DAT";
                        break;
                    case Enum_RecordStorageMedium.LD:
                        RecordMedium = "LD";
                        break;
                    case Enum_RecordStorageMedium.HDD:
                        RecordMedium = "HDD";
                        break;
                    case Enum_RecordStorageMedium.MICRO_MV:
                        RecordMedium = "MICRO-MV";
                        break;
                    case Enum_RecordStorageMedium.NETWORK:
                        RecordMedium = "NETWORK";
                        break;
                    case Enum_RecordStorageMedium.NONE:
                        RecordMedium = "NONE";
                        break;
                    case Enum_RecordStorageMedium.NOT_IMPLEMENTED:
                        RecordMedium = "NOT_IMPLEMENTED";
                        break;
                    case Enum_RecordStorageMedium._VENDOR_DEFINED_:
                        RecordMedium = " vendor-defined ";
                        break;
                    default:
                        RecordMedium = "";
                        break;
                }
                switch(e_WriteStatus)
                {
                    case Enum_RecordMediumWriteStatus.WRITABLE:
                        WriteStatus = "WRITABLE";
                        break;
                    case Enum_RecordMediumWriteStatus.PROTECTED:
                        WriteStatus = "PROTECTED";
                        break;
                    case Enum_RecordMediumWriteStatus.NOT_WRITABLE:
                        WriteStatus = "NOT_WRITABLE";
                        break;
                    case Enum_RecordMediumWriteStatus.UNKNOWN:
                        WriteStatus = "UNKNOWN";
                        break;
                    case Enum_RecordMediumWriteStatus.NOT_IMPLEMENTED:
                        WriteStatus = "NOT_IMPLEMENTED";
                        break;
                    default:
                        WriteStatus = "";
                        break;
                }
            }
            public void GetPositionInfo(System.UInt32 InstanceID, out System.UInt32 Track, out System.String TrackDuration, out System.String TrackMetaData, out System.String TrackURI, out System.String RelTime, out System.String AbsTime, out System.Int32 RelCount, out System.Int32 AbsCount)
            {
                if (Outer.External_GetPositionInfo != null)
                {
                    Outer.External_GetPositionInfo(InstanceID, out Track, out TrackDuration, out TrackMetaData, out TrackURI, out RelTime, out AbsTime, out RelCount, out AbsCount);
                }
                else
                {
                    Sink_GetPositionInfo(InstanceID, out Track, out TrackDuration, out TrackMetaData, out TrackURI, out RelTime, out AbsTime, out RelCount, out AbsCount);
                }
            }
            public void GetTransportInfo(System.UInt32 InstanceID, out System.String CurrentTransportState, out System.String CurrentTransportStatus, out System.String CurrentSpeed)
            {
                Enum_TransportState e_CurrentTransportState;
                Enum_TransportStatus e_CurrentTransportStatus;
                Enum_TransportPlaySpeed e_CurrentSpeed;
                if (Outer.External_GetTransportInfo != null)
                {
                    Outer.External_GetTransportInfo(InstanceID, out e_CurrentTransportState, out e_CurrentTransportStatus, out e_CurrentSpeed);
                }
                else
                {
                    Sink_GetTransportInfo(InstanceID, out e_CurrentTransportState, out e_CurrentTransportStatus, out e_CurrentSpeed);
                }
                switch(e_CurrentTransportState)
                {
                    case Enum_TransportState.STOPPED:
                        CurrentTransportState = "STOPPED";
                        break;
                    case Enum_TransportState.PAUSED_PLAYBACK:
                        CurrentTransportState = "PAUSED_PLAYBACK";
                        break;
                    case Enum_TransportState.PAUSED_RECORDING:
                        CurrentTransportState = "PAUSED_RECORDING";
                        break;
                    case Enum_TransportState.PLAYING:
                        CurrentTransportState = "PLAYING";
                        break;
                    case Enum_TransportState.RECORDING:
                        CurrentTransportState = "RECORDING";
                        break;
                    case Enum_TransportState.TRANSITIONING:
                        CurrentTransportState = "TRANSITIONING";
                        break;
                    case Enum_TransportState.NO_MEDIA_PRESENT:
                        CurrentTransportState = "NO_MEDIA_PRESENT";
                        break;
                    default:
                        CurrentTransportState = "";
                        break;
                }
                switch(e_CurrentTransportStatus)
                {
                    case Enum_TransportStatus.OK:
                        CurrentTransportStatus = "OK";
                        break;
                    case Enum_TransportStatus.ERROR_OCCURRED:
                        CurrentTransportStatus = "ERROR_OCCURRED";
                        break;
                    case Enum_TransportStatus._VENDOR_DEFINED_:
                        CurrentTransportStatus = " vendor-defined ";
                        break;
                    default:
                        CurrentTransportStatus = "";
                        break;
                }
                switch(e_CurrentSpeed)
                {
                    case Enum_TransportPlaySpeed._1:
                        CurrentSpeed = "1";
                        break;
                    case Enum_TransportPlaySpeed._VENDOR_DEFINED_:
                        CurrentSpeed = " vendor-defined ";
                        break;
                    default:
                        CurrentSpeed = "";
                        break;
                }
            }
            public void GetTransportSettings(System.UInt32 InstanceID, out System.String PlayMode, out System.String RecQualityMode)
            {
                Enum_CurrentPlayMode e_PlayMode;
                Enum_CurrentRecordQualityMode e_RecQualityMode;
                if (Outer.External_GetTransportSettings != null)
                {
                    Outer.External_GetTransportSettings(InstanceID, out e_PlayMode, out e_RecQualityMode);
                }
                else
                {
                    Sink_GetTransportSettings(InstanceID, out e_PlayMode, out e_RecQualityMode);
                }
                switch(e_PlayMode)
                {
                    case Enum_CurrentPlayMode.NORMAL:
                        PlayMode = "NORMAL";
                        break;
                    case Enum_CurrentPlayMode.SHUFFLE:
                        PlayMode = "SHUFFLE";
                        break;
                    case Enum_CurrentPlayMode.REPEAT_ONE:
                        PlayMode = "REPEAT_ONE";
                        break;
                    case Enum_CurrentPlayMode.REPEAT_ALL:
                        PlayMode = "REPEAT_ALL";
                        break;
                    case Enum_CurrentPlayMode.RANDOM:
                        PlayMode = "RANDOM";
                        break;
                    case Enum_CurrentPlayMode.DIRECT_1:
                        PlayMode = "DIRECT_1";
                        break;
                    case Enum_CurrentPlayMode.INTRO:
                        PlayMode = "INTRO";
                        break;
                    default:
                        PlayMode = "";
                        break;
                }
                switch(e_RecQualityMode)
                {
                    case Enum_CurrentRecordQualityMode._0_EP:
                        RecQualityMode = "0:EP";
                        break;
                    case Enum_CurrentRecordQualityMode._1_LP:
                        RecQualityMode = "1:LP";
                        break;
                    case Enum_CurrentRecordQualityMode._2_SP:
                        RecQualityMode = "2:SP";
                        break;
                    case Enum_CurrentRecordQualityMode._0_BASIC:
                        RecQualityMode = "0:BASIC";
                        break;
                    case Enum_CurrentRecordQualityMode._1_MEDIUM:
                        RecQualityMode = "1:MEDIUM";
                        break;
                    case Enum_CurrentRecordQualityMode._2_HIGH:
                        RecQualityMode = "2:HIGH";
                        break;
                    case Enum_CurrentRecordQualityMode.NOT_IMPLEMENTED:
                        RecQualityMode = "NOT_IMPLEMENTED";
                        break;
                    case Enum_CurrentRecordQualityMode._VENDOR_DEFINED_:
                        RecQualityMode = " vendor-defined ";
                        break;
                    default:
                        RecQualityMode = "";
                        break;
                }
            }
            public void Next(System.UInt32 InstanceID)
            {
                if (Outer.External_Next != null)
                {
                    Outer.External_Next(InstanceID);
                }
                else
                {
                    Sink_Next(InstanceID);
                }
            }
            public void Pause(System.UInt32 InstanceID)
            {
                if (Outer.External_Pause != null)
                {
                    Outer.External_Pause(InstanceID);
                }
                else
                {
                    Sink_Pause(InstanceID);
                }
            }
            public void Play(System.UInt32 InstanceID, System.String Speed)
            {
                Enum_TransportPlaySpeed e_Speed;
                switch(Speed)
                {
                    case "1":
                        e_Speed = Enum_TransportPlaySpeed._1;
                        break;
                    case " vendor-defined ":
                        e_Speed = Enum_TransportPlaySpeed._VENDOR_DEFINED_;
                        break;
                    default:
                        e_Speed = 0;
                        break;
                }
                if (Outer.External_Play != null)
                {
                    Outer.External_Play(InstanceID, e_Speed);
                }
                else
                {
                    Sink_Play(InstanceID, e_Speed);
                }
            }
            public void Previous(System.UInt32 InstanceID)
            {
                if (Outer.External_Previous != null)
                {
                    Outer.External_Previous(InstanceID);
                }
                else
                {
                    Sink_Previous(InstanceID);
                }
            }
            public void Record(System.UInt32 InstanceID)
            {
                if (Outer.External_Record != null)
                {
                    Outer.External_Record(InstanceID);
                }
                else
                {
                    Sink_Record(InstanceID);
                }
            }
            public void Seek(System.UInt32 InstanceID, System.String Unit, System.String Target)
            {
                Enum_A_ARG_TYPE_SeekMode e_Unit;
                switch(Unit)
                {
                    case "ABS_TIME":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.ABS_TIME;
                        break;
                    case "REL_TIME":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.REL_TIME;
                        break;
                    case "ABS_COUNT":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.ABS_COUNT;
                        break;
                    case "REL_COUNT":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.REL_COUNT;
                        break;
                    case "TRACK_NR":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.TRACK_NR;
                        break;
                    case "CHANNEL_FREQ":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.CHANNEL_FREQ;
                        break;
                    case "TAPE-INDEX":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.TAPE_INDEX;
                        break;
                    case "FRAME":
                        e_Unit = Enum_A_ARG_TYPE_SeekMode.FRAME;
                        break;
                    default:
                        e_Unit = 0;
                        break;
                }
                if (Outer.External_Seek != null)
                {
                    Outer.External_Seek(InstanceID, e_Unit, Target);
                }
                else
                {
                    Sink_Seek(InstanceID, e_Unit, Target);
                }
            }
            public void SetAVTransportURI(System.UInt32 InstanceID, System.String CurrentURI, System.String CurrentURIMetaData)
            {
                if (Outer.External_SetAVTransportURI != null)
                {
                    Outer.External_SetAVTransportURI(InstanceID, CurrentURI, CurrentURIMetaData);
                }
                else
                {
                    Sink_SetAVTransportURI(InstanceID, CurrentURI, CurrentURIMetaData);
                }
            }
            public void SetNextAVTransportURI(System.UInt32 InstanceID, System.String NextURI, System.String NextURIMetaData)
            {
                if (Outer.External_SetNextAVTransportURI != null)
                {
                    Outer.External_SetNextAVTransportURI(InstanceID, NextURI, NextURIMetaData);
                }
                else
                {
                    Sink_SetNextAVTransportURI(InstanceID, NextURI, NextURIMetaData);
                }
            }
            public void SetPlayMode(System.UInt32 InstanceID, System.String NewPlayMode)
            {
                Enum_CurrentPlayMode e_NewPlayMode;
                switch(NewPlayMode)
                {
                    case "NORMAL":
                        e_NewPlayMode = Enum_CurrentPlayMode.NORMAL;
                        break;
                    case "SHUFFLE":
                        e_NewPlayMode = Enum_CurrentPlayMode.SHUFFLE;
                        break;
                    case "REPEAT_ONE":
                        e_NewPlayMode = Enum_CurrentPlayMode.REPEAT_ONE;
                        break;
                    case "REPEAT_ALL":
                        e_NewPlayMode = Enum_CurrentPlayMode.REPEAT_ALL;
                        break;
                    case "RANDOM":
                        e_NewPlayMode = Enum_CurrentPlayMode.RANDOM;
                        break;
                    case "DIRECT_1":
                        e_NewPlayMode = Enum_CurrentPlayMode.DIRECT_1;
                        break;
                    case "INTRO":
                        e_NewPlayMode = Enum_CurrentPlayMode.INTRO;
                        break;
                    default:
                        e_NewPlayMode = 0;
                        break;
                }
                if (Outer.External_SetPlayMode != null)
                {
                    Outer.External_SetPlayMode(InstanceID, e_NewPlayMode);
                }
                else
                {
                    Sink_SetPlayMode(InstanceID, e_NewPlayMode);
                }
            }
            public void SetRecordQualityMode(System.UInt32 InstanceID, System.String NewRecordQualityMode)
            {
                Enum_CurrentRecordQualityMode e_NewRecordQualityMode;
                switch(NewRecordQualityMode)
                {
                    case "0:EP":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode._0_EP;
                        break;
                    case "1:LP":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode._1_LP;
                        break;
                    case "2:SP":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode._2_SP;
                        break;
                    case "0:BASIC":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode._0_BASIC;
                        break;
                    case "1:MEDIUM":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode._1_MEDIUM;
                        break;
                    case "2:HIGH":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode._2_HIGH;
                        break;
                    case "NOT_IMPLEMENTED":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode.NOT_IMPLEMENTED;
                        break;
                    case " vendor-defined ":
                        e_NewRecordQualityMode = Enum_CurrentRecordQualityMode._VENDOR_DEFINED_;
                        break;
                    default:
                        e_NewRecordQualityMode = 0;
                        break;
                }
                if (Outer.External_SetRecordQualityMode != null)
                {
                    Outer.External_SetRecordQualityMode(InstanceID, e_NewRecordQualityMode);
                }
                else
                {
                    Sink_SetRecordQualityMode(InstanceID, e_NewRecordQualityMode);
                }
            }
            public void Stop(System.UInt32 InstanceID)
            {
                if (Outer.External_Stop != null)
                {
                    Outer.External_Stop(InstanceID);
                }
                else
                {
                    Sink_Stop(InstanceID);
                }
            }

            public Delegate_GetCurrentTransportActions Sink_GetCurrentTransportActions;
            public Delegate_GetDeviceCapabilities Sink_GetDeviceCapabilities;
            public Delegate_GetMediaInfo Sink_GetMediaInfo;
            public Delegate_GetPositionInfo Sink_GetPositionInfo;
            public Delegate_GetTransportInfo Sink_GetTransportInfo;
            public Delegate_GetTransportSettings Sink_GetTransportSettings;
            public Delegate_Next Sink_Next;
            public Delegate_Pause Sink_Pause;
            public Delegate_Play Sink_Play;
            public Delegate_Previous Sink_Previous;
            public Delegate_Record Sink_Record;
            public Delegate_Seek Sink_Seek;
            public Delegate_SetAVTransportURI Sink_SetAVTransportURI;
            public Delegate_SetNextAVTransportURI Sink_SetNextAVTransportURI;
            public Delegate_SetPlayMode Sink_SetPlayMode;
            public Delegate_SetRecordQualityMode Sink_SetRecordQualityMode;
            public Delegate_Stop Sink_Stop;
        }
        public DMSAVTransport()
        {
            _S = new _DvAVTransport(this);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekMode").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_SeekMode);
            _S.GetUPnPService().GetStateVariableObject("NextAVTransportURI").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_NextAVTransportURI);
            _S.GetUPnPService().GetStateVariableObject("PossiblePlaybackStorageMedia").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_PossiblePlaybackStorageMedia);
            _S.GetUPnPService().GetStateVariableObject("RecordStorageMedium").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_RecordStorageMedium);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_InstanceID").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_InstanceID);
            _S.GetUPnPService().GetStateVariableObject("CurrentTrack").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentTrack);
            _S.GetUPnPService().GetStateVariableObject("CurrentTrackDuration").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentTrackDuration);
            _S.GetUPnPService().GetStateVariableObject("CurrentPlayMode").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentPlayMode);
            _S.GetUPnPService().GetStateVariableObject("TransportStatus").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_TransportStatus);
            _S.GetUPnPService().GetStateVariableObject("CurrentRecordQualityMode").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentRecordQualityMode);
            _S.GetUPnPService().GetStateVariableObject("TransportState").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_TransportState);
            _S.GetUPnPService().GetStateVariableObject("CurrentTrackURI").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentTrackURI);
            _S.GetUPnPService().GetStateVariableObject("PlaybackStorageMedium").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_PlaybackStorageMedium);
            _S.GetUPnPService().GetStateVariableObject("AVTransportURI").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_AVTransportURI);
            _S.GetUPnPService().GetStateVariableObject("AbsoluteCounterPosition").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_AbsoluteCounterPosition);
            _S.GetUPnPService().GetStateVariableObject("AVTransportURIMetaData").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_AVTransportURIMetaData);
            _S.GetUPnPService().GetStateVariableObject("LastChange").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_LastChange);
            _S.GetUPnPService().GetStateVariableObject("NextAVTransportURIMetaData").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_NextAVTransportURIMetaData);
            _S.GetUPnPService().GetStateVariableObject("CurrentTransportActions").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentTransportActions);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_SeekTarget").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_SeekTarget);
            _S.GetUPnPService().GetStateVariableObject("AbsoluteTimePosition").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_AbsoluteTimePosition);
            _S.GetUPnPService().GetStateVariableObject("RecordMediumWriteStatus").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_RecordMediumWriteStatus);
            _S.GetUPnPService().GetStateVariableObject("RelativeTimePosition").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_RelativeTimePosition);
            _S.GetUPnPService().GetStateVariableObject("CurrentTrackMetaData").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentTrackMetaData);
            _S.GetUPnPService().GetStateVariableObject("CurrentMediaDuration").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentMediaDuration);
            _S.GetUPnPService().GetStateVariableObject("TransportPlaySpeed").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_TransportPlaySpeed);
            _S.GetUPnPService().GetStateVariableObject("RelativeCounterPosition").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_RelativeCounterPosition);
            _S.GetUPnPService().GetStateVariableObject("NumberOfTracks").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_NumberOfTracks);
            _S.GetUPnPService().GetStateVariableObject("PossibleRecordQualityModes").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_PossibleRecordQualityModes);
            _S.GetUPnPService().GetStateVariableObject("PossibleRecordStorageMedia").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_PossibleRecordStorageMedia);
            _S.Sink_GetCurrentTransportActions = new Delegate_GetCurrentTransportActions(GetCurrentTransportActions);
            _S.Sink_GetDeviceCapabilities = new Delegate_GetDeviceCapabilities(GetDeviceCapabilities);
            _S.Sink_GetMediaInfo = new Delegate_GetMediaInfo(GetMediaInfo);
            _S.Sink_GetPositionInfo = new Delegate_GetPositionInfo(GetPositionInfo);
            _S.Sink_GetTransportInfo = new Delegate_GetTransportInfo(GetTransportInfo);
            _S.Sink_GetTransportSettings = new Delegate_GetTransportSettings(GetTransportSettings);
            _S.Sink_Next = new Delegate_Next(Next);
            _S.Sink_Pause = new Delegate_Pause(Pause);
            _S.Sink_Play = new Delegate_Play(Play);
            _S.Sink_Previous = new Delegate_Previous(Previous);
            _S.Sink_Record = new Delegate_Record(Record);
            _S.Sink_Seek = new Delegate_Seek(Seek);
            _S.Sink_SetAVTransportURI = new Delegate_SetAVTransportURI(SetAVTransportURI);
            _S.Sink_SetNextAVTransportURI = new Delegate_SetNextAVTransportURI(SetNextAVTransportURI);
            _S.Sink_SetPlayMode = new Delegate_SetPlayMode(SetPlayMode);
            _S.Sink_SetRecordQualityMode = new Delegate_SetRecordQualityMode(SetRecordQualityMode);
            _S.Sink_Stop = new Delegate_Stop(Stop);
        }
        public DMSAVTransport(string ID):this()
        {
            _S.GetUPnPService().ServiceID = ID;
        }
        public UPnPService GetUPnPService()
        {
            return(_S.GetUPnPService());
        }
        private void OnModifiedSink_A_ARG_TYPE_SeekMode(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_SeekMode != null) OnStateVariableModified_A_ARG_TYPE_SeekMode(this);
        }
        private void OnModifiedSink_NextAVTransportURI(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_NextAVTransportURI != null) OnStateVariableModified_NextAVTransportURI(this);
        }
        private void OnModifiedSink_PossiblePlaybackStorageMedia(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_PossiblePlaybackStorageMedia != null) OnStateVariableModified_PossiblePlaybackStorageMedia(this);
        }
        private void OnModifiedSink_RecordStorageMedium(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_RecordStorageMedium != null) OnStateVariableModified_RecordStorageMedium(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_InstanceID(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_InstanceID != null) OnStateVariableModified_A_ARG_TYPE_InstanceID(this);
        }
        private void OnModifiedSink_CurrentTrack(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentTrack != null) OnStateVariableModified_CurrentTrack(this);
        }
        private void OnModifiedSink_CurrentTrackDuration(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentTrackDuration != null) OnStateVariableModified_CurrentTrackDuration(this);
        }
        private void OnModifiedSink_CurrentPlayMode(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentPlayMode != null) OnStateVariableModified_CurrentPlayMode(this);
        }
        private void OnModifiedSink_TransportStatus(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_TransportStatus != null) OnStateVariableModified_TransportStatus(this);
        }
        private void OnModifiedSink_CurrentRecordQualityMode(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentRecordQualityMode != null) OnStateVariableModified_CurrentRecordQualityMode(this);
        }
        private void OnModifiedSink_TransportState(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_TransportState != null) OnStateVariableModified_TransportState(this);
        }
        private void OnModifiedSink_CurrentTrackURI(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentTrackURI != null) OnStateVariableModified_CurrentTrackURI(this);
        }
        private void OnModifiedSink_PlaybackStorageMedium(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_PlaybackStorageMedium != null) OnStateVariableModified_PlaybackStorageMedium(this);
        }
        private void OnModifiedSink_AVTransportURI(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_AVTransportURI != null) OnStateVariableModified_AVTransportURI(this);
        }
        private void OnModifiedSink_AbsoluteCounterPosition(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_AbsoluteCounterPosition != null) OnStateVariableModified_AbsoluteCounterPosition(this);
        }
        private void OnModifiedSink_AVTransportURIMetaData(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_AVTransportURIMetaData != null) OnStateVariableModified_AVTransportURIMetaData(this);
        }
        private void OnModifiedSink_LastChange(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_LastChange != null) OnStateVariableModified_LastChange(this);
        }
        private void OnModifiedSink_NextAVTransportURIMetaData(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_NextAVTransportURIMetaData != null) OnStateVariableModified_NextAVTransportURIMetaData(this);
        }
        private void OnModifiedSink_CurrentTransportActions(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentTransportActions != null) OnStateVariableModified_CurrentTransportActions(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_SeekTarget(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_SeekTarget != null) OnStateVariableModified_A_ARG_TYPE_SeekTarget(this);
        }
        private void OnModifiedSink_AbsoluteTimePosition(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_AbsoluteTimePosition != null) OnStateVariableModified_AbsoluteTimePosition(this);
        }
        private void OnModifiedSink_RecordMediumWriteStatus(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_RecordMediumWriteStatus != null) OnStateVariableModified_RecordMediumWriteStatus(this);
        }
        private void OnModifiedSink_RelativeTimePosition(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_RelativeTimePosition != null) OnStateVariableModified_RelativeTimePosition(this);
        }
        private void OnModifiedSink_CurrentTrackMetaData(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentTrackMetaData != null) OnStateVariableModified_CurrentTrackMetaData(this);
        }
        private void OnModifiedSink_CurrentMediaDuration(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentMediaDuration != null) OnStateVariableModified_CurrentMediaDuration(this);
        }
        private void OnModifiedSink_TransportPlaySpeed(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_TransportPlaySpeed != null) OnStateVariableModified_TransportPlaySpeed(this);
        }
        private void OnModifiedSink_RelativeCounterPosition(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_RelativeCounterPosition != null) OnStateVariableModified_RelativeCounterPosition(this);
        }
        private void OnModifiedSink_NumberOfTracks(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_NumberOfTracks != null) OnStateVariableModified_NumberOfTracks(this);
        }
        private void OnModifiedSink_PossibleRecordQualityModes(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_PossibleRecordQualityModes != null) OnStateVariableModified_PossibleRecordQualityModes(this);
        }
        private void OnModifiedSink_PossibleRecordStorageMedia(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_PossibleRecordStorageMedia != null) OnStateVariableModified_PossibleRecordStorageMedia(this);
        }
        //}}}}} End of Code Block

        #endregion

        /// <summary>
        /// Action: GetCurrentTransportActions
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="Actions">Associated State Variable: CurrentTransportActions</param>
        public void GetCurrentTransportActions(System.UInt32 InstanceID, out System.String Actions)
        {        
            Actions = "";
            Console.WriteLine("AVTransport_GetCurrentTransportActions(" + InstanceID.ToString() + ")");
        }
        /// <summary>
        /// Action: GetDeviceCapabilities
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="PlayMedia">Associated State Variable: PossiblePlaybackStorageMedia</param>
        /// <param name="RecMedia">Associated State Variable: PossibleRecordStorageMedia</param>
        /// <param name="RecQualityModes">Associated State Variable: PossibleRecordQualityModes</param>
        public void GetDeviceCapabilities(System.UInt32 InstanceID, out System.String PlayMedia, out System.String RecMedia, out System.String RecQualityModes)
        {
            PlayMedia = "UNKOWN";
            RecMedia = "UNKOWN";
            RecQualityModes = "UNKOWN";      
        }
        /// <summary>
        /// Action: GetMediaInfo
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="NrTracks">Associated State Variable: NumberOfTracks</param>
        /// <param name="MediaDuration">Associated State Variable: CurrentMediaDuration</param>
        /// <param name="CurrentURI">Associated State Variable: AVTransportURI</param>
        /// <param name="CurrentURIMetaData">Associated State Variable: AVTransportURIMetaData</param>
        /// <param name="NextURI">Associated State Variable: NextAVTransportURI</param>
        /// <param name="NextURIMetaData">Associated State Variable: NextAVTransportURIMetaData</param>
        /// <param name="PlayMedium">Associated State Variable: PlaybackStorageMedium</param>
        /// <param name="RecordMedium">Associated State Variable: RecordStorageMedium</param>
        /// <param name="WriteStatus">Associated State Variable: RecordMediumWriteStatus</param>
        public void GetMediaInfo(System.UInt32 InstanceID, out System.UInt32 NrTracks, out System.String MediaDuration, out System.String CurrentURI, out System.String CurrentURIMetaData, out System.String NextURI, out System.String NextURIMetaData, out Enum_PlaybackStorageMedium PlayMedium, out Enum_RecordStorageMedium RecordMedium, out Enum_RecordMediumWriteStatus WriteStatus)
        {
            NrTracks = 0;
            MediaDuration = "";
            CurrentURI = "";
            CurrentURIMetaData = "";
            NextURI = "";
            NextURIMetaData = "";
            PlayMedium = DMSAVTransport.Enum_PlaybackStorageMedium.UNKNOWN;
            RecordMedium = DMSAVTransport.Enum_RecordStorageMedium.UNKNOWN;
            WriteStatus = DMSAVTransport.Enum_RecordMediumWriteStatus.WRITABLE;
            Console.WriteLine("AVTransport_GetMediaInfo(" + InstanceID.ToString() + ")");
        }
        /// <summary>
        /// Action: GetPositionInfo
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="Track">Associated State Variable: CurrentTrack</param>
        /// <param name="TrackDuration">Associated State Variable: CurrentTrackDuration</param>
        /// <param name="TrackMetaData">Associated State Variable: CurrentTrackMetaData</param>
        /// <param name="TrackURI">Associated State Variable: CurrentTrackURI</param>
        /// <param name="RelTime">Associated State Variable: RelativeTimePosition</param>
        /// <param name="AbsTime">Associated State Variable: AbsoluteTimePosition</param>
        /// <param name="RelCount">Associated State Variable: RelativeCounterPosition</param>
        /// <param name="AbsCount">Associated State Variable: AbsoluteCounterPosition</param>
        public void GetPositionInfo(System.UInt32 InstanceID, out System.UInt32 Track, out System.String TrackDuration, out System.String TrackMetaData, out System.String TrackURI, out System.String RelTime, out System.String AbsTime, out System.Int32 RelCount, out System.Int32 AbsCount)
        {
            Track = 0;
            TrackDuration = "00:00:00";
            TrackMetaData = "";
            TrackURI = "";
            RelTime = "";
            AbsTime = "";
            RelCount = 0;
            AbsCount = 0;
            Console.WriteLine("AVTransport_GetPositionInfo(" + InstanceID.ToString() + ")");
        }
        /// <summary>
        /// Action: GetTransportInfo
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="CurrentTransportState">Associated State Variable: TransportState</param>
        /// <param name="CurrentTransportStatus">Associated State Variable: TransportStatus</param>
        /// <param name="CurrentSpeed">Associated State Variable: TransportPlaySpeed</param>
        public void GetTransportInfo(System.UInt32 InstanceID, out Enum_TransportState CurrentTransportState, out Enum_TransportStatus CurrentTransportStatus, out Enum_TransportPlaySpeed CurrentSpeed)
        {
            CurrentTransportState = DMSAVTransport.Enum_TransportState.PLAYING;
            CurrentTransportStatus = DMSAVTransport.Enum_TransportStatus.OK;
            CurrentSpeed = DMSAVTransport.Enum_TransportPlaySpeed._1;
        }
        /// <summary>
        /// Action: GetTransportSettings
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="PlayMode">Associated State Variable: CurrentPlayMode</param>
        /// <param name="RecQualityMode">Associated State Variable: CurrentRecordQualityMode</param>
        public void GetTransportSettings(System.UInt32 InstanceID, out Enum_CurrentPlayMode PlayMode, out Enum_CurrentRecordQualityMode RecQualityMode)
        {
            PlayMode = DMSAVTransport.Enum_CurrentPlayMode.NORMAL;
            RecQualityMode = DMSAVTransport.Enum_CurrentRecordQualityMode._0_EP;
        }
        /// <summary>
        /// Action: Next
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        public void Next(System.UInt32 InstanceID)
        {
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("AVTransport_Next(" + InstanceID.ToString() + ")");
        }
        /// <summary>
        /// Action: Pause
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        public void Pause(System.UInt32 InstanceID)
        {
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("AVTransport_Pause(" + InstanceID.ToString() + ")");
        }
        /// <summary>
        /// Action: Play
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="Speed">Associated State Variable: TransportPlaySpeed</param>
        public void Play(System.UInt32 InstanceID, Enum_TransportPlaySpeed Speed)
        {
            InstanceID = 0;
            Speed = DMSAVTransport.Enum_TransportPlaySpeed._1;
            if (this.TransportState == Enum_TransportState.STOPPED)
            {
                this.TransportState = Enum_TransportState.PLAYING;
            }
            else
            {
                Console.WriteLine("cant play when music is already playing");
            }
        }
        /// <summary>
        /// Action: Previous
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        public void Previous(System.UInt32 InstanceID)
        {
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("AVTransport_Previous(" + InstanceID.ToString() + ")");
        }
        /// <summary>
        /// Action: Record
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        public void Record(System.UInt32 InstanceID)
        {
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("AVTransport_Record(" + InstanceID.ToString() + ")");
        }
        /// <summary>
        /// Action: Seek
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="Unit">Associated State Variable: A_ARG_TYPE_SeekMode</param>
        /// <param name="Target">Associated State Variable: A_ARG_TYPE_SeekTarget</param>
        public void Seek(System.UInt32 InstanceID, Enum_A_ARG_TYPE_SeekMode Unit, System.String Target)
        {
            InstanceID = 0;
            Unit = Enum_A_ARG_TYPE_SeekMode.REL_TIME;
            Target = String.Empty;
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("AVTransport_Seek(" + InstanceID.ToString() + Unit.ToString() + Target.ToString() + ")");
        }
        /// <summary>
        /// Action: SetAVTransportURI
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="CurrentURI">Associated State Variable: AVTransportURI</param>
        /// <param name="CurrentURIMetaData">Associated State Variable: AVTransportURIMetaData</param>
        public void SetAVTransportURI(System.UInt32 InstanceID, System.String CurrentURI, System.String CurrentURIMetaData)
        {
            
            //InstanceID = 0;
            //this.AVTransportURI = CurrentURI;
            //this.AVTransportURIMetaData = CurrentURIMetaData;
            Uri uri;
            try
            {
                uri = new Uri(CurrentURI);
            }
            catch (Exception ex)
            {
                throw new UPnPCustomException(720,"CurrentURI can not be null or malformed : " + ex);
            }

            try
            {
                InstanceID = 0;
                this.AVTransportURIMetaData = CurrentURIMetaData;
            }
            catch (Exception ex)
            {
                throw new UPnPCustomException(720, "urimetadate cant be null : " + ex);
            }
        }
        /// <summary>
        /// Action: SetNextAVTransportURI
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="NextURI">Associated State Variable: NextAVTransportURI</param>
        /// <param name="NextURIMetaData">Associated State Variable: NextAVTransportURIMetaData</param>
        public void SetNextAVTransportURI(System.UInt32 InstanceID, System.String NextURI, System.String NextURIMetaData)
        {
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("AVTransport_SetNextAVTransportURI(" + InstanceID.ToString() + NextURI.ToString() + NextURIMetaData.ToString() + ")");
        }
        /// <summary>
        /// Action: SetPlayMode
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="NewPlayMode">Associated State Variable: CurrentPlayMode</param>
        public void SetPlayMode(System.UInt32 InstanceID, Enum_CurrentPlayMode NewPlayMode)
        {
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("test playmode");
        }
        /// <summary>
        /// Action: SetRecordQualityMode
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        /// <param name="NewRecordQualityMode">Associated State Variable: CurrentRecordQualityMode</param>
        public void SetRecordQualityMode(System.UInt32 InstanceID, Enum_CurrentRecordQualityMode NewRecordQualityMode)
        {
            //ToDo: Add Your implementation here, and remove exception
            Console.WriteLine("test recordqualitymode");
        }
        /// <summary>
        /// Action: Stop
        /// </summary>
        /// <param name="InstanceID">Associated State Variable: A_ARG_TYPE_InstanceID</param>
        public void Stop(System.UInt32 InstanceID)
        {
            if (this.TransportState == Enum_TransportState.PLAYING)
            {
                this.TransportState = Enum_TransportState.STOPPED;

            }
        }
    }
}