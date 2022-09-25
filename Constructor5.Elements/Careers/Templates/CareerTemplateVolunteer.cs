using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.CareerTracks;

namespace Constructor5.Elements.Careers.Templates
{
    [SelectableObjectType("CareerTypeTemplates", "CareerTemplateVolunteer")]
    [XmlSerializerExtraType]
    public class CareerTemplateVolunteer : CareerTemplateBase
    {
        //public override int ComponentDisplayOrder => 1;
        public override string Label => "Volunteer/Afterschool Activity";

        public override int GetBasePerformance(int level) => 0;

        public override int GetNegativeEmotionModifier(int level) => -5;

        public override int GetStandardEmotionModifier(int level) => 10;

        protected internal override void OnExport(CareerExportContext context)
        {
            TuningActionInvoker.InvokeFromFile("Career Type Volunteer", new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this,
            });

            ((TuningHeader)context.Tuning).SimDataHandler.Write(64, 4);
        }

        protected internal override void TuneOvermax(TuningBase tuning, CareerTrack track)
        {
        }
    }
}
