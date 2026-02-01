// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Audio;
using osu.Game.Rulesets.Objects.Drawables;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.osu_example_ruleset.Objects.Drawables
{
    public partial class Drawableosu_example_rulesetHitObject : DrawableHitObject<osu_example_rulesetHitObject>
    {
        private const double time_preempt = 600;
        private const double time_fadein = 400;

        public override bool HandlePositionalInput => true;

        public Drawableosu_example_rulesetHitObject(osu_example_rulesetHitObject hitObject)
            : base(hitObject)
        {
            Size = new Vector2(80);

            Origin = Anchor.Centre;
            Position = hitObject.Position;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            AddInternal(new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Texture = textures.Get("coin"),
            });
        }

        public override IEnumerable<HitSampleInfo> GetSamples() => new[]
        {
            new HitSampleInfo(HitSampleInfo.HIT_NORMAL)
        };

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= 0)
            {
                if (IsHovered)
                    ApplyMaxResult();
                else
                    ApplyMinResult();
            }
        }

        protected override double InitialLifetimeOffset => time_preempt;

        protected override void UpdateInitialTransforms() => this.FadeInFromZero(time_fadein);

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
                    this.FadeColour(Color4.Red.Opacity(0.5f), duration / 2, Easing.OutQuint).Then().FadeOut(duration / 2, Easing.InQuint).Expire();
                    break;
            }
        }
    }
}
