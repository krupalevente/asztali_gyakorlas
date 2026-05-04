using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Jatekos
{
    public string Nev { get; set; }
    public List<int> Tippek { get; set; }
}

class Program
{
    static void Main()
    {
        // 2. feladat – beolvasás
        List<Jatekos> jatekosok = new List<Jatekos>();

        foreach (var sor in File.ReadAllLines("egyszamjatek.txt"))
        {
            var adatok = sor.Split(' ');
            Jatekos j = new Jatekos
            {
                Nev = adatok.Last(),
                Tippek = adatok.Take(adatok.Length - 1).Select(int.Parse).ToList()
            };
            jatekosok.Add(j);
        }

       
        Console.WriteLine($"3. feladat: Játékosok száma: {jatekosok.Count}");

        // 4. feladat
        int fordulokSzama = jatekosok[0].Tippek.Count;
        Console.WriteLine($"4. feladat: Fordulók száma: {fordulokSzama}");

        // 5. feladat
        bool voltEgyes = jatekosok.Any(j => j.Tippek[0] == 1);
        Console.WriteLine("5. feladat: Az első fordulóban volt egyes tipp! " +
                          (voltEgyes ? "Igen!" : "Nem!"));

        // 6. feladat
        int maxTipp = jatekosok.Max(j => j.Tippek.Max());
        Console.WriteLine($"6. feladat: A legnagyobb tipp a fordulók során: {maxTipp}");

        // 7. feladat
        Console.Write($"7. feladat: Kérem a forduló sorszámát [1-{fordulokSzama}]: ");
        int fordulo;
        if (!int.TryParse(Console.ReadLine(), out fordulo) ||
            fordulo < 1 || fordulo > fordulokSzama)
        {
            fordulo = 1;
        }
        int index = fordulo - 1;

        // 8. feladat
        var tippek = jatekosok.Select(j => j.Tippek[index]).ToList();
        int nyertesTipp = tippek
            .Where(t => tippek.Count(x => x == t) == 1)
            .DefaultIfEmpty(-1)
            .Max();

        if (nyertesTipp == -1)
        {
            Console.WriteLine("8. feladat: Nem volt egyedi tipp a megadott fordulóban!");
            Console.WriteLine("9. feladat: Nem volt nyertes a megadott fordulóban!");
            return;
        }

        Console.WriteLine($"8. feladat: A nyertes tipp a megadott fordulóban: {nyertesTipp}");

        // 9. feladat
        var nyertes = jatekosok
            .First(j => j.Tippek[index] == nyertesTipp);

        Console.WriteLine($"9. feladat: A megadott forduló nyertese: {nyertes.Nev}");

    }
}
