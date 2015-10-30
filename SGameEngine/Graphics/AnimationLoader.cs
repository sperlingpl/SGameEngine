using System;
using System.IO;
using Microsoft.Xna.Framework;
using SGameEngine.Log;

namespace SGameEngine.Graphics
{
    public static class AnimationLoader
    {
        public static Animation LoadAnimation(string fileName)
        {
            Animation animation = null;

            try
            {
                using (var fileStream = TitleContainer.OpenStream(fileName))
                {
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

            return animation;
        }
    }
}