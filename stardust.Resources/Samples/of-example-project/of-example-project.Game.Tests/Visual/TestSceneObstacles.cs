using of_example_project.Game.Elements;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using NUnit.Framework;

namespace of_example_project.Game.Tests.Visual
{
    /// <summary>
    /// A scene to test the layout and positioning and rotation of two pipe sprites.
    /// </summary>
    [TestFixture]
    public partial class TestSceneObstacles : of_example_projectTestScene
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Obstacles obstacles = new Obstacles
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
            obstacles.Start();

            Add(obstacles);
        }
    }
}
