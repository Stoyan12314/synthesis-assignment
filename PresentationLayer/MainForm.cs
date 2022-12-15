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
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Orders form = new Orders();
            form.ShowDialog();
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            CategoryManagerForm form = new CategoryManagerForm();   
            form.ShowDialog();
          
        }
    }
}
