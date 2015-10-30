using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SGameEngine.Graphics
{
    public class GameObject
    {
        public GameObject()
        {
            Animations = new Dictionary<string, Animation>();
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
        ///     List of animations.
        /// </summary>
        public Dictionary<string, Animation> Animations { get; set; }

        /// <summary>
        ///     Add animation to object.
        /// </summary>
        /// <param name="animation">Animation definition.</param>
        public void AddAnimation(Animation animation)
        {
            if(animation == null)
                return;
            
            if (Animations.ContainsKey(animation.Name))
                return;

            Animations.Add(animation.Name, animation);
        }

        /// <summary>
        ///     Shows animation selected by name.
        /// </summary>
        /// <param name="name">Animation name.</param>
        public void ShowAnimation(string name)
        {
        }
    }
}