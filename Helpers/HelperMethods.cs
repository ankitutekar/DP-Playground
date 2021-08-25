using System;
using System.Linq;

namespace DP_Playground.Helpers
{
    public static class HelperMethods
    {
        public static void InitializeCache(int[][] cache, int rowSize)
        {
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = new int[rowSize];
            }

            for (int i = 0; i < cache.Length; i++)
            {
                for (int j = 0; j < cache[0].Length; j++)
                {
                    cache[i][j] = -1;
                }
            }
        }

        public static int[] ReadIntegerArray()
        {
            return Console.ReadLine()
                     .Split(' ')
                     .Select(x => Int32.Parse(x))
                     .ToArray();
        }
    }
}