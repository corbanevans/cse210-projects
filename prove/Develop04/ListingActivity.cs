using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you list as many positive things as possible in a given area.";
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowCountdown(3);
        List<string> responses = new List<string>();
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("Enter a response: ");
            responses.Add(Console.ReadLine());
            elapsed += 5;
        }
        Console.WriteLine($"You listed {responses.Count} items.");
    }
}