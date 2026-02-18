using osu.Framework;
using osu.Framework.Platform;

namespace stardust.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost("visual-tests"))
            using (var game = new stardustTestBrowser())
                host.Run(game);
        }
    }
}
