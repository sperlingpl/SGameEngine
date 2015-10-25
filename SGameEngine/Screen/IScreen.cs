using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SGameEngine.Screen
{
    public interface IScreen
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}