// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.osu_scrolling_ruleset.Objects
{
    public class osu_scrolling_rulesetHitObject : HitObject
    {
        public override Judgement CreateJudgement() => new Judgement();
    }
}
