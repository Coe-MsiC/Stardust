// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;
using osuTK;

namespace osu.Game.Rulesets.osu_example_scrolling_ruleset.UI
{
    public partial class osu_example_scrolling_rulesetCharacter : BeatSyncedContainer, IKeyBindingHandler<osu_example_scrolling_rulesetAction>
    {
        public readonly BindableInt LanePosition = new BindableInt
        {
            Value = 0,
            MinValue = 0,
            MaxValue = osu_example_scrolling_rulesetPlayfield.LANE_COUNT - 1,
        };

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Size = new Vector2(osu_example_scrolling_rulesetPlayfield.LANE_HEIGHT);

            Child = new Sprite
            {
                FillMode = FillMode.Fit,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1.2f),
                RelativeSizeAxes = Axes.Both,
                Texture = textures.Get("character")
            };

            LanePosition.BindValueChanged(e => { this.MoveToY(e.NewValue * osu_example_scrolling_rulesetPlayfield.LANE_HEIGHT); });
        }

        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            if (effectPoint.KiaiMode)
            {
                bool direction = beatIndex % 2 == 1;
                double duration = timingPoint.BeatLength / 2;

                Child.RotateTo(direction ? 10 : -10, duration * 2, Easing.InOutSine);

                Child.Animate(i => i.MoveToY(-10, duration, Easing.Out))
                     .Then(i => i.MoveToY(0, duration, Easing.In));
            }
            else
            {
                Child.ClearTransforms();
                Child.RotateTo(0, 500, Easing.Out);
                Child.MoveTo(Vector2.Zero, 500, Easing.Out);
            }
        }

        public bool OnPressed(KeyBindingPressEvent<osu_example_scrolling_rulesetAction> e)
        {
            switch (e.Action)
            {
                case osu_example_scrolling_rulesetAction.MoveUp:
                    changeLane(-1);
                    return true;

                case osu_example_scrolling_rulesetAction.MoveDown:
                    changeLane(1);
                    return true;

                default:
                    return false;
            }
        }

        public void OnReleased(KeyBindingReleaseEvent<osu_example_scrolling_rulesetAction> e)
        {
        }

        private void changeLane(int change) => LanePosition.Value = (LanePosition.Value + change + osu_example_scrolling_rulesetPlayfield.LANE_COUNT) % osu_example_scrolling_rulesetPlayfield.LANE_COUNT;
    }
}
