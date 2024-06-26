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
        #region stringa connessione DB
        private string ConnectionString = "Data Source=ANDREA;Initial Catalog=Universita;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        #endregion

        public List<Student> GetAllStudent()
        {
            // select * from studenti
            var listaStudenti = new List<Student>();

            var query = "select * from Studenti";

            using ( var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var student = new Student(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                        );

                    listaStudenti.Add(student);
                }

                connection.Close();
            }

            return listaStudenti;
        }
        public Student GetStudent(Guid id)
        {
            Student student = null;

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
                    student = new Student(
                        id.ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                        );
                }

                connection.Close();
            }

            return student;
        }

        public void AddStudent(Student s)
        {
            var student = GetStudent(s.UID);

            if (student != null)
            {
                UpdateStudent(s);
            }
            else
            {
                InsertStudent(s);
            }
        }

        public bool DeleteStudent(Guid id)
        {
            // Delete a student from DB
            var query = $"delete from Studenti where UID = '{id}'";

            int rows = 0;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand (query, connection);
                rows = command.ExecuteNonQuery();

                connection.Close();
            }

            if (rows == 0)
                return false;

            return true;
        }

        private void InsertStudent(Student s)
        {
            var query = $"insert into studenti " +
                $"values ('{s.UID}', '{s.Matricola}', '{s.Nome}', '{s.Cognome}', '{s.CodiceFiscale}');";
            
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Method <c>UpdateStudent()</c> Update a student with new values
        /// </summary>
        /// <param name="s">The istance of class <c>Student</c></param>
        private void UpdateStudent(Student s)
        {
            var query = $"update studenti set " + 
                $"Matricola = '{s.Matricola}', " +
                $"Nome = '{s.Nome}', " +
                $"Cognome = '{s.Cognome}', " +
                $"CodiceFiscale = '{s.CodiceFiscale}' " +
                $"where UID = '{s.UID}';";
            
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(query , connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

    }
}
