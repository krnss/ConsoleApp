using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string s1= "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            string s2= "Jason Puncheon, 26 / 06 / 1986; Jos Hooiveld, 22 / 04 / 1983; Kelvin Davis, 29 / 09 / 1976; Luke Shaw, 12 / 07 / 1995; Gaston Ramirez, 02 / 12 / 1990; Adam Lallana, 10 / 05 / 1988";
            string s3= "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            //11111111111111111111111111111111111111111
            List<string> ss1 = s1.Split(',').ToList();
            int i = 1;
            ss1=ss1.Select(s => s = $"{i++}.{s}").ToList();

            string ansver1 = "";
            foreach (var item in ss1)            
                ansver1 += item + " , ";            
            Console.WriteLine(ansver1);
            
            //222222222222222222222222222222222222222222222222222
            List<string> ss2 = s2.Split(';').ToList();
            List<Player> players = ss2.Select(s => new Player(s)).ToList();
            IEnumerable<Player> sortedPlayers = players.OrderBy(p => p.birthday);

            string ansver2 = "";
            foreach (var item in sortedPlayers)
            {
                ansver2 += item+" "+item.ShowAge()+"\n";
            }
            Console.WriteLine(ansver2);


            //333333333333333333333333333333333333333333333333333
            List<string> ss3 = s3.Split(',').ToList();
            List<Time> times = ss3.Select(s => new Time(s)).ToList();
            List<int> timesInSecond = times.Select(t => t.TimeInSecond()).ToList();
            Time ansver3 = new Time(Convert.ToInt32(timesInSecond.Average()));
            Console.WriteLine(ansver3);

            Console.ReadLine();
        }

        
    }
}
