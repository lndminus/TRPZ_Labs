using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    class ActionsException : Exception
    {
        public int Steps { get; }
        public ActionsException(string message, int steps)
            : base(message)
        {
            Steps = steps;
        }
    }

    class DirectionException : Exception
    {
        public DirectionException(string message)
            : base(message)
        {
        }
    }
    class OffRobotException : Exception
    {
        public OffRobotException(string message)
            : base(message)
        {
        }
    }
}
