using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazi_09._16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {

                HelloWorld();
                Koszones();
                Ketszeres();
                KetSzamMuveletek();
                Nagyobbik();
                LegkisebbHarom();
                HaromszogSzerkesztheto();
                SzamtaniMertaniKozep();
                MasodfokuVanEMegoldas();
                MasodfokuMegoldasok();
                DerekszoguAtfogo();
                TeglatestFelszinTerfogat();
                KorKeruletTerulet();
                KorivTeruletIv();
                SzamokSzokozzel();
                SzamokEgymasAla();
                Osztok();
                OsztokOsszege();
                TokeletesSzam();
                Hatvany();
                PozitivBeolvasas();
                KisebbMintTizOsszeg();
                KettesekSzorzata();
                CsakAlma();
                HarommalKivon();
                PrimE();
                PrimSzamokEddig();
                PrimOsztok();
                PrimTenyezosFelbontas();
                LNKO();
                LKKT();
            }
        }

            static void HelloWorld()
            {
                Console.WriteLine("Hello world!");
            }

            static void Koszones()
            {
                Console.Write("Add meg a neved: ");
                string nev = Console.ReadLine();
                Console.WriteLine($"Szia, {nev}!");
            }

            static void Ketszeres()
            {
                Console.Write("Adj meg egy számot: ");
                double szam = double.Parse(Console.ReadLine());
                Console.WriteLine($"A szám kétszerese: {szam * 2}");
            }

            static void KetSzamMuveletek()
            {
                Console.Write("Első szám: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Második szám: ");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine($"Különbség: {a - b}");
                Console.WriteLine($"Szorzat: {a * b}");
                if (b != 0)
                    Console.WriteLine($"Hányados: {a / b}");
                else
                    Console.WriteLine("Nullával nem lehet osztani!");
            }

            static void Nagyobbik()
            {
                Console.Write("Első egész szám: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Második egész szám: ");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine($"A nagyobbik: {(a > b ? a : b)}");
            }

            static void LegkisebbHarom()
            {
                Console.Write("Első szám: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Második szám: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Harmadik szám: ");
                int c = int.Parse(Console.ReadLine());

                int min = Math.Min(a, Math.Min(b, c));
                Console.WriteLine($"A legkisebb: {min}");
            }

            static void HaromszogSzerkesztheto()
            {
                Console.Write("1. oldal: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("2. oldal: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("3. oldal: ");
                double c = double.Parse(Console.ReadLine());

                if (a + b > c && a + c > b && b + c > a)
                    Console.WriteLine("Szerkeszthető háromszög.");
                else
                    Console.WriteLine("Nem szerkeszthető háromszög.");
            }

            static void SzamtaniMertaniKozep()
            {
                Console.Write("Első pozitív szám: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Második pozitív szám: ");
                double b = double.Parse(Console.ReadLine());

                if (a > 0 && b > 0)
                {
                    double szamtani = (a + b) / 2;
                    double mertani = Math.Sqrt(a * b);
                    Console.WriteLine($"Számtani közép: {szamtani}, Mértani közép: {mertani}");
                }
                else
                    Console.WriteLine("Csak pozitív számokkal működik!");
            }

            static void MasodfokuVanEMegoldas()
            {
                Console.WriteLine("Másodfokú egyenlet: ax^2 + bx + c = 0");
                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c = ");
                double c = double.Parse(Console.ReadLine());

                double D = b * b - 4 * a * c;
                if (D >= 0)
                    Console.WriteLine("Van megoldás.");
                else
                    Console.WriteLine("Nincs valós megoldás.");
            }

            static void MasodfokuMegoldasok()
            {
                Console.WriteLine("Másodfokú egyenlet: ax^2 + bx + c = 0");
                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c = ");
                double c = double.Parse(Console.ReadLine());

                double D = b * b - 4 * a * c;
                if (D > 0)
                {
                    double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    Console.WriteLine($"Két megoldás: x1 = {x1}, x2 = {x2}");
                }
                else if (D == 0)
                {
                    double x0 = -b / (2 * a);
                    Console.WriteLine($"Egy megoldás: x = {x0}");
                }
                else
                {
                    Console.WriteLine("Nincs valós megoldás.");
                }
            }

            static void DerekszoguAtfogo()
            {
                Console.Write("Első befogó: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Második befogó: ");
                double b = double.Parse(Console.ReadLine());

                double c = Math.Sqrt(a * a + b * b);
                Console.WriteLine($"Átfogó hossza: {c:F2}");
            }

            static void TeglatestFelszinTerfogat()
            {
                Console.Write("a él: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b él: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c él: ");
                double c = double.Parse(Console.ReadLine());

                double felszin = 2 * (a * b + a * c + b * c);
                double terfogat = a * b * c;
                Console.WriteLine($"Felszín: {felszin}, Térfogat: {terfogat}");
            }

            static void KorKeruletTerulet()
            {
                Console.Write("Kör átmérője: ");
                double d = double.Parse(Console.ReadLine());
                double r = d / 2;
                double kerulet = 2 * Math.PI * r;
                double terulet = Math.PI * r * r;
                Console.WriteLine($"Kerület: {kerulet}, Terület: {terulet}");
            }

            static void KorivTeruletIv()
            {
                Console.Write("Sugár: ");
                double r = double.Parse(Console.ReadLine());
                Console.Write("Középponti szög (fok): ");
                double alfa = double.Parse(Console.ReadLine());

                double ivHossz = 2 * Math.PI * r * (alfa / 360);
                double terulet = Math.PI * r * r * (alfa / 360);
                Console.WriteLine($"Körív hossza: {ivHossz}, Szelet területe: {terulet}");
            }


static void SzamokSzokozzel()
{
    Console.Write("Adj meg egy pozitív egész számot: ");
    int n = int.Parse(Console.ReadLine());
    for (int i = 1; i <= n; i++)
    {
        Console.Write(i);
        if (i < n) Console.Write(" ");
    }
    Console.WriteLine();
}


static void SzamokEgymasAla()
{
    Console.Write("Adj meg egy pozitív egész számot: ");
    int n = int.Parse(Console.ReadLine());
    for (int i = 1; i <= n; i++)
    {
        Console.WriteLine(i);
    }
}


static void Osztok()
{
    Console.Write("Adj meg egy pozitív egész számot: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Osztók: ");
    for (int i = 1; i <= n; i++)
    {
        if (n % i == 0)
            Console.Write(i + " ");
    }
    Console.WriteLine();
}


static void OsztokOsszege()
{
    Console.Write("Adj meg egy pozitív egész számot: ");
    int n = int.Parse(Console.ReadLine());
    int osszeg = 0;
    for (int i = 1; i <= n; i++)
    {
        if (n % i == 0)
            osszeg += i;
    }
    Console.WriteLine($"Az osztók összege: {osszeg}");
}

static void TokeletesSzam()
{
    Console.Write("Adj meg egy pozitív egész számot: ");
    int n = int.Parse(Console.ReadLine());
    int osszeg = 0;
    for (int i = 1; i <= n; i++)
    {
        if (n % i == 0)
            osszeg += i;
    }
    if (osszeg == 2 * n)
        Console.WriteLine($"{n} tökéletes szám.");
    else
        Console.WriteLine($"{n} nem tökéletes szám.");
}


static void Hatvany()
{
    Console.Write("Hatványalap: ");
    int alap = int.Parse(Console.ReadLine());
    Console.Write("Kitevő: ");
    int kitevo = int.Parse(Console.ReadLine());
    int eredmeny = 1;
    for (int i = 0; i < kitevo; i++)
        eredmeny *= alap;
    Console.WriteLine($"Hatványérték: {eredmeny}");
}

static int PozitivBeolvasas()
{
    int szam;
    do
    {
        Console.Write("Adj meg egy pozitív számot: ");
        szam = int.Parse(Console.ReadLine());
    } while (szam <= 0);
    return szam;
}


static void KisebbMintTizOsszeg()
{
    int osszeg = 0;
    while (true)
    {
        Console.Write("Adj meg egy számot (>=10-re kilép): ");
        int szam = int.Parse(Console.ReadLine());
        if (szam >= 10)
            break;
        osszeg += szam;
    }
    Console.WriteLine($"A beolvasott számok összege: {osszeg}");
}


static void KettesekSzorzata()
{
    Console.Write("Kérek egy egész számot: ");
    int n = int.Parse(Console.ReadLine());
    int eredeti = n;
    Console.Write($"{eredeti} = ");
    bool volt = false;
    while (n % 2 == 0)
    {
        Console.Write("2*");
        n /= 2;
        volt = true;
    }
    Console.WriteLine(n);
}

static void CsakAlma()
{
    string s;
    do
    {
        Console.Write("Írd be: ");
        s = Console.ReadLine();
    } while (s != "alma");
    Console.WriteLine("Az alma gyümölcs!");
}

static void HarommalKivon()
{
    Console.Write("Adj meg egy egész számot: ");
    int n = int.Parse(Console.ReadLine());
    int eredeti = n;
    while (n >= 3)
    {
        n -= 3;
    }
    Console.WriteLine($"{eredeti} maradékos osztása 3-mal: {n}");
}

// 26. Prímszám-e?
static void PrimE()
{
    Console.Write("Adj meg egy számot: ");
    int n = int.Parse(Console.ReadLine());
    if (n < 2)
    {
        Console.WriteLine("Nem prímszám.");
        return;
    }
    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (n % i == 0)
        {
            Console.WriteLine("Nem prímszám.");
            return;
        }
    }
    Console.WriteLine("Prímszám.");
}

// 27. Prímszámok kiírása eddig a számig
static void PrimSzamokEddig()
{
    Console.Write("Adj meg egy számot: ");
    int n = int.Parse(Console.ReadLine());
    for (int i = 2; i <= n; i++)
    {
        bool prim = true;
        for (int j = 2; j <= Math.Sqrt(i); j++)
        {
            if (i % j == 0)
            {
                prim = false;
                break;
            }
        }
        if (prim)
            Console.Write(i + " ");
    }
    Console.WriteLine();
}

// 28. Prímosztók kiírása
static void PrimOsztok()
{
    Console.Write("Adj meg egy számot: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Prímosztók: ");
    for (int i = 2; i <= n; i++)
    {
        if (n % i == 0)
        {
            bool prim = true;
            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    prim = false;
                    break;
                }
            }
            if (prim)
                Console.Write(i + " ");
        }
    }
    Console.WriteLine();
}

static void PrimTenyezosFelbontas()
{
    Console.Write("Adj meg egy számot: ");
    int n = int.Parse(Console.ReadLine());
    int eredeti = n;
    Console.Write($"{eredeti} = ");
    bool elso = true;
    for (int i = 2; i <= n; i++)
    {
        while (n % i == 0)
        {
            if (!elso) Console.Write("*");
            Console.Write(i);
            n /= i;
            elso = false;
        }
    }
    if (elso) Console.Write(eredeti); 
    Console.WriteLine();
}


static void LNKO()
{
    Console.Write("Első szám: ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Második szám: ");
    int b = int.Parse(Console.ReadLine());
    int eredetiA = a, eredetiB = b;
    while (b > 0)
    {
        int t = b;
        b = a % b;
        a = t;
    }
    Console.WriteLine($"{eredetiA} és {eredetiB} legnagyobb közös osztója: {a}");
}

static void LKKT()
{
    Console.Write("Első szám: ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Második szám: ");
    int b = int.Parse(Console.ReadLine());
    int lnko = a, b2 = b;
    while (b2 > 0)
    {
        int t = b2;
        b2 = lnko % b2;
        lnko = t;
    }
    int lkkt = (a * b) / lnko;
    Console.WriteLine($"{a} és {b} legkisebb közös többszöröse: {lkkt}");
}
        }

    }

