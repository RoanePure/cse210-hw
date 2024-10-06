using System;
using System.IO;

// For showing creativity snd exceeding requirements the program will load the scriptures from a file.
// I created a scripture.txt file to load the scriptures.
// I made sure that the program randomly selects a verse from the file instead of showing everything at once.
class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = LoadScriptureFromFile("scripture.txt");

        RunScriptureMemorizer(scripture);
    }

    static Scripture LoadScriptureFromFile(string filePath)
{
    string[] lines = File.ReadAllLines(filePath);
    List<string[]> scriptures = new List<string[]>();
    List<string> currentScripture = new List<string>();

    foreach (string line in lines)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            if (currentScripture.Count > 0)
            {
                scriptures.Add(currentScripture.ToArray());
                currentScripture.Clear();
            }
        }
        else
        {
            currentScripture.Add(line);
        }
    }
    if (currentScripture.Count > 0) scriptures.Add(currentScripture.ToArray());

    Random rand = new Random();
    string[] selectedScripture = scriptures[rand.Next(scriptures.Count)];

    string referenceLine = selectedScripture[0]; 
    string scriptureText = string.Join(" ", selectedScripture.Skip(1)); 

    string[] parts = referenceLine.Split(' ');
    string book = parts[0];
    string[] chapterAndVerse = parts[1].Split(':');
    int chapter = int.Parse(chapterAndVerse[0]);
    string[] verses = chapterAndVerse[1].Split('-');
    int verseStart = int.Parse(verses[0]);
    int? verseEnd = verses.Length > 1 ? int.Parse(verses[1]) : (int?)null;

    Reference reference = new Reference(book, chapter, verseStart, verseEnd);
    return new Scripture(reference, scriptureText);
}


    static void RunScriptureMemorizer(Scripture scripture)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Were you able to memorize the verse/s?");
                break;
            }

            Console.WriteLine("\nPress enter to hide more words, or type 'quit' to exit:");
            string input = Console.ReadLine().Trim();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            scripture.HideRandomWords();
        }
    }
}