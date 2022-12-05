using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using Entities;
using Entities.Enum;
namespace PresentationLayer
{
    public partial class ItemForm : Form
    {
        private IItemManager itemManager = new ItemManager(new DBItem());
        int id;
        EditItems form;
        public ItemForm(EditItems form) 
        {
            InitializeComponent();
            btnRemoveItem.Hide();
            this.form = form;
        }
        public ItemForm(int id, EditItems form)
        {
            InitializeComponent();
            this.id = id;
            this.form = form;
            LoadData();
        }
       
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.id == default)
                {
                    Byte[] image = (byte[])new ImageConverter().ConvertTo(pcBox.Image, typeof(Byte[]));
                    string itemName = tbItemName.Text;
                    string subCategory = tbSubCategory.Text;
                    string Category = cbCat.Text;
                    double price = Convert.ToDouble(tbPrice.Text);
                    int amount = Convert.ToInt32(tbAmount.Text);
                    string unit = cbUnit.Text;
                    string description = tbDescription.Text;
                    UnitType unitType = Enum.Parse<UnitType>(unit);
                    itemManager.CreateItem(new Item(itemName, subCategory, Category, price, unitType, amount, image, description));
                    MessageBox.Show("Item created");
                   // EditItems form = new EditItems();
                    form.LoadData();
                    this.Close();
                }
                else
                {
                    Byte[] image = (byte[])new ImageConverter().ConvertTo(pcBox.Image, typeof(Byte[]));
                    string itemName = tbItemName.Text;
                    string subCategory = tbSubCategory.Text;
                    string Category = cbCat.Text;
                    double price = Convert.ToDouble(tbPrice.Text);           
                    int amount = Convert.ToInt32(tbAmount.Text);
                    string unit = cbUnit.Text;
                    string description = tbDescription.Text;
                    UnitType unitType = Enum.Parse<UnitType>(unit);
                    itemManager.EditItem(this.id, new Item(itemName, subCategory, Category, price, unitType, amount, image, description));
                    MessageBox.Show("Item updated");
                   
                    //EditItems form = new EditItems();
                    form.LoadData();
                    this.Close();
                }
               
            }
            catch (Exception)
            {
                throw;
            }
           

        }
        public void LoadData()
        {
           
            Item item = itemManager.GetItemWith(id);
            MemoryStream stream = new MemoryStream(item.image);
            pcBox.Image = Image.FromStream(stream);
            tbItemName.Text = item.name;
            tbSubCategory.Text = item.subCategory;
            cbCat.Text = item.category;
            tbPrice.Text = item.price.ToString();
            tbAmount.Text = item.amount.ToString();
            cbUnit.Text = item.unit.ToString();
            tbDescription.Text = item.description;
           
        }
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.FileName = "";
            OD.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
            if (OD.ShowDialog() == DialogResult.OK)
                pcBox.Load(OD.FileName);
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            itemManager.DeleteItem(id);
            form.LoadData();
            this.Close();
            
        }
    }
}
