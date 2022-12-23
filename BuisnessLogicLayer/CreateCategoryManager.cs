using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer
{
    public class CreateCategoryManager : ICreateCategoryManager
    {
        private IDBCategory IDBCategory;
        public CreateCategoryManager(IDBCategory IDBCategory)
        {
            this.IDBCategory = IDBCategory;
        }
        public bool CreateCategory(string cat)
        {
            return IDBCategory.CreateCategory(cat);
        }
    }
}
