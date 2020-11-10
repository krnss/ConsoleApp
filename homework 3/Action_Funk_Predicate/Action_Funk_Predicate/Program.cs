using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Action_Funk_Predicate
{
    class Program
    {
        delegate void Action<T>(T s);
        static void Main(string[] args)
        {
            StringCollector stringCollector = new StringCollector();
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            Action<string> myAction;
            while (true)
            {
                string s = Console.ReadLine();
                myAction = stringCollector.Add;
                if (Regex.IsMatch(s, "[0-9]"))
                {
                    myAction = alphaNumbericCollector.Add;
                }
                myAction(s);
            }
        }
    }
}
