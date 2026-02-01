// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.osu_example_ruleset.UI
{
    [Cached]
    public partial class osu_example_rulesetPlayfield : Playfield
    {
        protected override GameplayCursorContainer CreateCursor() => new osu_example_rulesetCursorContainer();

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                HitObjectContainer,
            });
        }
    }
}
