using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Event
{
    class Program
    {
        delegate void MyDeledate(string s);
        private static event MyDeledate MyEvent1;
        private static event MyDeledate MyEvent2;
        static void Main(string[] args)
        {
            StringCollector stringCollector = new StringCollector();
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();

            MyEvent1 = stringCollector.Add;
            MyEvent2 = alphaNumbericCollector.Add;

            while (true)
            {
                string s = Console.ReadLine();

                if (Regex.IsMatch(s, "[0-9]"))
                {
                    MyEvent2(s);
                }
                else
                {
                    MyEvent1(s);
                }
            }
        }
    }
}
