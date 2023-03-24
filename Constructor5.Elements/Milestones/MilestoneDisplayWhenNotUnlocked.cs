using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.Milestones
{
    [XmlSerializerExtraType]
    public class MilestoneDisplayWhenNotUnlocked : MilestoneComponent
    {
        public bool DisplayWhenNotUnlocked { get; set; }

        public STBLString NameWhenNotUnlocked { get; set; } = new STBLString();
        public STBLString DescriptionsWhenNotUnlocked { get; set; } = new STBLString();

        public TestConditionList Conditions { get; set; } = new TestConditionList();

        public override int ComponentDisplayOrder => 50;
        public override string ComponentLabel => "DisplayWhenNotUnlocked";

        protected internal override void OnExport(MilestoneExportContext context)
        {
            if (!DisplayWhenNotUnlocked)
            {
                return;
            }

            var tunableVariant1 = context.Tuning.Set<TunableVariant>("is_primary_milestone", "True");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("True");
            tunableTuple1.Set<TunableBasic>("hint_text", DescriptionsWhenNotUnlocked);
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("revealable_name", "enabled");
            tunableVariant2.Set<TunableBasic>("enabled", NameWhenNotUnlocked);

            TestConditionTuning.TuneTestList(tunableTuple1, Conditions.ToConditionList(), "tests");

            if (Exporter.Current.STBLBuilder != null)
            {
                var header = (TuningHeader)context.Tuning;
                header.SimDataHandler.WriteText(352, Exporter.Current.STBLBuilder.GetKey(NameWhenNotUnlocked) ?? 0);
                header.SimDataHandler.WriteText(256, Exporter.Current.STBLBuilder.GetKey(DescriptionsWhenNotUnlocked) ?? 0);
            }
        }
    }
}
