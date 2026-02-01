// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.Replays;
using osuTK;

namespace osu.Game.Rulesets.osu_ruleset.Replays
{
    public class osu_rulesetReplayFrame : ReplayFrame
    {
        public List<osu_rulesetAction> Actions = new List<osu_rulesetAction>();
        public Vector2 Position;

        public osu_rulesetReplayFrame(osu_rulesetAction? button = null)
        {
            if (button.HasValue)
                Actions.Add(button.Value);
        }

        public override bool IsEquivalentTo(ReplayFrame other)
            => other is osu_rulesetReplayFrame freeformFrame && Time == freeformFrame.Time && Position == freeformFrame.Position && Actions.SequenceEqual(freeformFrame.Actions);
    }
}
