using System;
using System.Collections.Generic;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding your breathing.";
    }

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            for (int i = 1; i <= 5; i++)
            {
                Console.Clear();
                Console.WriteLine("Breathe in...");
                PrintCircle(i);
                Thread.Sleep(1000);
            }
            
            Console.Clear();
            Console.WriteLine("Breathe out...");
            for (int i = 5; i >= 1; i--)
            {
                Console.Clear();
                Console.WriteLine("Breathe out...");
                PrintCircle(i);
                Thread.Sleep(1000);
            }
            elapsed += 10;
        }
    }

    private void PrintCircle(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(new string('*', size * 2));
        }
    }
}