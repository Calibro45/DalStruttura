using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDaoStudent
    {
        List<Student> GetAllStudent();
        List<Student> GetStudentsX(Func<Student, bool> predicate);
        void AddStudent();
        void UpdateStudent(Guid id);
        void DeleteStudent(Guid id);
    }
}
