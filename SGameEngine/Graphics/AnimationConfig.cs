using System;
using System.Collections.Generic;
using System.Text;

namespace SGameEngine.Graphics
{
    public class AnimationConfig
    {
        public AnimationConfig()
        {
            Animations = new List<Animation>();
        }

        public string DefaultAnimation { get; set; }
        public List<Animation> Animations { get; set; } 
    }
}
