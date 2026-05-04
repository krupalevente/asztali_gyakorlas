using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CBRadio
{
    class Bejegyzes
    {
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int AdasDb { get; set; }
        public string Nev { get; set; }
    }

    class Program
    {
        static int AtszamolPercre(int ora, int perc)
        {
            return ora * 60 + perc;
        }

        static void Main(string[] args)
        {
       
            List<Bejegyzes> lista = new List<Bejegyzes>();
            string[] sorok = File.ReadAllLines("cb.txt");

            for (int i = 1; i < sorok.Length; i++)
            {
                string[] m = sorok[i].Split(';');
                lista.Add(new Bejegyzes
                {
                    Ora = int.Parse(m[0]),
                    Perc = int.Parse(m[1]),
                    AdasDb = int.Parse(m[2]),
                    Nev = m[3]
                });
            }

       
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Bejegyzesek szama: {lista.Count}");

          
            Console.WriteLine("4. feladat:");
            bool van4 = false;
            foreach (var b in lista)
            {
                if (b.AdasDb == 4)
                {
                    van4 = true;
                    break;
                }
            }
            Console.WriteLine(van4 ? "Van ilyen bejegyzes." : "Nincs ilyen bejegyzes.");

        
            Console.WriteLine("5. feladat:");
            Console.Write("Adja meg egy sofor nevet: ");
            string nev = Console.ReadLine();

            int osszes = lista
                .Where(b => b.Nev == nev)
                .Sum(b => b.AdasDb);

            if (osszes == 0)
                Console.WriteLine("Nincs ilyen nevu sofor!");
            else
                Console.WriteLine($"{nev} osszesen {osszes} adast inditott.");
       
            Console.WriteLine("8. feladat:");
            int soforokSzama = lista
                .Select(b => b.Nev)
                .Distinct()
                .Count();
            Console.WriteLine($"Soforok szama: {soforokSzama}");
            
            Console.WriteLine("9. feladat:");
            var maxSofor = lista
                .GroupBy(b => b.Nev)
                .Select(g => new
                {
                    Nev = g.Key,
                    Osszes = g.Sum(x => x.AdasDb)
                })
                .OrderByDescending(x => x.Osszes)
                .First();

            Console.WriteLine($"{maxSofor.Nev} {maxSofor.Osszes} adast inditott.");
        }
    }
}
