using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class Item
    {
        public string Name { get; set; }
        public int ItemNumber { get; set; }

        public Item(string _name, int _itemnumber) {
            Name = _name;
            ItemNumber = _itemnumber;
        }

    }
}
