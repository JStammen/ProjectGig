using Id3Lib;
using Id3Lib.Exceptions;
using Mp3Lib;
using OpenSource.UPnP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;
using System.Web;
using System.Windows;
using System.Windows.Threading;
using System.Threading;

namespace GigServer
{
    public class DMSContentHandler
    {
        private static DMSContentHandler instance;
        private UPnPService service;

        public static Dictionary<string, Container> hashContainers;
        public static Dictionary<string, Item> hashItems;
        public ManualResetEvent doneScanning;
        private static uint TotalMatches;

        public DMSContentHandler(UPnPService service)
        {
            instance = this;
            this.service = service;
            hashContainers = new Dictionary<string, Container>();
            hashItems = new Dictionary<string, Item>();
            TotalMatches = 0;
            doneScanning = new ManualResetEvent(false);
        }

        public const string UPNP_CONTAINER = "object.container.storageFolder";
        public const string UPNP_ITEM = "object.item.audioItem.musicTrack";

        private string GetProtocolInfo(string ext)
        {
            string mimeType = GetMimeType(ext);
            string retVal = "http-get:*:" + mimeType + ":*";
            return retVal;
        }

        private static string GetMimeType(string ext)
        {
            string modExt = ext.ToLower();
            modExt = modExt.Replace(".", "");
            switch (modExt)
            {
                case "wma":
                    return "audio/x-ms-wma";
                case "wav":
                    return "audio/wav";
                case "mpg":
                case "mpa":
                    return "audio/mpeg";
                case "wpl":
                    return "application/vnd.ms-wpl";
                case "asx":
                    return "text/xml"; //audio/x-ms-asf
                case "m3u":
                    return "application/x-mpegurl";
                case "mp3":
                    return "audio/mp3";
                default:
                    return "audio/*";
            }
        }

        public void IndexDirs()
        {
            string[] musicDir = RegistryUtil.GetInstance().MusicDir;

            for (int i = 0; i < musicDir.Length; i++)
            {
                string dir = musicDir[i];
                if (!Directory.Exists(dir)) continue;

                DirectoryInfo diParent = new DirectoryInfo(dir);
                RecurseAddContainers(diParent, "0", ref TotalMatches, 0); // "0" for root
            }

            doneScanning.Set();
            Console.WriteLine("###### DONE SCANNING ######");
            Console.WriteLine("Found " + hashItems.Count + " items in " + hashContainers.Count + " containers.");
        }

        private void RecurseAddContainers(DirectoryInfo di, string parentID, ref uint TotalMatches, int depth)
        {
            AddContainer(di, ref parentID);
            DirectoryInfo[] dia = di.GetDirectories();
            for (int i = 0; i < dia.Length; i++)
            {
                DirectoryInfo diTemp = dia[i];
                RecurseAddContainers(diTemp, parentID, ref TotalMatches, depth);
            }
        }

        private void AddContainer(DirectoryInfo di, ref string parentID)
        {
            TotalMatches++;

            string id = generateID(parentID);
            string childCount = (di.GetDirectories().Length + GetMp3Files(di).Length).ToString();
            string didl = DidlHandler.BuildUPnPContainer(id, parentID, childCount, "0", "1", di.Name, UPNP_CONTAINER);

            Container co = new Container(id, di, parentID, didl, true);
            UpsertContainer(id, co);
            if(Settings.Verbose) Console.WriteLine("New container: id: " + id + " parentID: " + parentID + " dir: " + di);

            parentID = id;
            ScanContainer(co);
        }

        public void ScanContainer(Container co)
        {
            FileInfo[] fia = co.dir.GetFiles("*.mp3", SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in fia)
            {
                if (fi.Length < 100000000)
                    AddItem(fi, co.id);
            }
        }

        // Generate ID by prepending the parent id
        // Example: ID = 2, parentID = 1, output: "1.2"
        private string generateID(string parentID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(parentID + ".");
            sb.Append(TotalMatches.ToString());

            return sb.ToString();
            //return (TotalMatches.ToString());
        }

        private void AddItem(FileInfo fi, string parentID)
        {
            TotalMatches++;
            string id = generateID(parentID);
            string ext = String.Empty;
            string trackInfo = String.Empty;
            string titleInfo = String.Empty;
            string artistInfo = String.Empty;
            string albumInfo = String.Empty;
            string genreInfo = String.Empty;
            string duration = String.Empty;
            string bitRate = String.Empty;
            string sampleFrequency = String.Empty;
            string nrAudioChannels = String.Empty;
            string protInfo = String.Empty;
            string baseUrl = String.Empty;
            string resUrl = String.Empty;

            //Mp3File mp3 = new Mp3File(fi); // for ID3 tag purposes only

            //if (mp3.TagModel.Header.Version == 3 || mp3.TagModel.Header.Version == 4)
            //{
            //    trackInfo = mp3.TagHandler.Track;
            //    //titleInfo = mp3.TagHandler.Song;
            //    artistInfo = mp3.TagHandler.Artist;
            //    albumInfo = mp3.TagHandler.Album;
            //    genreInfo = mp3.TagHandler.Genre;
            //    duration = "0:00:00.000";

            //    bitRate = (mp3.Audio.BitRate / 1000).ToString("F0", CultureInfo.InvariantCulture);
            //    sampleFrequency = mp3.Audio.Header.SamplesPerSecond.ToString();
            //    nrAudioChannels = (mp3.Audio.Header.IsMono) ? "1" : "2";
            //}
            //else
            //{
            titleInfo = fi.Name;
            trackInfo = String.Empty;
            artistInfo = String.Empty;
            albumInfo = String.Empty;
            genreInfo = String.Empty;
            duration = String.Empty;

            bitRate = String.Empty;
            sampleFrequency = String.Empty;
            nrAudioChannels = String.Empty;
            //}

            ext = Path.GetExtension(fi.Name);
            protInfo = GetProtocolInfo(ext);
            baseUrl = "http://" + service.ParentDevice.LocalIPEndPoints[0].ToString();
            string path = fi.DirectoryName.Replace(Path.GetPathRoot(fi.DirectoryName), String.Empty);
            resUrl = baseUrl + "/" + path + "/" + fi.Name;
            //Console.WriteLine(resUrl);

            string didl = DidlHandler.BuildUPnPItem(id, parentID, "1", titleInfo,
                            trackInfo, artistInfo, albumInfo, genreInfo,
                            duration, bitRate, sampleFrequency, nrAudioChannels,
                            protInfo, resUrl, UPNP_ITEM);

            UpsertItem(id, new Item(id, fi, parentID, didl));
            if(Settings.Verbose) Console.WriteLine("New item: id: " + id + " parentID: " + parentID + " fi: " + fi.Name);
        }

        protected static FileInfo[] GetMp3Files(DirectoryInfo di)
        {
            List<FileInfo> fiList = new List<FileInfo>();

            FileInfo[] fia = di.GetFiles("*.mp3");
            foreach (FileInfo fi in fia)
            {
                fiList.Add(fi);
            }

            return fiList.ToArray();
        }

        protected static bool IsFileOfTypes(string name, string[] extensions)
        {
            bool match = false;
            string fileExt = Path.GetExtension(name);
            fileExt = fileExt.ToLower();
            fileExt = fileExt.Replace(".", "");
            foreach (string ext in extensions)
            {
                string modExt = ext.ToLower();
                modExt = modExt.Replace(".", "");
                if (fileExt == modExt)
                {
                    match = true;
                    break;
                }
            }
            return match;
        }

        public static byte[] GetMusic(string url, out string mimeType)
        {
            mimeType = GetMimeType(Path.GetExtension(url));
            return GetContent(url);
        }

        public static byte[] GetContent(string url)
        {
            string id = Path.GetFileNameWithoutExtension(url);
            FileInfo fi = hashItems[id].fi;
            byte[] buffer = new byte[0];
            if (fi.Exists) //File
            {
                FileStream stream = fi.OpenRead();
                buffer = new byte[(int)stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                stream.Close();
            }
            return buffer;
        }

        void UpsertContainer(string id, Container co)
        {
            if (hashContainers.ContainsKey(id) == false)
            {
                hashContainers.Add(id, co);
            }
            else
            {
                hashContainers[id] = co;
            }
        }

        void UpsertItem(string id, Item it)
        {
            if (hashItems.ContainsKey(id) == false)
            {
                hashItems.Add(id, it);
            }
            else
            {
                hashItems[id] = it;
            }
        }

        public static DMSContentHandler GetInstance(){
            return instance;
        }
    }

    public class Container
    {
        public string id;
        public DirectoryInfo dir;
        public string parentID;
        public string didl;
        public bool isParent;

        public Container(string id, DirectoryInfo dir, string parentID, string didl, bool isParent)
        {
            this.id = id;
            this.dir = dir;
            this.parentID = parentID;
            this.didl = didl;
            this.isParent = isParent;
        }
    }

    public class Item
    {
        public string id;
        public FileInfo fi;
        public string parentID;
        public string didl;

        public Item(string id, FileInfo fi, string parentID, string didl)
        {
            this.id = id;
            this.fi = fi;
            this.parentID = parentID;
            this.didl = didl;
        }
    }
}
