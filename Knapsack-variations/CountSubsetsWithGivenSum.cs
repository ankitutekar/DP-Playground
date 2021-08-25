using DP_Playground.Helpers;

namespace DP_Playground.Knapsack_variations
{
    /*******************************************************************
        Given an array arr[] of length N and an integer X,
        the task is to find the number of subsets with a sum equal to X.
    ********************************************************************/
    public static class CountSubsetsWithGivenSum
    {
        public static int CountSubsetsWithGivenSumMemoized(int[] array, int targetSum)
        {
            int[][] cache = new int[array.Length][];
            HelperMethods.InitializeCache(cache, targetSum+1);

            return CountSubsetsWithGivenSumMemoized(array, targetSum, 0, array.Length-1, cache);
        }

        private static int CountSubsetsWithGivenSumMemoized(int[] array, int targetSum, int currentSum,
         int currentIndex, int[][] cache)
        {
            if(currentSum == targetSum)
            {
                return 1;
            }
            else if(currentIndex < 0)
            {
                return 0;
            }
            else if(cache[currentIndex][currentSum] != -1)
            {
                return cache[currentIndex][currentSum];
            }
            int totalWays = 0;
            if(array[currentIndex] + currentSum <= targetSum)
            {
                totalWays = CountSubsetsWithGivenSumMemoized(array, targetSum, currentSum + array[currentIndex], currentIndex - 1, cache)
                + CountSubsetsWithGivenSumMemoized(array, targetSum, currentSum, currentIndex - 1, cache);
            }
            else
            {
                totalWays = CountSubsetsWithGivenSumMemoized(array, targetSum, currentSum, currentIndex - 1, cache);
            }

            cache[currentIndex][currentSum] = totalWays;

            return cache[currentIndex][currentSum];
        }
    }
}