using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer
{
    public class DeleteItemManager :IDeleteItemManager
    {
        private IDBItem DBItem;
        public DeleteItemManager(IDBItem DBItem)
        {
            this.DBItem = DBItem;
        }
        public bool DeleteItem(int id)
        {
            return DBItem.DeleteItem(id);
        }
    }
}
