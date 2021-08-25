using System;
using System.Collections.Generic;
using DP_Playground.Helpers;

//Output maximum profit(based on value of selected item)
//Input value, weight array and target weight(capacity of knapsack)
public static class BasicKnapsack
{
    public static int BasicKnapsackTopDownMemo(IList<int> values, IList<int> weight, int capacity)
    {
        int[][] cache = new int[capacity+1][];
        HelperMethods.InitializeCache(cache, values.Count);

        int result =  BasicKnapsackTopDownMemo(values, weight, capacity, values.Count-1, cache);
        //PrintCache(cache);
        return result;
    }

    private static int BasicKnapsackTopDownMemo(IList<int> values, IList<int> weight, int remainingCapacity,
     int currentIndex, int[][] cache)
    {
        if(remainingCapacity == 0 || currentIndex < 0) {
            return 0;
        }
        if(cache[remainingCapacity][currentIndex] != -1) {
            return cache[remainingCapacity][currentIndex];
        }

        int profitWithIt = 0;
        if(weight[currentIndex] <= remainingCapacity) {
            int prevResult = BasicKnapsackTopDownMemo(values, weight, remainingCapacity - weight[currentIndex],
             currentIndex - 1, cache);
            profitWithIt = prevResult + values[currentIndex];
        }
        int profitWithoutIt = BasicKnapsackTopDownMemo(values, weight, remainingCapacity,
             currentIndex - 1, cache);

        cache[remainingCapacity][currentIndex] = Math.Max(profitWithIt, profitWithoutIt);

        return cache[remainingCapacity][currentIndex];
    }

    public static int BasicKnapsackBottomUpTabulation(IList<int> values, IList<int> weight, int capacity) {
        int[][] resultsTable = new int[values.Count+1][];

        for(int i = 0; i <= values.Count; i++) {
            resultsTable[i] = new int[capacity+1];
            resultsTable[i][0] = 0;
        }

        for (int c = 0; c <= capacity; c++) {
            resultsTable[0][c] = 0;
        }

        for(int row = 1; row < resultsTable.Length; row++) {
            for(int col = 1; col < resultsTable[0].Length; col++) {
                int profitWithIt = Int32.MinValue;
                if(weight[row-1] <= col) {
                    profitWithIt = values[row-1] + resultsTable[row-1][col-weight[row - 1]];
                }
                int profitWithoutIt = resultsTable[row - 1][col];
                int maxProfit = Math.Max(profitWithIt, profitWithoutIt);
                resultsTable[row][col] = maxProfit == Int32.MinValue ? 0 : maxProfit;
            }
        }
        Console.WriteLine("DP table: ");
        foreach(var row in resultsTable) {
            Console.WriteLine(string.Join('\t', row));
        }

        return resultsTable[resultsTable.Length-1][resultsTable[0].Length-1];
    }
}
