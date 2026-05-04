using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Entry
{
    public int Place { get; set; }       
    public int Athletes { get; set; }    
    public string Sport { get; set; }    
    public string Event { get; set; }    
    public int OlympicPoints
    {
        get
        {
            // mapping: 1->7, 2->5, 3->4, 4->3, 5->2, 6->1
            switch (Place)
            {
                case 1: return 7;
                case 2: return 5;
                case 3: return 4;
                case 4: return 3;
                case 5: return 2;
                case 6: return 1;
                default: return 0;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string inputFile = "helsinki.txt";
        string outputFile = "helsinki2.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"A bemeneti fájl '{inputFile}' nem található. Helyezd a programmal azonos mappába és próbáld újra.");
            return;
        }

        // 2. Olvasás és tárolás
        List<Entry> entries = new List<Entry>();
        string[] lines = File.ReadAllLines(inputFile, Encoding.UTF8);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(new char[] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 4) continue; // 
            if (!int.TryParse(parts[0], out int place)) continue;
            if (!int.TryParse(parts[1], out int athletes)) continue;
            string sport = parts[2];
            string ev = parts[3];

            entries.Add(new Entry
            {
                Place = place,
                Athletes = athletes,
                Sport = sport,
                Event = ev
            });
        }

   
        Console.WriteLine("3. feladat:");
        Console.WriteLine($"A pontszerző helyezések száma: {entries.Count}");
        Console.WriteLine();

   
        int gold = entries.Count(e => e.Place == 1);
        int silver = entries.Count(e => e.Place == 2);
        int bronze = entries.Count(e => e.Place == 3);
        int totalMedals = gold + silver + bronze;

        Console.WriteLine("4. feladat:");
        Console.WriteLine("Ermek statisztika:");
        Console.WriteLine($"Aranyak: {gold}");
        Console.WriteLine($"Ezustok: {silver}");
        Console.WriteLine($"Bronzok: {bronze}");
        Console.WriteLine($"Ermek osszesen: {totalMedals}");
        Console.WriteLine();


        Console.WriteLine("5. feladat:");
        Console.WriteLine("Helyezes Olimpiai pont");
        Console.WriteLine("1. 7");
        Console.WriteLine("2. 5");
        Console.WriteLine("3. 4");
        Console.WriteLine("4. 3");
        Console.WriteLine("5. 2");
        Console.WriteLine("6. 1");
        int totalPoints = entries.Sum(e => e.OlympicPoints);
        Console.WriteLine($"Olimpiai pontok osszesen: {totalPoints}");
        Console.WriteLine();

      
        int uszasMedals = entries.Count(e => (e.Sport.Equals("uszas", StringComparison.OrdinalIgnoreCase) || e.Sport.Equals("úszás", StringComparison.OrdinalIgnoreCase)) && e.Place >= 1 && e.Place <= 3);
        int tornaMedals = entries.Count(e => e.Sport.Equals("torna", StringComparison.OrdinalIgnoreCase) && e.Place >= 1 && e.Place <= 3);

        Console.WriteLine("6. feladat:");
        if (uszasMedals > tornaMedals)
        {
            Console.WriteLine("A uszas sportagban szereztek tobb ermet.");
        }
        else if (tornaMedals > uszasMedals)
        {
            Console.WriteLine("A torna sportagban szereztek tobb ermet.");
        }
        else
        {
            Console.WriteLine("Egyenlo volt az ermek szama");
        }
        Console.WriteLine();

        // 7. feladat: irja a helsinki2.txt file-t, sportag neve javitva: "kajakkenu" -> "kajak-kenu"
        var outLines = new List<string>();
        foreach (var e in entries)
        {
            string sportFixed = e.Sport.Equals("kajakkenu", StringComparison.OrdinalIgnoreCase) ? "kajak-kenu" : e.Sport;
            // place athletes points sport event
            string nl = $"{e.Place} {e.Athletes} {e.OlympicPoints} {sportFixed} {e.Event}";
            outLines.Add(nl);
        }
        File.WriteAllLines(outputFile, outLines, Encoding.UTF8);
        Console.WriteLine("7. feladat:");
        Console.WriteLine($"A '{outputFile}' fájl elkészült.");
        Console.WriteLine();

        // 8. feladat: melyik pontszerző helyezéshez fűződik a legtöbb sportoló?
        var maxAthletesEntry = entries.OrderByDescending(e => e.Athletes).FirstOrDefault();
        Console.WriteLine("8. feladat:");
        if (maxAthletesEntry != null)
        {
            Console.WriteLine($"A legtobb sportolo a {maxAthletesEntry.Place}. helyezeshez fuzodik:");
            Console.WriteLine($"Helyezes: {maxAthletesEntry.Place}");
            Console.WriteLine($"Sportag: {(maxAthletesEntry.Sport.Equals("kajakkenu", StringComparison.OrdinalIgnoreCase) ? "kajak-kenu" : maxAthletesEntry.Sport)}");
            Console.WriteLine($"Versenyszam: {maxAthletesEntry.Event}");
            Console.WriteLine($"Sportolok szama: {maxAthletesEntry.Athletes}");
        }
        else
        {
            Console.WriteLine("Nincs adat a bejegyzések között.");
        }
    }
}
