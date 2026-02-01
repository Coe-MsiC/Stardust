// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.osu_scrolling_ruleset.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.osu_scrolling_ruleset.Replays
{
    public class osu_scrolling_rulesetAutoGenerator : AutoGenerator<osu_scrolling_rulesetReplayFrame>
    {
        public new Beatmap<osu_scrolling_rulesetHitObject> Beatmap => (Beatmap<osu_scrolling_rulesetHitObject>)base.Beatmap;

        public osu_scrolling_rulesetAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
        }

        protected override void GenerateFrames()
        {
            Frames.Add(new osu_scrolling_rulesetReplayFrame());

            foreach (osu_scrolling_rulesetHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new osu_scrolling_rulesetReplayFrame
                {
                    Time = hitObject.StartTime
                    // todo: add required inputs and extra frames.
                });
            }
        }
    }
}
