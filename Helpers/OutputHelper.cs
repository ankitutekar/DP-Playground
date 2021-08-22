using System;

namespace DP_Playground.Helpers
{
    public static class OutputHelper
    {
        public static void PrintCache<T>(T[][] cache)
        {
            for (int i = 0; i < cache.Length; i++)
            {
                for (int j = 0; j < cache[0].Length; j++)
                {
                    Console.WriteLine($"row_{i} -> column_{j} = {cache[i][j]}");
                }
            }
        }
        
    }
}