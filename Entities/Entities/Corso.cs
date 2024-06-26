using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Corso
    {
        public Guid Uid { get; set; }
        public string Nome { get; set; }
        public Corso() { }
        public Corso(Guid uid, string nome)
        {
            Uid = uid;
            Nome = nome;
        }

    }
}
