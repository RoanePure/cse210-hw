using System;
using System.Collections.Generic;

// For showing creativity I included a word count for each entry added (Save other information in the journal entry).
// I also included an error handling for LoadFromFile if the file is not found.

// This class is responsible for the main application.
class Program
{
    private static Journal journal = new Journal();
    private static List<string> prompts = new List<string>
    {
        "What was the best part of my day?",
        "What life lessons did I learn today?",
        "How can I be better than I was yesterday?",
        "What challenges did I face today?",
        "How did I resolve or face problems I had today?"
    };

    static void Main(string[] args)
    {
        string choice ="";
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
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write(">> ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        JournalEntry entry = new JournalEntry(prompt, response, date);
        journal.AddEntry(entry);
    }

    private static void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    private static void SaveJournal()
    {
        Console.Write("Enter filename to save journal (journal.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "journal.txt";
        }

        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully");
    }

    private static void LoadJournal()
    {
        Console.Write("Enter filename to load journal (journal.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "journal.txt";
        }
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully");
    }
}