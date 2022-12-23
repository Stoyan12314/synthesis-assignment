using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IDBBonusCard
    {
        public bool AddPointsToCard(int userId, double price);
        public int GetPointsFromCard(int userId);

        public void SpentPointsFromCard(int userId, double total);
    }
}
