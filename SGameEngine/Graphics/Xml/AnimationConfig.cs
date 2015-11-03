using System.Collections.Generic;
using System.Xml.Serialization;

namespace SGameEngine.Graphics.Xml
{
    [XmlRoot("Config")]
    public class AnimationConfig
    {
        [XmlElement]
        public string DefaultAnimation { get; set; }

        [XmlArray]
        public List<Animation> Animations { get; set; }
    }

    public class Animation
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool Loop { get; set; }

        [XmlAttribute]
        public string Texture { get; set; }

        [XmlArray]
        public List<Frame> Frames { get; set; }
    }

    public class Frame
    {
        [XmlAttribute]
        public int X { get; set; }

        [XmlAttribute]
        public int Y { get; set; }

        [XmlAttribute]
        public int Width { get; set; }

        [XmlAttribute]
        public int Height { get; set; }

        [XmlAttribute]
        public double Duration { get; set; }
    }
}