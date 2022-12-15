using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class subCategoryForm : Form
    {
        int id;
        private ICategoryManager categoryManager;
        public subCategoryForm(int catId)
        {
            InitializeComponent();
            categoryManager = new CategoryManager(new DBCategory());
            this.id = catId;
            LoadData();
        }

        private void btnSubCat_Click(object sender, EventArgs e)
        {
            string name = tbSubCat.Text;
            categoryManager.CreateSubCategory(name, id);
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (SubCategory cat in categoryManager.GetAllSubCat(id))
            {
                dataGridView1.Rows.Add(cat.id, cat.Name);
            }
        }
        private void tbSubCat_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
