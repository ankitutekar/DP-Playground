﻿using System;
using System.Linq;

namespace DP_Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
            int totalProfit = BasicKnapsack.BasicKnapsackTopDownMemo(values, weight, totalCapacity);

            Console.WriteLine($"Here is your total profit:{totalProfit}!!! \nPress any key to close:");
            Console.ReadKey();
        }
    }
}