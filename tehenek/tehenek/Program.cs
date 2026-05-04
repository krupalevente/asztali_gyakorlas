using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehenek
{
    internal class Program
    {
        class Tehen : IEquatable<Tehen>
        {

            public string Id { get; private set; }
            public string nap { get; private set; }
            public int[] Mennyisegek { get; private set; }

            public bool Equals(Tehen masik)
            {
                return masik != null && masik.Id == this.Id;
            }

            public void EredmenytRogzit(string nap, string menyiseg)
            {
                Mennyisegek[int.Parse(nap)] = int.Parse(menyiseg);
            }

            public Tehen(string id)
            {
                Id = id;
                Mennyisegek = new int[7];
            }
            public int HetiTej()
            {
                int osszeg = 0;
                foreach (int t in Mennyisegek)
                {
                    osszeg += t;
                }
                return osszeg;
            }
            public int hetiAtlag()
            {
                int napokszam = 0;
                foreach (int t in Mennyisegek)
                {
                    if (t > 0)
                    {
                        napokszam++;
                    }
                }
                if (napokszam < 3)
                {
                    return -1;
                }
                return HetiTej() / napokszam;
            }
        }

        static void Main(string[] args)
        {
            List<Tehen> tehenek = new List<Tehen>();
            var sorok = File.ReadAllLines("tehenek.txt");

            foreach (var sor in sorok)
            {
                var darabok = sor.Split(';');
                var id = darabok[0];
                var nap = darabok[1];
                var mennyiseg = darabok[2];

                Tehen t = new Tehen(darabok[0]);
                t.EredmenytRogzit(darabok[1], darabok[2]);
                tehenek.Add(t);
            }
            Console.WriteLine($"Az allattartomany {tehenek.Count}db tehenet tartalmaz");

            List<Tehen> joltejelo = new List<Tehen>();
            foreach (Tehen t in tehenek)
            {
                if (t.hetiAtlag() != -1)
                    joltejelo.Add(t);
            }

            using (StreamWriter sw = new StreamWriter("joltejelok.txt"))
            {
                foreach (Tehen t in joltejelo)
                {
                    sw.WriteLine($"{t.Id} {t.hetiAtlag()}");
                }
            }

            Console.WriteLine($"A joltejelok.txt állományba {joltejelo.Count} tehén adatait írtuk ki.");

            // 7. feladat: leszármazottak számlálása
            Console.Write("Adjon meg egy tehénazonosítót: ");
            string bekerettAzonosito = Console.ReadLine() ?? "";

            int leszarmazottakSzama = 0;
            foreach (Tehen t in tehenek)
            {
                if (t.Id.StartsWith(bekerettAzonosito) && t.Id.Length > bekerettAzonosito.Length)
                {
                    leszarmazottakSzama++;
                }
            }

            Console.WriteLine($"A(z) {bekerettAzonosito} azonosítójú tehénnek {leszarmazottakSzama} leszármazottja van.");
        }


    }
}
