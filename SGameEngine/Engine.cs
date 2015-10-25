using Microsoft.Xna.Framework;
using SGameEngine.Screen;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using SGameEngine.Sound;

namespace SGameEngine
{
    public sealed class Configuration : IScreen
    {
        private ScreenManager screenManager;

        private ISoundPlayer soundPlayer;
        public ISoundPlayer SoundPlayer
        {
            private get { return soundPlayer; }
            set
            {
                soundPlayer = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screenManager.Draw(spriteBatch);
        }

        /// <summary>
        /// Initialize game engine.
        /// </summary>
        /// <param name="game"></param>
        public void Init(Game game)
        {
            screenManager = new ScreenManager();

            if (SoundPlayer == null)
                SoundPlayer = new SoundPlayer();

            game.Services.AddService(typeof(ScreenManager), screenManager);
        }

        public void Update(GameTime gameTime)
        {
            screenManager.Update(gameTime);
        }
    }
}
