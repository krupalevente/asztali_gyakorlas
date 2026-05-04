using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrvosiNobeldijasok
{
    class Elethossz
    {
        public int DijazasiEv { get; set; }
        public string Nev { get; set; }

       public int Tol { get; set; }
       public int Ig { get; set; }
       public string Orszagkod { get; set; }
        public int ElethosszEvekben => Tol == -1 || Ig == -1 ? -1 : Ig - Tol;

        public bool IsmertAzElethossz => ElethosszEvekben != -1;

        public Elethossz(string SzuletesHalalozas)
        {
            string[] m = SzuletesHalalozas.Split('-');
            try
            {
                Tol = int.Parse(m[0]);
            }
            catch (Exception)
            {
                Tol = -1;
            }
            try
            {
                Ig = int.Parse(m[1]);
            }
            catch (Exception)
            {
                Ig = -1;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Elethossz> dijazottak = new List<Elethossz>();
            var sorok = File.ReadAllLines("orvosi_nobeldijasok.txt");

            for (int i = 1; i < sorok.Length; i++)
            {
                var adatok = sorok[i].Split(';');

                Elethossz e = new Elethossz(adatok[2])
                {
                    DijazasiEv = int.Parse(adatok[0]),
                    Nev = adatok[1],
                    Orszagkod = adatok[3]
                };
                dijazottak.Add(e);
            }
            Console.WriteLine($"3. feladat: {dijazottak.Count} Nobel-díjas orvos volt eddig.");
            int maxev = dijazottak.Max(x => x.DijazasiEv);
            Console.WriteLine($"A legregebbi dijazas {maxev}-ban toretent");

            Console.WriteLine("5. feladat: Kérem adja meg egy országkódot!");
            string kod = Console.ReadLine();
            var szurt = dijazottak.Where(x => x.Orszagkod == kod).ToList();

            if (szurt.Count == 0)
            {
                Console.WriteLine("A megadott országból nem volt díjazott!");
            }
            else if (szurt.Count == 1)
            {
                Console.WriteLine($"Név: {szurt[0].Nev}, Díjazás éve: {szurt[0].DijazasiEv}, Kód: {szurt[0].Orszagkod}");
            }
            else
            {
                Console.WriteLine($"A megadott országból {szurt.Count} fő díjazott volt!");
            }

            var statisztika = dijazottak.GroupBy(x => x.Orszagkod).Where(g => g.Count() > 5);

            foreach (var csoport in statisztika)
            {
                Console.WriteLine($"Országkód: {csoport.Key}, Díjazottak száma: {csoport.Count()}");
            }

            var ismeretlenereletu = dijazottak.Where(x => !x.IsmertAzElethossz);
            double atlag = ismeretlenereletu.Average(x => x.ElethosszEvekben);

            Console.WriteLine($"7. feladat: Az ismert élethosszú díjazottak átlagos élethossza: {atlag:F1} év");
        }
        }
    }

