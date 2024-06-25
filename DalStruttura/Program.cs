using DAL;
using Entities.Entities;
namespace DalStruttura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DAL");

            var dal = new DaoStudent();

            var student = dal.GetStudent(new Guid("F19A8573-5348-4155-9900-014EBB75156B"));

            Console.WriteLine($"Mi chiamo {student.Nome} matricola {student.Matricola}");

            //var st = new Student()
            //{
            //    UID = Guid.NewGuid(),
            //    Matricola = "Pl325",
            //    Nome = "Pluto",
            //    Cognome = "Plutarco",
            //    CodiceFiscale = "PLO35H"
            //};

            //dal.AddStudent(st);
            //dal.DeleteStudent(new Guid("02F7CB7F-7FB6-4B07-8A14-A3C1FE971397"));

            var sUp = dal.GetStudent(new Guid("4B4D853D-2DBC-41AC-A235-54E813ACD566"));
            sUp.Cognome = "Pippus";
            dal.AddStudent(sUp);

            var listaStudenti = dal.GetAllStudent();

            foreach (var s in listaStudenti)
            {
                Console.WriteLine($"Mi chiamo {s.Nome} Cognome {s.Cognome} CodFisc {s.CodiceFiscale} matricola {s.Matricola}");
            }


        }
    }
}
