using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string _activityName;
    protected string _activityDescription;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _activityName = name;
        _activityDescription = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName}: {_activityDescription}");
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine($"Good job! You have completed the {_activityName} for {_duration} seconds.");
        DisplaySpinner(3);
    }

    public void DisplaySpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b"); 
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    public abstract void PerformActivity();
}