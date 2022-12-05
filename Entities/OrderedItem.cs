using System;
using System.Collections.Generic;
using System.Text;
using Entities;
namespace BuisnessLogicLayer
{
    public class OrderedItem
    {
        private int Quantity;
        private Item item;

        public OrderedItem(Item item, int Quantity)
        {
            this.item = item;
            this.Quantity= Quantity;
        }
        public OrderedItem( Item item)
        {
            this.item = item;
            this.Quantity = 1;
        }
    }
}
