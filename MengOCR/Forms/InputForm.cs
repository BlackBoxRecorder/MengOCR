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
    public partial class InputForm : Form
    {

        public string NewValue { get; set; }

        public string OldValue { get; set; }


        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            TextInput.Text = OldValue;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            NewValue = TextInput.Text;

            Close();
        }
    }
}
