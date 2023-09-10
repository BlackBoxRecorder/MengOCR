using System;
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
                string SnapSaveDir = StoreData.Instance.GetKeyVal<string>(StoreKeys.SnapSaveDir);
                TxtSnapSaveDir.Text = SnapSaveDir;

                string keyBinding = StoreData.Instance.GetKeyVal<string>(StoreKeys.KeyBingding);
                TxtKeybinding.Text = keyBinding;

            }
            catch (Exception)
            {

            }
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
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

            StoreData.Instance.SetKeyVal<string>(StoreKeys.KeyBingding, $"{mkey}+{key}");

        }

        private void BtnSelectSaveDir_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                TxtSnapSaveDir.Text = folderBrowserDialog.SelectedPath;
            }

            StoreData.Instance.SetKeyVal<string>(StoreKeys.SnapSaveDir, TxtSnapSaveDir.Text);
        }

        private void RBtnMini_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                StoreData.Instance.SetKeyVal<bool>(StoreKeys.CloseExit, false);
            }
            else
            {
                MessageBox.Show("不是RadioButton");
            }

        }

        private void RBtnClose_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                StoreData.Instance.SetKeyVal<bool>(StoreKeys.CloseExit, true);
            }
            else
            {
                MessageBox.Show("不是RadioButton");
            }
        }

        private void RBtnShowMain_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                StoreData.Instance.SetKeyVal<bool>(StoreKeys.SnapShowMain, true);
            }
            else
            {
                MessageBox.Show("不是RadioButton");
            }
        }

        private void RBtnNotify_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                StoreData.Instance.SetKeyVal<bool>(StoreKeys.SnapShowMain, false);
            }
            else
            {
                MessageBox.Show("不是RadioButton");
            }
        }
    }
}
