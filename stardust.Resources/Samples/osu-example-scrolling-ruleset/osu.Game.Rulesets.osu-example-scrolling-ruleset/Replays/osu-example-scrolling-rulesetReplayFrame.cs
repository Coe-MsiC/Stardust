// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.osu_example_scrolling_ruleset.Replays
{
    public class osu_example_scrolling_rulesetReplayFrame : ReplayFrame
    {
        public List<osu_example_scrolling_rulesetAction> Actions = new List<osu_example_scrolling_rulesetAction>();

        public osu_example_scrolling_rulesetReplayFrame(osu_example_scrolling_rulesetAction? button = null)
        {
            if (button.HasValue)
                Actions.Add(button.Value);
        }

        public override bool IsEquivalentTo(ReplayFrame other)
            => other is osu_example_scrolling_rulesetReplayFrame osu_example_scrolling_rulesetFrame && Time == osu_example_scrolling_rulesetFrame.Time && Actions.SequenceEqual(osu_example_scrolling_rulesetFrame.Actions);
    }
}
