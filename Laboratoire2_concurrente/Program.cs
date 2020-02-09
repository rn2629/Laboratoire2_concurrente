using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratoire2_concurrente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title="HelpDesk Virtuelle";
            HelpDesk helpDeskRun = new HelpDesk();
            helpDeskRun.Affichage();
        }
 
    }
}
