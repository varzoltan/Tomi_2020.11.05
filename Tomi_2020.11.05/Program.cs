using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tomi_2020._11._05
{
    class Program
    {
        struct Adat
        {
            public string datum;
            public string nev;
            public string resz;
            public int hossz;
            public int igennem;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[400];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Downloads\lista.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string datum = olvas.ReadLine();
                for (int i = 1;i<2;i++)
                {                   
                    adatok[n].datum = datum;
                    string nev = olvas.ReadLine();
                    adatok[n].nev = nev;
                    string resz = olvas.ReadLine();
                    adatok[n].resz = resz;
                    adatok[n].hossz = int.Parse(olvas.ReadLine());
                    adatok[n].igennem = int.Parse(olvas.ReadLine());
                }
                n++;
            }
            olvas.Close();
            Console.WriteLine("1. feladat: Beolvasás kész!");

            //2.feladat
            int ni = 0;
            for (int i =0;i<n;i++)
            {
                if (adatok[i].datum == "NI")
                {
                    ni++;
                }
            }
            Console.WriteLine("2.Feladat:\n A listában {0} db vetítési dátummal rendelkező epizód van.",n - ni);

            /*int vetit = 0;
            for (int i = 0; i < n; i++)
            {
                if (adatok[i].datum.Substring(0,1) == "2")
                {
                    vetit++;
                }
            }
            Console.WriteLine("2.Feladat:\n A listában {0} db vetítési dátummal rendelkező epizód van.",vetit);
            */

            //3.feladat
            int egy = 0;
            for (int i = 0; i < n; i++)
            {
                if (adatok[i].igennem == 1)
                {
                    egy++;
                }
            }
            Console.WriteLine("3.Feladat:\n A listában lévő epizódok {0}%-át látta.",Math.Round(egy*100.0/n,2));

            //4.feladat
            int összhossz = 0;
            for (int i = 0; i < n; i++)
            {
                if (adatok[i].igennem == 1)
                {
                    összhossz += adatok[i].hossz;
                }
            }

            int nap = összhossz/(24*60);
            int ora = (összhossz % (24 * 60)) / 60;
            int perc = (összhossz % (24 * 60)) % 60;
            Console.WriteLine("4.Feladat:\nSorozatnézéssel "+nap+" napot "+ora+" órát "+perc+" percet töltött.");

            //5.feladat
            Console.Write("Kérem adjon meg egy dátumot:");
            string bekertdatum = Console.ReadLine();
            string[] Bdb = bekertdatum.Split('.');
            int Bev = int.Parse(Bdb[0]);
            int Bhonap = int.Parse(Bdb[1]);
            int Bnap = int.Parse(Bdb[2]);
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].datum.Substring(0,1) == "2")
                {
                    string[] darab = adatok[i].datum.Split('.');
                    int ev = int.Parse(darab[0]);
                    int honap = int.Parse(darab[1]);
                    int naps = int.Parse(darab[2]);
                    if (ev <= Bev && honap <= Bhonap && naps <= Bnap && adatok[i].igennem == 0)
                    {
                        Console.WriteLine($"{adatok[i].resz}\t{adatok[i].nev}");
                    }
                }
                 
            }

            //7.feladat
            Console.Write("7.Feladat\nAdjon meg egy napot rövidítve: ");
            string hetesfeladat = Console.ReadLine();
            string sorozatnev = null;
            int g = 0;
            for (int i =0;i<n;i++)
            {
                if (adatok[i].datum != "NI")
                {
                    string sor = adatok[i].datum;
                    string[] db = sor.Split('.');
                    int ev = int.Parse(db[0]);
                    int ho = int.Parse(db[1]);
                    int napok = int.Parse(db[2]);
                    if (Hetnapja(ev, ho, napok) == hetesfeladat)
                    {
                        if(sorozatnev != adatok[i].nev)
                        {
                            Console.WriteLine(adatok[i].nev);
                            sorozatnev = adatok[i].nev;
                        }
                        
                    }
                    
                }
            }
            if (sorozatnev==null)
            {
                Console.WriteLine("Az adott napon nem kerül adásba sorozat.");
            }

            //8.feladat
            StreamWriter ir = new StreamWriter(@"C:\Users\Rendszergazda\Downloads\summa.txt");
            int osszegzes = 0;
            int szamol = 0;
            for (int i = 0;i<n;i++)
            {
                if(adatok[i].nev == adatok[i + 1].nev)
                {
                    osszegzes += adatok[i].hossz;
                    szamol++;
                }
                else
                {
                    osszegzes += adatok[i].hossz;
                    szamol++;
                    ir.WriteLine($"{adatok[i].nev} {osszegzes} {szamol}");
                    osszegzes = 0;
                    szamol = 0;
                }
                
            }
            ir.Close();
            Console.ReadKey();
        }

        //6.feladat: Hetnapja függvény megírása
        static string Hetnapja(int ev, int ho, int nap)
        {
            string[] napok = { "v", "h", "k", "sze", "cs", "p", "szo" };
            int[] honapok = {0,3,2,5,0,3,5,1,4,6,2,4};          
            
            if (ho<3)
            {
                ev = ev - 1;
            }          
            return napok[(ev + ev / 4 - ev/100 + ev/400 + honapok[ho-1] + nap) %7];
        }
    }
}
