// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Replays;
using osuTK;

namespace osu.Game.Rulesets.osu_example_ruleset.Replays
{
    public class osu_example_rulesetReplayFrame : ReplayFrame
    {
        public Vector2 Position;

        public override bool IsEquivalentTo(ReplayFrame other)
            => other is osu_example_rulesetReplayFrame osu_example_rulesetFrame && Time == osu_example_rulesetFrame.Time && Position == osu_example_rulesetFrame.Position;
    }
}
