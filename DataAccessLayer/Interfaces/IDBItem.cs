using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IDBItem
    {
        public bool CreateItem(Item item);
        public bool DeleteItem(int id);
        public Item GetItemWith(int id);
        public void UpdateItem(int id, Item item);
        public List<Item> GetAllItems();
    }
           
}
