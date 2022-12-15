using BuisnessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnessLogicLayer;
using DataAccessLayer;
using Entities;

namespace PresentationLayer
{
    public partial class CategoryManagerForm : Form
    {
        private ICategoryManager categoryManager;
        public CategoryManagerForm()
        {
            InitializeComponent();
            categoryManager = new CategoryManager(new DBCategory());
            LoadData();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string catName = tbCatName.Text;
            categoryManager.CreateCategory(catName);
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (Category cat in categoryManager.GetAllCategoriesFilter())
            {
                dataGridView1.Rows.Add(cat.id, cat.category);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            int id = (int)selectedRow.Cells[0].Value;

            subCategoryForm newForm = new subCategoryForm(id);
            newForm.ShowDialog();
        }
    }
}
