using DataAccessLayer.Interfaces;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IItemManager
    {
       

        public bool CreateItem(Item item);

        public void EditItem(int id, Item item);

        public bool DeleteItem(int id);

        public Item GetItemWith(int id);

        public List<Item> GetAllItems();

        public List<Item> GetItemWithCategory(string category);
        public List<Item> GetItemWithSubCategory(string subCategory);
    }
}
