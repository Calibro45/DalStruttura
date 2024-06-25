using Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var listaStudenti = new List<Student>();

            var query = $"select * from Studenti";

            using ( var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var student = new Student();

                    student.UID = new Guid(reader[0].ToString());
                    student.Matricola = reader[1].ToString();
                    student.Name = reader[2].ToString();
                    student.Surname = reader[3].ToString();
                    student.CodiceFiscale = reader[4].ToString();

                    listaStudenti.Add(student);
                }

                connection.Close();
            }

            return listaStudenti;
        }
        public Student GetStudent(Guid id)
        {
            var student = new Student();
            student.UID = id;

            var query = $"select * from Studenti where UID = '{id}'";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                //Console.WriteLine("State: {0}", connection.State);

                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var matricola = reader[1].ToString();
                    var nome = reader[2].ToString();
                    var cognome = reader[3].ToString();
                    var codiceFiscale = reader[4].ToString();

                    student.Matricola = matricola ?? string.Empty;
                    student.Name = nome ?? string.Empty;
                    student.Surname = cognome ?? string.Empty;
                    student.CodiceFiscale = codiceFiscale ?? string.Empty;
                }

                connection.Close();
            }

            return student;
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
