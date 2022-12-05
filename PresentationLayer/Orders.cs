using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewOrders.Rows[index];
            int id = (int)selectedRow.Cells[0].Value;

          //  ItemForm newForm = new ItemForm(id, this);
          //  newForm.ShowDialog();
        }
    }
}
