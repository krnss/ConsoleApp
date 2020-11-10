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
        private static event MyDeledate MyEvent;
        static void Main(string[] args)
        {
            StringCollector stringCollector = new StringCollector();
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();

            while (true)
            {
                string s = Console.ReadLine();
                MyEvent = stringCollector.Add;
                if (Regex.IsMatch(s, "[0-9]"))
                {
                    MyEvent = alphaNumbericCollector.Add;
                }
                MyEvent(s);
            }
        }
    }
}
