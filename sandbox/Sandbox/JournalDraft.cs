public class JournalDraft
{
    private List<JournalEntryDraft> Entries = new List<JournalEntryDraft>();

    public void AddEntry (JournalEntryDraft entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split ('|');
                Entries.Add(new JournalEntryDraft(parts[1], parts[2], parts [0]));
            } 
        }
    }
}