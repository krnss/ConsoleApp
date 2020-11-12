using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Player
    {
       public string name;
       public DateTime birthday;

        public Player(string name,DateTime birthday)
        {
            this.name = name;
            
            this.birthday = birthday;
        }
        public Player(string name,  string birthday)
        {
            this.name = name;           
            this.birthday = new DateTime(
                int.Parse(birthday.Split('/')[2]),
                int.Parse(birthday.Split('/')[1]),
                int.Parse(birthday.Split('/')[0]));
        }
        public Player(string info)
        {
            string[] s = info.Split(',');
            this.name = s[0];
            
            this.birthday = new DateTime(
                int.Parse(s[1].Split('/')[2]),
                int.Parse(s[1].Split('/')[1]),
                int.Parse(s[1].Split('/')[0]));
        }

        public int ShowAge()
        {
            if (DateTime.Now.Month - birthday.Month > 0)
            {
                return (DateTime.Now.Year - birthday.Year);
            }
            else
            {
                if (DateTime.Now.Day - birthday.Day > 0)
                {
                    return (DateTime.Now.Year - birthday.Year);
                }
                else
                {
                    return (DateTime.Now.Year - birthday.Year)+1;
                }
            }
        }
        public override string ToString()
        {
            return $"{name},{birthday.ToString("d")};"; 
        }
    }
}
