using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SGameEngine.Graphics
{
    public class GameObject
    {
        /// <summary>
        ///     List of animations.
        /// </summary>
        private readonly Dictionary<string, Animation> animations;

        /// <summary>
        ///     Current visible animation.
        /// </summary>
        private Animation currentAnimation;

        public GameObject()
        {
            animations = new Dictionary<string, Animation>();
            Position = new Vector2();
            Visible = true;
        }

        /// <summary>
        ///     Visibility of object.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        ///     Object position.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        ///     Add animation to object.
        /// </summary>
        /// <param name="animation">Animation definition.</param>
        public void AddAnimation(Animation animation)
        {
            if (animation == null)
                return;

            if (animations.ContainsKey(animation.Name))
                return;

            animations.Add(animation.Name, animation);
        }

        /// <summary>
        ///     Loads animations definition file and associated textures.
        /// </summary>
        /// <param name="fileName">XML file to load.</param>
        public void AddAnimations(string fileName)
        {
            var animationsConfig = AnimationLoader.LoadAnimation(fileName);


            if (animationsConfig.Animations != null)
            {
                foreach (var animation in animationsConfig.Animations)
                {
                    AddAnimation(animation);
                }
            }

            ShowAnimation(animationsConfig.DefaultAnimation);
        }

        /// <summary>
        ///     Shows animation selected by name.
        /// </summary>
        /// <param name="name">Animation name.</param>
        public void ShowAnimation(string name)
        {
            animations.TryGetValue(name, out currentAnimation);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 screenOffset)
        {
            if(!Visible)
                return;
            
            if(currentAnimation == null)
                return;
            
            if(currentAnimation.Texture2D == null)
                return;

            var drawPosition = Position - screenOffset;
            var animationFrame = currentAnimation.CurrentFrame;

            spriteBatch.Draw(currentAnimation.Texture2D, drawPosition, null, animationFrame.RegionRectangle);
        }

        public virtual void Update(GameTime gameTime)
        {
            currentAnimation?.Update(gameTime);
        }
    }
}