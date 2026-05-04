using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace barlangok
{
    class Barlang
    {
        private int melyseg = 0;
        private int hossz = 0;

        public int Azon { get; private set; }
        public string Nev { get; private set; }

        public int Hossz
        {
            get
            {
                return hossz;
            }
            set
            {
                if (value >= hossz)
                {
                    hossz = value;
                }
            }
        }

        public int Melyseg
        {
            get
            {
                return melyseg;
            }
            set
            {
                if (value >= melyseg)
                {
                    melyseg = value;
                }
            }
        }

        public string Telepules { get; private set; }
        public string Vedettseg { get; private set; }

        public Barlang(string sor)
        {
            string[] m = sor.Split(';');
            Azon = int.Parse(m[0]);
            Nev = m[1];
            Hossz = int.Parse(m[2]);
            Melyseg = int.Parse(m[3]);
            Telepules = m[4];
            Vedettseg = m[5];
        }

        public override string ToString()
        {
            return $"\tAzon: {Azon}\n\tNév: {Nev}\n\tHossz: {Hossz} m\n\tMélység: {Melyseg} m\n\tTelepülés: {Telepules}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Barlang> barlangok = new List<Barlang>();
            var sorok = File.ReadAllLines("barlangok.txt").Skip(1);
            foreach (var sor in sorok)
            {
                Barlang b = new Barlang(sor);
                barlangok.Add(b);
            }

            Console.WriteLine($"3. feladat: Barlangok száma: {barlangok.Count}");

            var miskolciak = barlangok.Where(b => b.Telepules.StartsWith("Miskolc")).ToList();
            int db = 0;
            int osszeg = 0;
            for (int i = 0; i < miskolciak.Count; i++)
            {
                db++;
                osszeg += miskolciak[i].Melyseg;
            }
            double atlag = (double)osszeg / db;
            Console.WriteLine($"4. feladat: Miskolci barlangok átlagos mélysége: {atlag:N2} m");

            Console.WriteLine("\n6. feladat");
            Console.Write("Adjon meg egy védettségi szintet: ");
            string vedettség = Console.ReadLine();

            var szintBarlangok = barlangok.Where(b => b.Vedettseg == vedettség).ToList();
            if (szintBarlangok.Count == 0)
            {
                Console.WriteLine("Nincs ilyen védettségi szinttel barlang az adatok között!");
            }
            else
            {
                Barlang leghosszabb = szintBarlangok.OrderByDescending(b => b.Hossz).First();
                Console.WriteLine($"A(z) \"{vedettség}\" védettségi szintű leghosszabb barlang:");
                Console.WriteLine(leghosszabb.ToString());
            }
            int vedett = 0;
            int fokozottanVedett = 0;
            int mekulonboztetett = 0;
            foreach (var b in barlangok)
            {
                if (b.Vedettseg == "védett")
                { 
                    vedett++;
                }
                else if (b.Vedettseg == "fokozottan védett")
                {
                    fokozottanVedett++;
                }
                else if (b.Vedettseg == "megkülönböztetett")
                {
                    mekulonboztetett++;
                }

            }
            }
    }
}
