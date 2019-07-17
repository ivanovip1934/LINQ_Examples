using System;

namespace LINQ_Examples
{
    class InStockStatus
    {
        public int ItemNumber { get; set; }
        public bool InStock { get; set; }

        public InStockStatus(int itemNumber, bool inStock) {
            ItemNumber = itemNumber;
            InStock = inStock;
        }

    }
}
