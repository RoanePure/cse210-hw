using System;
using System.Transactions;

class Program
{
    private static JournalDraft journal = new JournalDraft();
    private static List<string> prompts = new List<string>()
    {
        "What was the best part of my day?",
        "What life lessons did I learn today?",
        "How can I be better than I was yesterday?",
        "What challenges did I face today?",
        "How did I resolve or face problems I had today?"
    };

    static void Main(string[] args)
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("select an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                
                case "2":
                    DisplayJournal();
                    break;
                
                case "3":
                    SaveJournal();
                    break;

                case "4":
                    LoadJournal();
                    break;
            }
        }
    }

    private static void WriteNewEntry()
    {
        Random random = new Random();
        string prompt = prompts [random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        JournalEntryDraft entry = new JournalEntryDraft(prompt, response, date);
        journal.AddEntry(entry);
    }

    private static void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    private static void SaveJournal()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal save successfully");
    }

    public static void LoadJournal()
    {
        Console.Write("Enter files name to load journal: ");
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully");
    }
}