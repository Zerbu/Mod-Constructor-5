using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "CareersCareerTrackCondition")]
    [SelectableObjectType("SituationGoalConditionTypes", "CareersCareerTrackCondition")]
    [SelectableObjectType("ObjectiveConditionTypes", "CareersCareerTrackCondition")]
    [XmlSerializerExtraType]
    public class CareerTrackCondition : CareerConditionBase
    {
        public CareerTrackCondition() => GeneratedLabel = "Careers: Career Track/Branch Condition";

        [AutoTuneVariantRange("user_level")]
        public IntBounds CareerLevel { get; set; } = new IntBounds();

        [AutoTuneBasic("career_track")]
        public Reference CareerTrack { get; set; } = new Reference();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "career_track");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
