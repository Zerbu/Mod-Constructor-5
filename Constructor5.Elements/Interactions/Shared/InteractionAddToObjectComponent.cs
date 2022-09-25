using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Python;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Super;
using System.Collections.Generic;

namespace Constructor5.Elements.Interactions.Shared
{
    [SuperInteractionComponent]
    [XmlSerializerExtraType]
    public class InteractionAddToObjectComponent : InteractionComponent
    {
        public ReferenceList AddToObjects { get; set; } = new ReferenceList();

        public ReferenceList AddToObjectsWithInteraction { get; set; } = new ReferenceList();

        public bool AddToPhone { get; set; }
        public bool AddToSims { get; set; }
        public bool AddToSimsActiveOnly { get; set; }

        public override string ComponentLabel => "AddToSimsOrObjects";

        protected internal override void OnExport(InteractionExportContext context)
        {
            var objectsKeys = new List<ulong>();
            if (AddToSims)
            {
                objectsKeys.Add(14965);
                TuneHumansOnly(context);
                if (AddToSimsActiveOnly)
                {
                    TuneActiveSimsOnly(context);
                }
            }
            objectsKeys.AddRange(ElementTuning.GetInstanceKeys(AddToObjects));
            PythonBuilder.AddStep(ObjectInteractionsPythonStep.Current);
            if (objectsKeys.Count > 0)
            {
                ObjectInteractionsPythonStep.Current.AddObjectInteraction(objectsKeys, (ulong)ElementTuning.GetSingleInstanceKey(Element));
            }

            foreach(var interaction in ElementTuning.GetInstanceKeys(AddToObjectsWithInteraction))
            {
                ObjectInteractionsPythonStep.Current.AddInteractionToInteraction(interaction, (ulong)ElementTuning.GetSingleInstanceKey(Element));
            }

            if (AddToPhone)
            {
                ObjectInteractionsPythonStep.Current.AddPhoneInteraction((ulong)ElementTuning.GetSingleInstanceKey(Element));
            }
        }

        private void TuneActiveSimsOnly(InteractionExportContext context)
        {
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("_icon", "participant");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("participant");
            var tunableList1 = tunableTuple1.Get<TunableList>("participant_type");
            tunableList1.Set<TunableEnum>(null, "Actor");

            if (context.Tuning.Get<TunableBasic>("target_type") == null)
            {
                context.Tuning.Set<TunableEnum>("target_type", "ACTOR");
            }
            
            var tunableList2 = context.Tuning.Get<TunableList>("test_globals");
            var tunableVariant4 = tunableList2.Set<TunableVariant>(null, "identity");
            var tunableTuple3 = tunableVariant4.Get<TunableTuple>("identity");
            tunableTuple3.Set<TunableBasic>("subjects_match", "True");
        }

        private void TuneHumansOnly(InteractionExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("test_globals");
            var tunableVariant2 = tunableList1.Set<TunableVariant>(null, "sim_info");
            var tunableTuple2 = tunableVariant2.Get<TunableTuple>("sim_info");
            var tunableVariant3 = tunableTuple2.Set<TunableVariant>("species", "unspecified");
            tunableTuple2.Set<TunableEnum>("who", "Actor");
        }
    }
}