using System;
using System.Collections.Generic;
namespace LabS8
{
    public class Load
    {

        public static void Main(string[] args)
        {
            Elev.load(@"..\..\..\Data.in"); 
        }
    }
    public class SortByName : IComparer<Elev>
    {
        public int Compare(Elev e1, Elev e2)
        {
            return string.Compare(e1.Nume, e2.Nume);
        }
    }

    public class SortByAverage : IComparer<Elev>
    {
        public int Compare(Elev e1, Elev e2)
        {
            if (e1.media < e2.media)
                return 1;
            if (e1.media > e2.media)
                return -1;
            if (e1.media == e2.media)
                new SortByName();
            return 0;
        }
    }
    public class Elev
    {
        public Elev(string n, string p, double m)
        {
            Nume = n;
            Prenume = p;
            media = m;
        }
        public override string ToString()
        {
            return Nume + " " + Prenume + " " + media.ToString();
        }

        public string Nume { get; }
        public string Prenume { get; }
        public double media { get; }
           public static void load(string file_name)
            {
                System.IO.TextReader data_load = new System.IO.StreamReader(file_name);
                List<string> data = new List<string>();
                string buffer;
                while ((buffer = data_load.ReadLine()) != null)
                    data.Add(buffer);
            List<Elev> elev = new List<Elev>();

            foreach (string item in data)
                {
                    string nextWord = " ";
                    string[] words = item.Split(nextWord, System.StringSplitOptions.RemoveEmptyEntries);
                    int count = Convert.ToInt32(words[2]);
                    int suma = 0;
                    for (int i = 3; i < words.Length; i++)
                    {
                        suma += Convert.ToInt32(words[i]);
                    }
                    float media = suma / count;
                elev.Add(new Elev(words[0], words[1], media));
            }
            static void print(List<Elev> a)
            {
                foreach (object o in a)
                    Console.WriteLine(o);
            }
            elev.Sort(new SortByName());
            Console.WriteLine("\n\nSortarea dupa nume:\n");
            print(elev);

            elev.Sort(new SortByAverage());
            Console.WriteLine("\n\nSortarea dupa medie:\n");
            print(elev);
        }
        }
    }