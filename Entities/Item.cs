using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entities
{
    public class Item
    {
        
        public int id { get; private set; }

        public string name { get; private set; }

        public int itemId { get; private set;  }

        public string subCategory { get; private set;  }

        public string category { get; private set;}
        
        public double price { get; private set; }
        
        public UnitType unit { get; private set; }

        public int amount { get; private set; }

        public Byte[] image { get; private set; }

        public string description { get; private set; }

        public Item(string name, string SubCategory, string Category, double price, UnitType unit, int amount, Byte[] image, string description)
        {
            this.name = name;   
            this.unit = unit;
            this.price = price;
            this.category = Category;
            this.price = price;
            this.subCategory = SubCategory;
            this.image = image;
            this.amount = amount;
            this.description = description;
        }
        public Item(int id, string name, string SubCategory, string Category, UnitType Unit, double price,int amount, Byte[] image, string description)
        {
            this.id = id;
            this.name = name;
            this.subCategory = SubCategory;
            this.category = Category;
            this.unit = unit;
            this.price = price;
            this.image = image;
            this.amount = amount;
            this.description = description;
        }   


    }
}
