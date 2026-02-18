using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
namespace stardust.Game
{
    public partial class ProjectsPanel : Container
    {
        public ProjectsPanel(string title, Colour4 color)
        {
            RelativeSizeAxes = Axes.X;
            Height = 60;
            Masking = true;
            CornerRadius = 10;

            InternalChildren = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = color
                },
                new SpriteText
                {
                    Text = title,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Font = FontUsage.Default.With(size: 20)
                }
            };
        }
    }
}