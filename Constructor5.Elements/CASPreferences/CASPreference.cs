using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.TestConditions;
using Constructor5.Elements.Traits;

namespace Constructor5.Elements.CASPreferences
{
    [ElementTypeData("CASPreference", true, ElementTypes = new[] { typeof(CASPreference) }, IsRootType = true)]
    public class CASPreference : Element, IExportableElement, ISupportsCustomTuning
    {
        public bool AllowAdult { get; set; } = true;
        public bool AllowBaby { get; set; } = false;
        public bool AllowChild { get; set; } = true;
        public bool AllowElder { get; set; } = true;
        public bool AllowTeen { get; set; } = true;
        public bool AllowToddler { get; set; } = false;
        public bool AllowYoungAdult { get; set; } = true;

        public Reference Category { get; set; } = new Reference();
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public Reference DislikeTrait { get; set; } // do not add = new Reference();
        public STBLString DislikeTraitName { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public Reference LikeTrait { get; set; } // do not add = new Reference();
        public STBLString LikeTraitName { get; set; } = new STBLString();
        public STBLString PreferenceName { get; set; } = new STBLString();

        public TestCondition AutoCondition { get; set; } = new AlwaysRunCondition();
        public Reference DislikeBuff { get; set; } = new Reference();
        public Reference LikeBuff { get; set; } = new Reference();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "ObjectPreferenceItem";
            tuning.InstanceType = "cas_preference_item";
            tuning.Module = "cas.cas_preference_item";

            tuning.Set<TunableBasic>("cas_preference_category", Category);
            tuning.Set<TunableBasic>("dislike", DislikeTrait);
            tuning.Set<TunableBasic>("like", LikeTrait);

            tuning.SimDataHandler = new SimDataHandler("SimData/CASPreference.data");
            tuning.SimDataHandler.Write(64, ElementTuning.GetSingleInstanceKey(Category) ?? 0);
            tuning.SimDataHandler.Write(72, ElementTuning.GetSingleInstanceKey(DislikeTrait) ?? 0);
            tuning.SimDataHandler.Write(80, ElementTuning.GetSingleInstanceKey(LikeTrait) ?? 0);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;

            PreferenceName.CustomText = label;
            LikeTraitName.CustomText = $"Likes {label}";
            DislikeTraitName.CustomText = $"Dislikes {label}";

            if (LikeTrait == null)
            {
                var newReference = (Trait)ElementManager.Create(typeof(Trait), null, true);
                newReference.Label = $"Likes {label}";
                newReference.ShowPreset = true;
                newReference.AddContextModifier(new CASPreferenceContextModifier
                {
                    CASPreference = new Reference(this)
                });
                LikeTrait = new Reference(newReference);
            }

            if (DislikeTrait == null)
            {
                var newReference = (Trait)ElementManager.Create(typeof(Trait), null, true);
                newReference.Label = $"Dislikes {label}";
                newReference.ShowPreset = true;
                newReference.AddContextModifier(new CASPreferenceContextModifier
                {
                    CASPreference = new Reference(this),
                    IsDislike = true
                });
                DislikeTrait = new Reference(newReference);
            }
        }
    }
}