﻿using OpenSource.UPnP;
using System;
using System.Net;

namespace GigServer
{
    public class DMSConnectionManager : IUPnPService
    {
        // Place your declarations above this line

        #region AutoGenerated Code Section [Do NOT Modify, unless you know what you're doing]
        //{{{{{ Begin Code Block

        private _DMSConnectionManager _S;
        public static string URN = "urn:schemas-upnp-org:service:ConnectionManager:1";
        public double VERSION
        {
           get
           {
               return(double.Parse(_S.GetUPnPService().Version));
           }
        }

        public enum Enum_A_ARG_TYPE_Direction
        {
            INPUT,
            OUTPUT,
        }
        public Enum_A_ARG_TYPE_Direction A_ARG_TYPE_Direction
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_A_ARG_TYPE_Direction.INPUT:
                     v = "Input";
                     break;
                  case Enum_A_ARG_TYPE_Direction.OUTPUT:
                     v = "Output";
                     break;
               }
               _S.SetStateVariable("A_ARG_TYPE_Direction",v);
            }
            get
            {
               Enum_A_ARG_TYPE_Direction RetVal = 0;
               string v = (string)_S.GetStateVariable("A_ARG_TYPE_Direction");
               switch(v)
               {
                  case "Input":
                     RetVal = Enum_A_ARG_TYPE_Direction.INPUT;
                     break;
                  case "Output":
                     RetVal = Enum_A_ARG_TYPE_Direction.OUTPUT;
                     break;
               }
               return(RetVal);
           }
        }
        public enum Enum_A_ARG_TYPE_ConnectionStatus
        {
            OK,
            CONTENTFORMATMISMATCH,
            INSUFFICIENTBANDWIDTH,
            UNRELIABLECHANNEL,
            UNKNOWN,
        }
        public Enum_A_ARG_TYPE_ConnectionStatus A_ARG_TYPE_ConnectionStatus
        {
            set
            {
               string v = "";
               switch(value)
               {
                  case Enum_A_ARG_TYPE_ConnectionStatus.OK:
                     v = "OK";
                     break;
                  case Enum_A_ARG_TYPE_ConnectionStatus.CONTENTFORMATMISMATCH:
                     v = "ContentFormatMismatch";
                     break;
                  case Enum_A_ARG_TYPE_ConnectionStatus.INSUFFICIENTBANDWIDTH:
                     v = "InsufficientBandwidth";
                     break;
                  case Enum_A_ARG_TYPE_ConnectionStatus.UNRELIABLECHANNEL:
                     v = "UnreliableChannel";
                     break;
                  case Enum_A_ARG_TYPE_ConnectionStatus.UNKNOWN:
                     v = "Unknown";
                     break;
               }
               _S.SetStateVariable("A_ARG_TYPE_ConnectionStatus",v);
            }
            get
            {
               Enum_A_ARG_TYPE_ConnectionStatus RetVal = 0;
               string v = (string)_S.GetStateVariable("A_ARG_TYPE_ConnectionStatus");
               switch(v)
               {
                  case "OK":
                     RetVal = Enum_A_ARG_TYPE_ConnectionStatus.OK;
                     break;
                  case "ContentFormatMismatch":
                     RetVal = Enum_A_ARG_TYPE_ConnectionStatus.CONTENTFORMATMISMATCH;
                     break;
                  case "InsufficientBandwidth":
                     RetVal = Enum_A_ARG_TYPE_ConnectionStatus.INSUFFICIENTBANDWIDTH;
                     break;
                  case "UnreliableChannel":
                     RetVal = Enum_A_ARG_TYPE_ConnectionStatus.UNRELIABLECHANNEL;
                     break;
                  case "Unknown":
                     RetVal = Enum_A_ARG_TYPE_ConnectionStatus.UNKNOWN;
                     break;
               }
               return(RetVal);
           }
        }
        static public string Enum_A_ARG_TYPE_Direction_ToString(Enum_A_ARG_TYPE_Direction en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_A_ARG_TYPE_Direction.INPUT:
                    RetVal = "Input";
                    break;
                case Enum_A_ARG_TYPE_Direction.OUTPUT:
                    RetVal = "Output";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_A_ARG_TYPE_Direction
        {
            get
            {
                string[] RetVal = new string[2]{"Output","Input"};
                return(RetVal);
            }
        }
        static public string Enum_A_ARG_TYPE_ConnectionStatus_ToString(Enum_A_ARG_TYPE_ConnectionStatus en)
        {
            string RetVal = "";
            switch(en)
            {
                case Enum_A_ARG_TYPE_ConnectionStatus.OK:
                    RetVal = "OK";
                    break;
                case Enum_A_ARG_TYPE_ConnectionStatus.CONTENTFORMATMISMATCH:
                    RetVal = "ContentFormatMismatch";
                    break;
                case Enum_A_ARG_TYPE_ConnectionStatus.INSUFFICIENTBANDWIDTH:
                    RetVal = "InsufficientBandwidth";
                    break;
                case Enum_A_ARG_TYPE_ConnectionStatus.UNRELIABLECHANNEL:
                    RetVal = "UnreliableChannel";
                    break;
                case Enum_A_ARG_TYPE_ConnectionStatus.UNKNOWN:
                    RetVal = "Unknown";
                    break;
            }
            return(RetVal);
        }
        static public string[] Values_A_ARG_TYPE_ConnectionStatus
        {
            get
            {
                string[] RetVal = new string[5]{"Unknown","UnreliableChannel","InsufficientBandwidth","ContentFormatMismatch","OK"};
                return(RetVal);
            }
        }
        public delegate void OnStateVariableModifiedHandler(DMSConnectionManager sender);
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_ConnectionStatus;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_ConnectionID;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_AVTransportID;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_RcsID;
        public event OnStateVariableModifiedHandler OnStateVariableModified_SourceProtocolInfo;
        public event OnStateVariableModifiedHandler OnStateVariableModified_SinkProtocolInfo;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_ProtocolInfo;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_ConnectionManager;
        public event OnStateVariableModifiedHandler OnStateVariableModified_A_ARG_TYPE_Direction;
        public event OnStateVariableModifiedHandler OnStateVariableModified_CurrentConnectionIDs;
        public Int32 A_ARG_TYPE_ConnectionID
        {
            get
            {
               return((Int32)_S.GetStateVariable("A_ARG_TYPE_ConnectionID"));
            }
            set
            {
               _S.SetStateVariable("A_ARG_TYPE_ConnectionID", value);
            }
        }
        public Int32 A_ARG_TYPE_AVTransportID
        {
            get
            {
               return((Int32)_S.GetStateVariable("A_ARG_TYPE_AVTransportID"));
            }
            set
            {
               _S.SetStateVariable("A_ARG_TYPE_AVTransportID", value);
            }
        }
        public Int32 A_ARG_TYPE_RcsID
        {
            get
            {
               return((Int32)_S.GetStateVariable("A_ARG_TYPE_RcsID"));
            }
            set
            {
               _S.SetStateVariable("A_ARG_TYPE_RcsID", value);
            }
        }
        public String Evented_SourceProtocolInfo
        {
            get
            {
               return((String)_S.GetStateVariable("SourceProtocolInfo"));
            }
            set
            {
               _S.SetStateVariable("SourceProtocolInfo", value);
            }
        }
        public String Evented_SinkProtocolInfo
        {
            get
            {
               return((String)_S.GetStateVariable("SinkProtocolInfo"));
            }
            set
            {
               _S.SetStateVariable("SinkProtocolInfo", value);
            }
        }
        public String A_ARG_TYPE_ProtocolInfo
        {
            get
            {
               return((String)_S.GetStateVariable("A_ARG_TYPE_ProtocolInfo"));
            }
            set
            {
               _S.SetStateVariable("A_ARG_TYPE_ProtocolInfo", value);
            }
        }
        public String A_ARG_TYPE_ConnectionManager
        {
            get
            {
               return((String)_S.GetStateVariable("A_ARG_TYPE_ConnectionManager"));
            }
            set
            {
               _S.SetStateVariable("A_ARG_TYPE_ConnectionManager", value);
            }
        }
        public String Evented_CurrentConnectionIDs
        {
            get
            {
               return((String)_S.GetStateVariable("CurrentConnectionIDs"));
            }
            set
            {
               _S.SetStateVariable("CurrentConnectionIDs", value);
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_ConnectionStatus
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionStatus")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionStatus")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_ConnectionStatus
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionStatus")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionStatus")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_ConnectionID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionID")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionID")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_ConnectionID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionID")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionID")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_AVTransportID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_AVTransportID")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_AVTransportID")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_AVTransportID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_AVTransportID")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_AVTransportID")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_RcsID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_RcsID")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_RcsID")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_RcsID
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_RcsID")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_RcsID")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_SourceProtocolInfo
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SourceProtocolInfo")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SourceProtocolInfo")).Accumulator = value;
            }
        }
        public double ModerationDuration_SourceProtocolInfo
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SourceProtocolInfo")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SourceProtocolInfo")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_SinkProtocolInfo
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SinkProtocolInfo")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SinkProtocolInfo")).Accumulator = value;
            }
        }
        public double ModerationDuration_SinkProtocolInfo
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SinkProtocolInfo")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("SinkProtocolInfo")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_ProtocolInfo
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ProtocolInfo")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ProtocolInfo")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_ProtocolInfo
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ProtocolInfo")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ProtocolInfo")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_ConnectionManager
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionManager")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionManager")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_ConnectionManager
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionManager")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionManager")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_A_ARG_TYPE_Direction
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_Direction")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_Direction")).Accumulator = value;
            }
        }
        public double ModerationDuration_A_ARG_TYPE_Direction
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_Direction")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_Direction")).ModerationPeriod = value;
            }
        }
        public UPnPModeratedStateVariable.IAccumulator Accumulator_CurrentConnectionIDs
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentConnectionIDs")).Accumulator);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentConnectionIDs")).Accumulator = value;
            }
        }
        public double ModerationDuration_CurrentConnectionIDs
        {
            get
            {
                 return(((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentConnectionIDs")).ModerationPeriod);
            }
            set
            {
                 ((UPnPModeratedStateVariable)_S.GetUPnPService().GetStateVariableObject("CurrentConnectionIDs")).ModerationPeriod = value;
            }
        }
        public delegate void Delegate_GetCurrentConnectionIDs(out String ConnectionIDs);
        public delegate void Delegate_GetCurrentConnectionInfo(Int32 ConnectionID, out Int32 RcsID, out Int32 AVTransportID, out String ProtocolInfo, out String PeerConnectionManager, out Int32 PeerConnectionID, out DMSConnectionManager.Enum_A_ARG_TYPE_Direction Direction, out DMSConnectionManager.Enum_A_ARG_TYPE_ConnectionStatus Status);
        public delegate void Delegate_GetProtocolInfo(out String Source, out String Sink);

        public Delegate_GetCurrentConnectionIDs External_GetCurrentConnectionIDs = null;
        public Delegate_GetCurrentConnectionInfo External_GetCurrentConnectionInfo = null;
        public Delegate_GetProtocolInfo External_GetProtocolInfo = null;

        public void RemoveStateVariable_A_ARG_TYPE_ConnectionStatus()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionStatus"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_ConnectionID()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionID"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_AVTransportID()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_AVTransportID"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_RcsID()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_RcsID"));
        }
        public void RemoveStateVariable_SourceProtocolInfo()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("SourceProtocolInfo"));
        }
        public void RemoveStateVariable_SinkProtocolInfo()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("SinkProtocolInfo"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_ProtocolInfo()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ProtocolInfo"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_ConnectionManager()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionManager"));
        }
        public void RemoveStateVariable_A_ARG_TYPE_Direction()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_Direction"));
        }
        public void RemoveStateVariable_CurrentConnectionIDs()
        {
            _S.GetUPnPService().RemoveStateVariable(_S.GetUPnPService().GetStateVariableObject("CurrentConnectionIDs"));
        }
        public void RemoveAction_GetCurrentConnectionIDs()
        {
             _S.GetUPnPService().RemoveMethod("GetCurrentConnectionIDs");
        }
        public void RemoveAction_GetCurrentConnectionInfo()
        {
             _S.GetUPnPService().RemoveMethod("GetCurrentConnectionInfo");
        }
        public void RemoveAction_GetProtocolInfo()
        {
             _S.GetUPnPService().RemoveMethod("GetProtocolInfo");
        }
        public IPEndPoint GetCaller()
        {
             return(_S.GetUPnPService().GetCaller());
        }
        public IPEndPoint GetReceiver()
        {
             return(_S.GetUPnPService().GetReceiver());
        }

        private class _DMSConnectionManager
        {
            private DMSConnectionManager Outer = null;
            private UPnPService S;
            internal _DMSConnectionManager(DMSConnectionManager n)
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
                UPnPStateVariable[] RetVal = new UPnPStateVariable[10];
                RetVal[0] = new UPnPModeratedStateVariable("A_ARG_TYPE_ConnectionStatus", typeof(String), false);
                RetVal[0].AllowedStringValues = new string[5]{"OK", "ContentFormatMismatch", "InsufficientBandwidth", "UnreliableChannel", "Unknown"};
                RetVal[0].AddAssociation("GetCurrentConnectionInfo", "Status");
                RetVal[1] = new UPnPModeratedStateVariable("A_ARG_TYPE_ConnectionID", typeof(Int32), false);
                RetVal[1].AddAssociation("GetCurrentConnectionInfo", "ConnectionID");
                RetVal[1].AddAssociation("GetCurrentConnectionInfo", "PeerConnectionID");
                RetVal[2] = new UPnPModeratedStateVariable("A_ARG_TYPE_AVTransportID", typeof(Int32), false);
                RetVal[2].AddAssociation("GetCurrentConnectionInfo", "AVTransportID");
                RetVal[3] = new UPnPModeratedStateVariable("A_ARG_TYPE_RcsID", typeof(Int32), false);
                RetVal[3].AddAssociation("GetCurrentConnectionInfo", "RcsID");
                RetVal[4] = new UPnPModeratedStateVariable("SourceProtocolInfo", typeof(String), true);
                RetVal[4].AddAssociation("GetProtocolInfo", "Source");
                RetVal[5] = new UPnPModeratedStateVariable("SinkProtocolInfo", typeof(String), true);
                RetVal[5].AddAssociation("GetProtocolInfo", "Sink");
                RetVal[6] = new UPnPModeratedStateVariable("A_ARG_TYPE_ProtocolInfo", typeof(String), false);
                RetVal[6].AddAssociation("GetCurrentConnectionInfo", "ProtocolInfo");
                RetVal[7] = new UPnPModeratedStateVariable("A_ARG_TYPE_ConnectionManager", typeof(String), false);
                RetVal[7].AddAssociation("GetCurrentConnectionInfo", "PeerConnectionManager");
                RetVal[8] = new UPnPModeratedStateVariable("A_ARG_TYPE_Direction", typeof(String), false);
                RetVal[8].AllowedStringValues = new string[2]{"Input", "Output"};
                RetVal[8].AddAssociation("GetCurrentConnectionInfo", "Direction");
                RetVal[9] = new UPnPModeratedStateVariable("CurrentConnectionIDs", typeof(String), true);
                RetVal[9].AddAssociation("GetCurrentConnectionIDs", "ConnectionIDs");

                UPnPService S = new UPnPService(1, "urn:upnp-org:serviceId:ConnectionManager", URN, true, this);
                for(int i=0;i<RetVal.Length;++i)
                {
                   S.AddStateVariable(RetVal[i]);
                }
                S.AddMethod("GetCurrentConnectionIDs");
                S.AddMethod("GetCurrentConnectionInfo");
                S.AddMethod("GetProtocolInfo");
                return(S);
            }

            public void GetCurrentConnectionIDs(out String ConnectionIDs)
            {
                if (Outer.External_GetCurrentConnectionIDs != null)
                {
                    Outer.External_GetCurrentConnectionIDs(out ConnectionIDs);
                }
                else
                {
                    Sink_GetCurrentConnectionIDs(out ConnectionIDs);
                }
            }
            public void GetCurrentConnectionInfo(Int32 ConnectionID, out Int32 RcsID, out Int32 AVTransportID, out String ProtocolInfo, out String PeerConnectionManager, out Int32 PeerConnectionID, out String Direction, out String Status)
            {
                Enum_A_ARG_TYPE_Direction e_Direction;
                Enum_A_ARG_TYPE_ConnectionStatus e_Status;
                if (Outer.External_GetCurrentConnectionInfo != null)
                {
                    Outer.External_GetCurrentConnectionInfo(ConnectionID, out RcsID, out AVTransportID, out ProtocolInfo, out PeerConnectionManager, out PeerConnectionID, out e_Direction, out e_Status);
                }
                else
                {
                    Sink_GetCurrentConnectionInfo(ConnectionID, out RcsID, out AVTransportID, out ProtocolInfo, out PeerConnectionManager, out PeerConnectionID, out e_Direction, out e_Status);
                }
                switch(e_Direction)
                {
                    case Enum_A_ARG_TYPE_Direction.INPUT:
                        Direction = "Input";
                        break;
                    case Enum_A_ARG_TYPE_Direction.OUTPUT:
                        Direction = "Output";
                        break;
                    default:
                        Direction = "";
                        break;
                }
                switch(e_Status)
                {
                    case Enum_A_ARG_TYPE_ConnectionStatus.OK:
                        Status = "OK";
                        break;
                    case Enum_A_ARG_TYPE_ConnectionStatus.CONTENTFORMATMISMATCH:
                        Status = "ContentFormatMismatch";
                        break;
                    case Enum_A_ARG_TYPE_ConnectionStatus.INSUFFICIENTBANDWIDTH:
                        Status = "InsufficientBandwidth";
                        break;
                    case Enum_A_ARG_TYPE_ConnectionStatus.UNRELIABLECHANNEL:
                        Status = "UnreliableChannel";
                        break;
                    case Enum_A_ARG_TYPE_ConnectionStatus.UNKNOWN:
                        Status = "Unknown";
                        break;
                    default:
                        Status = "";
                        break;
                }
            }
            public void GetProtocolInfo(out String Source, out String Sink)
            {
                if (Outer.External_GetProtocolInfo != null)
                {
                    Outer.External_GetProtocolInfo(out Source, out Sink);
                }
                else
                {
                    Sink_GetProtocolInfo(out Source, out Sink);
                }
            }

            public Delegate_GetCurrentConnectionIDs Sink_GetCurrentConnectionIDs;
            public Delegate_GetCurrentConnectionInfo Sink_GetCurrentConnectionInfo;
            public Delegate_GetProtocolInfo Sink_GetProtocolInfo;
        }
        public DMSConnectionManager()
        {
            _S = new _DMSConnectionManager(this);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionStatus").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_ConnectionStatus);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionID").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_ConnectionID);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_AVTransportID").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_AVTransportID);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_RcsID").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_RcsID);
            _S.GetUPnPService().GetStateVariableObject("SourceProtocolInfo").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_SourceProtocolInfo);
            _S.GetUPnPService().GetStateVariableObject("SinkProtocolInfo").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_SinkProtocolInfo);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ProtocolInfo").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_ProtocolInfo);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_ConnectionManager").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_ConnectionManager);
            _S.GetUPnPService().GetStateVariableObject("A_ARG_TYPE_Direction").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_A_ARG_TYPE_Direction);
            _S.GetUPnPService().GetStateVariableObject("CurrentConnectionIDs").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_CurrentConnectionIDs);
            _S.Sink_GetCurrentConnectionIDs = new Delegate_GetCurrentConnectionIDs(GetCurrentConnectionIDs);
            _S.Sink_GetCurrentConnectionInfo = new Delegate_GetCurrentConnectionInfo(GetCurrentConnectionInfo);
            _S.Sink_GetProtocolInfo = new Delegate_GetProtocolInfo(GetProtocolInfo);
        }
        public DMSConnectionManager(string ID):this()
        {
            _S.GetUPnPService().ServiceID = ID;
        }
        public UPnPService GetUPnPService()
        {
            return(_S.GetUPnPService());
        }
        private void OnModifiedSink_A_ARG_TYPE_ConnectionStatus(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_ConnectionStatus != null) OnStateVariableModified_A_ARG_TYPE_ConnectionStatus(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_ConnectionID(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_ConnectionID != null) OnStateVariableModified_A_ARG_TYPE_ConnectionID(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_AVTransportID(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_AVTransportID != null) OnStateVariableModified_A_ARG_TYPE_AVTransportID(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_RcsID(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_RcsID != null) OnStateVariableModified_A_ARG_TYPE_RcsID(this);
        }
        private void OnModifiedSink_SourceProtocolInfo(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_SourceProtocolInfo != null) OnStateVariableModified_SourceProtocolInfo(this);
        }
        private void OnModifiedSink_SinkProtocolInfo(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_SinkProtocolInfo != null) OnStateVariableModified_SinkProtocolInfo(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_ProtocolInfo(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_ProtocolInfo != null) OnStateVariableModified_A_ARG_TYPE_ProtocolInfo(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_ConnectionManager(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_ConnectionManager != null) OnStateVariableModified_A_ARG_TYPE_ConnectionManager(this);
        }
        private void OnModifiedSink_A_ARG_TYPE_Direction(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_A_ARG_TYPE_Direction != null) OnStateVariableModified_A_ARG_TYPE_Direction(this);
        }
        private void OnModifiedSink_CurrentConnectionIDs(UPnPStateVariable sender, object NewValue)
        {
            if (OnStateVariableModified_CurrentConnectionIDs != null) OnStateVariableModified_CurrentConnectionIDs(this);
        }
        //}}}}} End of Code Block

        #endregion

        /// <summary>
        /// Action: GetCurrentConnectionIDs
        /// </summary>
        /// <param name="ConnectionIDs">Associated State Variable: CurrentConnectionIDs</param>
        public void GetCurrentConnectionIDs(out String ConnectionIDs)
        {
            ConnectionIDs = "0";
        }
        /// <summary>
        /// Action: GetCurrentConnectionInfo
        /// </summary>
        /// <param name="ConnectionID">Associated State Variable: A_ARG_TYPE_ConnectionID</param>
        /// <param name="RcsID">Associated State Variable: A_ARG_TYPE_RcsID</param>
        /// <param name="AVTransportID">Associated State Variable: A_ARG_TYPE_AVTransportID</param>
        /// <param name="ProtocolInfo">Associated State Variable: A_ARG_TYPE_ProtocolInfo</param>
        /// <param name="PeerConnectionManager">Associated State Variable: A_ARG_TYPE_ConnectionManager</param>
        /// <param name="PeerConnectionID">Associated State Variable: A_ARG_TYPE_ConnectionID</param>
        /// <param name="Direction">Associated State Variable: A_ARG_TYPE_Direction</param>
        /// <param name="Status">Associated State Variable: A_ARG_TYPE_ConnectionStatus</param>
        public void GetCurrentConnectionInfo(Int32 ConnectionID, out Int32 RcsID, out Int32 AVTransportID, out String ProtocolInfo, out String PeerConnectionManager, out Int32 PeerConnectionID, out Enum_A_ARG_TYPE_Direction Direction, out Enum_A_ARG_TYPE_ConnectionStatus Status)
        {

            RcsID = 0;
            AVTransportID = 0;
            ProtocolInfo = "http-get:*:audio/mp3:*";
            PeerConnectionManager = "";
            PeerConnectionID = 0;
            Direction = DMSConnectionManager.Enum_A_ARG_TYPE_Direction.INPUT;
            Status = DMSConnectionManager.Enum_A_ARG_TYPE_ConnectionStatus.OK;
        }
        /// <summary>
        /// Action: GetProtocolInfo
        /// </summary>
        /// <param name="Source">Associated State Variable: SourceProtocolInfo</param>
        /// <param name="Sink">Associated State Variable: SinkProtocolInfo</param>
        public void GetProtocolInfo(out String Source, out String Sink)
        {
            Source = "http-get:*:audio/mp3:*";
            Sink = String.Empty;
        }
    }
}
