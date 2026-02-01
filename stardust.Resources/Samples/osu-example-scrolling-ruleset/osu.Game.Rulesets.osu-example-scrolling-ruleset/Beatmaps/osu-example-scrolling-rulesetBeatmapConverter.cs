// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.osu_example_scrolling_ruleset.Objects;
using osu.Game.Rulesets.osu_example_scrolling_ruleset.UI;

namespace osu.Game.Rulesets.osu_example_scrolling_ruleset.Beatmaps
{
    public class osu_example_scrolling_rulesetBeatmapConverter : BeatmapConverter<osu_example_scrolling_rulesetHitObject>
    {
        private readonly float minPosition;
        private readonly float maxPosition;

        public osu_example_scrolling_rulesetBeatmapConverter(IBeatmap beatmap, Ruleset ruleset)
            : base(beatmap, ruleset)
        {
            if (beatmap.HitObjects.Any())
            {
                minPosition = beatmap.HitObjects.Min(getUsablePosition);
                maxPosition = beatmap.HitObjects.Max(getUsablePosition);
            }
        }

        public override bool CanConvert() => Beatmap.HitObjects.All(h => h is IHasXPosition && h is IHasYPosition);

        protected override IEnumerable<osu_example_scrolling_rulesetHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap, CancellationToken cancellationToken)
        {
            yield return new osu_example_scrolling_rulesetHitObject
            {
                Samples = original.Samples,
                StartTime = original.StartTime,
                Lane = getLane(original)
            };
        }

        private int getLane(HitObject hitObject) => (int)Math.Clamp(
            (getUsablePosition(hitObject) - minPosition) / (maxPosition - minPosition) * osu_example_scrolling_rulesetPlayfield.LANE_COUNT, 0, osu_example_scrolling_rulesetPlayfield.LANE_COUNT - 1);

        private float getUsablePosition(HitObject h) => (h as IHasYPosition)?.Y ?? ((IHasXPosition)h).X;
    }
}
