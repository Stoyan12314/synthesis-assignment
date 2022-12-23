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
    public class CategoryManagerTest
    {
      
        
        [TestMethod]
        public void GetAllCategories_AllCategoriesGottenSuccesfully_Void()
        {
            List<Category> categories = new List<Category>();
            List<SubCategory> subCategories = new List<SubCategory>();
            Category category = new Category(1, "category");
            SubCategory subCat = new SubCategory(1, "subCategory");
            subCategories.Add(subCat);
            category.AddToList(subCategories);
            categories.Add(category);

            FakeCategoryDB fakeRepo = new FakeCategoryDB(categories);

            CategoryManager gameManager = new CategoryManager(fakeRepo);

            List<Category> cat = gameManager.GetAllCategories();

            Assert.AreSame(categories, cat);
            Assert.AreEqual(cat,categories);
        }

        [TestMethod]
        public void GetAllSubCategories_AllSubCategoriesGottenSuccesfully_Void()
        {
            List<Category> categories = new List<Category>();
            List<SubCategory> subCategories = new List<SubCategory>();
            Category category = new Category(1, "category");
            SubCategory subCat = new SubCategory(1, "subCategory");
            subCategories.Add(subCat);
            category.AddToList(subCategories);
            categories.Add(category);

            FakeCategoryDB fakeRepo = new FakeCategoryDB(categories);

            CategoryManager gameManager = new CategoryManager(fakeRepo);

            List<SubCategory> SubCat = gameManager.GetAllSubCat(1);



            Assert.IsTrue(categories.Contains(category));
            Assert.AreEqual(subCategories[0], SubCat[0]);
        }
    }
}
