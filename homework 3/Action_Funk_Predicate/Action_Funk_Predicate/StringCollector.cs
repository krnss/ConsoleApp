using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Funk_Predicate
{
    class StringCollector
    {
        List<string> stringCollector = new List<string>();

        public void Add(string s)
        {
            stringCollector.Add(s);
        }
    }
}
