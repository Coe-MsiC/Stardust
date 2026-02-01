// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.osu_example_ruleset.Beatmaps;
using osu.Game.Rulesets.osu_example_ruleset.Mods;
using osu.Game.Rulesets.osu_example_ruleset.UI;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.osu_example_ruleset
{
    public class osu_example_rulesetRuleset : Ruleset
    {
        public override string Description => "gather the osu!coins";

        public override DrawableRuleset CreateDrawableRulesetWith(IBeatmap beatmap, IReadOnlyList<Mod> mods = null) =>
            new Drawableosu_example_rulesetRuleset(this, beatmap, mods);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) =>
            new osu_example_rulesetBeatmapConverter(beatmap, this);

        public override DifficultyCalculator CreateDifficultyCalculator(IWorkingBeatmap beatmap) =>
            new osu_example_rulesetDifficultyCalculator(RulesetInfo, beatmap);

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.Automation:
                    return new[] { new osu_example_rulesetModAutoplay() };

                default:
                    return Array.Empty<Mod>();
            }
        }

        public override string ShortName => "osu_example_ruleset";

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.Z, osu_example_rulesetAction.Button1),
            new KeyBinding(InputKey.X, osu_example_rulesetAction.Button2),
        };

        public override Drawable CreateIcon() => new osu_example_rulesetRulesetIcon(this);

        // Leave this line intact. It will bake the correct version into the ruleset on each build/release.
        public override string RulesetAPIVersionSupported => CURRENT_RULESET_API_VERSION;
    }
}
