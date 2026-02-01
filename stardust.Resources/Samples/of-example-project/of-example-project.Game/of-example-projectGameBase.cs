using of_example_project.Resources;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;

namespace of_example_project.Game
{
    /// <summary>
    /// Set up the relevant resource stores and texture settings.
    /// </summary>
    public abstract partial class of_example_projectGameBase : osu.Framework.Game
    {
        protected override TextureFilteringMode DefaultTextureFilteringMode
            // To preserve the 8-bit aesthetic, disable texture filtering
            // so they won't become blurry when upscaled
            => TextureFilteringMode.Nearest;

        [BackgroundDependencyLoader]
        private void load()
        {
            // Load the assets from our Resources project
            Resources.AddStore(new DllResourceStore(of_example_projectResources.ResourceAssembly));
        }
    }
}
