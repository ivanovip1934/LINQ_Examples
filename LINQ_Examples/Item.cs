using System;

namespace LINQ_Examples
{
    class Item
    {
        public string Name { get; set; }
        public int ItemNumber { get; set; }

        public Item(string name, int itemMumber)
        {
            Name = name;
            ItemNumber = itemMumber;
        }
    }
}
