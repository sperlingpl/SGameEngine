using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SGameEngine.Screen;
using SGameEngine.Sound;
using SGameEngine.Timers;

namespace SGameEngine
{
    public sealed class Configuration : IScreen
    {
        private ScreenManager screenManager;
        private TimerManager timerManager;
        public ISoundPlayer SoundPlayer { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            screenManager.Draw(spriteBatch);
        }

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
            timerManager = new TimerManager();
            game.Services.AddService(typeof(TimerManager),timerManager);

            screenManager = new ScreenManager(game);
            game.Services.AddService(typeof(ScreenManager), screenManager);


            if (SoundPlayer == null)
                SoundPlayer = new SoundPlayer();
            game.Services.AddService(typeof(ISoundPlayer), SoundPlayer);
        }
    }
}