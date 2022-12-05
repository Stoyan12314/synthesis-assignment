using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnEditItems_Click(object sender, EventArgs e)
        {
            EditItems form = new EditItems();
            form.ShowDialog();
            this.Close();   
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
