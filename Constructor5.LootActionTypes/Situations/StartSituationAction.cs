using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.TestConditionTypes.Situations;
using System.Collections.ObjectModel;

namespace Constructor5.LootActionTypes.Situations
{
    [SelectableObjectType("LootActionTypes", "SituationsStartSituation")]
    [XmlSerializerExtraType]
    public class StartSituationAction : LootAction
    {
        public StartSituationAction() => GeneratedLabel = "Start Situation";

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public bool IsUserFacing { get; set; }

        public ObservableCollection<StartSituationInvitedParticipant> OtherInvitedParticipants { get; set; }
            = new ObservableCollection<StartSituationInvitedParticipant>();

        public string Participant { get; set; } = "Actor";

        public Reference Situation { get; set; } = new Reference();

        public Reference SituationJobActor { get; set; } = new Reference();
        public Reference SituationJobTarget { get; set; } = new Reference();

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "create_situation");
            var createSituationTuple = mainTuple.Get<TunableTuple>("create_situation");

            createSituationTuple.Set<TunableBasic>("invite_actor", "False");
            createSituationTuple.Set<TunableBasic>("invite_target_sim", "False");
            createSituationTuple.Set<TunableBasic>("invite_picked_sims", "False");

            if (!IsUserFacing)
            {
                createSituationTuple.Set<TunableBasic>("user_facing", "False");
            }

            createSituationTuple.Set<TunableBasic>("situation", Situation);

            var actorKey = ElementTuning.GetSingleInstanceKey(SituationJobActor);
            if (actorKey != null)
            {
                createSituationTuple.Set<TunableBasic>("invite_actor", "True");
                var tunableVariant1 = createSituationTuple.Set<TunableVariant>("actor_init_job", "specify_job");
                tunableVariant1.Set<TunableBasic>("specify_job", actorKey);
            }

            var targetKey = ElementTuning.GetSingleInstanceKey(SituationJobTarget);
            if (targetKey != null)
            {
                createSituationTuple.Set<TunableBasic>("invite_target_sim", "True");
                var tunableVariant1 = createSituationTuple.Set<TunableVariant>("target_init_job", "specify_job");
                tunableVariant1.Set<TunableBasic>("specify_job", targetKey);
            }

            if (!string.IsNullOrEmpty(Participant))
            {
                TuneParticipant(createSituationTuple);
            }

            if (OtherInvitedParticipants.Count > 0)
            {
                TuneExtraParticipants(createSituationTuple);
            }

            AutoTunerInvoker.Invoke(this, mainTuple);

            var newContext = new LASExportContext(originalContext);

            if (IsUserFacing)
            {
                var condition = new CanCreatePlayerFacingSituationCondition
                {
                    //IsInverted = true
                };
                newContext.TestConditions.Add(condition);
            }

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }

        private void TuneExtraParticipants(TunableTuple createSituationTuple)
        {
            var list = createSituationTuple.Get<TunableList>("invite_participants");
            foreach(var participant in OtherInvitedParticipants)
            {
                var tuple = list.Get<TunableTuple>(null);
                var jobList = tuple.GetVariant<TunableList>("invite_to_job", "specify_job");
                jobList.Set<TunableBasic>(null, participant.SituationJob);
                tuple.Set<TunableEnum>("participants_to_invite", participant.Participant);
            }
        }

        private void TuneParticipant(TunableTuple createSituationTuple)
        {
            var tunableVariant1 = createSituationTuple.Set<TunableVariant>("linked_sim_participant", "enabled");
            tunableVariant1.Set<TunableEnum>("enabled", Participant);
        }
    }
}