using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface ICreateSubCategoryManager
    {
        public bool CreateSubCategory(string subCategory, int CategoryId);
       
    }
}
