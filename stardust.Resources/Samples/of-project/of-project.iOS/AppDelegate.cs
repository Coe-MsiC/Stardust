using osu.Framework.iOS;
using of_project.Game;

namespace of_project.iOS
{
    /// <inheritdoc />
    public class AppDelegate : GameApplicationDelegate
    {
        /// <inheritdoc />
        protected override osu.Framework.Game CreateGame() => new of_projectGame();
    }
}
