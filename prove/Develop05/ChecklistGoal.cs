using System;

namespace EternalQuestProgram
{
    public class ChecklistGoal : Goal
    {
        public int PointsPerEvent { get; private set; }
        public int CurrentCount { get; private set; }
        public int RequiredCount { get; private set; }
        public int BonusPoints { get; private set; }
        public bool IsCompleted { get; private set; }

        public ChecklistGoal(string description, int pointsPerEvent, int requiredCount, int bonusPoints)
        {
            Description = description;
            PointsPerEvent = pointsPerEvent;
            RequiredCount = requiredCount;
            BonusPoints = bonusPoints;
            CurrentCount = 0;
            IsCompleted = false;
        }

        public override void RecordEvent()
        {
            if (!IsCompleted)
            {
                CurrentCount++;
                Points += PointsPerEvent;

                if (CurrentCount >= RequiredCount)
                {
                    Points += BonusPoints;
                    IsCompleted = true;
                }
            }
        }

        public override string GetProgress()
        {
            return $"Completed {CurrentCount}/{RequiredCount} times.";
        }

        // Method to load saved progress
        public void LoadProgress(int currentCount, bool isCompleted)
        {
            CurrentCount = currentCount;
            IsCompleted = isCompleted;
        }
    }
}