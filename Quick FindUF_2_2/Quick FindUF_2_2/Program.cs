using System;

namespace Quick_FindUF_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickFindUF quickFind = new QuickFindUF();

            // Connecting
            while (true)
            {
                string readLine = Console.ReadLine();
                int p = int.Parse(readLine);

                string readLine1 = Console.ReadLine();
                int q = int.Parse(readLine1);

                //ExitPoint
                if(p == -1)
                    break;
                
                quickFind.Union(p, q);
            
            }

            // Check if points are connected.
            string readLine2 = Console.ReadLine();
            int p1 = int.Parse(readLine2);

            string readLine3 = Console.ReadLine();
            int q1 = int.Parse(readLine3);

            if (quickFind.IsConnected(p1, q1))
            {
                Console.WriteLine("Connected");
                Console.ReadLine();
            }
        }
    }

    class QuickFindUF
    {
        int[] id = new int[10];

        public QuickFindUF()
        {
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }

        public bool IsConnected(int p, int q)
        {
            return id[p] == id[q];
        }

        public void Union(int p, int q) 
        {
            int pid = id[p];
            int qid = id[q];
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pid)
                {
                    id[i] = qid;
                }
                Console.Write("{0} ", id[i]);
            }
            Console.WriteLine();
        }
    }
}
