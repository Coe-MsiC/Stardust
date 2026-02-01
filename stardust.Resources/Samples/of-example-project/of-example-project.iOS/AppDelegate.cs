using of_example_project.Game;
using osu.Framework.iOS;

namespace of_example_project.iOS
{
    /// <inheritdoc />
    public class AppDelegate : GameApplicationDelegate
    {
        /// <inheritdoc />
        protected override osu.Framework.Game CreateGame() => new of_example_projectGame();
    }
}
