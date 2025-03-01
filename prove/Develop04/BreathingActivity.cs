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
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            elapsed += 8;
        }
    }
}