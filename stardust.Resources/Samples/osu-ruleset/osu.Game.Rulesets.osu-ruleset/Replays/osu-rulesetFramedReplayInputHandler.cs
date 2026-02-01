// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Input.StateChanges;
using osu.Framework.Utils;
using osu.Game.Replays;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.osu_ruleset.Replays
{
    public class osu_rulesetFramedReplayInputHandler : FramedReplayInputHandler<osu_rulesetReplayFrame>
    {
        public osu_rulesetFramedReplayInputHandler(Replay replay)
            : base(replay)
        {
        }

        protected override bool IsImportant(osu_rulesetReplayFrame frame) => frame.Actions.Any();

        protected override void CollectReplayInputs(List<IInput> inputs)
        {
            var position = Interpolation.ValueAt(CurrentTime, StartFrame.Position, EndFrame.Position, StartFrame.Time, EndFrame.Time);

            inputs.Add(new MousePositionAbsoluteInput
            {
                Position = GamefieldToScreenSpace(position),
            });
            inputs.Add(new ReplayState<osu_rulesetAction>
            {
                PressedActions = CurrentFrame?.Actions ?? new List<osu_rulesetAction>(),
            });
        }
    }
}
