using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Email e = new Email();
            e.SendEmail("SUBJECT", "BODY", "TO");
        }
    }
}
