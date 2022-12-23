using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Org.BouncyCastle.Bcpg.OpenPgp;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Org.BouncyCastle.Pkcs;

namespace BuisnessLogicLayer
{
    public class ItemManager : IItemManager
    {
        private IDBItem DBItem;
        public ItemManager(IDBItem DBItem)
        {
            this.DBItem = DBItem;
        }
       
        public void EditItem(int id, Item item)
        {
            DBItem.UpdateItem(id, item);
        }
      
        public Item GetItemWith(int id) 
        {
            return DBItem.GetItemWith(id);
        }
        public List<Item> GetAllItems()
        {
            return DBItem.GetAllItems();
        }
        public List<Item> GetItemWithCategory(string category)
        {
            return DBItem.GetItemWithCategory(category);
        }
        public List<Item> GetItemWithSubCategory(string subCategory)
        {
            return DBItem.GetItemWithSubCategory(subCategory);
        }


    }
}
