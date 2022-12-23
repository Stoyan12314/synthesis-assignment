using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface ICreateItemManager
    {
        public bool CreateItem(Item item);
    }
}
