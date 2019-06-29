using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class Account
    {
        public string FirsName { get; private set; }
        public string LastName { get; private set; }
        public double Balance { get; private set; }
        public string AccountNumber { get; private set; }

        public Account(string fn, string ln, string account, double b) {
            FirsName = fn;
            LastName = ln;
            AccountNumber = account;
            Balance = b;
        }


    }
}
