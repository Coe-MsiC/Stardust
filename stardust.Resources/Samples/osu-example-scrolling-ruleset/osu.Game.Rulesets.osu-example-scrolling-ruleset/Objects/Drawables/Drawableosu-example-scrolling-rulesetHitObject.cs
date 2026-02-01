// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Audio;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.osu_example_scrolling_ruleset.UI;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.osu_example_scrolling_ruleset.Objects.Drawables
{
    public partial class Drawableosu_example_scrolling_rulesetHitObject : DrawableHitObject<osu_example_scrolling_rulesetHitObject>
    {
        private BindableNumber<int> currentLane;

        public Drawableosu_example_scrolling_rulesetHitObject(osu_example_scrolling_rulesetHitObject hitObject)
            : base(hitObject)
        {
            Size = new Vector2(40);

            Origin = Anchor.Centre;
            Y = hitObject.Lane * osu_example_scrolling_rulesetPlayfield.LANE_HEIGHT;
        }

        [BackgroundDependencyLoader]
        private void load(osu_example_scrolling_rulesetPlayfield playfield, TextureStore textures)
        {
            AddInternal(new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Texture = textures.Get("coin"),
            });

            currentLane = playfield.CurrentLane.GetBoundCopy();
        }

        public override IEnumerable<HitSampleInfo> GetSamples() => new[]
        {
            new HitSampleInfo(HitSampleInfo.HIT_NORMAL)
        };

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= 0)
            {
                if (currentLane.Value == HitObject.Lane)
                    ApplyMaxResult();
                else
                    ApplyMinResult();
            }
        }

        protected override void UpdateHitStateTransforms(ArmedState state)
        {
            switch (state)
            {
                case ArmedState.Hit:
                    this.ScaleTo(5, 1500, Easing.OutQuint).FadeOut(1500, Easing.OutQuint).Expire();
                    break;

                case ArmedState.Miss:

                    const double duration = 1000;

                    this.ScaleTo(0.8f, duration, Easing.OutQuint);
                    this.MoveToOffset(new Vector2(0, 10), duration, Easing.In);
                    this.FadeColour(Color4.Red, duration / 2, Easing.OutQuint).Then().FadeOut(duration / 2, Easing.InQuint).Expire();
                    break;
            }
        }
    }
}
