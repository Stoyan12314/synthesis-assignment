using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IBonusCard
    {
        public bool AddPointsToCard(int userId, double price);
        public int GetPointsFromCard(int userId);

        public double SpentPointsFromCard(int userId, double total);
    }
}
