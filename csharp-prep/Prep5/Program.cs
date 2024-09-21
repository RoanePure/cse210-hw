using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string UserName = PromptUserName();
        int UserNumber = PromptUserNumber();

        int SquaredNumber = SquareNumber(UserNumber);

        DisplayResult(UserName, SquaredNumber);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number*number;
    }

    static void DisplayResult(string name, int SquaredNumber)
    {
        Console.WriteLine ($"{name}, the square of your number is {SquaredNumber}");
    }
}