using System;

class Program
{
    static void Main()
    {
        Activity running = new Running(new DateTime(2025, 4, 5), 30, 3.0);
        Activity cycling = new Cycling(new DateTime(2025, 4, 6), 40, 15.0);
        Activity swimming = new Swimming(new DateTime(2025, 4, 7), 25, 20);

        Activity[] activities = { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}