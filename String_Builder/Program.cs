using System;
using System.Text;

namespace String_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "двадцять людей йдуть по широкому шляху. Вони людей спiвають старовинних пiсень, та пiдганяють гужових волiв.";
                       
            StringBuilder rez = new StringBuilder("");
            
            Console.WriteLine(a);

           Console.WriteLine($"введите слово");
           string K = Console.ReadLine();

            int prognose_vhojd = 1;

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                prognose_vhojd = FindWordInText(a, K, prognose_vhojd);
            }


            string[] mas = {"ють","уть","ять","ать","ати","ве"};
            glagol(a, mas, rez);
    }


        public static void glagol(string a, string[] mas, StringBuilder rez)
        {
            bool flag = false;
            string[] z = a.Split();

            foreach (string r in z)
            {
                flag = false;
                foreach (string slv in mas)
                    if (r.Contains(slv) && !r.Contains("цять"))
                    {
                        flag = true;
                        Console.WriteLine(r);
                        break;
                    }

                if (!flag) { rez.Append(r + " "); }
            }

            Console.WriteLine($"в итоге строка: {rez}");
        }

        public static int FindWordInText(string stroka, string word, int prognose_vhojd)
        {
            string[] mas_slov = stroka.Split();
            int vhojd = 0, granich_vhojd=0;
            
            foreach (string slov in mas_slov)
            {
                if (string.Compare(slov, word) == 0)
                    granich_vhojd++;
            }

            if (granich_vhojd < prognose_vhojd || prognose_vhojd >= mas_slov.Length)
            {
                Console.WriteLine("there are no much this word in string");
                return 1;                
            }

                foreach (string slov in mas_slov)
                {
                if (string.Compare(slov, word) == 0 && ++vhojd == prognose_vhojd)
                    {
                       Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(slov + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(slov + " ");
                    }
                }
                Console.WriteLine();

                return ++prognose_vhojd;            
        }     
    }
}
