using System;

namespace LabS10
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numarul de elemente alea listei");
            int idx = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul elementului pe care doriti sa-l afisati");
            int nrr = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numele a carei pozitie doriti sa o afisati");
            string nn = Console.ReadLine();
            int contor = 0;
            Names n = new Names(idx);
            Console.WriteLine(n[nrr]);
            for (int i = 0; i < idx; i++)
            {
                if(nn == n[i])
                {
                    Console.WriteLine("Acest nume se afla pe pozitia");
                    Console.WriteLine(i);
                    contor++;
                }
            }
            if (contor == 0)
                Console.WriteLine("Acest nume nu se afla in lista");
        }
        class Names
        {
            string[] names;
            public int dimensions;
            public bool error;

            public Names(int nr)
            {
                string[] chars = new string[]{ "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
                dimensions = nr;
                names = new string[nr];
                for (int i = 0; i < nr; i++)
                {
                    int indexx = rnd.Next(chars.Length);
                   names[i] = "abc" + chars[indexx];
                }
            }
            public string this[int index]
            {
                get
                {
                    if (index >= 0 && index < dimensions)
                    {
                        error = false;
                        return names[index];
                    }
                    else
                        error = true;
                    return "Out of Index";
                }
                
            }
        }
    }
}

