using System;
using System.Collections.Generic;
using System.Linq;

// For showing creativity snd exceeding requirements the program will load the scriptures from a file.
// I created a scripture.txt file to load the scriptures.
// I made sure that the program randomly selects a verse from the file instead of showing everything at once.  
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count = 3)
    {
        Random rand = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string Display()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.Display()));
        return $"{_reference}\n{scriptureText}";
    }
}
