using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Python;
using Constructor5.Core;
using System.Xml.Serialization;

namespace Constructor5.Elements.ZoneDirectors.Components
{
    [XmlSerializerExtraType]
    public class ZoneDirectorMergeComponent : ZoneDirectorComponent
    {
        [XmlIgnore]
        public override int ComponentDisplayOrder => 2;

        public override string ComponentLabel => "ZoneDirectorMerges";

        public ReferenceList MergeTo { get; set; } = new ReferenceList();

        protected internal override void OnExport(ZoneDirectorExportContext context)
        {
            foreach (var key in ElementTuning.GetInstanceKeys(MergeTo))
            {
                PythonBuilder.AddStep(MergeZoneDirectorPythonStep.Current);
                MergeZoneDirectorPythonStep.Current.Add(key, ElementTuning.GetSingleInstanceKey(context.Element).Value);
            }
        }
    }
}
