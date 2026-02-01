using osu.Framework.Platform;
using osu.Framework;
using of_project.Game;

namespace of_project.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"of_project"))
            using (osu.Framework.Game game = new of_projectGame())
                host.Run(game);
        }
    }
}
