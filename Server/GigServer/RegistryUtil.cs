using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace GigServer
{
    public class RegistryUtil
    {
        private const string PREFERENCES_KEY = @"SOFTWARE\ProjectGig\GigServer";
        private const string LISTEN_PORT = @"ListenPort";
        private const string MUSIC_DIR = @"MusicDir";

        public int ListenPort = 41955;
        public string[] MusicDir = Settings.MusicDir;


        private const string splitChar = ";";

        private RegistryUtil()
        {
            try
            {
                if (!Directory.Exists(MusicDir[0]) == true) 
                {
                    MusicDir = new string[] { Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) };
                }
                DirectoryInfo diMusic = new DirectoryInfo(MusicDir[0]);
                DirectoryInfo diUser = diMusic.Parent;
            }
            catch (Exception ex)
            {
                string sex = ex.ToString();
            }
        }

        private static RegistryUtil regUtil = null;
        public static RegistryUtil GetInstance()
        {
            if (regUtil == null)
            {
                regUtil = new RegistryUtil();
                regUtil.LoadSettings();
            }
            return regUtil;
        }

        public void LoadSettings()
        {
            try
            {
                using (RegistryKey preferencesKey = Registry.LocalMachine.OpenSubKey(PREFERENCES_KEY))
                {
                    if (preferencesKey != null)
                    {
                        object objListenPort = (int)preferencesKey.GetValue(LISTEN_PORT);
                        if (objListenPort != null)
                        {
                            ListenPort = (int)objListenPort;
                        }
                        object objMusicDir = (string)preferencesKey.GetValue(MUSIC_DIR);
                        if (objMusicDir != null)
                        {
                            string strMusicDir = (string)objMusicDir;
                            MusicDir = StringToStringArray(strMusicDir);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string sex = ex.ToString();
            }
        }

        public static string StringArrayToString(string[] strings)
        {
            string retVal = String.Empty;
            for(int i=0; i<strings.Length; i++)
            {
                string str = strings[i];
                retVal = retVal + str.Trim();
                if (i < strings.Length - 1)
                {
                    retVal = retVal + ";";
                }
            }
            return retVal.Trim();
        }

        public static string [] StringToStringArray(string str)
        {
            string [] retVal = new string[0];
            retVal = str.Split(splitChar.ToCharArray());
            List<string> list = new List<string>();
            foreach (string strTemp in retVal)
            {
                string trim = strTemp.Trim();
                if (trim != String.Empty)
                {
                    list.Add(trim);
                }
            }
            return list.ToArray();
        }

        public void SaveSettings()
        {
            try
            {
                RegistryKey preferencesKey = Registry.LocalMachine.OpenSubKey(PREFERENCES_KEY, true);
                if (preferencesKey == null)
                {
                    preferencesKey = Registry.LocalMachine.CreateSubKey(PREFERENCES_KEY);
                }

                preferencesKey.SetValue(LISTEN_PORT, ListenPort);


                string strMusicDir = StringArrayToString(MusicDir);
                preferencesKey.SetValue(MUSIC_DIR, strMusicDir);

                preferencesKey.Close();
            }
            catch (Exception ex)
            {
                string sex = ex.ToString();
            }
        }
    }
}
