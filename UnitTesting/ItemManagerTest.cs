using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using DataAccessLayer.Interfaces;
using BuisnessLogicLayer;
using UnitTesting.FakeDataAccessLayer;

namespace UnitTesting
{
    [TestClass]
    public class ItemManagerTest 
    {
        [TestMethod]
        public void CreateItem_ItemCreatedSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1,"testSubCat"), new Category(1,"testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);

            FakeItemDB fakeRepo = new FakeItemDB(items);

            ItemManager itemManager = new ItemManager(fakeRepo);

            bool check = itemManager.CreateItem(item);


            Assert.IsFalse(check);

        }

        [TestMethod]
        public void DeleteItem_ItemDeletedSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);

            FakeItemDB fakeRepo = new FakeItemDB(items);

            ItemManager itemManager = new ItemManager(fakeRepo);

            bool check = itemManager.DeleteItem(item.id);


            Assert.IsTrue(check);

        }

        [TestMethod]
        public void GetAllItems_ItemsGottenSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);

            FakeItemDB fakeRepo = new FakeItemDB(items);

            ItemManager itemManager = new ItemManager(fakeRepo);

            List<Item> gottenItems = itemManager.GetAllItems();


            Assert.AreEqual(gottenItems[0], items[0]);

        }


        [TestMethod]
        public void GetItemWithId_ItemGottenSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);

            FakeItemDB fakeRepo = new FakeItemDB(items);

            ItemManager itemManager = new ItemManager(fakeRepo);

            Item gottenItem = itemManager.GetItemWith(item.id);


            Assert.AreEqual(item, gottenItem);

        }

        [TestMethod]
        public void GetItemWithCategory_ItemGottenSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);

            FakeItemDB fakeRepo = new FakeItemDB(items);

            ItemManager itemManager = new ItemManager(fakeRepo);

            List<Item> gottenItem = itemManager.GetItemWithCategory("testCat");


            Assert.AreEqual(item.category.category, gottenItem[0].category.category);

        }


        [TestMethod]
        public void GetItemWithSubCategory_ItemGottenSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);

            FakeItemDB fakeRepo = new FakeItemDB(items);

            ItemManager itemManager = new ItemManager(fakeRepo);

            List<Item> gottenItem = itemManager.GetItemWithSubCategory("testSubCat");


            Assert.AreEqual(item.subCategory.Name, gottenItem[0].subCategory.Name);

        }

        [TestMethod]
        public void UpdateItem_ItemUpdatedSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
            List<Item> items = new List<Item>();
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            Item edditedItem = new Item(1, "testttttt", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            items.Add(item);


            FakeItemDB fakeRepo = new FakeItemDB(items);
            ItemManager itemManager = new ItemManager(fakeRepo);
            itemManager.EditItem(1, edditedItem);
            Item gottenItem = itemManager.GetItemWith(1);


            Assert.AreEqual(gottenItem, edditedItem);

        }
    }
}