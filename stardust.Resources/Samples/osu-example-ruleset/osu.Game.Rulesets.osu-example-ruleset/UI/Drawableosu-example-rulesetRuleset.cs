// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Input.Handlers;
using osu.Game.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.osu_example_ruleset.Objects;
using osu.Game.Rulesets.osu_example_ruleset.Objects.Drawables;
using osu.Game.Rulesets.osu_example_ruleset.Replays;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.osu_example_ruleset.UI
{
    [Cached]
    public partial class Drawableosu_example_rulesetRuleset : DrawableRuleset<osu_example_rulesetHitObject>
    {
        public Drawableosu_example_rulesetRuleset(osu_example_rulesetRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
        }

        public override PlayfieldAdjustmentContainer CreatePlayfieldAdjustmentContainer() => new osu_example_rulesetPlayfieldAdjustmentContainer();

        protected override Playfield CreatePlayfield() => new osu_example_rulesetPlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new osu_example_rulesetFramedReplayInputHandler(replay);

        public override DrawableHitObject<osu_example_rulesetHitObject> CreateDrawableRepresentation(osu_example_rulesetHitObject h) => new Drawableosu_example_rulesetHitObject(h);

        protected override PassThroughInputManager CreateInputManager() => new osu_example_rulesetInputManager(Ruleset?.RulesetInfo);
    }
}
