using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Time
    {
        int minute;
        int secunde;

        public Time(int minute, int secunde)
        {
            this.minute = minute;
            this.secunde = secunde;
        } public Time(int secunde)
        {
            this.minute = secunde/60;
            this.secunde = secunde%60;
        }
        public Time(string info)
        {
            this.minute =int.Parse(info.Split(':')[0]);
            this.secunde = int.Parse(info.Split(':')[1]);
        }

        public int TimeInSecond()
        {
            return minute * 60 + secunde;
        }
        public override string ToString()
        {
            return $"{minute}:{secunde}";
        }
    }
}
