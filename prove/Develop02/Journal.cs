using System;
using System.Collections.Generic;
using System.IO;

// This class is for managing journal entries
public class Journal
{
    private List<JournalEntry> _entries;

    public Journal()
    {
        _entries =  new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }

        else
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.WordCount}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
            return; // Exit if the file does not exist.
        }
        
        _entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                JournalEntry entry = new JournalEntry(parts[1], parts[2], parts[0]);
                _entries.Add(entry);
            }
        }
    }
}