using System;

namespace EternalQuestProgram
{
    public class SimpleGoal : Goal
    {
        private bool _isCompleted;

        public SimpleGoal(string description, int points)
        {
            _description = description;
            _points = points;
            _isCompleted = false;
        }

        public override void RecordEvent()
        {
            _isCompleted = true;
        }

        public override string GetProgress()
        {
            return _isCompleted ? "[X] Completed" : "[ ] Not Completed";
        }

        public bool GetCompletionStatus()
        {
            return _isCompleted;
        }
    }
}