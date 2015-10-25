using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SGameEngine.Screen
{
    public class ScreenManager : IScreen
    {
        private readonly Game game;

        /// <summary>
        ///     List of screens visible on device. Last screen is on top and it gets input.
        /// </summary>
        private readonly List<BaseScreen> visibleScreens;

        public ScreenManager(Game game)
        {
            this.game = game;
            Screens = new Dictionary<Type, BaseScreen>();
            visibleScreens = new List<BaseScreen>();
        }

        public Dictionary<Type, BaseScreen> Screens { get; set; }

        /// <summary>
        ///     Draws all visible screens.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (var i = 0; i < visibleScreens.Count; i++)
            {
                visibleScreens[i].Draw(spriteBatch);
            }
        }

        /// <summary>
        ///     Updates last (top) screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            for (var i = 0; i < visibleScreens.Count; i++)
            {
                visibleScreens[i].Update(gameTime);
            }
        }

        public void Load(Type screenType)
        {
            if (Screens.ContainsKey(screenType))
            {
                if (Screens[screenType] != null)
                    return;
            }

            var screen = (BaseScreen) Activator.CreateInstance(screenType, game);

            Screens[screenType] = screen;

            Task.Run(() => { screen.Load(); });
        }

        /// <summary>
        ///     Invokes Unload method on screen and removes it from visible screens stack (if it's on this stack).
        /// </summary>
        /// <param name="screenType"></param>
        public void Unload(Type screenType)
        {
            if (!Screens.ContainsKey(screenType))
                return;

            if (Screens[screenType] == null)
                return;

            var screen = Screens[screenType];

            if (visibleScreens.Contains(screen))
                visibleScreens.Remove(screen);

            screen.Unload();
            Screens[screenType] = null;
        }

        /// <summary>
        ///     Shows selected screen on top of screen stack.
        /// </summary>
        /// <param name="screenType">Screen type to show.</param>
        public void ShowOnTop(Type screenType)
        {
            if (!Screens.ContainsKey(screenType))
                return;

            if (Screens[screenType] == null)
                return;

            var screen = Screens[screenType];

            if (visibleScreens.Contains(screen) && visibleScreens.Last() != screen)
            {
                visibleScreens.Remove(screen);
            }

            var lastScreen = visibleScreens.LastOrDefault();
            lastScreen?.Deactivated();

            visibleScreens.Add(screen);

            screen.Activated();
        }
    }
}