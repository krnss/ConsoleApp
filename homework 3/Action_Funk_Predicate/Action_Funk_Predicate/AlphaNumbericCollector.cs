using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Funk_Predicate
{
    class AlphaNumbericCollector
    {
        List<string> alphaNumbericCollector = new List<string>();

        public void Add(string s)
        {
            alphaNumbericCollector.Add(s);
        }
    }
}
