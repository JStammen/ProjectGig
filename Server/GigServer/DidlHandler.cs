using System;
using System.Collections.Generic;
using System.Text;
using System.Web;


namespace GigServer
{
    public static class DidlHandler
    {
        public static string BuildUPnPContainer(string id, string parentID, string childCount, string restricted, string searchable, string title, string _class)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(UPnPContainerHeader(id, parentID, childCount, restricted, searchable));

            sb.Append("\t\t<dc:title>" + HttpUtility.HtmlEncode(title) + "</dc:title>\n");
            sb.Append("\t\t<upnp:class>" + _class + "</upnp:class>\n");
            sb.Append("\t</container>\n");

            return sb.ToString();
        }

        public static string BuildUPnPItem(string id, string parentID, string restricted, string title,
            string track, string artist, string album, string genre, 
            string duration, string bitrate, string sampleFrequency, string nrAudioChannels,
            string protocolInfo, string resUri, string _class)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\t<item id=\"" + id + "\" parentID=\"" + parentID + "\" restricted=\"" + restricted + "\">\n");
            sb.Append("\t\t<dc:title>" + HttpUtility.HtmlEncode(title) + "</dc:title>\n");
            sb.Append("\t\t<res protocolInfo=\"" + protocolInfo + "\"");
            if (duration != String.Empty) sb.Append("duration=\"" + duration + "\"");
            if (nrAudioChannels != String.Empty) sb.Append("nrAudioChannels=\"" + nrAudioChannels + "\"");
            if (bitrate != String.Empty) sb.Append("bitrate=\"" + bitrate + "\"");
            if (sampleFrequency != String.Empty) sb.Append("sampleFrequency=\"" + sampleFrequency + "\"");
            sb.Append(">\n\t\t\t" + HttpUtility.HtmlEncode(resUri) + "\n\t\t</res>\n");
            if (track != String.Empty) sb.Append("\t\t<upnp:originalTrackNumber>" + track + "</upnp:originalTrackNumber>\n");
            if (artist != String.Empty) sb.Append("\t\t<upnp:artist>" + artist + "</upnp:artist>\n");
            if (album != String.Empty) sb.Append("\t\t<upnp:album>" + album + "</upnp:album>\n");
            if (genre != String.Empty) sb.Append("\t\t<upnp:genre>" + genre + "</upnp:genre>\n");
            sb.Append("\t\t<upnp:class>" + _class + "</upnp:class>\n");
            sb.Append("\t</item>\n");

            return sb.ToString();
        }

        public static string UPnPContainerHeader(string id, string parentID, string childCount, string restricted, string searchable)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\t<container ");
            sb.Append("id=\"" + id + "\" ");
            sb.Append("parentID=\"" + parentID + "\" ");
            if(childCount != String.Empty) sb.Append("childCount=\"" + childCount + "\" ");
            sb.Append("restricted=\"" + restricted + "\" ");
            sb.Append("searchable=\"" + searchable + "\"");
            sb.Append(">\n");

            return sb.ToString();
        }

        public static string DidlHeader()
        {
            return "<DIDL-Lite xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:upnp=\"urn:schemas-upnp-org:metadata-1-0/upnp/\" xmlns=\"urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/\">\n";
        }

        public static string DidlFooter()
        {
            return "</DIDL-Lite>";
        }
    }
}
