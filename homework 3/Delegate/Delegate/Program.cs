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
            MyDeledate myDeledate2;

            myDeledate = stringCollector.Add;
            myDeledate2 = alphaNumbericCollector.Add;

            while (true)
            {
                string s = Console.ReadLine();

                if (Regex.IsMatch(s, "[0-9]"))
                {
                    myDeledate2(s);
                }
                else
                {
                    myDeledate(s);
                }
            }
        }
    }
}
