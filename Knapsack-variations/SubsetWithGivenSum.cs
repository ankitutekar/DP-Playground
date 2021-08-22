using System;
using System.Linq;

namespace DP_Playground.Knapsack_variations
{
    /*
        Given a set of non-negative integers, and a value sum,
        determine if there is a subset of the given set with sum equal to given sum.
    */
    static public class SubsetWithGivenSum
    {
        public static bool SubSetWithGivenSumMemoized(int[] array, int sum)
        {
            var cache = GetInitializedBooleanCache(array.Length, sum+1);
            var result = SubSetWithGivenSumMemoized(array, 0, sum, array.Length - 1, cache);
            return result;
        }

        public static bool SubSetWithGivenSumTabulation(int[] array, int sum)
        {
            var resultsTable = GetInitializedBooleanCache(array.Length + 1, sum+1);

            for(int i = 1; i < resultsTable.Length; i++)
            {
                for(int j = 1; j < resultsTable[0].Length; j++)
                {
                    if(array[i-1] <= j)
                    {
                        resultsTable[i][j] = (array[i-1] == j) ||
                                            resultsTable[i-1][j-array[i - 1]];
                    }
                    else
                    {
                        resultsTable[i][j] = resultsTable[i - 1][j];
                    }
                }
            }

            return resultsTable[resultsTable.Length-1][resultsTable[0].Length - 1];
            
        }

        private static bool SubSetWithGivenSumMemoized(int[] array, int currentSum, int targetSum,
         int currentIndex, bool[][] cache)
        {
            if (currentSum == targetSum)
                return true;
            else if(currentIndex < 0)
                return false;
            else if(cache[currentIndex][currentSum])
            {
                return false;
            }

            cache[currentIndex][currentSum] = true;
            if(currentSum + array[currentIndex] <= targetSum)
            {
                return SubSetWithGivenSumMemoized(array, currentSum, targetSum, currentIndex - 1, cache)
                        || SubSetWithGivenSumMemoized(array, currentSum + array[currentIndex], targetSum, currentIndex - 1, cache);
            }
            else
            {
                return SubSetWithGivenSumMemoized(array, currentSum, targetSum, currentIndex - 1, cache);
            }
        }

        private static bool[][] GetInitializedBooleanCache(int rows, int cols)
        {
            var cache = new bool[rows][];
            for (int i = 0; i < rows; i++)
            {
                cache[i] = Enumerable.Repeat(false, cols).ToArray();
            }
            return cache;
        }
        
    }
}