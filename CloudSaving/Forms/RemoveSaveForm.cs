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
    public partial class RemoveSaveForm : Form
    {
        public RemoveSaveForm()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RemoveSaveForm_Load(object sender, EventArgs e)
        {
            List<string> saves = SyncService.CountCloudServices(string.Format("{0}\\SavesInCloud", Directory.GetCurrentDirectory()));
            foreach (string save in saves)
            {
                CheckBox cb = new CheckBox();
                cb.Name = "Cb" + Path.GetFileNameWithoutExtension(save);
                cb.Text = Path.GetFileNameWithoutExtension(save);
                cb.Width = 250;
                FlpCheckBox.Controls.Add(cb);
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            bool files = false;
            foreach (CheckBox cb in FlpCheckBox.Controls)
            {
                if (cb.Checked)
                {
                    SyncService.RemoveSyncSave(cb.Text);
                    files = true;
                }
            }
            if(files)
                MessageBox.Show("Arquivos restaurados.");
            else
                MessageBox.Show("Nenhum arquivo foi selecionado.");
            Form form = new StartForm();
            form.Show();
            Close();
        }
    }
}
