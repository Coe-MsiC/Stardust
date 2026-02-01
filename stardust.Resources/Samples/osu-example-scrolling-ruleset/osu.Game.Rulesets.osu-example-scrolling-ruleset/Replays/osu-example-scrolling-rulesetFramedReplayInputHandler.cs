// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Input.StateChanges;
using osu.Game.Replays;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.osu_example_scrolling_ruleset.Replays
{
    public class osu_example_scrolling_rulesetFramedReplayInputHandler : FramedReplayInputHandler<osu_example_scrolling_rulesetReplayFrame>
    {
        public osu_example_scrolling_rulesetFramedReplayInputHandler(Replay replay)
            : base(replay)
        {
        }

        protected override bool IsImportant(osu_example_scrolling_rulesetReplayFrame frame) => frame.Actions.Any();

        protected override void CollectReplayInputs(List<IInput> inputs)
        {
            inputs.Add(new ReplayState<osu_example_scrolling_rulesetAction>
            {
                PressedActions = CurrentFrame?.Actions ?? new List<osu_example_scrolling_rulesetAction>(),
            });
        }
    }
}
