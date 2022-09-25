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

        [AutoTuneBasic("ideal_value")]
        public int IdealValue { get; set; }

        [AutoTuneBasic("max_value")]
        public int MaxValue { get; set; }

        [AutoTuneBasic("min_value")]
        public int MinValue { get; set; }

        [AutoTuneBasic("statistic")]
        public Reference Skill { get; set; } = new Reference();

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, "skill");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("skill");
            AutoTunerInvoker.Invoke(this, tunableTuple1);
        }
    }
}
