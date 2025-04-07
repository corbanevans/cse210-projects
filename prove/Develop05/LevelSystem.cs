using System;

namespace EternalQuestProgram
{
    public class LevelSystem
    {
        private int _currentLevel;
        private int _totalPoints;
        private int _pointsToNextLevel;

        public LevelSystem()
        {
            _currentLevel = 1;
            _totalPoints = 0;
            _pointsToNextLevel = CalculatePointsToNextLevel();
        }

        public void AddPoints(int points)
        {
            _totalPoints += points;

            while (_totalPoints >= _pointsToNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            _currentLevel++;
            Console.WriteLine($"Congratulations! You've leveled up to Level {_currentLevel}!");
            _pointsToNextLevel = CalculatePointsToNextLevel();
        }

        private int CalculatePointsToNextLevel()
        {
            return _currentLevel * 1000;
        }

        public void DisplayLevelStatus()
        {
            Console.WriteLine($"Current Level: {_currentLevel}");
            Console.WriteLine($"Total Points: {_totalPoints}");
            Console.WriteLine($"Points to Next Level: {_pointsToNextLevel - _totalPoints}");
        }

        public string Save()
        {
            return $"{_currentLevel},{_totalPoints},{_pointsToNextLevel}";
        }

        public void Load(string data)
        {
            var parts = data.Split(',');
            _currentLevel = int.Parse(parts[0]);
            _totalPoints = int.Parse(parts[1]);
            _pointsToNextLevel = int.Parse(parts[2]);
        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }

        public int GetTotalPoints()
        {
            return _totalPoints;
        }

        public int GetPointsToNextLevel()
        {
            return _pointsToNextLevel;
        }
    }
}