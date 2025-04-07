using System;
using System.Collections.Generic;
using System.IO;




// Added a level up functionality. Each new level requires more points to attain a new level, posing a good challenge for the user to keep up with their goals and continue setting new ones.

namespace EternalQuestProgram
{
    class Program
    {
        private const string SaveFilePath = "EternalQuestData.txt";

        static void Main(string[] args)
        {
            var goals = new List<Goal>();
            var levelSystem = new LevelSystem();

            // Load existing data if available
            LoadData(goals, levelSystem);

            Console.WriteLine("Welcome to the Eternal Quest Program!");
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. Record progress on a goal");
                Console.WriteLine("3. View goals");
                Console.WriteLine("4. View level status");
                Console.WriteLine("5. Save and exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal(goals);
                        break;
                    case "2":
                        RecordProgress(goals, levelSystem);
                        break;
                    case "3":
                        ViewGoals(goals);
                        break;
                    case "4":
                        levelSystem.DisplayLevelStatus();
                        break;
                    case "5":
                        SaveData(goals, levelSystem);
                        exitProgram = true;
                        Console.WriteLine("Data saved. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateGoal(List<Goal> goals)
        {
            Console.WriteLine("\nWhat type of goal would you like to create?");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter a description: ");
                    string simpleDescription = Console.ReadLine();
                    Console.Write("Enter points awarded upon completion: ");
                    int simplePoints = int.Parse(Console.ReadLine());
                    goals.Add(new SimpleGoal(simpleDescription, simplePoints));
                    Console.WriteLine("Simple goal created successfully!");
                    break;

                case "2":
                    Console.Write("Enter a description: ");
                    string eternalDescription = Console.ReadLine();
                    Console.Write("Enter points awarded per event: ");
                    int eternalPoints = int.Parse(Console.ReadLine());
                    goals.Add(new EternalGoal(eternalDescription, eternalPoints));
                    Console.WriteLine("Eternal goal created successfully!");
                    break;

                case "3":
                    Console.Write("Enter a description: ");
                    string checklistDescription = Console.ReadLine();
                    Console.Write("Enter points awarded per event: ");
                    int checklistPoints = int.Parse(Console.ReadLine());
                    Console.Write("Enter the number of events required to complete the goal: ");
                    int requiredCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points awarded upon completion: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(checklistDescription, checklistPoints, requiredCount, bonusPoints));
                    Console.WriteLine("Checklist goal created successfully!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Goal not created.");
                    break;
            }
        }

        static void RecordProgress(List<Goal> goals, LevelSystem levelSystem)
        {
            Console.WriteLine("\nSelect a goal to record progress:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDescription()}");
            }

            Console.Write("Enter the number of the goal: ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < goals.Count)
            {
                goals[goalIndex].RecordEvent();
                levelSystem.AddPoints(goals[goalIndex].GetPoints());
                Console.WriteLine("Progress recorded successfully!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Progress not recorded.");
            }
        }

        static void ViewGoals(List<Goal> goals)
        {
            Console.WriteLine("\nYour Goals:");
            foreach (var goal in goals)
            {
                Console.WriteLine($"- {goal.GetDescription()}");
                Console.WriteLine($"  Progress: {goal.GetProgress()}");
            }
        }

        static void SaveData(List<Goal> goals, LevelSystem levelSystem)
        {
            using (StreamWriter writer = new StreamWriter(SaveFilePath))
            {
                // Save LevelSystem
                writer.WriteLine($"{levelSystem.GetCurrentLevel},{levelSystem.GetTotalPoints},{levelSystem.GetPointsToNextLevel}");

                // Save Goals
                foreach (var goal in goals)
                {
                    if (goal is SimpleGoal simpleGoal)
                    {
                        writer.WriteLine($"SimpleGoal|{simpleGoal.GetDescription}|{simpleGoal.GetPoints}|{simpleGoal.GetCompletionStatus}");
                    }
                    else if (goal is EternalGoal eternalGoal)
                    {
                        writer.WriteLine($"EternalGoal|{eternalGoal.GetDescription}|{eternalGoal.GetPointsPerEvent}|{eternalGoal.GetProgressCount}");
                    }
                    else if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"ChecklistGoal|{checklistGoal.GetDescription}|{checklistGoal.GetPointsPerEvent}|{checklistGoal.GetCurrentCount}|{checklistGoal.GetRequiredCount}|{checklistGoal.GetBonusPoints}|{checklistGoal.GetCompletionStatus}");
                    }
                }
            }
        }

        static void LoadData(List<Goal> goals, LevelSystem levelSystem)
{
    if (!File.Exists(SaveFilePath)) return;

    using (StreamReader reader = new StreamReader(SaveFilePath))
    {
        // Load LevelSystem data
        string levelData = reader.ReadLine();
        var levelParts = levelData.Split(',');
        levelSystem.Load(levelData); // Ensures proper handling in LevelSystem class

        // Load Goals
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var parts = line.Split('|');
            string goalType = parts[0];

            switch (goalType)
            {
                case "SimpleGoal":
                    var simpleGoal = new SimpleGoal(parts[1], int.Parse(parts[2]));
                    if (bool.Parse(parts[3])) 
                    {
                        simpleGoal.RecordEvent(); // Marks it completed if saved as completed
                    }
                    goals.Add(simpleGoal);
                    break;

                case "EternalGoal":
                    var eternalGoal = new EternalGoal(parts[1], int.Parse(parts[2]));
                    eternalGoal.LoadProgress(int.Parse(parts[3]));
                    goals.Add(eternalGoal);
                    break;

                case "ChecklistGoal":
                    var checklistGoal = new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[5]));
                    checklistGoal.LoadProgress(int.Parse(parts[3]), bool.Parse(parts[6]));
                    goals.Add(checklistGoal);
                    break;

                    }
                }
            }
        }
    }
}