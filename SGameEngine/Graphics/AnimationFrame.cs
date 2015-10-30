using Microsoft.Xna.Framework;

namespace SGameEngine.Graphics
{
    public class AnimationFrame
    {
        public AnimationFrame(double frameDuration, Rectangle regionRectangle)
        {
            FrameDuration = frameDuration;
            RegionRectangle = regionRectangle;
        }

        /// <summary>
        ///     Frame duration in seconds and milliseconds.
        /// </summary>
        public double FrameDuration { get; set; }

        /// <summary>
        ///     Rectangle region coordinates in texture of animation frame.
        /// </summary>
        public Rectangle RegionRectangle { get; set; }
    }
}