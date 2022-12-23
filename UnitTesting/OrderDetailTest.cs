using BuisnessLogicLayer;
using Entities.Enum;
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
    public class OrderDetailTest
    {
        [TestMethod]
        public void CreateOrder_OrderCreatedSuccesfully_Void()
        {
            List<Order> fakerOrders = new List<Order>();
            List<OrderedItem> orderedItems = new List<OrderedItem>();
            byte[] bytes = { 0, 0, 0, 25 };
            Item item = new Item(1, "test", new SubCategory(1, "testSubCat"), new Category(1, "testCat"), Entities.Enum.UnitType.grams, 3, 1, bytes, "description");
            orderedItems.Add(new OrderedItem(item, 3));
            Order order = new Order(1, 1, orderedItems, DateTime.Now, DateTime.Now.AddDays(1), DeliveryOption.PickUp, DeliveryStatus.InProgress, "Marconilan 75", "Eindhoven", "1235NE", "The Netherlands");
            fakerOrders.Add(order);


            FakeOrderDB fakeRepo = new FakeOrderDB(fakerOrders);

            OrderDetail orderManager = new OrderDetail(fakeRepo);


            List<OrderedItem> check = orderManager.GetOrderedItems(1);

            Assert.AreSame(orderedItems,check);
            Assert.IsNotNull(check);

        }
    }
}
