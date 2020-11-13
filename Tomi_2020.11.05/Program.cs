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
                if (adatok[i].datum.Substring(0,1) == "2" || adatok[i].datum.Substring(0, 1) == "2")
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
            Console.ReadKey();
        }
    }
}
