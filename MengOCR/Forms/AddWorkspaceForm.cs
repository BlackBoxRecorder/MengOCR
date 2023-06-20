using System;
using System.Windows.Forms;

namespace MengOCR.Forms
{
    public partial class AddWorkspaceForm : Form
    {
        public AddWorkspaceForm()
        {
            InitializeComponent();


        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddWorkspaceForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;

        }
    }
}
