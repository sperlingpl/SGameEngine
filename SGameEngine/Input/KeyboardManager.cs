using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SGameEngine.Input
{
    public static class KeyboardManager
    {
        private static readonly List<Keys> keysDownList = new List<Keys>();

        /// <summary>
        ///     Updates pressed keys.
        /// </summary>
        public static void Update()
        {
            var state = Keyboard.GetState();

            var keysToRemove = new List<Keys>();

            foreach (var key in keysDownList)
            {
                if (state.IsKeyUp(key))
                    keysToRemove.Add(key);
            }

            for (var i = 0; i < keysToRemove.Count; i++)
            {
                keysDownList.Remove(keysToRemove[i]);
            }
        }

        /// <summary>
        ///     Checks if key is pressed.
        /// </summary>
        /// <param name="key">Key to check.</param>
        /// <returns>True if key is pressed.</returns>
        public static bool IsKeyPressed(Keys key)
        {
            var state = Keyboard.GetState();
            return state.IsKeyDown(key);
        }

        /// <summary>
        ///     Checks if is pressed once.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns false if after first check key wasn't up.</returns>
        public static bool IsKeyPressedOnce(Keys key)
        {
            if (!IsKeyPressed(key))
                return false;

            if (keysDownList.Contains(key))
                return false;

            keysDownList.Add(key);

            return true;
        }
    }
}
