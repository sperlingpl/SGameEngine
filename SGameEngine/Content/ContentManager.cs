using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SGameEngine.Log;

namespace SGameEngine.Content
{
    public class ContentManager
    {
        private readonly List<ContentFile> files = new List<ContentFile>();
        private Game game;

        public void Init(Game game)
        {
            this.game = game;
        }

        /// <summary>
        ///     Load asset.
        /// </summary>
        /// <typeparam name="T">Asset type.</typeparam>
        /// <param name="fileName">Asset file name.</param>
        /// <param name="tag">Asset group tag.</param>
        /// <returns>Asset object.</returns>
        public T Load<T>(string fileName, string tag = "") where T : class
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Logger.Write(LogType.Error, "Asset file name is empty!");
                return null;
            }

            var file = files.FirstOrDefault(x => x.FileName == fileName);

            // Check if file is already loaded.
            if (file == null)
            {
                // Perform loading.
                file = new ContentFile {Tag = tag};

                try
                {
                    file.Load<T>(game, fileName);
                }
                catch (ContentLoadException contentLoadException)
                {
                    Logger.Write(LogType.Error, contentLoadException);
                    return null;
                }
            }

            return (T) file.Data;
        }

        /// <summary>
        ///     Remove all loaded assets by tag.
        /// </summary>
        /// <param name="tag">Tag group.</param>
        public void RemoveAllByTag(string tag)
        {
            var toRemove = files.Where(x => x.Tag == tag).ToList();
            foreach (var file in toRemove)
            {
                file.Unload();
                files.Remove(file);
            }
        }

        /// <summary>
        ///     Remove single asset by file name.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void Remove(string fileName)
        {
            var toRemove = files.FirstOrDefault(x => x.FileName == fileName);
            if (toRemove == null)
                return;

            toRemove.Unload();
            files.Remove(toRemove);
        }

        #region Instance

        private static ContentManager instance;

        public static ContentManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContentManager();
                }

                return instance;
            }
        }

        #endregion
    }
}