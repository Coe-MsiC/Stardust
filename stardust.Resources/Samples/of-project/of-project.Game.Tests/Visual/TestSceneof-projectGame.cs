using osu.Framework.Allocation;
using NUnit.Framework;

namespace of_project.Game.Tests.Visual
{
    [TestFixture]
    public partial class TestSceneof_projectGame : of_projectTestScene
    {
        // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they will recompile and update immediately.

        [BackgroundDependencyLoader]
        private void load()
        {
            AddGame(new of_projectGame());
        }
    }
}
