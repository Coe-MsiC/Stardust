using of_example_project.Game;
using osu.Framework;
using osu.Framework.Platform;

namespace of_example_project.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"of_example_project"))
            using (osu.Framework.Game game = new of_example_projectGame())
            {
                host.Run(game);
            }
        }
    }
}
