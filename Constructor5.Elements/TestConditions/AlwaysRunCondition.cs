using Constructor5.Base.SelectableObjects;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;

namespace Constructor5.Elements.TestConditions
{
    [SelectableObjectType("TestConditionTypes", "AlwaysRun")]
    [XmlSerializerExtraType]
    public class AlwaysRunCondition : NoTestConditionSelected
    {
        public AlwaysRunCondition() => GeneratedLabel = "Always Run";

        protected internal override string GetVariantTunableName(string contextTag = null)
        {
            return null;
        }

        protected internal override void OnExportVariant(TunableBase variantTunable, string tag)
        {
            return;
        }
    }
}
