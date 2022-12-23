using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities;
using Org.BouncyCastle.Utilities;

namespace UnitTesting.FakeDataAccessLayer
{
    public class FakeCategoryDB : IDBCategory
    {
        List<Category> categories;
        public FakeCategoryDB(List<Category> categories)
        {
            this.categories = categories;
        }
        

        public bool CreateCategory(string cat)
        {
                    categories.Add(new Category(1, cat));
                    return true;
        }

       
        public bool CreateSubCategory(string subCategory, int CategoryId)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            
            foreach (Category g in categories)
            {
                if (g.id == CategoryId)
                {
                    foreach (var item in g.subCategories)
                    {
                        if (item.Name != subCategory)
                        {
                            subCategories.Add(new SubCategory(1, subCategory));
                            g.AddToList(subCategories);

                            return true;
                        }
                    }
                   
                }
            }
            return false;
        }

        public List<Category> GetAllCategories()
        {
            return this.categories;
        }

        public List<SubCategory> GetAllSubCat(int id)
        {
            foreach (Category g in categories)
            {
                if(g.id == id)
                {
                    return g.subCategories;
                }
               
            }
            return null;
        }

        
    }
}
