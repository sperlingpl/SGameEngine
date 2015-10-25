using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SGameEngine.Screen
{
    public class ScreenManager : IScreen
    {
        /// <summary>
        /// Current displayed screen.
        /// </summary>
        private IScreen currentScreen;

        public Dictionary<Type, IScreen> Screens { get; set; }

        public ScreenManager()
        {
            Screens = new Dictionary<Type, IScreen>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Load(Type screenType)
        {
            
        }
    }
}
