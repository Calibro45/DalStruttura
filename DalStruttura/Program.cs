using DAL;
namespace DalStruttura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DAL");

            var dal = new DaoStudent();

            var student = dal.GetStudent(new Guid("F19A8573-5348-4155-9900-014EBB75156B"));

            Console.WriteLine($"Mi chiamo {student.Name} matricola {student.Matricola}");

            var listaStudenti = dal.GetAllStudent();

            foreach (var s in listaStudenti)
            {
                Console.WriteLine($"Mi chiamo {s.Name} matricola {s.Matricola}");
            }

        }
    }
}
