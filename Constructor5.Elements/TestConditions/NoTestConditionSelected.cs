using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.TestConditions
{
    [XmlSerializerExtraType]
    [SelectableObjectType("ObjectiveConditionTypes", "NoTestConditionSelected")]
    public class NoTestConditionSelected : TestCondition
    {
        public NoTestConditionSelected() => GeneratedLabel = "No Condition Selected";

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