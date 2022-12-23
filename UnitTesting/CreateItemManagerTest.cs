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
    public class CreateItemManagerTest
    {
        [TestMethod]
        public void CreateItem_ItemCreatedSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);

            FakeItemDB fakeRepo = new FakeItemDB(items);

            CreateItemManager itemManager = new CreateItemManager(fakeRepo);

            bool check = itemManager.CreateItem(item);

            Assert.IsTrue(items.Contains(item));
            Assert.IsFalse(check);

        }
    }
}
