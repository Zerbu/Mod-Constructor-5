using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.CareerTracks;
using System.Linq;

namespace Constructor5.Elements.Careers.Templates
{
    [SelectableObjectType("CareerTypeTemplates", "CareerTemplatePartTime")]
    [XmlSerializerExtraType]
    public class CareerTemplatePartTime : CareerTemplateBase
    {
        public override string Label => "Part Time Career";

        public override int GetBasePerformance(int level)
        {
            var arr = new[] { 50, 40, 30, 20, 15, 10, 8, 7, 6, 5 };
            return level >= arr.Length ? arr.Last() : arr[level];
        }

        public override int GetNegativeEmotionModifier(int level) => -5;

        public override int GetStandardEmotionModifier(int level) => 10;

        protected internal override void OnExport(CareerExportContext context)
        {
            TuningActionInvoker.InvokeFromFile("Career Type Part Time", new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this,
            });
        }

        protected internal override void TuneOvermax(TuningBase tuning, CareerTrack track)
        {
        }
    }
}
