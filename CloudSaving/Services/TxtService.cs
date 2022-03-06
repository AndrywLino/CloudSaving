using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSaving.Services
{
    public static class TxtService
    {
        public static bool WriteTxt(string directoryOrigin, string directoryDestiny, string name)
        {
            try
            {
                string dir = string.Format("{0}\\SavesInCloud", Directory.GetCurrentDirectory());

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string folderName = new DirectoryInfo(directoryOrigin).Name;
                using (StreamWriter sw = new StreamWriter(Path.Combine(dir, string.Format("{0}.txt", name))))
                {
                    sw.WriteLine(string.Format("{0}\\{1}", directoryDestiny, folderName));
                    sw.WriteLine(directoryOrigin);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool WriteTxtCloud(string directoryOrigin, string directoryDestiny, string name)
        {
            try
            {
                string dir = string.Format("{0}\\SavesInCloud", directoryDestiny);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string folderName = new DirectoryInfo(directoryOrigin).Name;
                using (StreamWriter sw = new StreamWriter(Path.Combine(dir, string.Format("{0}.txt", name))))
                {
                    sw.WriteLine(string.Format("{0}\\{1}", directoryDestiny, folderName));
                    sw.WriteLine(directoryOrigin);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static string[] ReadTxt(string name)
        {
            try
            {
                string dir = string.Format("{0}\\SavesInCloud", Directory.GetCurrentDirectory());
                string file = Path.Combine(dir, string.Format("{0}.txt", name));
                string[] line = new string[3];
                using (StreamReader sr = new StreamReader(file))
                {
                    int i = 0;
                    while ((line[i] = sr.ReadLine()) != null)
                    {
                        i++;
                    }
                }
                File.Delete(file);
                return line;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
