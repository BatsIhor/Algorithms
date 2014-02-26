using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    /// <summary>
    /// Depth-first search alg
    /// </summary>
    class Program
    {
        private int[] arr = new[] {2, 3, 4, 4, 4, 5, 6, 4, 8, 9, 10, 11};

        static void Main(string[] args)
        {
        }

        private void dfs(int v)
        {
           
        }


        int findHead(int index)
        {
            int item = arr[index];
            if(item != index)
                findHead(item);
            return item;
        }
    }
}
