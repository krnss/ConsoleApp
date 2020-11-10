using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        delegate void MyDeledate(string s);
        static void Main(string[] args)
        {
            StringCollector stringCollector = new StringCollector();
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            MyDeledate myDeledate;

            while (true)
            {
                string s = Console.ReadLine();
                myDeledate = stringCollector.Add;
                if (Regex.IsMatch(s, "[0-9]"))
                {
                    myDeledate = alphaNumbericCollector.Add;
                }
                myDeledate(s);
            }
        }
    }
}
