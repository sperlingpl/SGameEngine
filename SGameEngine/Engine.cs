using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SGameEngine.Log;
using SGameEngine.Screen;
using SGameEngine.Sound;
using SGameEngine.Timers;

namespace SGameEngine
{
    public sealed class Engine : IScreen
    {
        private ScreenManager screenManager;
        private TimerManager timerManager;

        /// <summary>
        ///     If no implementation provided, the default one will be used.
        /// </summary>
        public ISoundPlayer SoundPlayer { get; set; }

        /// <summary>
        ///     Draws everything on screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            screenManager.Draw(spriteBatch);
        }

        /// <summary>
        ///     Updates everything.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            timerManager.Update(gameTime);
            screenManager.Update(gameTime);
        }

        /// <summary>
        ///     Initialize game engine.
        /// </summary>
        /// <param name="game"></param>
        public void Init(Game game)
        {
            Logger.Write(LogType.Info, "Initializing engine.");

            timerManager = new TimerManager();
            game.Services.AddService(typeof (TimerManager), timerManager);

            screenManager = new ScreenManager(game);
            game.Services.AddService(typeof (ScreenManager), screenManager);


            if (SoundPlayer == null)
                SoundPlayer = new SoundPlayer();
            game.Services.AddService(typeof (ISoundPlayer), SoundPlayer);
            
            Logger.Write(LogType.Info, "Engine initialized.");
        }
    }
}