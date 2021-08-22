using System;
using System.Linq;
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
                RunSubSetWithGivenSum();
                Console.WriteLine("\nPress 'Q' to quit, any other key to continue with other test cases:");
                choice = Console.ReadKey().KeyChar;
            }
        }

        static void RunSubSetWithGivenSum()
        {
            Console.WriteLine("\nEnter array values:");
            var inputArray = Console.ReadLine()
                             .Split(' ')
                             .Select(x => Int32.Parse(x))
                             .ToArray();
            Console.WriteLine("Enter target sum:");
            var sum = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Is it possible to generate target sum with given array??? {SubsetWithGivenSum.SubSetWithGivenSumMemoized(inputArray, sum)}!!!!");
        }

        static void RunBasicKnapsack()
        {
            Console.WriteLine("Enter values array:");
            int[] values = Console.ReadLine()
                                    .Split(' ')
                                    .Select(x => Int32.Parse(x))
                                    .ToArray();
            Console.WriteLine("Enter weight array:");
            int[] weight = Console.ReadLine()
                                    .Split(' ')
                                    .Select(x => Int32.Parse(x))
                                    .ToArray();
            Console.WriteLine("Enter total capacity of Knapsack:");
            int totalCapacity = Convert.ToInt32(Console.ReadLine());
            int totalProfitUsingMemo = BasicKnapsack.BasicKnapsackTopDownMemo(values, weight, totalCapacity);
            int totalProfitUsingTabulation = BasicKnapsack.BasicKnapsackBottomUpTabulation(values, weight, totalCapacity);
            Console.WriteLine($"Here is your total profit using memoization:{totalProfitUsingMemo}!!!");
            Console.WriteLine($"Here is your total profit using tabulation:{totalProfitUsingTabulation}!!! \nPress any key to close:");
            Console.ReadKey();
        }
    }
}
