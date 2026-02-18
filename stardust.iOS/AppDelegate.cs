using osu.Framework.iOS;
using stardust.Game;

namespace stardust.iOS
{
    /// <inheritdoc />
    public class AppDelegate : GameApplicationDelegate
    {
        /// <inheritdoc />
        protected override osu.Framework.Game CreateGame() => new stardustGame();
    }
}
