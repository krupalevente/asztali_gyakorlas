using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toto_cshap
{
    class Fordulo
    {
        public int Ev;
        public int Het;
        public int ForduloSzam;
        public int T13p1;
        public int Ny13p1;
        public string Eredmenyek;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2. feladat");

            List<Fordulo> lista = new List<Fordulo>();

            var sorok = File.ReadAllLines("toto.txt").Skip(1);

            foreach (var sor in sorok)
            {
                var adatok = sor.Split(';');

                lista.Add(new Fordulo
                {
                    Ev = int.Parse(adatok[0]),
                    Het = int.Parse(adatok[1]),
                    ForduloSzam = int.Parse(adatok[2]),
                    T13p1 = int.Parse(adatok[3]),
                    Ny13p1 = int.Parse(adatok[4]),
                    Eredmenyek = adatok[5]
                });
            }

            Console.WriteLine("3. feladat");
            Console.WriteLine($"Fordulók száma: {lista.Count}");

            Console.WriteLine("4. feladat");
            int telitalalatDb = lista.Sum(x => x.T13p1);
            Console.WriteLine($"Telitalálatos szelvények száma: {telitalalatDb}");

            Console.WriteLine("5. feladat");
            var telitalalatos = lista.Where(x => x.T13p1 > 0 && x.Ny13p1 > 0);

            long osszeg = 0;
            int db = 0;

            foreach (var f in telitalalatos)
            {
                osszeg += (long)f.T13p1 * f.Ny13p1;
                db++;
            }

            long atlag = osszeg / db;
            Console.WriteLine($"Átlag nyeremény: {atlag}");

            // 6. feladat
            Console.WriteLine("6. feladat");

            var max = lista.Where(x => x.Ny13p1 > 0).OrderByDescending(x => x.Ny13p1).First();
            var min = lista.Where(x => x.Ny13p1 > 0).OrderBy(x => x.Ny13p1).First();

            Console.WriteLine("Legnagyobb nyeremény:");
            Console.WriteLine($"{max.Ev};{max.Het};{max.ForduloSzam};{max.T13p1};{max.Ny13p1}");

            Console.WriteLine("Legkisebb nyeremény:");
            Console.WriteLine($"{min.Ev};{min.Het};{min.ForduloSzam};{min.T13p1};{min.Ny13p1}");

        }
    }
}
