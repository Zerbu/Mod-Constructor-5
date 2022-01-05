using Constructor5.Base.SelectableObjects;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;

namespace Constructor5.Elements.TestConditions
{
    [SelectableObjectType("TestConditionTypes", "Always Run")]
    [XmlSerializerExtraType]
    public class AlwaysRunCondition : TestCondition
    {
        public AlwaysRunCondition() => GeneratedLabel = "Always Run";

        protected internal override string GetVariantTunableName()
        {
            return null;
        }

        protected internal override void OnExportVariant(TunableBase variantTunable)
        {
            return;
        }
    }
}
