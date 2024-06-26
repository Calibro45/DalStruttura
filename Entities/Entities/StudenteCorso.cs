using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class StudenteCorso
    {
        public Guid Uid { get; set; }
        public Student Student { get; set; }
        public Corso Corso { get; set; }

        public StudenteCorso() { }

        public StudenteCorso(Guid uid, Student s, Corso c)
        {
            Uid = uid;
            Student = s;
            Corso = c;
        }
    }
}
