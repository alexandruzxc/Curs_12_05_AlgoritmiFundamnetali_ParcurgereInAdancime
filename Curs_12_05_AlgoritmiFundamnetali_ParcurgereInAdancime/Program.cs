using System;

namespace Curs_12_05_AlgoritmiFundamnetali_ParcurgereInAdancime
{
    /*Problema nr 1

Se da o matrice de val 0 si 1 de dimensiuni(n, m)
Sa se afiseze daca exista drum de 0 de la locatia(0,0) la(n-1, n-1)

0 0 1 1 0 0 1
0 1 0 1 0 1 0
0 1 0 1 0 1 0
0 1 0 1 0 1 0 
0 0 0 1 0 0 0
0 0 0 1 0 1 0
0 0 0 0 0 1 0

Sa se afiseze Da, daca exista drum.*/
    class Program
    {
        static Random rnd = new Random();
        static int n, m;
        static int[,] a;
        static bool [,]b;
        static bool ok = false;

        static void PA(int i, int j)
        {
            if ( i >= 0 && j >=0 && i < n && j < m && !b[i,j] && a[i,j] == 0)
            {
                if (i == n - 1 && j == m - 1) 
                    ok = true;               
                    b[i, j] = true;
                    PA(i - 1, j);
                    PA(i, j + 1);
                    PA(i + 1, j);
                    PA(i, j - 1);
                
            }
        }
        static void Main(string[] args)
        {

            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            a = new int[n, m];
            b = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(5);
                    if (a[i, j] != 0)
                        a[i, j] = 0;
                    else
                        a[i, j] = 1;
                    b[i, j] = false;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            PA(0, 0);
            if (ok == true)
                Console.WriteLine("Da");
            else
                Console.WriteLine("Nu");
            Console.ReadKey();
        }
    }

}



