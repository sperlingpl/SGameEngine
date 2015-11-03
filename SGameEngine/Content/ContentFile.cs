using Microsoft.Xna.Framework;
using MonoContent = Microsoft.Xna.Framework.Content.ContentManager;

namespace SGameEngine.Content
{
    internal class ContentFile
    {
        private MonoContent monoContentManager;

        /// <summary>
        ///     File name.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        ///     File tag for grouping content files.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        ///     Content data.
        /// </summary>
        public object Data { get; private set; }

        /// <summary>
        ///     Creates new Mono content manager and loads data.
        /// </summary>
        /// <typeparam name="T">Content type.</typeparam>
        /// <param name="game">Game instance.</param>
        /// <param name="fileName">File to load.</param>
        public void Load<T>(Game game, string fileName)
        {
            monoContentManager = new MonoContent(game.Content.ServiceProvider, game.Content.RootDirectory);
            Data = monoContentManager.Load<T>(fileName);
            FileName = fileName;
        }

        /// <summary>
        ///     Unload content.
        /// </summary>
        public void Unload()
        {
            if (Data != null)
            {
                Data = null;
            }

            monoContentManager?.Unload();
        }
    }
}