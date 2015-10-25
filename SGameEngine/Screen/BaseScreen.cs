using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SGameEngine.Screen
{
    public class BaseScreen : IScreen
    {
        protected ContentManager Content { get; set; }

        public BaseScreen(Game game)
        {
            Content = new ContentManager(game.Content.ServiceProvider, game.Content.RootDirectory);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
