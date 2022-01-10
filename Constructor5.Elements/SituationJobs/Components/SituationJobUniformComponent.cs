using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.SituationJobs.Components
{
    [XmlSerializerExtraType]
    public class SituationJobUniformComponent : SituationJobComponent
    {
        public override string ComponentLabel => "Outfit";

        public bool HigherPriority { get; set; }
        public string OutfitChangeReason { get; set; }

        protected internal override void OnExport(SituationJobExportContext context)
        {
            if (string.IsNullOrEmpty(OutfitChangeReason))
            {
                return;
            }

            var tunableVariant1 = context.Tuning.Set<TunableVariant>("job_uniform", "uniform_specified");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("uniform_specified");
            tunableTuple1.Set<TunableEnum>("outfit_change_priority", HigherPriority ? "High" : "Medium");
            tunableTuple1.Set<TunableEnum>("outfit_change_reason", OutfitChangeReason);
        }
    }
}
