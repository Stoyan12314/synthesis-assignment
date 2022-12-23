using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer
{
    public class BonusCardManager : IBonusCard
    {
      

        private IDBBonusCard IDBBonus;
        public BonusCardManager(IDBBonusCard IDBBonus)
        {
            this.IDBBonus = IDBBonus;
        }

      

        public bool AddPointsToCard(int userId, double price)
        {
            
           int points = (int)price;
           return  IDBBonus.AddPointsToCard(userId, points);
        }

      

        public int GetPointsFromCard(int userId)
        {
           return IDBBonus.GetPointsFromCard(userId);
        }

      

        public double SpentPointsFromCard(int userId, double total)
        {
            int points = IDBBonus.GetPointsFromCard(userId);
            if (points < 100)
            {
                return -1;
            }
            else
            {
                int number = points;
                int euro = number / 100;
               
               
                IDBBonus.SpentPointsFromCard(userId, euro * 100);

                double returnVal = total - euro;
                return returnVal;
            }
           
           
        }
    }
}
