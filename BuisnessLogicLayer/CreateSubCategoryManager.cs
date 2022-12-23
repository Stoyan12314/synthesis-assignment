using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer
{
    public class CreateSubCategoryManager : ICreateSubCategoryManager
    {
        private IDBCategory IDBcategory;
        public CreateSubCategoryManager(IDBCategory IDBcategory)
        {
            this.IDBcategory = IDBcategory;
        }

        public bool CreateSubCategory(string subCategory, int CategoryId)
        {
            return IDBcategory.CreateSubCategory(subCategory, CategoryId);
        }
    }
}
