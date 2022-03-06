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
            FolderBrowserDialog fbdLocal = new FolderBrowserDialog();
            using (fbdLocal)
            {
                MessageBox.Show("Selecione a pasta do save local");
                fbdLocal.Description = "Selecione a pasta do save Local";
                fbdLocal.UseDescriptionForTitle = true;
                DialogResult result = fbdLocal.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdLocal.SelectedPath))
                {
                    directoryOrigin = fbdLocal.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Tarefa Cancelada");
                    return;
                }
            }

            //diretorio na nuvem
            FolderBrowserDialog fbdNuvem = new FolderBrowserDialog();
            using (fbdNuvem)
            {
                MessageBox.Show("Selecione a pasta na nuvem");
                fbdNuvem.Description = "Selecione a pasta na nuvem";
                fbdNuvem.UseDescriptionForTitle = true;
                DialogResult result = fbdNuvem.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdNuvem.SelectedPath))
                {
                    directoryDestiny = fbdNuvem.SelectedPath;
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
                bool textCloud = TxtService.WriteTxtCloud(directoryOrigin, directoryDestiny, folderName);
                if (text && textCloud)
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

        private void BtnDownSaves_Click(object sender, EventArgs e)
        {
            string directoryOrigin;
            string directoryDestiny;

            //diretorio na nuvem
            FolderBrowserDialog fbdNuvem = new FolderBrowserDialog();
            using (fbdNuvem)
            {
                MessageBox.Show("Selecione a pasta na nuvem");
                fbdNuvem.Description = "Selecione a pasta na nuvem";
                fbdNuvem.UseDescriptionForTitle = true;
                DialogResult result = fbdNuvem.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdNuvem.SelectedPath))
                {
                    directoryOrigin = fbdNuvem.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Tarefa Cancelada");
                    return;
                }
            }

            //diretorio local
            FolderBrowserDialog fbdLocal = new FolderBrowserDialog();
            using (fbdLocal)
            {
                MessageBox.Show("Selecione a pasta do save local");
                fbdLocal.Description = "Selecione a pasta do save Local";
                fbdLocal.UseDescriptionForTitle = true;
                DialogResult result = fbdLocal.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdLocal.SelectedPath))
                {
                    directoryDestiny = fbdLocal.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Tarefa Cancelada");
                    return;
                }
            }

            bool sync = SyncService.DownSaves(directoryOrigin, directoryDestiny);
            if (sync)
            {
                string folderName = new DirectoryInfo(directoryDestiny).Name;
                bool text = TxtService.WriteTxt(directoryDestiny, directoryOrigin, folderName);
                LoadSavesText();
                MessageBox.Show("Saves Sincronizados!!!");
            }
        }

        private void BtnAjuda_Click(object sender, EventArgs e)
        {
            Form help = new HelpForm();
            help.ShowDialog();
        }
    }
}
