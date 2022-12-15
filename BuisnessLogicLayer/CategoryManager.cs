using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;
using BuisnessLogicLayer.Interfaces;
using Entities;
using System.Linq;
using Org.BouncyCastle.Utilities;

namespace BuisnessLogicLayer
{
    public class CategoryManager : ICategoryManager
    {
        private IDBCategory dBCategory;

        public CategoryManager(IDBCategory dBCategory)
        {
            this.dBCategory = dBCategory;
        }

        
        private Category CheckForCategory(Category cat, List<Category> currentCategories)
        {
            List<Category> categories = currentCategories.ToList();
            foreach (Category c in categories.ToList()) 
            {
                if (c.category == cat.category)
                {
                    return c;
                }
               
            }
            return null;
        }
        public List<Category> GetAllCategoriesFilter()
        {
            //spageti code
            List<Category> categories = dBCategory.GetAllCategories();
            Category cat;
            List<Category> noDupes = new List<Category>();

            foreach (var item in categories.ToList())
            {
                cat = CheckForCategory(item, noDupes);
                if (cat == null)
                {
                    noDupes.Add(item);
                }
                else
                {
                        cat.AddToList(item.subCategories);
                        categories.Remove(item);
                        noDupes.Remove(cat);
                        noDupes.Add(cat);
                }
            }

            return noDupes.OrderBy(x => x.category).ToList();

        }





        public List<SubCategory> GetAllSubCat(int id)
        {
            return dBCategory.GetAllSubCat(id);
        }
      
        public List<Category> GetAllCategories()
        {
            return dBCategory.GetAllCategories();
        }
       
        public bool CreateCategory(string cat)
        {
            return dBCategory.CreateCategory(cat);
        }

        public bool CreateSubCategory(string subCategory, int CategoryId)
        {
            return dBCategory.CreateSubCategory(subCategory, CategoryId);
        }


    }
}
