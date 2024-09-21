using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask user for grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int GradePercentage = int.Parse(input);

        // Variable for letter grade
        string letter = "";

        // Determine letter grade
        if (GradePercentage >= 90)
        {
            letter = "A";
        }

        else if (GradePercentage >= 80)
        {
            letter = "B";
        }

        else if (GradePercentage >= 70)
        {
            letter = "C";
        }

        else if (GradePercentage >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        // Print lettetr grade
        Console.WriteLine($"Your grade is: {letter}");

        // Determine if passed or failed
        if (GradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You PASSED!");
        }

        else
        {
            Console.WriteLine("Sorry, you did NOT PASSED");
        }
    }
}