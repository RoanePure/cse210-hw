using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding your breathing in and out slowly.") {}

    public override void PerformActivity()
    {
        StartActivity();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.WriteLine("Breathe in...");
                Countdown(4);
                DisplayBreathingAnimation(4);
            }
            else
            {
                Console.WriteLine("Breathe out...");
                Countdown(6);
                DisplayBreathingAnimation(6);
            }
            breatheIn = !breatheIn;
        }

        EndActivity();
    }

    private void Countdown(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("o ");
            Thread.Sleep(1000); 
        }
        Console.WriteLine(); 
    }

    private void DisplayBreathingAnimation(int duration)
    {
        for (int i = 1; i <= duration; i++)
        {
            int sleepTime = i * 100;
            Console.Write("");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b"); 
        }
        Console.WriteLine(); 
    }
}