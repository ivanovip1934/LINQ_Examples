using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class InStockStatus
    {
        public int ItemNumber { get; set; }
        public bool InStock { get; set; }

        public InStockStatus(int _itemnumber, bool _instock) {
            ItemNumber = _itemnumber;
            InStock = _instock;
        }
    }
}
