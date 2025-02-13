using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference Reference { get; }
    private List<Word> Words { get; }
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", Words));
    }

    public void HideRandomWords()
    {
        var visibleWords = Words.Where(w => !w._isHidden).ToList();
        if (visibleWords.Count == 0) return;
        
        int wordsToHide = Math.Max(1, visibleWords.Count / 5);
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden() => Words.All(w => w._isHidden);

    public string GetReference() => Reference.ToString();
}