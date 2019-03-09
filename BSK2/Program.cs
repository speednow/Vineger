using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] all = new char[26, 26];
            char f = 'A';
            int y = 0;
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    all[i, j] = f;
                    if (f == 'Z')
                    {
                        f = 'A';
                        f--;
                    }
                    f++;
                }
                f = 'A';
                y++;
                
                for (int z = 0; z < y; z++)
                {
                    f++;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    Console.Write(all[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Slowo do zaszyfrowania:");
            string key1=Console.ReadLine().ToUpper();
            Console.WriteLine("Klucz do zaszyfrowania:");
            string key2= Console.ReadLine().ToUpper();

            char[] t = new char[key1.Length];
            int counter = 0;

            if (key1.Length > key2.Length)
            {
                for (int i = 0; i < key1.Length; i++)
                {
                    
                    t[i] = key2[counter% (key2.Length)];
                   // Console.WriteLine(t[i]);
                    counter++;
                }
            }



            //Console.WriteLine(t);
            string s = new string(t);
            Console.WriteLine();
            Console.WriteLine(Szyfr(key1, s, all));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Szyfrowanie dla slowa CRYPTOGRAPHY i klucza BREAKBREAKBR");
            Console.WriteLine();
            Console.WriteLine(Szyfr("CRYPTOGRAPHY", "BREAKBREAKBR", all)); //BREAK i za mało znaków to ma się powtarzać
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deszyfrowanie dla szyfru DICPDPXVAZIP i klucza BREAKBREAKBR");
            Console.WriteLine();
            Console.WriteLine(DeSzyfr("DICPDPXVAZIP", "BREAKBREAKBR", all));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Slowo do deszyfracji:");
            string key3 = Console.ReadLine().ToUpper();
            Console.WriteLine("Klucz do deszyfrowania:");
            string key4 = Console.ReadLine().ToUpper();
            char[] t2 = new char[key3.Length];
            int counter2 = 0;

            if (key3.Length > key4.Length)
            {
                for (int i = 0; i < key3.Length; i++)
                {

                    t2[i] = key4[counter2 % (key4.Length)];
                     //Console.WriteLine(t2[i]);
                    counter2++;
                }
            }
            string s2 = new string(t2);
            Console.WriteLine();
            Console.WriteLine(DeSzyfr(key3, s2, all));

            System.Console.Read();
        }

        static string Szyfr(String tekst, String tekst2, char[,] tab)
        {
            char[] text = tekst.ToCharArray();
            char[] text2 = tekst2.ToCharArray();
            char[] text3 = tekst.ToCharArray();
            int a = 0;
            int k = 0;
        
            for (int i = 0; i < text.Length; i++)

            {
                for (int x = 0; x < 26; x++)
                {
                    if (tab[0, x] == text[i])
                        a=x;
                }
                for (int y = 0; y < 26; y++)
                {
                    if (tab[y, 0] == text2[i])
                        k = y;
                }
                text3[i] = tab[a, k];

                }
            return new string(text3);

        }
        static string DeSzyfr(String tekst, String tekst2, char[,] tab)
        {
            char[] text = tekst.ToCharArray();
            char[] text2 = tekst2.ToCharArray();
            char[] text3 = tekst.ToCharArray();
            int a = 0;
            int k = 0;

            for (int i = 0; i < tekst.Length; i++)

            {
                for (int x = 0; x < 26; x++)
                {
                    if (tab[0, x] == text2[i])
                        a = x;
                }

                for (int y = 0; y < 26; y++)
                {
                    if (tab[y, a] == text[i])
                        k = y;
                }
                text3[i] = tab[k,0];
            }

            return new string(text3);

        }
    }
}
