using of_example_project.Game.Elements;
using osu.Framework.Allocation;
using NUnit.Framework;

namespace of_example_project.Game.Tests.Visual
{
    /// <summary>
    /// A test scene for testing the alignment
    /// and placement of the sprites that make up the backdrop
    /// </summary>
    [TestFixture]
    public partial class TestSceneBackdrop : of_example_projectTestScene
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new Backdrop(() => new BackdropSprite()));
        }
    }
}
