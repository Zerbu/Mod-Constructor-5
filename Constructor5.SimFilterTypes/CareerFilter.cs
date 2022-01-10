using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SimFilters;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "Career Filter")]
    [XmlSerializerExtraType]
    public class CareerFilter : SimFilterTerm
    {
        public CareerFilter() => GeneratedLabel = "Career Filter";
        [AutoTuneIfFalse("career_seniority")]
        public bool PreferSeniority { get; set; } = true;
        public Reference Career { get; set; } = new Reference();
        public bool RestrictCareerLevel { get; set; }
        public int CareerLevel { get; set; } = 1;

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var careerVariant = filterTermsTunable.Set<TunableVariant>(null, "career");
            var careerTuple = careerVariant.Get<TunableTuple>("career");

            var tunableVariant1 = careerTuple.Set<TunableVariant>("career", "from_explicit_type");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("from_explicit_type");
            tunableTuple1.Set<TunableBasic>("career_type", Career);

            if (RestrictCareerLevel)
            {
                var tunableVariant2 = careerTuple.Set<TunableVariant>("career_level", "enabled");
                var tunableVariant3 = tunableVariant2.Set<TunableVariant>("enabled", "career_user_level");
                var tunableTuple2 = tunableVariant3.Get<TunableTuple>("career_user_level");
                tunableTuple2.Set<TunableBasic>("career_user_level", CareerLevel);
            }

            AutoTunerInvoker.Invoke(this, careerTuple);
        }
    }
}
