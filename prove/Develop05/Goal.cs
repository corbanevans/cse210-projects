using System;

namespace EternalQuestProgram
{
    public abstract class Goal
    {
        public string Description { get; set; }
        public int Points { get; protected set; }
        public abstract void RecordEvent();
        public abstract string GetProgress();
    }
}