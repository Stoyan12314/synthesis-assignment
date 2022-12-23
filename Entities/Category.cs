using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Category
    {
        public int id { private set; get; }
        public string category { private set; get; }
        public List<SubCategory> subCategories; 


        public Category(int id, string category)
        {
            this.category = category;
            this.id = id;
            subCategories = new List<SubCategory>();
        }
        public override string ToString()
        {
          
            return $"{category}";
        }
        [JsonConstructor]
        public Category(int category_id, string category, int subCat_id, string subCatName)
        {
            subCategories= new List<SubCategory>();
            this.id = category_id;
            this.category = category;
            subCategories.Add(new SubCategory(subCat_id, subCatName));

        }
       
       
        public void AddToList(List<SubCategory> subCategory)
        {
            foreach (SubCategory item in subCategory)
            {
                if (CheckForRepSubCategory(item) == false)
                {
                    subCategories.Add(item);
                }
              
            }
           
        }

        private bool CheckForRepSubCategory(SubCategory subCat)
        {
            if (subCategories.Count == 0)
            {
                subCategories.Add(subCat);
            }
            foreach (SubCategory s in subCategories.ToList())
            {
                if (s.Name == subCat.Name)
                {
                    return true;
                }

            }
            return false;
        }




    }
}
