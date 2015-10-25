using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SGameEngine.Timers
{
    public class TimerManager
    {
        private readonly List<Timer> timers = new List<Timer>();

        /// <summary>
        ///     Add a new timer and starts measuring time.
        /// </summary>
        /// <param name="duration">When the action must be started.</param>
        /// <param name="callbackAction">Action to invoke on time.</param>
        /// <param name="removeAfterCallback">Remove timer from list after execution of callback.</param>
        /// <returns>Timer instance.</returns>
        public Timer AddTimer(double duration, Action callbackAction, bool removeAfterCallback = false)
        {
            var timer = new Timer(duration, callbackAction, removeAfterCallback) {Running = true};
            timers.Add(timer);

            return timer;
        }

        /// <summary>
        ///     Remove specified timer.
        /// </summary>
        /// <param name="timer">Timer to remove.</param>
        public void Remove(Timer timer)
        {
            timers.Remove(timer);
        }

        /// <summary>
        ///     Remove all timers.
        /// </summary>
        public void RemoveAll()
        {
            timers.Clear();
        }

        /// <summary>
        ///     Update timers.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {
            var timersToRemove = new List<Timer>();

            for (var i = 0; i < timers.Count; i++)
            {
                var timer = timers[i];

                if (!timer.Running)
                    continue;

                timer.TimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

                if (timer.TimeElapsed >= timer.Duration)
                {
                    timer.Running = false;

                    timer.CallbackAction?.Invoke();

                    if (timer.RemoveAfterCallback)
                        timersToRemove.Add(timer);
                }
            }

            foreach (var timer in timersToRemove)
            {
                timers.Remove(timer);
            }
        }
    }
}