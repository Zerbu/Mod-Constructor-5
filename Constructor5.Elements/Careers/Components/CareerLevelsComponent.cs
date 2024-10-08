﻿using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;

namespace Constructor5.Elements.Careers.Components
{
    [XmlSerializerExtraType]
    public class CareerLevelsComponent : CareerComponent
    {
        [AutoTuneBasic("start_track")]
        public Reference BaseTrack { get; set; } // do not add = new Reference();

        public override int ComponentDisplayOrder => 3;

        public override string ComponentLabel => "Levels";

        protected internal override void OnExport(CareerExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            var header = (TuningHeader)context.Tuning;
            header.SimDataHandler.Write(context.Element.GetComponent<CareerTemplateComponent>().Template.GetSimDataTrackBytePosition(), ElementTuning.GetSingleInstanceKey(BaseTrack) ?? 0);
        }
    }
}