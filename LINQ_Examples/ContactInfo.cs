using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class ContactInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public ContactInfo(string _name, string _email, string _phone) {
            Name = _name;
            Email = _email;
            Phone = _phone;
        }
    }
}
