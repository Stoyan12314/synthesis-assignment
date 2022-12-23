
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BuisnessLogicLayer
{
    public class OrderedItem
    {
        public int quantity {  set; get; }
        public Item item {  set; get; }

        [JsonConstructor]
        public OrderedItem(Item item, int Quantity)
        {
            this.item = item;
            this.quantity = Quantity;
        }
        public OrderedItem(Item item)
        {
            this.item = item;
            this.quantity = 1;
        }
    }
}
