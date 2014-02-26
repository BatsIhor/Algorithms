using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader reader = new StreamReader("map.txt");

            //parse file
            int[,] inputArray = Parse(reader);

            //Connect lines horizontally
            ConnectHorizontally(inputArray);
        }

        private static int[,] ConnectHorizontally(int[,] inputArray)
        {
            int[,] result = new int[7, 12];

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    //build relation table or smt like that. 
                    if(inputArray[x,y])
                }
            }
            return result;
        }

        private static int[,] Parse(TextReader reader)
        {

            int[,] midle = new int[7, 12];

            int j = 0;

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    for (int x = 0; x < 7; x++)
                    {
                        for (int y = 0; y < 12; y++)
                        {
                            Console.Write(midle[x, y]);
                        }
                        Console.WriteLine();

                    }
                }
                //split lines

                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (line[i] == '1')
                    {
                        midle[j, i] = 1;
                    }
                    else
                    {
                        midle[j, i] = 0;
                    }
                }
                j++; // next line
            }
            return midle;
        }


    }
}
