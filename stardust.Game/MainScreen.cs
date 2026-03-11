using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK.Graphics;
using osuTK;

namespace stardust.Game
{
    public partial class MainScreen : Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {

            InternalChildren = new Drawable[]
            {
                new Box // Background
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new osuTK.Graphics.Color4(18, 18, 28, 255),
                },

                ColumnDimensions = new[]
                {
                    new Dimension(GridSizeMode.Absolute, 250),
                    new Dimension(),
                }

                private CreateProjectPanel createPanel = null!;

                createPanel = new CreateProjectPanel();


                Action = () => createPanel.Show()
            };

        }
    }
}
 