using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
namespace DataAccessLayer.Interfaces
{
    public interface IDBCategory
    {
        public List<Category> GetAllCategories();
        
        public bool CreateCategory(string cat);
        public bool CreateSubCategory(string subCategory, int CategoryId);

        public List<SubCategory> GetAllSubCat(int id);
      
    }
}
