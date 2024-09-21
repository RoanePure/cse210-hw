using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List to store the numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished: ");

        int number = -1;

        // Collect numbers until user enter 0
        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Compute sum of numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Compute average of numbers
        float average = (float)sum/numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find largest number
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}