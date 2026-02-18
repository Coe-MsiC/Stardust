using osu.Framework.Platform;
using osu.Framework;
using stardust.Game;

namespace stardust.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"stardust"))
            using (osu.Framework.Game game = new stardustGame())
                host.Run(game);
        }
    }
}
