using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
namespace DataAccessLayer.Interfaces
{
    public interface IDBItem
    {
        public bool CreateItem(Item item);
        public bool DeleteItem(int id);
        public Item GetItemWith(int id);
        public void UpdateItem(int id, Item item);
        public List<Item> GetAllItems();
        public List<Item> GetItemWithCategory(string category);
        public List<Item> GetItemWithSubCategory(string subCategory);
    }
           
}
