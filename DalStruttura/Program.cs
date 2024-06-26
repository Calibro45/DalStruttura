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

            var listaStudenti = dal.GetAllStudent();
            var listaCorsi = cDao.GetAllCorsi();

            foreach (var s in listaStudenti)
            {
                Console.WriteLine($"Mi chiamo {s.Nome} Cognome {s.Cognome} CodFisc {s.CodiceFiscale} matricola {s.Matricola}");
            }

            foreach (var c in listaCorsi)
            {
                Console.WriteLine(c.Nome);
            }

            


        }
    }
}
