using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface ICategoryManager
    {
        public List<Category> GetAllCategories();
        public bool CreateCategory(string cat);
        public bool CreateSubCategory(string subCategory, int CategoryId);
        public List<SubCategory> GetAllSubCat(int id);
        public List<Category> GetAllCategoriesFilter();


    }
}
