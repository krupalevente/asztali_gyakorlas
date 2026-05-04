using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Versenyzo
{
    public string Nev;
    public string Kategoria;
    public string Egyesulet;
    public List<int> Pontok;

    public int OsszPont()
    {
        var rendezett = Pontok.OrderBy(x => x).ToList();

        int elso = rendezett[0];
        int masodik = rendezett[1];

        int osszeg = Pontok.Sum() - elso - masodik;

        if (elso > 0) osszeg += 10;
        if (masodik > 0) osszeg += 10;

        return osszeg;
    }
}

class Program
{
    static void Main()
    {
        List<Versenyzo> v = new List<Versenyzo>();

        foreach (var sor in File.ReadAllLines("fob2016.txt", Encoding.UTF8))
        {
            var m = sor.Split(';');
            Versenyzo x = new Versenyzo();
            x.Nev = m[0];
            x.Kategoria = m[1];
            x.Egyesulet = m[2];
            x.Pontok = m.Skip(3).Select(int.Parse).ToList();
            v.Add(x);
        }

        // 3. feladat
        Console.WriteLine($"3. feladat: Versenyzők száma: {v.Count}");

        // 4. feladat
        int noi = v.Count(a => a.Kategoria == "Noi");
        double arany = 100.0 * noi / v.Count;
        Console.WriteLine($"4. feladat: A női versenyzők aránya: {arany:0.00}%");

        // 6. feladat
        var noiLista = v.Where(a => a.Kategoria == "Noi")
                        .Select(a => new { Nev = a.Nev, Egyesulet = a.Egyesulet, Pont = a.OsszPont() })
                        .OrderByDescending(a => a.Pont)
                        .First();

        Console.WriteLine("6. feladat: A bajnok női versenyző");
        Console.WriteLine($" Név: {noiLista.Nev}");
        Console.WriteLine($" Egyesület: {noiLista.Egyesulet}");
        Console.WriteLine($" Összpont: {noiLista.Pont}");
    }
}
