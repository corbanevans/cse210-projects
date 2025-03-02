using System;
using System.Collections.Generic;
using System.Threading;


class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you showed strength and resilience.";
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.Clear();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(3);
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Clear();
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}