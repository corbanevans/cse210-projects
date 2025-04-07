using System;

namespace EternalQuestProgram
{
    public class EternalGoal : Goal
    {
        public int PointsPerEvent { get; private set; }
        public int ProgressCount { get; private set; }

        public EternalGoal(string description, int pointsPerEvent)
        {
            Description = description;
            PointsPerEvent = pointsPerEvent;
            ProgressCount = 0;
        }

        public override void RecordEvent()
        {
            ProgressCount++;
            Points += PointsPerEvent;
        }

        public override string GetProgress()
        {
            return $"Recorded {ProgressCount} times.";
        }
    }
}