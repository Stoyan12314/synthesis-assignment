using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.FakeDataAccessLayer
{
    public class FakeItemDB : IDBItem
    {
        List<Item> items;
        public FakeItemDB(List<Item> items)
        {
            this.items = items;
        }
        public bool CreateItem(Item item)
        {
            foreach (Item g in items)
            {
                if (g.id != item.id)
                {
                    items.Add(item);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteItem(int id)
        {
            foreach (Item g in items)
            {
                if (g.id == id)
                {
                    items.Remove(g);
                    return true;
                }
            }
            return false;
        }

        public List<Item> GetAllItems()
        {
            return this.items;
        }

        public Item GetItemWith(int id)
        {
            foreach (Item g in items)
            {
                if (g.id == id)
                {
                    
                    return g;
                }
            }
            return null;
        }

        public List<Item> GetItemWithCategory(string category)
        {
            List<Item> categories = new List<Item>();
            foreach (Item g in items)
            {
                if (g.category.category == category)
                {
                    categories.Add(g);
                   
                }
            }
            return categories;
        }

        public List<Item> GetItemWithSubCategory(string subCategory)
        {
            
            List<Item> SubCategories = new List<Item>();
            foreach (Item g in items)
            {
                if (g.subCategory.Name == subCategory)
                {
                    SubCategories.Add(g);

                }
            }
            return SubCategories;
        }

        public void UpdateItem(int id, Item item)
        {
            foreach (Item g in items.ToList())
            {
                if (g.id == id)
                {
                    items.Remove(g);
                    items.Add(item);

                }
            }
        }
    }
}
