using System;

namespace PrintNumIndex
{
    internal class Program
    {
        static void Main()
        {
            int k;
            
            do
            {
                k = int.Parse(Console.ReadLine());

                if (k <= 0 || k >= 21)
                {
                    Console.WriteLine("Invalid value for k! Please try again.");
                }
            } while (k <= 0 || k >= 21);

            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];

            for (int i = 0; i < n;)
            {
                int num = int.Parse(Console.ReadLine());

                if (num <= 0 || num >= 21)
                {
                    Console.WriteLine("Invalid value for number! Please try again.");
                }
                else
                {
                    nums[i] = num;
                    i++;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < k)
                {
                    Console.WriteLine($"{nums[i]}: {i}");
                }
            }
        }
    }
}