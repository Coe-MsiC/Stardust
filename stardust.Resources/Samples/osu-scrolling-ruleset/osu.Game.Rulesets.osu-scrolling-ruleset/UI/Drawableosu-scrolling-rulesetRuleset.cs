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
using osu.Game.Rulesets.osu_scrolling_ruleset.Objects;
using osu.Game.Rulesets.osu_scrolling_ruleset.Objects.Drawables;
using osu.Game.Rulesets.osu_scrolling_ruleset.Replays;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.osu_scrolling_ruleset.UI
{
    [Cached]
    public partial class Drawableosu_scrolling_rulesetRuleset : DrawableScrollingRuleset<osu_scrolling_rulesetHitObject>
    {
        public Drawableosu_scrolling_rulesetRuleset(osu_scrolling_rulesetRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
            Direction.Value = ScrollingDirection.Left;
            TimeRange.Value = 6000;
        }

        protected override Playfield CreatePlayfield() => new osu_scrolling_rulesetPlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new osu_scrolling_rulesetFramedReplayInputHandler(replay);

        public override DrawableHitObject<osu_scrolling_rulesetHitObject> CreateDrawableRepresentation(osu_scrolling_rulesetHitObject h) => new Drawableosu_scrolling_rulesetHitObject(h);

        protected override PassThroughInputManager CreateInputManager() => new osu_scrolling_rulesetInputManager(Ruleset?.RulesetInfo);
    }
}
