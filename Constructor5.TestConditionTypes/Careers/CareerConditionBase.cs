using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Careers
{
    public abstract class CareerConditionBase : TestCondition
    {
        public bool Inverted { get; set; }
        public string Participant { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "career_test";

        protected override sealed void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("career_test");

            if (Inverted)
            {
                tupleTunable.Set<TunableBasic>("negate", "True");
            }

            tupleTunable.Set<TunableEnum>("subjects", Participant);

            OnExportCareer(tupleTunable);
        }

        protected abstract void OnExportCareer(TunableTuple tupleTunable);
    }
}
