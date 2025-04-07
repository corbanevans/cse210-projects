using System;

namespace EternalQuestProgram
{
    public class LevelSystem
    {
        public int CurrentLevel { get; set; }
        public int TotalPoints { get; set; }
        public int PointsToNextLevel { get; set; }

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
            return CurrentLevel * 1000;
        }

        public void DisplayLevelStatus()
        {
            Console.WriteLine($"Current Level: {CurrentLevel}");
            Console.WriteLine($"Total Points: {TotalPoints}");
            Console.WriteLine($"Points to Next Level: {PointsToNextLevel - TotalPoints}");
        }

        public string Save()
        {
            return $"{CurrentLevel},{TotalPoints},{PointsToNextLevel}";
        }

        public void Load(string data)
        {
            var parts = data.Split(',');
            CurrentLevel = int.Parse(parts[0]);
            TotalPoints = int.Parse(parts[1]);
            PointsToNextLevel = int.Parse(parts[2]);
        }
    }
}