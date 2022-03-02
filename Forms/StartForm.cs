using CloudSaving.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudSaving.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void SyncSaves_Click(object sender, EventArgs e)
        {
            string directoryOrigin;
            string directoryDestiny;

            //diretorio local
            using (var fbd = new FolderBrowserDialog())
            {
                //MessageBox.Show("Selecione a pasta do save local");
                fbd.Description = "Selecione a pasta do save Local";
                fbd.UseDescriptionForTitle = true;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    directoryOrigin = fbd.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Tarefa Cancelada");
                    return;
                }
            }

            //diretorio na nuvem
            using (var fbd = new FolderBrowserDialog())
            {
                //MessageBox.Show("Selecione a pasta na nuvem");
                fbd.Description = "Selecione a pasta na nuvem";
                fbd.UseDescriptionForTitle = true;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    directoryDestiny = fbd.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Tarefa Cancelada");
                    return;
                }
            }

            bool sync = SyncService.SyncSaves(directoryOrigin, directoryDestiny);
            if (sync)
            {
                string folderName = new DirectoryInfo(directoryOrigin).Name;
                bool text = TxtService.WriteTxt(directoryOrigin, directoryDestiny, folderName);
                if (text)
                {
                    LoadSavesText();
                    MessageBox.Show("Saves Adicionados!!!");
                }
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            LoadSavesText();
        }

        private void LoadSavesText()
        {
            string dir = string.Format("{0}\\SavesInCloud", Directory.GetCurrentDirectory());

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            List<string> files = SyncService.CountCloudServices(dir);
            string listFiles = "";
            foreach (string file in files)
            {
                listFiles = listFiles.Insert(listFiles.Length, string.Format("-> {0}\n", Path.GetFileNameWithoutExtension(file)));
            }
            LblGames.Text = listFiles;
        }
        private void btnRemoveSave_Click(object sender, EventArgs e)
        {
            Form form = new RemoveSaveForm();
            Hide();
            form.ShowDialog();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
