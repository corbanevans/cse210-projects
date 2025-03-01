using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"{_name}\n{_description}\n");
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity();
        EndActivity();
    }

    protected abstract void RunActivity();

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    private void EndActivity()
    {
        Console.WriteLine($"Well done! You completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }
}