using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Student
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Matricola { get; set; }

        public Student() { }

    }
}
