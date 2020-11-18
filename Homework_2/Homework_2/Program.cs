using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string boo = "boo";
            string hello = "hello";
            MyColection<string> vs = new MyColection<string>();
            vs.Add(hello);
            vs.Add(boo);
            vs.Add("row");

            vs.Remove(boo);

            if (vs.Contains(hello))
            {
                vs.RemoveAt(0);
            }
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
