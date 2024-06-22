using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DaoStudent : IDaoStudent
    {
        public List<Student> GetAllStudent()
        {
            return new List<Student>();
        }
        public List<Student> GetStudentsX(Func<Student, bool> predicate)
        {
            return new List<Student>();
        }
        public void AddStudent()
        {
            // add student to DB
        }
        public void UpdateStudent(Guid id)
        {
            // Update student to DB
            
        }
        public void DeleteStudent(Guid id)
        {
            // Delete a student from DB
        }
    }
}
