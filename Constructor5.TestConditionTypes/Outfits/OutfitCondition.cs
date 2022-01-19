using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;

namespace Constructor5.TestConditionTypes.Outfits
{
    [SelectableObjectType("TestConditionTypes", "OutfitCondition")]
    [XmlSerializerExtraType]
    public class OutfitCondition : TestCondition
    {
        public OutfitCondition() => GeneratedLabel = "Outfit Condition";

        public bool IncludeAthletic { get; set; }
        public bool IncludeBatuu { get; set; }
        public bool IncludeCareer { get; set; }
        public bool IncludeColdWeather { get; set; }
        public bool IncludeEveryday { get; set; }
        public bool IncludeFormal { get; set; }
        public bool IncludeHotWeather { get; set; }
        public bool Inverted { get; set; }
        public bool IncludeNude { get; set; }
        [AutoTuneEnum("participant")]
        public string Participant { get; set; }
        public bool IncludeParty { get; set; }
        public bool IncludeSituation { get; set; }
        public bool IncludeSleepwear { get; set; }
        public bool IncludeSpecial { get; set; }
        public bool IncludeSwimwear { get; set; }

        protected override string GetVariantTunableName() => "outfit";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var outfits = new List<string>();
            if (IncludeEveryday)
            {
                outfits.Add("EVERYDAY");
            }
            if (IncludeFormal)
            {
                outfits.Add("FORMAL");
            }
            if (IncludeAthletic)
            {
                outfits.Add("ATHLETIC");
            }
            if (IncludeSleepwear)
            {
                outfits.Add("SLEEP");
            }
            if (IncludeParty)
            {
                outfits.Add("PARTY");
            }
            if (IncludeNude)
            {
                outfits.Add("BATHING");
            }
            if (IncludeCareer)
            {
                outfits.Add("CAREER");
            }
            if (IncludeSituation)
            {
                outfits.Add("SITUATION");
            }
            if (IncludeSpecial)
            {
                outfits.Add("SPECIAL");
            }
            if (IncludeSwimwear)
            {
                outfits.Add("SWIMWEAR");
            }
            if (IncludeHotWeather)
            {
                outfits.Add("HOTWEATHER");
            }
            if (IncludeColdWeather)
            {
                outfits.Add("COLDWEATHER");
            }
            if (IncludeBatuu)
            {
                outfits.Add("BATUU");
            }

            var tuple = variantTunable.Get<TunableTuple>("outfit");

            var list = tuple.Get<TunableList>(Inverted ? "blacklist_outfits" : "whitelist_outfits");
            foreach (var outfit in outfits)
            {
                list.Set<TunableBasic>(null, outfit);
            }

            AutoTunerInvoker.Invoke(this, tuple);
        }
    }
}