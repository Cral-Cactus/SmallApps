using System;
using System.Linq;

namespace SumPositiveAndNegative
{
    internal class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();

            int positiveSum = 0;
            int negativeSum = 0;

            Console.Write("Positive: ");
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    Console.Write($"{(i == 0 ? "" : "+")}{nums[i]}");
                    positiveSum += nums[i];
                }
            }

            Console.WriteLine($"={positiveSum}");

            Console.Write("Negative: ");
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    Console.Write($"{nums[i]}");
                    negativeSum += nums[i];
                }
            }

            Console.WriteLine($"={negativeSum}");
        }
    }
}