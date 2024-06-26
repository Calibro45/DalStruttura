using DAL;
using Entities.Entities;
namespace DalStruttura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dal = new DaoStudent();
            var cDao = new CorsoDao();
            var scDao = new StudenteCorsoDao();

            var listaStudenti = dal.GetAllStudent();
            var listaCorsi = cDao.GetAllCorsi();
            var listaStudentiCorso = scDao.GetAllStudentiCorsi();

            foreach (var s in listaStudenti)
            {
                Console.WriteLine($"Mi chiamo {s.Nome} Cognome {s.Cognome} CodFisc {s.CodiceFiscale} matricola {s.Matricola}");
            }

            foreach (var c in listaCorsi)
            {
                Console.WriteLine(c.Nome);
            }

            foreach (var sc in listaStudentiCorso)
            {
                Console.WriteLine($"Lo studente {sc.Student.Nome} {sc.Student.Cognome}, frequenta il corso {sc.Corso.Nome}");
            }

            


        }
    }
}
