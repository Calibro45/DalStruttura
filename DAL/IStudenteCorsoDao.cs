using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStudenteCorsoDao
    {
        List<StudenteCorso> GetAllStudentiCorsi();
        StudenteCorso GetStudenteCorso(Guid uid);
        void AddStudenteCorso(StudenteCorso sc);
        void DeleteStudenteCorso(Guid uid);
    }
}
