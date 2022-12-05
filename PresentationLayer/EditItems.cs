using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;

namespace PresentationLayer
{
    public partial class EditItems : Form
    {
        private IItemManager itemManager;
        public EditItems()
        {
            InitializeComponent();
            itemManager = new ItemManager(new DBItem());
            LoadData();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridViewItems.Rows[index];
                int id = (int)selectedRow.Cells[0].Value;

                ItemForm newForm = new ItemForm(id, this);
                newForm.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show("Select item first!");
            }
          
        }
        public void LoadData()
        {
            dataGridViewItems.Rows.Clear();
            foreach (Item item in itemManager.GetAllItems())
            {
                dataGridViewItems.Rows.Add(item.id, item.name, item.subCategory, item.category, Math.Round(item.price, 2)+" $", item.unit.ToString(), item.amount);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            ItemForm form = new ItemForm(this);
            form.ShowDialog();
           
        }
    }
}
