using osu.Framework;
using osu.Framework.Platform;

namespace of_project.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost("visual-tests"))
            using (var game = new of_projectTestBrowser())
                host.Run(game);
        }
    }
}
