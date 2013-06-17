using System;

namespace Quick_Union_Improvements_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickUnion quickUnion = new QuickUnion();

            // Connecting
            while (true)
            {
                string readLine = Console.ReadLine();
                int p = int.Parse(readLine);
                int pRoot = quickUnion.FindRoot(p);
                int pRootDepth = quickUnion.FindRootDepth(p);

                //ExitPoint
                if (p == -1)
                    break;

                string readLine1 = Console.ReadLine();
                int q = int.Parse(readLine1);
                int qRoot = quickUnion.FindRoot(q);
                int qRootDepth = quickUnion.FindRootDepth(q);

                if (pRootDepth < qRootDepth)
                {
                    quickUnion.Union(pRoot, qRoot);
                }
                else
                {
                    quickUnion.Union(qRoot, pRoot);                    
                }
            }

            // Check if points are connected.
            string readLine2 = Console.ReadLine();
            int p1 = int.Parse(readLine2);

            string readLine3 = Console.ReadLine();
            int q1 = int.Parse(readLine3);

            if (quickUnion.IsConnected(p1, q1))
            {
                Console.WriteLine("Connected");
                Console.ReadLine();
            }
        }
    }

    internal class QuickUnion
    {
        int[] id = new int[10];
        int[] rd = new int[10];

        public QuickUnion()
        {
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }

            for (int i = 0; i < rd.Length; i++)
            {
                rd[i] =1;
            }
        }

        public void Union(int p, int q)
        {
            id[p] = id[q];

            rd[q] += rd[p];

            for (int i = 0; i < id.Length; i++)
            {
                Console.Write("{0} ", id[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < rd.Length; i++)
            {
                Console.Write("{0} ", rd[i]);
            }
            Console.WriteLine();
        }

        public bool IsConnected(int p, int q)
        {
            return id[p] == id[q];
        }

        public int FindRoot(int item)
        {
            while (item != id[item])
            {
                item = id[item];
            }

            Console.WriteLine("Root {0}", item);
            return item;
        }

        /// <summary>
        /// Array has to be used here because find the root depth takes maybe the same time as looking for it before merge. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int FindRootDepth(int item)
        {
            Console.WriteLine("Root Depth {0}", rd[item]);
            return rd[item];
        }
    }
}
