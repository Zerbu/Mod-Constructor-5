using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SimFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "SkillFilter")]
    [XmlSerializerExtraType]
    public class SkillFilter : SimFilterTerm
    {
        public SkillFilter() => GeneratedLabel = "Skill Filter";

        [AutoTuneBasic("ideal_value", IgnoreIf = -1)]
        public int IdealValue { get; set; } = -1;

        [AutoTuneBasic("max_value", IgnoreIf = -1)]
        public int MaxValue { get; set; } = -1;

        [AutoTuneBasic("min_value", IgnoreIf = -1)]
        public int MinValue { get; set; } = -1;

        public bool IsOptional { get; set; }


        [AutoTuneBasic("skill")]
        public Reference Skill { get; set; } = new Reference();

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, "skill");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("skill");
            AutoTunerInvoker.Invoke(this, tunableTuple1);

            if (IsOptional)
            {
                tunableTuple1.Set<TunableBasic>("minimum_filter_score", "0.1");
            }
        }
    }
}
