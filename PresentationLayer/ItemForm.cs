﻿using System;
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
        private IItemManager itemManager;
        private ICreateItemManager createItemManager;
        private IDeleteItemManager deleteItemManager;
        private ICategoryManager categoryManager;
        int id;
        EditItems form;
        public ItemForm(EditItems form) 
        {
            InitializeComponent();
            categoryManager = new CategoryManager(new DBCategory());
            createItemManager = new CreateItemManager(new DBItem());
            itemManager = new ItemManager(new DBItem());
            btnRemoveItem.Hide();
            this.form = form;
            loadCategories();
        }
        public ItemForm(int id, EditItems form)
        {
            InitializeComponent();
            this.id = id;
            this.form = form;
            deleteItemManager = new DeleteItemManager(new DBItem());
            categoryManager = new CategoryManager(new DBCategory());
            LoadData();
            loadCategories();
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
                    SubCategory subCategory = (SubCategory)cbSubCat.SelectedItem; 
                    Category Category = (Category)cbCat.SelectedItem;
                    double price = Convert.ToDouble(tbPrice.Text);
                    int amount = Convert.ToInt32(tbAmount.Text);
                    string unit = cbUnit.Text;
                    string description = tbDescription.Text;
                    UnitType unitType = Enum.Parse<UnitType>(unit);
                    createItemManager.CreateItem(new Item(itemName, subCategory, Category, price, unitType, amount, image, description));
                    MessageBox.Show("Item created");
                    form.LoadData();
                    this.Close();
                }
                else
                {
                    Byte[] image = (byte[])new ImageConverter().ConvertTo(pcBox.Image, typeof(Byte[]));
                    string itemName = tbItemName.Text;
                
                      SubCategory subCategory = (SubCategory)cbSubCat.SelectedItem;

               

                    Category Category = (Category)cbCat.SelectedItem;
                    if (subCategory == null || Category == null)
                    {
                        Item item = itemManager.GetItemWith(id);
                        subCategory = item.subCategory;
                        Category = item.category;
                    }
     
                    double price = Convert.ToDouble(tbPrice.Text);           
                    int amount = Convert.ToInt32(tbAmount.Text);
                    string unit = cbUnit.Text;
                    string description = tbDescription.Text;
                    UnitType unitType = Enum.Parse<UnitType>(unit);
                    itemManager.EditItem(this.id, new Item(itemName, subCategory, Category, price, unitType, amount, image, description));
                    MessageBox.Show("Item updated");
                   
                   
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
            itemManager = new ItemManager(new DBItem());
            Item item = itemManager.GetItemWith(id); 
            MemoryStream stream = new MemoryStream(item.image);
            pcBox.Image = Image.FromStream(stream);
            tbItemName.Text = item.name;
           

            cbSubCat.Text = item.subCategory.Name;
          
            cbCat.Text = item.category.category;

            tbPrice.Text = item.price.ToString();
            tbAmount.Text = item.amount.ToString();
            cbUnit.Text = item.unit.ToString();
            tbDescription.Text = item.description;
        }
        public void loadCategories()
        {
            foreach (Category item in categoryManager.GetAllCategoriesFilter())
            {
                cbCat.Items.Add(item);
                foreach (SubCategory subCat in item.subCategories)
                {
                    cbSubCat.Items.Add(subCat);
                }
                
            }
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
            deleteItemManager.DeleteItem(id);
            form.LoadData();
            this.Close();
            
        }

        private void cbSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
