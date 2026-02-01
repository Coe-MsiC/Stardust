using osu.Framework.Allocation;
using NUnit.Framework;

namespace of_example_project.Game.Tests.Visual
{
    /// <summary>
    /// A test scene wrapping the entire game,
    /// including audio.
    /// </summary>
    [TestFixture]
    public partial class TestSceneof_example_projectGame : of_example_projectTestScene
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddGame(new of_example_projectGame());
        }
    }
}
