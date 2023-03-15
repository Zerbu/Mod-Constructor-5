using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.Python;
using Constructor5.Core;
using Constructor5.Elements.Buffs.References;

namespace Constructor5.Elements.Traits.Components
{
    [XmlSerializerExtraType]
    public class TraitSpecialCasesComponent : TraitComponent
    {
        public bool BlockAging => BlockAgingFromBaby
                    || BlockAgingFromToddler
            || BlockAgingFromChild
            || BlockAgingFromTeen
            || BlockAgingFromYoungAdult
            || BlockAgingFromAdult
            || BlockAgingFromElder;

        public bool BlockAgingFromAdult { get; set; }
        public bool BlockAgingFromBaby { get; set; }
        public bool BlockAgingFromChild { get; set; }
        public bool BlockAgingFromElder { get; set; }
        public bool BlockAgingFromTeen { get; set; }
        public bool BlockAgingFromToddler { get; set; }
        public bool BlockAgingFromYoungAdult { get; set; }

        public bool BlockAllAging => BlockAgingFromBaby
            && BlockAgingFromToddler
            && BlockAgingFromChild
            && BlockAgingFromTeen
            && BlockAgingFromYoungAdult
            && BlockAgingFromAdult
            && BlockAgingFromElder;

        [AutoTuneReferenceList("excluded_mood_types")]
        public ReferenceList BlockedEmotions { get; } = new ReferenceList();

        public override string ComponentLabel => "SpecialCases";

        [AutoTuneIfTrue("hide_relationships")]
        public bool HideRelationships { get; set; }

        [AutoTuneIfTrue("can_die", "False")]
        public bool ImmuneToDeath { get; set; }

        [AutoTuneIfTrue("persistable", "False")]
        public bool IsNonPersisted { get; set; }

        [AutoTuneIfTrue("npc_only")]
        public bool IsNPCOnly { get; set; }

        [AutoTuneBuffWithReasonList("buffs")]
        public ReferenceList TraitBuffs { get; set; } = new ReferenceList();

        [AutoTuneBasic("trait_origin_description")]
        public STBLString TraitOrigin { get; set; } = new STBLString();

        public string VoiceEffect { get; set; }

        public bool IsGlobalTrait { get; set; }

        protected internal override void OnExport(TraitExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            TuningActionInvoker.InvokeFromFile("Trait Special Cases",
                new TuningActionContext
                {
                    Tuning = context.Tuning,
                    DataContext = this
                });

            if (Exporter.Current.STBLBuilder != null)
            {
                (context.Tuning).SimDataHandler.WriteText(236, Exporter.Current.STBLBuilder.GetKey(TraitOrigin) ?? 0);
            }

            if (IsGlobalTrait)
            {
                PythonBuilder.AddStep(GlobalTraitPythonStep.Current);
                GlobalTraitPythonStep.Current.AddTrait(ElementTuning.GetSingleInstanceKey(Element) ?? 0);
            }
        }
    }
}