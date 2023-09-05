using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MengOCR.Forms
{
    public partial class ConfigForm : Form
    {

        public event EventHandler RebuildStoreClick;


        public ConfigForm()
        {
            InitializeComponent();
        }



        private void BtnRebuildStore_Click(object sender, EventArgs e)
        {
            RebuildStoreClick.Invoke(this, new EventArgs());
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            try
            {
                string SnapSaveDir = StoreData.Instance.GetKeyVal<string>("snapSaveDir");
                TxtSnapSaveDir.Text = SnapSaveDir;

                string keyBinding = StoreData.Instance.GetKeyVal<string>("keyBinding");
                TxtKeybinding.Text = keyBinding;

            }
            catch (Exception)
            {

            }
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {

            StoreData.Instance.SetKeyVal<string>("snapSaveDir", TxtSnapSaveDir.Text);


            Close();

        }

        private void TxtKeybinding_KeyDown(object sender, KeyEventArgs e)
        {
            Keys mkey;
            if (e.Shift)
            {
                mkey = Keys.Shift;
            }
            else if (e.Alt)
            {
                mkey = Keys.Alt;
            }
            else if (e.Control)
            {
                mkey = Keys.Control;
            }
            else
            {
                return;
            }

            var key = e.KeyCode;
            TxtKeybinding.Text = $"{mkey} + {key}";

            StoreData.Instance.SetKeyVal<string>("keyBinding", $"{mkey}+{key}");

        }

        private void BtnSelectSaveDir_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                TxtSnapSaveDir.Text = folderBrowserDialog.SelectedPath;
            }



        }
    }
}
