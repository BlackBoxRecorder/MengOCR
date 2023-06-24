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
            }
            catch (Exception)
            {

            }
        }
    }
}
