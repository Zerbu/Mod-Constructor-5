using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Traits
{
    [SelectableObjectType("LootActionTypes", "TraitsLearnOtherSim'sTraits")]
    [XmlSerializerExtraType]
    public class LearnTraitAction : LootAction
    {
        public LearnTraitAction() => GeneratedLabel = "Learn Other Sim's Traits";

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public string ParticipantA { get; set; } = "Actor";
        public bool ParticipantAToB { get; set; } = true;
        public string ParticipantB { get; set; } = "TargetSim";
        public bool ParticipantBToA { get; set; } = true;
        public ReferenceList Traits { get; set; } = new ReferenceList();

        protected override void OnExport(LASExportContext originalContext)
        {
            if (ParticipantAToB)
            {
                Tune(originalContext, ParticipantA, ParticipantB);
            }
            if (ParticipantBToA)
            {
                Tune(originalContext, ParticipantB, ParticipantA);
            }
        }

        private void Tune(LASExportContext originalContext, string participantA, string participantB)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "know_other_sims_trait");

            var tunableVariant1 = mainTuple.Set<TunableVariant>("notification", "enabled");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("dialog", "single");
            var tunableVariant3 = tunableVariant2.Set<TunableVariant>("single", "literal");
            var tunableTuple2 = tunableVariant3.Get<TunableTuple>("literal");
            var tunableVariant4 = tunableTuple2.Set<TunableVariant>("text", "single");
            tunableVariant4.Set<TunableBasic>("single", "0x1883D451");
            var tunableVariant5 = tunableTuple2.Set<TunableVariant>("text_tokens", "enabled");
            var tunableVariant6 = mainTuple.Set<TunableVariant>("traits", "specified");
            var tunableTuple3 = tunableVariant6.Get<TunableTuple>("specified");
            var tunableList1 = tunableTuple3.Get<TunableList>("potential_traits");

            foreach (var key in ElementTuning.GetInstanceKeys(Traits))
            {
                tunableList1.Set<TunableBasic>(null, key);
            }

            mainTuple.Set<TunableEnum>("subject", participantA);
            mainTuple.Set<TunableEnum>("target_participant_type", participantB);

            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");

            AutoTunerInvoker.Invoke(this, mainTuple);
        }
    }
}