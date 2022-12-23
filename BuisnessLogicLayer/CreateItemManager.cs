using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer
{
    public class CreateItemManager : ICreateItemManager
    {
        private IDBItem DBItem;
        public CreateItemManager(IDBItem DBItem)
        {
            this.DBItem = DBItem;
        }
        public bool CreateItem(Item item)
        {
            return DBItem.CreateItem(item);
        }
    }
}
