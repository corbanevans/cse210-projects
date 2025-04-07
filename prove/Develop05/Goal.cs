using System;

namespace EternalQuestProgram
{
    public abstract class Goal
    {
        protected string _description; // Protected for access in derived classes
        protected int _points;         // Protected for access in derived classes

        public string GetDescription()
        {
            return _description;
        }

        public int GetPoints()
        {
            return _points;
        }

        public abstract void RecordEvent();
        public abstract string GetProgress();
    }
}