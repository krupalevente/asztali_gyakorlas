using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukkmaraton
{
    class Versenytav
    {
        private string Rajtszam;
        public string Tav
        {
            get
            {
                switch (Rajtszam[0])
                {
                    case 'M': return "Mini";
                    case 'R': return "Rövid";
                    case 'K': return "Közép";
                    case 'H': return "Hosszú";
                    case 'E': return "Pedelec";
                }
                return "Hibás rajtszám";
            }
        }
        public Versenytav(string rajtszam)
        {
            Rajtszam = rajtszam;
        }
    }
    public class Maraton
    {
        public string rajtszam { get; set; }
        public string Kategoria { get; set; }
        public string Nev { get; set; }
        public string egyesulet { get; set; }
        public TimeSpan ido { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Maraton> maraton = new List<Maraton>();
            var file = File.ReadAllLines("bukkm2019.txt").Skip(1);

            foreach (var sor in file)
            {
                var sorok = sor.Split(';');

                maraton.Add(new Maraton
                {
                    rajtszam = sorok[0],
                    Kategoria = sorok[1],
                    Nev = sorok[2],
                    egyesulet = sorok[3],
                    ido = TimeSpan.Parse(sorok[4])
                });
            }
            int osszesenIndult = 691;
            int celbaErkezett = maraton.Count;
            int nemTeljesitett = osszesenIndult - celbaErkezett;
            double arany = (double)nemTeljesitett / osszesenIndult * 100;

            Console.WriteLine($"4. feladat:");
            Console.WriteLine($"Nem teljesítette a versenyt: {nemTeljesitett} fő");
            Console.WriteLine($"Arányuk: {arany:F2}%");

            var noirovid = maraton.Where(m => m.rajtszam.StartsWith("R") && m.Kategoria.EndsWith("n")).ToList();

            Console.WriteLine(noirovid.Count);

            bool voltHatOranTobb = false;
            foreach (var versenyzo in maraton)
            {
                if (versenyzo.ido > TimeSpan.FromHours(6))
                {
                    voltHatOranTobb = true;
                    break; // megvan a válasz, nem kell tovább keresni
                }
            }

            Console.WriteLine("6. feladat:");
            if (voltHatOranTobb)
                Console.WriteLine("Volt ilyen versenyző");
            else
                Console.WriteLine("Nem volt ilyen versenyző");

            var rovidtav = maraton.Where(m => m.rajtszam.StartsWith("R") && m.Kategoria == "ff").ToList();

            var gyoztes = rovidtav.OrderBy(m => m.ido).First();

            Console.WriteLine($"7. feladat: A gyoztes {gyoztes.Nev}");

            var kategoriak = maraton.Where(m => m.Kategoria.EndsWith("f")).Select(m => m.Kategoria).Distinct();
            foreach (var kat in kategoriak)
            {
                int db = 0;
                foreach (var versenyzo in maraton)
                {
                    if (versenyzo.Kategoria == kat && versenyzo.Kategoria.EndsWith("f"))
                        db++;
                }
                Console.WriteLine($"{kat}: {db} fő");
            }
        }
    }
}
