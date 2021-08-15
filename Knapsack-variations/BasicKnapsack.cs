using System;
using System.Collections.Generic;

//Output maximum profit(based on value of selected item)
//Input value, weight array and target weight(capacity of knapsack)
public static class BasicKnapsack
{
    public static int BasicKnapsackTopDownMemo(IList<int> values, IList<int> weight, int capacity)
    {
        int[][] cache = new int[capacity+1][];
        InitializeCache(cache, values.Count);

        int result =  BasicKnapsackTopDownMemo(values, weight, capacity, values.Count-1, cache);
        //PrintCache(cache);
        return result;
    }

    private static int BasicKnapsackTopDownMemo(IList<int> values, IList<int> weight, int remainingCapacity,
     int currentIndex, int[][] cache)
    {
        if(remainingCapacity == 0) {
            return 0;
        }
        if(currentIndex < 0) {
            return Int32.MinValue;
        }
        if(cache[remainingCapacity][currentIndex] != -1) {
            return cache[remainingCapacity][currentIndex];
        }

        int profitWithIt = Int32.MinValue;
        if(weight[currentIndex] <= remainingCapacity) {
            profitWithIt = BasicKnapsackTopDownMemo(values, weight, remainingCapacity - weight[currentIndex],
             currentIndex - 1, cache) + values[currentIndex];
        }
        int profitWithoutIt = BasicKnapsackTopDownMemo(values, weight, remainingCapacity,
             currentIndex - 1, cache);

        cache[remainingCapacity][currentIndex] = Math.Max(profitWithIt, profitWithoutIt);

        return cache[remainingCapacity][currentIndex];
    }

    private static void InitializeCache(int[][] cache, int rowSize)
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

    private static void PrintCache(int[][] cache) {
        for (int i = 0; i < cache.Length; i++) {
            for (int j = 0; j < cache[0].Length; j++) {
                Console.WriteLine($"capacity{i} -> currentIndex{j} = {cache[i][j]}");
            }
        }
    }
}
