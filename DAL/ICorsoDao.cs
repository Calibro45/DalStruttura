using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DAL
{
    public interface ICorsoDao
    {
        List<Corso> GetAllCorsi();
        Corso GetCorso(Guid uid);
        Corso AddCorso(Corso c); 
        Corso DeleteCorso(Guid uid);
    }
}
