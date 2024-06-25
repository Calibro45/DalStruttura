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
        public string ?Matricola { get; set; }
        public string ?Nome { get; set; }
        public string ?Cognome { get; set; }
        public string ?CodiceFiscale { get; set; }

        public Student() 
        {

        }

    }
}
