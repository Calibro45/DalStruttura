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
        Student GetStudent(Guid id);
        void AddStudent(Student s);
        void DeleteStudent(Guid id);
    }
}
