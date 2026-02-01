// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.osu_example_scrolling_ruleset
{
    public partial class osu_example_scrolling_rulesetInputManager : RulesetInputManager<osu_example_scrolling_rulesetAction>
    {
        public osu_example_scrolling_rulesetInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }
    }

    public enum osu_example_scrolling_rulesetAction
    {
        [Description("Move up")]
        MoveUp,

        [Description("Move down")]
        MoveDown,
    }
}
