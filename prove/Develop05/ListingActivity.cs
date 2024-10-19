class ListingActivity : MindfulnessActivity
{
    private string[] _prompts = {
        "\nWho are people that you appreciate?",
        "\nWhat are personal strengths of yours?",
        "\nWho are people that you have helped this week?",
        "\nWho are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on positive things by listing items in certain areas.") {}

    public override void PerformActivity()
    {
        StartActivity();
        
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Length)]);
        Console.WriteLine("Start listing your items:");

        int itemCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity();
    }
}