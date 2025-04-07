using System;

namespace EternalQuestProgram
{
    public class SimpleGoal : Goal
    {
        public bool IsCompleted { get; private set; }

        public SimpleGoal(string description, int points)
        {
            Description = description;
            Points = points;
            IsCompleted = false;
        }

        public override void RecordEvent()
        {
            IsCompleted = true;
        }

        public override string GetProgress()
        {
            return IsCompleted ? "[X] Completed" : "[ ] Not Completed";
        }
    }
}