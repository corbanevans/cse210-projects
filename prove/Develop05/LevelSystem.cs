using System;

namespace EternalQuestProgram
{
    public class LevelSystem
    {
        public int CurrentLevel { get; private set; }
        public int TotalPoints { get; private set; }
        public int PointsToNextLevel { get; private set; }

        public LevelSystem()
        {
            CurrentLevel = 1;
            TotalPoints = 0;
            PointsToNextLevel = CalculatePointsToNextLevel();
        }

        public void AddPoints(int points)
        {
            TotalPoints += points;

            while (TotalPoints >= PointsToNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            CurrentLevel++;
            Console.WriteLine($"Congratulations! You've leveled up to Level {CurrentLevel}!");
            PointsToNextLevel = CalculatePointsToNextLevel();
        }

        private int CalculatePointsToNextLevel()
        {
            return CurrentLevel * 1000; // Example: Levels require 1000 points multiplied by the current level.
        }

        public void DisplayLevelStatus()
        {
            Console.WriteLine($"Current Level: {CurrentLevel}");
            Console.WriteLine($"Total Points: {TotalPoints}");
            Console.WriteLine($"Points to Next Level: {PointsToNextLevel - TotalPoints}");
        }
    }
}