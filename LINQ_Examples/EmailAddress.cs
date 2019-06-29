using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public EmailAddress(string _name, string _address) {
            Name = _name;
            Address = _address;
        }
    }
}
