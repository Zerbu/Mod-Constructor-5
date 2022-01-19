using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.SimFilters;

namespace Constructor5.SimFilterTypes
{
    public abstract class InvertOnlyFilter : SimFilterTerm
    {
        protected override void OnExport(TunableList filterTermsTunable)
        {
            var variantName = GetVariantName();
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, variantName);
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>(variantName);
            AutoTunerInvoker.Invoke(this, tunableTuple1);
        }

        protected abstract string GetVariantName();
    }
}
