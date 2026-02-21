using System;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace stardust.Game
{
    public partial class CreateProjectPanel : FocusedOverlayContainer
    {
        private BasicTextBox nameInput;
        private BasicTextBox pathInput;
        private BasicButton createButton;

        public CreateProjectPanel()
        {
            Size = new Vector2(500, 400);
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Masking = true;
            CornerRadius = 10;

            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(30, 30, 30, 255)
                },
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(0, 20),
                    Padding = new MarginPadding(20),
                    Children = new Drawable[]
                    {
                        new SpriteText { Text = "Create New Project", Font = new FontUsage(size: 30) },
                        
                        new SpriteText { Text = "Project Name" },
                        nameInput = new BasicTextBox { RelativeSizeAxes = Axes.X, Height = 40},
                        
                        new SpriteText { Text = "Location" },
                        pathInput = new BasicTextBox { RelativeSizeAxes = Axes.X, Height = 40, PlaceholderText = "/home/user/projects/" },
                        

                        createButton = new BasicButton
                        {
                            Text = "CREATE IT!",
                            RelativeSizeAxes = Axes.X,
                            Height = 50,
                            BackgroundColour = Color4.DeepSkyBlue,
                            Action = OnCreateRequested
                        }
                    }
                }
            };
        }

        // ---------THE GENERATOR---------
        private async void OnCreateRequested()
        {
            string name = nameInput.Text;
            string path = pathInput.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(path))
                return; // This is for Error messages

            createButton.Enabled.Value = false;
            createButton.Text = "Creating Project";

            try
            {
                // AWAKE THE GENERATOR
                var generator = new ProjectGenerator();
                
                // DO DOTNET SH*T
                await generator.CreateProjectAsync(name, path);

                // K*LL... I MEANT CLOSE THE WINDOW
                this.Hide();
                
                // if you making a fork you cna add things that happen after generating
            }
            catch (Exception e)
            {
                createButton.Text = "An Error happend!";
                createButton.BackgroundColour = Color4.Red;
            }
            finally // so true...
            {
                createButton.Enabled.Value = true;
            }
        }  



        // This sh*t is there so the submenu will turn into Wing Ding Gaster
        protected override void PopIn()
        {
            this.FadeIn(400, Easing.OutQuint);
            this.ScaleTo(0.7f).ScaleTo(1.0f, 400, Easing.OutBounce);
        }

        protected override void PopOut()
        {

            this.FadeOut(200, Easing.InQuint);
            this.ScaleTo(0.8f, 200, Easing.InQuint);
        }

    }
}
