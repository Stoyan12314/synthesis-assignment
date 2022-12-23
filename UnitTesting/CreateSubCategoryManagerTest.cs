using BuisnessLogicLayer;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.FakeDataAccessLayer;

namespace UnitTesting
{
    [TestClass]
    public class CreateSubCategoryManagerTest
    {

        [TestMethod]
        public void AddSubCategory_SubCategoryAddedUnSuccesfully_Void()
        {
            List<Category> categories = new List<Category>();
            List<SubCategory> subCategories = new List<SubCategory>();
            Category category = new Category(1, "category");
            SubCategory subCat = new SubCategory(1, "subCategory");
            subCategories.Add(subCat);
            category.AddToList(subCategories);
            categories.Add(category);

            FakeCategoryDB fakeRepo = new FakeCategoryDB(categories);

            CreateSubCategoryManager createSubCategoryManager = new CreateSubCategoryManager(fakeRepo);

            bool check = createSubCategoryManager.CreateSubCategory("subCategory", 1);


            Assert.IsTrue(categories.Contains(category));
            Assert.IsFalse(check); //is false because there is already a subcategory with the same id
        }
    }
}
