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
        private string ConnectionString = "Data Source=ANDREA;Initial Catalog=Universita;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public List<Student> GetAllStudent()
        {
            // select * from studenti
            return new List<Student>();
        }
        public Student GetStudent(Guid id)
        {
            return new Student();
        }
        public void AddStudent(Student s)
        {
            if (GetStudent(s.UID) != null)
            {
                UpdateStudent(s);
            }
            else
            {
                InsertStudent(s);
            }
            
        }
        public void DeleteStudent(Guid id)
        {
            // Delete a student from DB
        }
        private void InsertStudent(Student s)
        {
            // Update student to DB
            
        }
        private void UpdateStudent(Student s)
        {
            // Update student to DB
        }

    }
}
