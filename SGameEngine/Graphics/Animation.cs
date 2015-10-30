using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SGameEngine.Graphics
{
    public class Animation
    {
        /// <summary>
        ///     List of animation frames (coords in texture).
        /// </summary>
        private readonly List<AnimationFrame> frames = new List<AnimationFrame>();

        /// <summary>
        ///     Duration of current frame.
        /// </summary>
        private double currentFrameDuration;

        /// <summary>
        ///     Current showing frame index.
        /// </summary>
        private int currentFrameIndex;

        public Animation(Texture2D texture2D, string name, List<AnimationFrame> frames, bool loop = false)
        {
            Texture2D = texture2D;
            Name = name;
            Loop = loop;
            this.frames = frames;
        }

        /// <summary>
        ///     Texture containing animation.
        /// </summary>
        public Texture2D Texture2D { get; set; }

        /// <summary>
        ///     Animation name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets looping of animation.
        /// </summary>
        public bool Loop { get; set; }

        /// <summary>
        ///     Gets current frame.
        /// </summary>
        public AnimationFrame CurrentFrame
        {
            get { return frames[currentFrameIndex]; }
        }

        public void Update(GameTime gameTime)
        {
            if (currentFrameDuration >= frames[currentFrameIndex].FrameDuration)
            {
                if (currentFrameIndex < frames.Count - 1)
                    currentFrameIndex++;
                else
                {
                    if (!Loop)
                        return;

                    currentFrameIndex = 0;
                }

                currentFrameDuration = 0.0f;
                return;
            }

            currentFrameDuration += gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}