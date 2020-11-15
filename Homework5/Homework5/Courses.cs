using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Courses
    {
        public int CoursesID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeatherID { get; set; }

        public override string ToString()
        {
            return $"ID: {CoursesID.ToString("000")}; Name: {Name}; Description: {Description}; TeatherID: {TeatherID}";
        }
    }
}
