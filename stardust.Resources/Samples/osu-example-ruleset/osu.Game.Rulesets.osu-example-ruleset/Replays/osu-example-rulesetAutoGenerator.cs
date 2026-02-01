// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.osu_example_ruleset.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.osu_example_ruleset.Replays
{
    public class osu_example_rulesetAutoGenerator : AutoGenerator<osu_example_rulesetReplayFrame>
    {
        public new Beatmap<osu_example_rulesetHitObject> Beatmap => (Beatmap<osu_example_rulesetHitObject>)base.Beatmap;

        public osu_example_rulesetAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
        }

        protected override void GenerateFrames()
        {
            Frames.Add(new osu_example_rulesetReplayFrame());

            foreach (osu_example_rulesetHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new osu_example_rulesetReplayFrame
                {
                    Time = hitObject.StartTime,
                    Position = hitObject.Position,
                });
            }
        }
    }
}
