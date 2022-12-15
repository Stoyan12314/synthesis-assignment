using BuisnessLogicLayer;
using Entities;
using Entities.Enum;
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
    public class OrderManagerTest
    {
        [TestMethod]
        public void CreateOrder_OrderCreatedSuccesfully_Void()
        {
            byte[] bytes = { 0, 0, 0, 25 };
           
            Order order = new Order(1, 1, DateTime.Now, DateTime.Now.AddDays(1), DeliveryOption.PickUp, DeliveryStatus.InProgress,"Marconilan 75", "Eindhoven", "1235NE", "The Netherlands");
            List<Order> orders = new List<Order>();
           

            FakeOrderDB fakeRepo = new FakeOrderDB(orders);

            OrderManager orderManager = new OrderManager(fakeRepo);

          
            bool check = orderManager.CreateOrder(order);


            Assert.IsFalse(check);

        }

        [TestMethod]
        public void GetOrder_OrderGottenSuccesfully_Void()
        {
           
          //  (int orderId, int userId, DateTime OrderDate, DateTime DeliveryDate, DeliveryOption DeliveryOption, DeliveryStatus DeliveryStatus, string shipAddress, string shipCity, string shipPostCode, string shipCountry)
            Order order = new Order(1, 1, DateTime.Now, DateTime.Now.AddDays(1), DeliveryOption.PickUp, DeliveryStatus.InProgress, "Marconilan 75", "Eindhoven", "1235NE", "The Netherlands");
            List<Order> orders = new List<Order>();
            orders.Add(order);

            FakeOrderDB fakeRepo = new FakeOrderDB(orders);

            OrderManager orderManager = new OrderManager(fakeRepo);


            Order gottenOrder = orderManager.GetOrder(order.OrderId);


            Assert.AreEqual(order.OrderId, gottenOrder.OrderId);

        }

        [TestMethod]
        public void GetOrders_OrdersGottenSuccesfully_Void()
        {
            
            Order order = new Order(1, 1, DateTime.Now, DateTime.Now.AddDays(1), DeliveryOption.PickUp, DeliveryStatus.InProgress, "Marconilan 75", "Eindhoven", "1235NE", "The Netherlands");
            List<Order> orders = new List<Order>();
            orders.Add(order);

            FakeOrderDB fakeRepo = new FakeOrderDB(orders);

            OrderManager orderManager = new OrderManager(fakeRepo);


            List<Order> gottenOrder = orderManager.GetOrders(1);


            Assert.AreEqual(order.OrderId, gottenOrder[0].OrderId);

        }

        [TestMethod]
        public void UpdateOrder_OrdersUpdatedSuccesfully_Void()
        {
           
            Order order = new Order(1, 1, DateTime.Now, DateTime.Now.AddDays(1), DeliveryOption.PickUp, DeliveryStatus.InProgress, "Marconilan 75", "Eindhoven", "1235NE", "The Netherlands");
            List<Order> orders = new List<Order>();
            orders.Add(order);

            FakeOrderDB fakeRepo = new FakeOrderDB(orders);

            OrderManager orderManager = new OrderManager(fakeRepo);


            orderManager.UpgradeOrder(DeliveryStatus.Delivered,order.OrderId);
            Order gottenOrder = orderManager.GetOrder(order.OrderId); 


            Assert.AreEqual(gottenOrder.DeliveryStatus, gottenOrder.DeliveryStatus);

        }
    }
}
