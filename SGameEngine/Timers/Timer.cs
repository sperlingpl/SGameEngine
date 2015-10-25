using System;
using System.Collections.Generic;
using System.Text;

namespace SGameEngine.Timers
{
    public class Timer
    {
        internal Action CallbackAction;
        internal double Duration;
        internal bool Running;
        internal double TimeElapsed;
        internal bool RemoveAfterCallback;

        public Timer(double duration, Action callbackAction, bool removeAfterCallback)
        {
            Duration = duration;
            CallbackAction = callbackAction;
            RemoveAfterCallback = removeAfterCallback;
        }
    }
}
