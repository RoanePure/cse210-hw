using System;

class Program
{
    static void Main(string[] args)
    {
        // Generate random number 1-100
        Random random = new Random();
        int MagicNumber = random.Next(1, 101);

        int guess = -1;

        // Looping until guessed correctly
        while (guess != MagicNumber)
        {
            Console.Write("What is your guess? ");
            string GuessInput = Console.ReadLine();
            guess = int.Parse(GuessInput);

            // Determine if guessed number is lower or higher or correct
            if (guess < MagicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > MagicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it correctly!");
            }
        }
    }
}