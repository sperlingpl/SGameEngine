using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SGameEngine.Screen
{
    public abstract class BaseScreen : IScreen
    {
        private readonly Game game;

        protected BaseScreen(Game game)
        {
            this.game = game;
            Content = new ContentManager(game.Content.ServiceProvider, game.Content.RootDirectory);
        }

        /// <summary>
        ///     Screen content.
        /// </summary>
        protected ContentManager Content { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Load()
        {
        }

        /// <summary>
        ///     Unloads all content.
        /// </summary>
        public virtual void Unload()
        {
            Content.Unload();
        }

        public virtual void Activated()
        {
        }

        public virtual void Deactivated()
        {
        }

        public virtual void GetInput()
        {
        }
    }
}