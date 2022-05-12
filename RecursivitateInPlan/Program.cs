using System;
using System.Collections.Generic;
using System.IO;

namespace RecursivitateInPlan
{
    class Program
    {
        
        static int [,] readM( string fName) //how to read a Matrix from file
        {
            int[,] toR;
            string buffer;
            List<string> T = new List<string>();
            TextReader load = new StreamReader(fName);
            while ((buffer = load.ReadLine()) != null)
                T.Add(buffer);
            load.Close();
            int n = T.Count;
            int m = T[0].Split(' ').Length;
            toR = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] ld = T[i].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    toR[i, j] = int.Parse(ld[j]);
                }               
            }
            return toR;
        }

        static void viewM(int [,]m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] tn;
        static bool[,] b;
        static int t, nr, nrmax = 0;
        static void PA(int i,int j)
        {
            if (i >= 0 && j >= 0 && i < tn.GetLength(0) && j < tn.GetLength(1) && !b[i,j] && tn[i,j] == t )
            {
                nr++;
                b[i, j] = true;
                PA(i - 1, j);
                PA(i, j + 1);
                PA(i + 1, j);
                PA(i, j + 1);
            }
        }
            
        static void Main(string[] args)
        {
            tn = readM(@"..\..\TextFile1.txt");
            b = new bool[tn.GetLength(0), tn.GetLength(1)];
            viewM(tn);

            for (int i = 0; i < tn.GetLength(0); i++)
            {
                for (int j = 0; j < tn.GetLength(1); j++)
                {
                    if (! b[i,j])
                    {
                        nr = 0;
                        t = tn[i, j];
                        PA(i, j);
                        if (nr > nrmax)
                            nrmax = nr;
                    }
                }
            }
            Console.Write(nrmax + " ");
            Console.ReadKey();



        }
    }
}
