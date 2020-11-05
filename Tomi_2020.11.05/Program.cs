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
                /*while (!olvas.EndOfStream && olvas.Peek() != '1' || olvas.Peek() != '0')
                {

                }*/
                for (int i = 1;i<2;i++)
                {
                    string datum = olvas.ReadLine();
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

            Console.Write($"{adatok[n-1].datum} {adatok[n - 1].nev} {adatok[n - 1].resz} {adatok[n - 1].hossz} {adatok[n - 1].igennem}");
            //2.feladat

            Console.ReadKey();
        }
    }
}
