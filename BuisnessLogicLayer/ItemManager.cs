﻿using System;
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
        public bool CreateItem(Item item)
        {
          return  DBItem.CreateItem(item);
        }
        public void EditItem(int id, Item item)
        {
            DBItem.UpdateItem(id, item);
        }
        public bool DeleteItem(int id) 
        {
            return  DBItem.DeleteItem(id);
        }
        public Item GetItemWith(int id) 
        {
            return DBItem.GetItemWith(id);
        }
        public List<Item> GetAllItems()
        {
            return DBItem.GetAllItems();
        }
    }
}