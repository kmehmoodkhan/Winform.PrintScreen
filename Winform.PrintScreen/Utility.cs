using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Winform.PrintScreen
{
    public static class Utility
    {
        public static string SettingsFilePath = Utility.BasePath + "Settings\\state.xml";
        public static string BasePath
        {
            get
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToLower();

                path = path.Replace("\\bin\\debug\\netcoreapp3.1", "\\");
                return path;
            }
        }
        public static string GetWordPath()
        {
            string path = string.Empty;
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Winword.exe"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("Path");
                    if (o != null)
                    {
                        path = o as string;
                    }
                }
            }

            path += "Winword.exe";
            return path;
        }

        public static SettingsInstance GetSettings()
        {
            SettingsInstance settings = new SettingsInstance();
            if (File.Exists(SettingsFilePath))
            {                
                XmlSerializer formatter = new XmlSerializer(typeof(SettingsInstance));
                using (FileStream aFile = new FileStream(SettingsFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[aFile.Length];
                    aFile.Read(buffer, 0, (int)aFile.Length);
                    MemoryStream stream = new MemoryStream(buffer);
                    return (SettingsInstance)formatter.Deserialize(stream);
                }
            }
            return settings;
        }
        public static void SaveSettings(SettingsInstance listofa)
        {
            using (FileStream outFile = File.Create(SettingsFilePath))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(SettingsInstance));
                formatter.Serialize(outFile, listofa);
            }
        }

        public static Color GetColor(string hexString)
        {
            if (hexString.IndexOf('#') != -1)
                hexString = hexString.Replace("#", "");

            int r, g, b = 0;

            r = int.Parse(hexString.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            g = int.Parse(hexString.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            b = int.Parse(hexString.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            return Color.FromArgb(r, g, b);
        }

        public static void LaunchWordDocument(string docPath)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "word",
                FileName = Utility.GetWordPath(),
                Arguments = docPath
            };
            p.Start();
        }

        public static void DeleteTempFiles()
        {
            var files = Directory.GetFiles(Utility.BasePath+"Temp", "*.jpeg");
            foreach (var f in files)
            {
                try
                {
                    File.Delete(f);
                }
                catch (Exception ex)
                {
                    var error = ex;
                }
            }
        }

        public static void DeleteTempImages(List<string> imagePaths)
        {
            foreach (var img in imagePaths)
            {
                if (File.Exists(img))
                {
                    try
                    {
                        File.Delete(img);
                    }
                    catch (Exception ex)
                    {
                        var error = ex;
                    }
                }
            }
        }

        public static Image GetCursor()
        {
            var cursorSize = GetSettings().CursorImageSize;
            var bitmap = Properties.Resources.Cursor_Fullsize;
            var requiredBitmap = new Bitmap(bitmap, cursorSize, cursorSize);
            return (Image)requiredBitmap;
        }
    }
}
