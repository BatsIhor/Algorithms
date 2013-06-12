using System;

namespace Quick_Union_2_3
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

                string readLine1 = Console.ReadLine();
                int q = int.Parse(readLine1);
                int qRoot = quickUnion.FindRoot(q);

                //ExitPoint
                if (p == -1)
                    break;

                quickUnion.Union(pRoot, qRoot);

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

        public QuickUnion()
        {
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            id[p] = id[q];
            
            for (int i = 0; i < id.Length; i++)
            {
                Console.Write("{0} ", id[i]);
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
    }
}
