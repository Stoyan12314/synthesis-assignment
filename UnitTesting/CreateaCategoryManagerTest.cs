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
    public class CreateaCategoryManagerTest
    {
        [TestMethod]
        public void AddCategory_CategoryAddedSuccesfully_Void()
        {
            List<Category> categories = new List<Category>();
            Category category = new Category(1, "category");

            FakeCategoryDB fakeRepo = new FakeCategoryDB(categories);

            CreateCategoryManager createCategoryManager = new CreateCategoryManager(fakeRepo);

            bool check = createCategoryManager.CreateCategory("category");

            Assert.IsFalse(categories.Contains(category));
            Assert.IsTrue(check);

        }
    }
}
