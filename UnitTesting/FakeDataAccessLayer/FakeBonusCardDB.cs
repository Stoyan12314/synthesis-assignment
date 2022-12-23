using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities;
namespace UnitTesting.FakeDataAccessLayer
{
    public class FakeBonusCardDB : IDBBonusCard
    {
        private Dictionary<int, double> IDBBonus;
        public FakeBonusCardDB(Dictionary<int, double> IDBBonus)
        {
                this.IDBBonus= IDBBonus;
        }
        public bool AddPointsToCard(int userId, double price)
        {

            int points = (int)price;
            IDBBonus.Add(userId, points);
            return true;
           
        }



        public int GetPointsFromCard(int userId)
        {
         
            int points = (int)IDBBonus[userId];
            return points;
        }



      
        public void SpentPointsFromCard(int userId, double total)
        {
            int points = GetPointsFromCard(userId);
            if (points < 100)
            {
             
            }
            else
            {
               
                int euro = points / 100;

                int value = (int)IDBBonus[userId] - euro;
                IDBBonus.Remove(userId);
                IDBBonus.Add(userId, value);



                double returnVal = total - euro;
              
            }


        }


    }
}
