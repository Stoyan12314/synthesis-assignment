using BuisnessLogicLayer;
using DataAccessLayer.Interfaces;
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
    public class BonusCardManagerTest
    {
        [TestMethod]
        public void AddPointsToCard_PointsAddedSuccesfully_Void()
        {
            Dictionary<int, double> points=new Dictionary<int, double>();
        
            

            FakeBonusCardDB fakeRepo = new FakeBonusCardDB(points);

            BonusCardManager bonusCardManager = new BonusCardManager(fakeRepo);

            bool check = bonusCardManager.AddPointsToCard(1,900);

            Assert.IsTrue(points.ContainsKey(1));
          
            Assert.IsTrue(check);

        }
        [TestMethod]
        public void SpentPointsFromCard_PointsSpendSuccesfully_Void()
        {
            Dictionary<int, double> points = new Dictionary<int, double>();
            points.Add(1, 385);


            FakeBonusCardDB fakeRepo = new FakeBonusCardDB(points);

            BonusCardManager bonusCardManager = new BonusCardManager(fakeRepo);

            int takenUserPoint = bonusCardManager.GetPointsFromCard(1);

            double check = bonusCardManager.SpentPointsFromCard(1,385);

            Assert.IsTrue(points.ContainsKey(1));
            Assert.AreNotSame(385, takenUserPoint);
        }
        [TestMethod]
        public void GetPointsFromCard_PointsGottenSuccesfully_Void()
        {
            Dictionary<int, double> points = new Dictionary<int, double>();
            points.Add(1, 385);


            FakeBonusCardDB fakeRepo = new FakeBonusCardDB(points);

            BonusCardManager bonusCardManager = new BonusCardManager(fakeRepo);

            int pointsFromCard = bonusCardManager.GetPointsFromCard(1);

            Assert.AreEqual(pointsFromCard, 385);
            
        }

    }
}
