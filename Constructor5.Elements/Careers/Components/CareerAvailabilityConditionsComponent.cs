using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Careers.Components
{
    [XmlSerializerExtraType]
    public class CareerAvailabilityConditionsComponent : CareerComponent
    {
        public override string ComponentLabel => "AvailabilityConditions";

        public TestConditionList Conditions { get; set; } = new TestConditionList();

        protected internal override void OnExport(CareerExportContext context)
        {
            //throw new System.NotImplementedException();
        }
    }
}