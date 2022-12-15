using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SubCategory
    {
        public string Name { get; private set; }
        public int id { get; private set; }
        [JsonConstructor]
        public SubCategory(int id, string catName)
        {
            this.Name = catName;
            this.id = id;
        }
        public override string ToString()
        {
           // return $"{id}-{Name}";
            return $"{Name}";
        }
    }
}
