using System;

// This class is for representing a single entry.
public class JournalEntry
{
    private string _prompt;
    private string _response;
    private string _date;
    private int _wordCount;

    public JournalEntry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
        _wordCount = response.Split(' ').Length; // Calculates the word count
    }

    public string Prompt => _prompt;
    public string Response => _response;
    public string Date => _date;
    public int WordCount => _wordCount;

    public override string ToString()
    {
        return $"{Date} - {Prompt}\nResponse: {Response}\nWord Count: {WordCount}\n";
    }

}