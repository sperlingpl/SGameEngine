using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SGameEngine.Content;
using SGameEngine.Log;

namespace SGameEngine.Graphics
{
    public static class AnimationLoader
    {
        /// <summary>
        ///     Loads XML file, deserialize and return list of animations.
        /// </summary>
        /// <param name="fileName">File to load.</param>
        /// <returns>Animation list.</returns>
        public static AnimationConfig LoadAnimation(string fileName)
        {
            var animationConfig = new AnimationConfig();

            try
            {
                Xml.AnimationConfig xmlAnimationConfig;

                using (var fileStream = TitleContainer.OpenStream(fileName))
                {
                    var xmlSerializer = new XmlSerializer(typeof (Xml.AnimationConfig));
                    xmlAnimationConfig = (Xml.AnimationConfig) xmlSerializer.Deserialize(fileStream);
                }

                animationConfig.DefaultAnimation = xmlAnimationConfig.DefaultAnimation;

                foreach (var animationXml in xmlAnimationConfig.Animations)
                {
                    var animation = new Animation
                    {
                        Name = animationXml.Name,
                        Loop = animationXml.Loop,
                        Texture2D = ContentManager.Instance.Load<Texture2D>(animationXml.Texture)
                    };

                    var animationFrames = new List<AnimationFrame>();

                    foreach (var frameXml in animationXml.Frames)
                    {
                        var animationFrame = new AnimationFrame(frameXml.Duration,
                            new Rectangle(frameXml.X, frameXml.Y, frameXml.Width, frameXml.Height));

                        animationFrames.Add(animationFrame);
                    }

                    animation.Frames = animationFrames;

                    animationConfig.Animations.Add(animation);
                }
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Logger.Write(LogType.Error, fileNotFoundException);
            }
            catch (ArgumentException argumentException)
            {
                Logger.Write(LogType.Error, argumentException);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                Logger.Write(LogType.Error, invalidOperationException);
            }

            return animationConfig;
        }
    }
}