using System;

class ReflectionActivity : MindfulnessActivity
{
    private string[] _prompts = {
        "\n------ Think of a time when you stood up for someone else. ------",
        "\n------ Think of a time when you did something really difficult. ------",
        "\n------ Think of a time when you helped someone in need. ------",
        "\n------ Think of a time when you did something truly selfless. ------"
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times when you have shown strength and resilience.") {}

    public override void PerformActivity()
    {
        StartActivity();
        
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Length)]);

        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();
        
        // Shuffle the questions array
        ShuffleQuestions(_questions, random);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        foreach (string question in _questions)
        {
            if (DateTime.Now >= endTime) break;
            Console.WriteLine(question);
            DisplaySpinner(5);
        }

        EndActivity();
    }

    private void ShuffleQuestions(string[] questions, Random random)
    {
        for (int i = questions.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            string temp = questions[i];
            questions[i] = questions[j];
            questions[j] = temp;
        }
    }
}