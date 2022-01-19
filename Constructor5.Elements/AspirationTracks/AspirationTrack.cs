using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using Constructor5.Elements.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.AspirationTracks
{
    [ElementTypeData("AspirationTrack", false, ElementTypes = new[] { typeof(AspirationTrack) }, PresetFolders = new[] { "AspirationTrack" }, IsRootType = true)]
    public class AspirationTrack : SimpleComponentElement<AspirationTrackComponent>, IExportableElement
    {
        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "AspirationTrack";
            tuning.InstanceType = "aspiration_track";
            tuning.Module = "aspirations.aspiration_tuning";

            tuning.SimDataHandler = new SimDataHandler($"SimData/{GetSimDataFileName()}.data");

            var context = new AspirationTrackExportContext
            {
                Element = this,
                Tuning = tuning
            };

            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            TuningExport.AddToQueue(tuning);
        }

        private string GetSimDataFileName()
        {
            switch (GetComponent<AspirationTrackMilestonesComponent>().Milestones.Items.Count())
            {
                case 1:
                    return "AspirationTrackWith1Objective";
                case 2:
                    return "AspirationTrackWith2Objectives";
                case 3:
                    return "AspirationTrackWith3Objectives";
                default:
                    return "AspirationTrack";
            }
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetSubtypes(typeof(AspirationTrackComponent)))
            {
                AddComponent(type);
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var info = GetComponent<AspirationTrackInfoComponent>();
            info.Name = new STBLString() { CustomText = label };
        }
    }
}