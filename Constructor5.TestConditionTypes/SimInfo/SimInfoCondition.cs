using Constructor5.Base.SelectableObjects;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using Constructor5.Base.ExportSystem.AutoTuners;

namespace Constructor5.TestConditionTypes.SimInfo
{
    [SelectableObjectType("TestConditionTypes", "SimInfoCondition")]
    [SelectableObjectType("HolidayTraditionConditionTypes", "SimInfoCondition")]
    [XmlSerializerExtraType]
    public class SimInfoCondition : TestCondition
    {
        public SimInfoCondition() => GeneratedLabel = "Sim Info Condition";

        public bool AllowBaby { get; set; } = true;
        public bool AllowToddler { get; set; } = true;
        public bool AllowChild { get; set; } = true;
        public bool AllowTeen { get; set; } = true;
        public bool AllowYoungAdult { get; set; } = true;
        public bool AllowAdult { get; set; } = true;
        public bool AllowElder { get; set; } = true;

        public SimInfoYesNoAny CanAgeUp { get; set; } = SimInfoYesNoAny.Any;
        public SimInfoGenders Gender { get; set; } = SimInfoGenders.Any;
        public SimInfoYesNoAny HasEverBeenPlayed { get; set; } = SimInfoYesNoAny.Any;
        public SimInfoYesNoAny IsNPC { get; set; } = SimInfoYesNoAny.Any;

        [AutoTuneEnum("who")]
        public string Participant { get; set; }

        public bool RestrictAge => !AllowBaby || !AllowToddler || !AllowChild || !AllowTeen || !AllowYoungAdult || !AllowAdult || !AllowElder;

        protected override string GetVariantTunableName(string contextTag = null) => "sim_info";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("sim_info");
            AutoTunerInvoker.Invoke(this, tupleTunable);
            TuningActionInvoker.InvokeFromFile("Sim Info Condition",
            new TuningActionContext
            {
                Tuning = tupleTunable,
                DataContext = this
            });
        }
    }
}
