using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace baza_danych_net
{

    public class Samochod
    {
        public int ID { set; get; }
        public string Marka { set; get; }
        public string Model { set; get; }
    }

    public class BazaSamochodow : DbContext
    {
        public virtual DbSet<Samochod> Samochods { get; set; }
    }


    class Program1
    {
        static void Main(string[] args)
        {

            // Dodanie
            var context = new BazaSamochodow();
            var x = new Samochod { Marka = "Toyota", Model = "Yaris" };
            context.Samochods.Add(x);
            context.SaveChanges();

            // Wyswietlenie
            var lista_samochodow = context.Samochods.SqlQuery("select * from Samochods ").ToList<Samochod>();
            foreach (var s in lista_samochodow)
                Console.WriteLine("ID: {0}, Marka: {1}, Model: {2}", s.ID, s.Marka, s.Model);
            Console.Read();

        }
    }
}