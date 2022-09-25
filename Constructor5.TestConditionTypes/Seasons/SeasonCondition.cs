using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.TestConditionTypes.Seasons
{
    [SelectableObjectType("TestConditionTypes", "SeasonCondition")]
    [XmlSerializerExtraType]
    public class SeasonCondition : TestCondition
    {
        public SeasonCondition() => GeneratedLabel = "Season Condition";

        public bool AllowSpring { get; set; }
        public bool AllowSummer { get; set; }
        public bool AllowFall { get; set; }
        public bool AllowWinter { get; set; }

        [AutoTuneIfTrue("requires_seasons_pack", "False")]
        public bool PassIfSeasonsNotInstalled { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "season";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("season");

            var tunableList1 = tupleTunable.Get<TunableList>("seasons");
            if (AllowSpring)
            {
                tunableList1.Set<TunableEnum>(null, "SPRING");
            }
            if (AllowSummer)
            {
                tunableList1.Set<TunableEnum>(null, "SUMMER");
            }
            if (AllowFall)
            {
                tunableList1.Set<TunableEnum>(null, "FALL");
            }
            if (AllowWinter)
            {
                tunableList1.Set<TunableEnum>(null, "WINTER");
            }

            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}
