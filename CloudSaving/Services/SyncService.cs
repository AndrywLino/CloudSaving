using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSaving.Services
{
    public static class SyncService
    {
        public static bool SyncSaves(string directoryOrigin, string directoryDestiny)
        {
            try
            {
                var files = Directory.GetFiles(directoryOrigin);
                var folders = Directory.GetDirectories(directoryOrigin);

                string folderName = new DirectoryInfo(directoryOrigin).Name;
                string destiny = string.Format("{0}\\{1}", directoryDestiny, folderName);

                DirectoryInfo directory = new DirectoryInfo(destiny);
                if (!Directory.Exists(destiny))
                    directory = Directory.CreateDirectory(destiny);

                folders.ToList().ForEach(f => Directory.Move(f, string.Format("{0}\\{1}", directory.FullName, new DirectoryInfo(f).Name)));
                files.ToList().ForEach(f => File.Move(f, string.Format("{0}\\{1}", directory.FullName, Path.GetFileName(f))));

                Directory.Delete(directoryOrigin, true);
                Directory.CreateSymbolicLink(directoryOrigin, directory.FullName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool DownSaves(string directoryOrigin, string directoryDestiny)
        {
            try
            {
                string folderName = new DirectoryInfo(directoryOrigin).Name;
                string destiny = string.Format("{0}\\{1}", directoryDestiny, folderName);

                DirectoryInfo directory = new DirectoryInfo(destiny);

                Directory.CreateSymbolicLink(directory.FullName, directoryOrigin);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool RemoveSyncSave(string name)
        {
            try
            {
                string[] folders = TxtService.ReadTxt(name);
                if (folders != null)
                {
                    string directoryOrigin = folders[1];
                    string directoryDestiny = folders[0];

                    Directory.Delete(directoryOrigin, true);

                    string folderName = new DirectoryInfo(directoryOrigin).Name;
                    DirectoryInfo directory = new DirectoryInfo(directoryOrigin);
                    directory = Directory.CreateDirectory(directoryOrigin);

                    var filesDirectory = Directory.GetFiles(directoryDestiny);
                    var foldersDirectory = Directory.GetDirectories(directoryDestiny);

                    foldersDirectory.ToList().ForEach(f => Directory.Move(f, string.Format("{0}\\{1}", directory.FullName, new DirectoryInfo(f).Name)));
                    filesDirectory.ToList().ForEach(f => File.Move(f, string.Format("{0}\\{1}", directory.FullName, Path.GetFileName(f))));

                    Directory.Delete(directoryDestiny, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static List<string> CountCloudServices(string dir)
        {
            string[] files = Directory.GetFiles(dir);
            return files.ToList();
        }
    }
}
