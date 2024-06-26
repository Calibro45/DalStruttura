using Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CorsoDao : ICorsoDao
    {
        #region stringa di connessione
        private string ConnectionString = "Data Source=ANDREA;Initial Catalog=Universita;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        #endregion 

        public List<Corso> GetAllCorsi()
        {
            var listaCorsi = new List<Corso>();

            var query = "select * from corsi";

            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();

                var cm = new SqlCommand(query, cn);
                var rd = cm.ExecuteReader();

                while (rd.Read())
                {
                    var g = new Guid(rd[0].ToString());

                    var c = new Corso(g, rd[1].ToString());

                    listaCorsi.Add(c);  
                }

                cn.Close();
            }

            return listaCorsi;
        }

        public Corso GetCorso(Guid uid)
        {
            Corso c = null;

            var query = $"select * from corsi where UID = '{uid}'";

            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();

                var cm = new SqlCommand(query, cn);
                var rd = cm.ExecuteReader();

                while (rd.Read())
                {
                    var g = new Guid(rd[0].ToString());

                    c = new Corso(g, rd[1].ToString());
                }

                cn.Close();
            }

            return c;
        }

        public Corso AddCorso(Corso c)
        {
            var corso = GetCorso(c.Uid);

            if (corso != null)
            {
                return UpdateCorso(c);
            }
            else
            {
                return InsertCorso(c);
            }
        }

        public Corso DeleteCorso(Guid uid)
        {
            Corso c = null;

            var query = $"delete from corsi where UID = '{uid}'";

            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();

                var cm = new SqlCommand(query, cn);
                var rd = cm.ExecuteReader();

                while (rd.Read()) 
                {
                    var g = new Guid(rd[0].ToString());

                    c = new Corso(g, rd[1].ToString());
                }

                cn.Close();
            }

            return c;
        }

        private Corso UpdateCorso(Corso c)
        {
            var query = $"update corsi set Nome = '{c.Nome}'";

            using(var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();

                var cm = new SqlCommand(query, cn);
                var rows = cm.ExecuteNonQuery();

                cn.Close();
            }

            return c;
        }

        private Corso InsertCorso(Corso c)
        {
            var query = $"insert into corsi values ('{c.Uid}', '{c.Nome}')";

            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();

                var cm = new SqlCommand(query, cn);
                var rows = cm.ExecuteNonQuery();

                cn.Close();
            }

            return c;
        }
    }
}
