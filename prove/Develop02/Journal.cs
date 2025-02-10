using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private Random random = new Random();

    public void WriteNewEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Rate your mood today (1-10): ");
        int moodRating = int.TryParse(Console.ReadLine(), out int mood) ? mood : 5;

        JournalEntry entry = new JournalEntry
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd"),
            Prompt = prompt,
            Response = response,
            MoodRating = moodRating
        };

        entries.Add(entry);
        Console.WriteLine($"Entry saved! Word count: {response.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length}");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\nMood Rating: {entry.MoodRating}/10\n---");
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);

        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<JournalEntry>>(json) ?? new List<JournalEntry>();
            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}