using System;
using System.Linq;
using DP_Playground.Helpers;
using DP_Playground.Knapsack_variations;

namespace DP_Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            char choice = ' ';
            while(choice != 'Q')
            {
                RunCountSubsetsWithGivenSum();
                Console.WriteLine("\nPress 'Q' to quit, any other key to continue with other test cases:");
                choice = Console.ReadKey().KeyChar;
            }
        }

        static void RunSubSetWithGivenSum()
        {
            Console.WriteLine("\nEnter array values:");
            var inputArray = HelperMethods.ReadIntegerArray();
            Console.WriteLine("Enter target sum:");
            var sum = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Is it possible to generate target sum with given array??? Memoized solution says {SubsetWithGivenSum.SubSetWithGivenSumMemoized(inputArray, sum)}!!!!");
            Console.WriteLine($"Is it possible to generate target sum with given array??? Tabulation solution says {SubsetWithGivenSum.SubSetWithGivenSumTabulation(inputArray, sum)}!!!!");
        }

        static void RunBasicKnapsack()
        {
            Console.WriteLine("Enter values array:");
            int[] values = HelperMethods.ReadIntegerArray();
            Console.WriteLine("Enter weight array:");
            int[] weight = HelperMethods.ReadIntegerArray();
            Console.WriteLine("Enter total capacity of Knapsack:");
            int totalCapacity = Convert.ToInt32(Console.ReadLine());
            int totalProfitUsingMemo = BasicKnapsack.BasicKnapsackTopDownMemo(values, weight, totalCapacity);
            int totalProfitUsingTabulation = BasicKnapsack.BasicKnapsackBottomUpTabulation(values, weight, totalCapacity);
            Console.WriteLine($"Here is your total profit using memoization:{totalProfitUsingMemo}!!!");
            Console.WriteLine($"Here is your total profit using tabulation:{totalProfitUsingTabulation}!!! \nPress any key to close:");
            Console.ReadKey();
        }

        static void RunCountSubsetsWithGivenSum()
        {
            Console.WriteLine("\nEnter array values:");
            var inputArray = HelperMethods.ReadIntegerArray();
            Console.WriteLine("Enter target sum:");
            var sum = Int32.Parse(Console.ReadLine());
            
            int totalWays = CountSubsetsWithGivenSum.CountSubsetsWithGivenSumMemoized(inputArray, sum);

            Console.WriteLine($"Total number of subsets with given sum using top-down memoized solution:{totalWays}!!");
        }
    }
}
