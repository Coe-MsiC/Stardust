// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.osu_example_scrolling_ruleset.Objects;
using osu.Game.Rulesets.osu_example_scrolling_ruleset.UI;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.osu_example_scrolling_ruleset.Replays
{
    public class osu_example_scrolling_rulesetAutoGenerator : AutoGenerator<osu_example_scrolling_rulesetReplayFrame>
    {
        public new Beatmap<osu_example_scrolling_rulesetHitObject> Beatmap => (Beatmap<osu_example_scrolling_rulesetHitObject>)base.Beatmap;

        public osu_example_scrolling_rulesetAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
        }

        protected override void GenerateFrames()
        {
            int currentLane = 0;

            Frames.Add(new osu_example_scrolling_rulesetReplayFrame());

            foreach (osu_example_scrolling_rulesetHitObject hitObject in Beatmap.HitObjects)
            {
                if (currentLane == hitObject.Lane)
                    continue;

                int totalTravel = Math.Abs(hitObject.Lane - currentLane);
                var direction = hitObject.Lane > currentLane ? osu_example_scrolling_rulesetAction.MoveDown : osu_example_scrolling_rulesetAction.MoveUp;

                double time = hitObject.StartTime - 5;

                if (totalTravel == osu_example_scrolling_rulesetPlayfield.LANE_COUNT - 1)
                    addFrame(time, direction == osu_example_scrolling_rulesetAction.MoveDown ? osu_example_scrolling_rulesetAction.MoveUp : osu_example_scrolling_rulesetAction.MoveDown);
                else
                {
                    time -= totalTravel * KEY_UP_DELAY;

                    for (int i = 0; i < totalTravel; i++)
                    {
                        addFrame(time, direction);
                        time += KEY_UP_DELAY;
                    }
                }

                currentLane = hitObject.Lane;
            }
        }

        private void addFrame(double time, osu_example_scrolling_rulesetAction direction)
        {
            Frames.Add(new osu_example_scrolling_rulesetReplayFrame(direction) { Time = time });
            Frames.Add(new osu_example_scrolling_rulesetReplayFrame { Time = time + KEY_UP_DELAY }); //Release the keys as well
        }
    }
}
