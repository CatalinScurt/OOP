using System;
/*********************************************************************************
 * programul functioneaza corespunzator daca se introduce un format valid,
 * adica orele/min/sec/sutimile trebuie sa fie din 2 cifre, altfel programul
 * afiseaza eroare datorita prelucrarii string-ului initial.
 *********************************************************************************/
namespace S4Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti prima ora in unul din urmatoarele formate: hh:mm, hh:mm:ss, hh:mm:ss:ms (sau cu ','in loc de ':' intre ore/min/sec/sutimi )");
            string time1 = Console.ReadLine();
            Console.WriteLine("Introduceti a doua ora in unul din urmatoarele formate: hh:mm, hh:mm:ss, hh:mm:ss:ms (sau cu ',' in loc de ':' intre ore/min/sec/sutimi )");
            string time2 = Console.ReadLine();

            int ora1 = Timp(time1, time2).Item1;
            int minut1 = Timp(time1, time2).Item2;
            int secunda1 = Timp(time1, time2).Item3;
            int sutime1 = Timp(time1, time2).Item4;

            int ora2 = Timp(time1, time2).Item5;
            int minut2 = Timp(time1, time2).Item6;
            int secunda2 = Timp(time1, time2).Item7;
            int sutime2 = Timp(time1, time2).Rest.Item1;

            Time t1 = new Time(ora1, minut1, secunda1, sutime1);
            Time t2 = new Time(ora2, minut2, secunda2, sutime2);
            Time t3 = t1 + t2;
            Console.WriteLine($"In total sunt {t3.Ora} ore, {t3.Minut} minute, {t3.Secunda} secunde, {t3.Sutime} sutimi");

        }
        static Tuple<int, int, int, int, int, int, int, Tuple<int>> Timp(string time1, string time2)
        {
            int found1 = 1;
            foreach (var item in time1)
            {
                if ((item == ':') || (item == ','))
                    found1 += 1;
            }
            int hr1 = 0, min1 = 0, sec1 = 0, stm1 = 0;
            switch (found1)
            {
                case 2:
                    hr1 = int.Parse(time1.Substring(0, 2));
                    min1 = int.Parse(time1.Substring(3, 2));
                    sec1 = 0;
                    stm1 = 0;
                    break;
                case 3:
                    hr1 = int.Parse(time1.Substring(0, 2));
                    min1 = int.Parse(time1.Substring(3, 2));
                    sec1 = int.Parse(time1.Substring(6, 2));
                    stm1 = 0;
                    break;
                case 4:
                    hr1 = int.Parse(time1.Substring(0, 2));
                    min1 = int.Parse(time1.Substring(3, 2));
                    sec1 = int.Parse(time1.Substring(6, 2));
                    stm1 = int.Parse(time1.Substring(9, 2));
                    break;
                default:
                    Console.WriteLine("Introduceti o ora conform modelului!");
                    break;
            }
            int found2 = 1;
            foreach (var item2 in time2)
            {
                if ((item2 == ':') || (item2 == ','))
                    found2 += 1;
            }
            int hr2 = 0, min2 = 0, sec2 = 0, stm2 = 0;
            switch (found2)
            {
                case 2:
                    hr2 = int.Parse(time2.Substring(0, 2));
                    min2 = int.Parse(time2.Substring(3, 2));
                    sec2 = 0;
                    stm2 = 0;
                    break;
                case 3:
                    hr2 = int.Parse(time2.Substring(0, 2));
                    min2 = int.Parse(time2.Substring(3, 2));
                    sec2 = int.Parse(time2.Substring(6, 2));
                    stm2 = 0;
                    break;
                case 4:
                    hr2 = int.Parse(time2.Substring(0, 2));
                    min2 = int.Parse(time2.Substring(3, 2));
                    sec2 = int.Parse(time2.Substring(6, 2));
                    stm2 = int.Parse(time2.Substring(9, 2));
                    break;
                default:
                    Console.WriteLine("Introduceti o ora conform modelului!");
                    break;
            }
            Tuple<int, int, int, int, int, int, int, Tuple<int>> result = new Tuple<int, int, int, int, int, int, int, Tuple<int>>(hr1, min1, sec1, stm1, hr2, min2, sec2, Tuple.Create(stm2));
            return result;
        }
        class Time
        {
            public int Ora { get; set; }
            public int Minut { get; set; }
            public int Secunda { get; set; }
            public int Sutime { get; set; }
            public Time(int ora, int minut, int secunda, int sutime)
            {
                Ora = ora;
                Minut = minut;
                Secunda = secunda;
                Sutime = sutime;
            }
            public static Time operator +(Time t1, Time t2)
            {
                int k;
                int sutime = (t1.Sutime + t2.Sutime) % 100;
                k = (t1.Sutime + t2.Sutime) / 100;
                int secunda = (t1.Secunda + t2.Secunda + k) % 60;
                k = (t1.Secunda + t2.Secunda + k) / 60;
                int minut = (t1.Minut + t2.Minut + k) % 60;
                k = (t1.Minut + t2.Minut + k) / 60;
                int ora = t1.Ora + t2.Ora + k;
                Time result = new Time(ora, minut, secunda, sutime);
                return result;
            }
        }
    }
}
