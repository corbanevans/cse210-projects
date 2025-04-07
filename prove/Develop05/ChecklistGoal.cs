using System;

namespace EternalQuestProgram
{
    public class ChecklistGoal : Goal
    {
        public int RequiredCount { get; private set; }
        public int CurrentCount { get; private set; }
        public int BonusPoints { get; private set; }
        public bool IsCompleted { get; private set; }

        public ChecklistGoal(string description, int pointsPerEvent, int requiredCount, int bonusPoints)
        {
            Description = description;
            Points = 0;
            RequiredCount = requiredCount;
            CurrentCount = 0;
            BonusPoints = bonusPoints;
            IsCompleted = false;
        }

        public override void RecordEvent()
        {
            if (!IsCompleted)
            {
                CurrentCount++;
                Points += CurrentCount == RequiredCount ? BonusPoints : 0;
                IsCompleted = CurrentCount >= RequiredCount;
            }
        }

        public override string GetProgress()
        {
            return $"Completed {CurrentCount}/{RequiredCount} times.";
        }
    }
}