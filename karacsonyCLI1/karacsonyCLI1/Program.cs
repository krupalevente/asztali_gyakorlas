using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karacsonyCLI1
{
    class NapiMunka
    {
        public static int KeszultDb { get; private set; }
        public int Nap { get; private set; }
        public int HarangKesz { get; private set; }
        public int HarangEladott { get; private set; }
        public int AngyalkaKesz { get; private set; }
        public int AngyalkaEladott { get; private set; }
        public int FenyofaKesz { get; private set; }
        public int FenyofaEladott { get; private set; }

        public NapiMunka(string sor)
        {
            string[] s = sor.Split(';');
            Nap = Convert.ToInt32(s[0]);
            HarangKesz = Convert.ToInt32(s[1]);
            HarangEladott = Convert.ToInt32(s[2]);
            AngyalkaKesz = Convert.ToInt32(s[3]);
            AngyalkaEladott = Convert.ToInt32(s[4]);
            FenyofaKesz = Convert.ToInt32(s[5]);
            FenyofaEladott = Convert.ToInt32(s[6]);

            NapiMunka.KeszultDb += HarangKesz + AngyalkaKesz + FenyofaKesz;
        }

        public int NapiBevetel()
        {
            return -(HarangEladott * 1000 + AngyalkaEladott * 1350 + FenyofaEladott * 1500);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<NapiMunka> napok = new List<NapiMunka>();
            string[] sorok = File.ReadAllLines("diszek.txt");
            foreach (string sor in sorok)
            {
                napok.Add(new NapiMunka(sor));
            }

            Console.WriteLine($"3. feladat: Készített díszek száma: {NapiMunka.KeszultDb}");


            Console.WriteLine("5.feladat:");
            bool voltNemKeszitett = false;
            int nemKeszitettNap = -1;
            foreach (NapiMunka nm in napok)
            {
                if (nm.HarangKesz == 0 && nm.AngyalkaKesz == 0 && nm.FenyofaKesz == 0)
                {
                    voltNemKeszitett = true;
                    nemKeszitettNap = nm.Nap;
                    break;
                }
            }
            if (voltNemKeszitett)
                Console.WriteLine($"Volt olyan nap ({nemKeszitettNap}. nap), amikor a hölgy egyetlen díszt sem készített.");
            else
                Console.WriteLine("Nem volt olyan nap, amikor a hölgy egyetlen díszt sem készített.");


            Console.WriteLine("6.feladat:");
            int napSzam = -1;
            bool ervenyesInput = false;
            while (!ervenyesInput)
            {
                Console.Write("Adjon meg egy napot (1-40): ");
                string bev = Console.ReadLine();
                if (int.TryParse(bev, out napSzam) && napSzam >= 1 && napSzam <= 40)
                {
                    ervenyesInput = true;
                }
                else
                {
                    Console.WriteLine("Érvénytelen érték! Kérem, adjon meg egy 1 és 40 közé eső számot!");
                }
            }
            if (!ervenyesInput) napSzam = 15;

            int harangKeszlet = 0, angyalkaKeszlet = 0, fenyofaKeszlet = 0;
            foreach (NapiMunka nm in napok)
            {
                if (nm.Nap <= napSzam)
                {
                    harangKeszlet += nm.HarangKesz + nm.HarangEladott;
                    angyalkaKeszlet += nm.AngyalkaKesz + nm.AngyalkaEladott;
                    fenyofaKeszlet += nm.FenyofaKesz + nm.FenyofaEladott;
                }
            }
            Console.WriteLine($"A(z) {napSzam}. nap végén készleten lévő díszek:");
            Console.WriteLine($"  Harang: {harangKeszlet} db");
            Console.WriteLine($"  Angyalka: {angyalkaKeszlet} db");
            Console.WriteLine($"  Fenyőfa: {fenyofaKeszlet} db");

            Console.WriteLine("7.feladat:");
            int osszeHarang = 0, osszeAngyalka = 0, osszeFenyofa = 0;
            foreach (NapiMunka nm in napok)
            {
                osszeHarang += -nm.HarangEladott;
                osszeAngyalka += -nm.AngyalkaEladott;
                osszeFenyofa += -nm.FenyofaEladott;
            }
            int max = Math.Max(osszeHarang, Math.Max(osszeAngyalka, osszeFenyofa));
            Console.WriteLine($"A legtöbbet eladott díszek ({max} db):");
            if (osszeHarang == max) Console.WriteLine($"  Harang: {osszeHarang} db");
            if (osszeAngyalka == max) Console.WriteLine($"  Angyalka: {osszeAngyalka} db");
            if (osszeFenyofa == max) Console.WriteLine($"  Fenyőfa: {osszeFenyofa} db");

            Console.WriteLine("8.feladat:");
            int tizezerFeletti = 0;
            using (StreamWriter sw = new StreamWriter("bevetel.txt"))
            {
                foreach (NapiMunka nm in napok)
                {
                    int bev = nm.NapiBevetel();
                    if (bev >= 10000)
                    {
                        sw.WriteLine($"{nm.Nap}:{bev}");
                        tizezerFeletti++;
                    }
                }
                sw.WriteLine($"{tizezerFeletti} napon volt legalabb 10000 Ft a bevétel.");
            }
            Console.WriteLine("A bevetel.txt fájl elkészült.");
            Console.WriteLine($"{tizezerFeletti} napon volt legalabb 10000 Ft a bevétel.");
        }

    }
}

}
