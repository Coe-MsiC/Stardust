// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.osu_ruleset.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.osu_ruleset.Replays
{
    public class osu_rulesetAutoGenerator : AutoGenerator<osu_rulesetReplayFrame>
    {
        public new Beatmap<osu_rulesetHitObject> Beatmap => (Beatmap<osu_rulesetHitObject>)base.Beatmap;

        public osu_rulesetAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
        }

        protected override void GenerateFrames()
        {
            Frames.Add(new osu_rulesetReplayFrame());

            foreach (osu_rulesetHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new osu_rulesetReplayFrame
                {
                    Time = hitObject.StartTime,
                    Position = hitObject.Position,
                    // todo: add required inputs and extra frames.
                });
            }
        }
    }
}
