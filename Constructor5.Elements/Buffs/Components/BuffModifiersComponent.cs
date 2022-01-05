using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Elements.Buffs.Modifiers;
using Constructor5.Elements.Traits;
using Constructor5.Core;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    [SharedWithTraits]
    public class BuffModifiersComponent : BuffComponent
    {
        public override int ComponentDisplayOrder => 2;
        public override string ComponentLabel => "Modifiers";

        public ObservableCollection<BuffTagModifier> BuffDecayMultipliers { get; } = new ObservableCollection<BuffTagModifier>();
        public ObservableCollection<BuffReferenceModifier> EmotionWeightMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();

        public ObservableCollection<BuffReferenceModifier> ContinuousStatisticModifiers { get; } = new ObservableCollection<BuffReferenceModifier>();

        public ObservableCollection<BuffReferenceModifier> EffectiveSkillModifiers { get; } = new ObservableCollection<BuffReferenceModifier>();
        public ObservableCollection<BuffTagModifier> EffectiveSkillTagModifiers { get; } = new ObservableCollection<BuffTagModifier>();

        public ObservableCollection<BuffReferenceModifier> NeedDecayMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();
        public ObservableCollection<BuffReferenceModifier> NeedIncreaseMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();

        public ObservableCollection<BuffReferenceModifier> RelationshipTrackIncreaseMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();
        public ObservableCollection<BuffReferenceModifier> RelationshipTrackDecreaseMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();

        public ObservableCollection<BuffReferenceModifier> SkillMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();
        public ObservableCollection<BuffTagModifier> SkillTagMultipliers { get; } = new ObservableCollection<BuffTagModifier>();

        public ObservableCollection<BuffReferenceModifier> SimologyDecreaseMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();
        public ObservableCollection<BuffReferenceModifier> SimologyIncreaseMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();

        public ObservableCollection<BuffReferenceModifier> StatisticDecreaseMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();
        public ObservableCollection<BuffReferenceModifier> StatisticIncreaseMultipliers { get; } = new ObservableCollection<BuffReferenceModifier>();

        protected internal override bool HasContent() => BuffDecayMultipliers.Count > 0
            || EmotionWeightMultipliers.Count > 0
            || ContinuousStatisticModifiers.Count > 0
            || EffectiveSkillModifiers.Count > 0
            || EffectiveSkillTagModifiers.Count > 0
            || NeedDecayMultipliers.Count > 0
            || NeedIncreaseMultipliers.Count > 0
            || RelationshipTrackIncreaseMultipliers.Count > 0
            || RelationshipTrackDecreaseMultipliers.Count > 0
            || SkillMultipliers.Count > 0
            || SkillTagMultipliers.Count > 0
            || SimologyDecreaseMultipliers.Count > 0
            || SimologyIncreaseMultipliers.Count > 0
            || StatisticDecreaseMultipliers.Count > 0
            || StatisticIncreaseMultipliers.Count > 0;

        protected internal override void OnExport(BuffExportContext context)
        {
            TuningActionInvoker.InvokeFromFile("Buff Modifiers",
                new TuningActionContext
                {
                    Tuning = context.Tuning,
                    DataContext = this
                });
        }
    }
}
