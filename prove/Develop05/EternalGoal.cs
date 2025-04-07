using System;

namespace EternalQuestProgram
{
    public class EternalGoal : Goal
    {
        private int _pointsPerEvent;
        private int _progressCount;

        public EternalGoal(string description, int pointsPerEvent)
        {
            _description = description;
            _pointsPerEvent = pointsPerEvent;
            _progressCount = 0;
        }

        public override void RecordEvent()
        {
            _progressCount++;
            _points += _pointsPerEvent;
        }

        public override string GetProgress()
        {
            return $"Recorded {_progressCount} times.";
        }

        public void LoadProgress(int progressCount)
        {
            _progressCount = progressCount;
        }

        public int GetPointsPerEvent()
        {
            return _pointsPerEvent;
        }

        public int GetProgressCount()
        {
            return _progressCount;
        }
    }
}