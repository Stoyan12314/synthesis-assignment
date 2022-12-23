using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface ICategoryManager
    {
        public List<Category> GetAllCategories();
       
        public List<SubCategory> GetAllSubCat(int id);
        public List<Category> GetAllCategoriesFilter();


    }
}
