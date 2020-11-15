using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"ID: {StudentID.ToString("000")};" +
                $"Name: {Name};" +
                $"Surname: {Surname};" +
                $"Email: {Email};";

        }
    }

}
