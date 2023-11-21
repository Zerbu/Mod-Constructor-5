using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.Buffs;
using Constructor5.Elements.Traits;
using Constructor5.Elements.Traits.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements
{
    [ElementTypeData("Trait", true, ElementTypes = new[] { typeof(Trait) }, PresetFolders = new[] { "Trait" }, IsRootType = true)]
    public class Trait : Element, IHasComponents, IExportableElement, IIsFNV32Element, ISupportsCustomTuning
    {
        public Trait() => SaveVersion = 2;

        // components list must be public for saving and loading
        // list must use ElementComponent instead of ITraitComponent to prevent save errors
        public List<BuffComponent> BuffComponents { get; } = new List<BuffComponent>();

        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public List<TraitComponent> TraitComponents { get; } = new List<TraitComponent>();

        public T GetBuffComponent<T>() where T : BuffComponent => (T)BuffComponents.Find(x => x is T);

        public T GetTraitComponent<T>() where T : TraitComponent => (T)TraitComponents.Find(x => x is T);

        ElementComponent[] IHasComponents.GetSortedUserFacingComponents()
        {
            var result = new List<ElementComponent>();
            result.AddRange(BuffComponents);
            result.AddRange(TraitComponents);
            return result.OrderBy(x => ((ITraitComponent)x).ComponentDisplayOrder).ThenBy(x => ((ITraitComponent)x).ComponentLabel).ToArray();
        }

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Trait";
            tuning.InstanceType = "trait";
            tuning.Module = "traits.traits";

            var infoComponent = GetTraitComponent<TraitInfoComponent>();

            var contextModifier = GetContextModifier<CASPreferenceContextModifier>();

            var handlerFile = "SimData/TraitGameplay.data";
            if (infoComponent.TraitType == TraitTypes.Personality)
            {
                handlerFile = "SimData/Trait.data";
            }
            if (contextModifier != null)
            {
                tuning.Class = "Preference";
                //handlerFile = "SimData/TraitPreference.data";
            }
            tuning.SimDataHandler = new SimDataHandler(handlerFile);

            var context = new TraitExportContext()
            {
                Tuning = tuning
            };

            var buffComponents = new List<BuffComponent>();

            foreach (var component in TraitComponents)
            {
                component.OnExport(context);
            }

            foreach (var component in BuffComponents)
            {
                if (!component.HasContent())
                {
                    continue;
                }
                buffComponents.Add(component);
            }

            var alwaysHasContent = SharedBuffTuner.AlwaysHasContent(this);
            if (buffComponents.Count > 0 || alwaysHasContent)
            {
                var buffTuning = SharedBuffTuner.CreateTuning(this, buffComponents.ToArray(), "Buff", true);
                var tunableList1 = tuning.Get<TunableList>("buffs");
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("buff_type", buffTuning.InstanceKey.ToString());
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected void AddBuffComponent(Type type)
        {
            var component = BuffComponents.FirstOrDefault(x => x.GetType() == type);
            if (component == null)
            {
                component = (BuffComponent)Reflection.CreateObject(type);
                BuffComponents.Add(component);
            }
            component.Element = this;
        }

        protected void AddTraitComponent(Type type)
        {
            var component = TraitComponents.FirstOrDefault(x => x.GetType() == type);
            if (component == null)
            {
                component = (TraitComponent)Reflection.CreateObject(type);
                TraitComponents.Add(component);
            }
            component.Element = this;
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetSubtypes(typeof(TraitComponent)))
            {
                AddTraitComponent(type);
            }

            foreach (var type in Reflection.GetTypesWithAttribute<SharedWithTraitsAttribute>(true))
            {
                AddBuffComponent(type);
            }

            if (SaveVersion == 1)
            {
                var info = GetTraitComponent<TraitInfoComponent>();
                info.AllowInfant = info.AllowBaby;
                SaveVersion = 2;
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var info = GetTraitComponent<TraitInfoComponent>();
            info.Name = new Base.PropertyTypes.STBLString() { CustomText = label };
            info.AllowBaby = false;
            info.AllowInfant = false;
            info.AllowToddler = false;
            info.TraitType = TraitTypes.Personality;
        }
    }
}