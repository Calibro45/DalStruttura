using Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudenteCorsoDao : IStudenteCorsoDao
    {
        #region connection string
        private string ConnectionString = "Data Source=ANDREA;Initial Catalog=Universita;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        #endregion
        public void AddStudenteCorso(StudenteCorso sc)
        {
            var studenteCorso = GetStudenteCorso(sc.Uid);

            if (studenteCorso != null)
            {
                UpdateStudenteCorso(sc);
            }
            else
            {
                InsertStudenteCorso(sc);
            }
        }

        public void DeleteStudenteCorso(Guid uid)
        {
            var query = $"delete from studenti_corsi where studente_corso_uid = '{uid}'";

            using (var cn = new SqlConnection(ConnectionString))
            {

                cn.Open();

                var cm = new SqlCommand(query, cn);
                var r = cm.ExecuteNonQuery();

                cn.Close();
            }

        }

        public List<StudenteCorso> GetAllStudentiCorsi()
        {
            var listaStudentiCorso = new List<StudenteCorso>();

            var query = $"select " +
                $"s.UID as studente_id, " +
                $"s.Matricola, " +
                $"s.Nome, " +
                $"s.Cognome, " +
                $"s.CodiceFiscale, " +
                $"c.UID as corso_id, " +
                $"c.Nome as nome_corso, " +
                $"sc.studente_corso_uid as studente_corso_id " +
                $"from studenti s " +
                $"join studenti_corsi sc on s.UID = sc.studente_id " +
                $"join corsi c on c.UID = sc.corso_id";

            Console.WriteLine(query);

            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();

                var cm = new SqlCommand(query, cn);
                var reader = cm.ExecuteReader();

                while (reader.Read())
                {
                    var s = new Student(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                        );

                    var c = new Corso(
                        new Guid(reader[5].ToString()),
                        reader[6].ToString()
                        );

                    var sc = new StudenteCorso(new Guid(reader[7].ToString()), s, c);

                    listaStudentiCorso.Add(sc);
                }

                cn.Close();
            }

            return listaStudentiCorso;
        }

        public StudenteCorso GetStudenteCorso(Guid uid)
        {
            throw new NotImplementedException();
        }

        private void UpdateStudenteCorso(StudenteCorso sc) 
        {
            
        }

        private void InsertStudenteCorso(StudenteCorso sc) 
        {

        }
    }
}
