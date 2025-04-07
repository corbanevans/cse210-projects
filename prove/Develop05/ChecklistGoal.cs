using System;

namespace EternalQuestProgram
{
    public class ChecklistGoal : Goal
    {
        private int _pointsPerEvent;
        private int _currentCount;
        private int _requiredCount;
        private int _bonusPoints;
        private bool _isCompleted;

        public ChecklistGoal(string description, int pointsPerEvent, int requiredCount, int bonusPoints)
        {
            _description = description;
            _pointsPerEvent = pointsPerEvent;
            _requiredCount = requiredCount;
            _bonusPoints = bonusPoints;
            _currentCount = 0;
            _isCompleted = false;
        }

        public override void RecordEvent()
        {
            if (!_isCompleted)
            {
                _currentCount++;
                _points += _pointsPerEvent;

                if (_currentCount >= _requiredCount)
                {
                    _points += _bonusPoints;
                    _isCompleted = true;
                }
            }
        }

        public override string GetProgress()
        {
            return $"Completed {_currentCount}/{_requiredCount} times.";
        }

        public void LoadProgress(int currentCount, bool isCompleted)
        {
            _currentCount = currentCount;
            _isCompleted = isCompleted;
        }

        public int GetPointsPerEvent()
        {
            return _pointsPerEvent;
        }

        public int GetCurrentCount()
        {
            return _currentCount;
        }

        public int GetRequiredCount()
        {
            return _requiredCount;
        }

        public int GetBonusPoints()
        {
            return _bonusPoints;
        }

        public bool GetCompletionStatus()
        {
            return _isCompleted;
        }
    }
}