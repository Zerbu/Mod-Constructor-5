using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.OddJobs.Components
{
    [XmlSerializerExtraType]
    public class OddJobSpecialCasesComponent : OddJobComponent
    {
        public override int ComponentDisplayOrder => 5;
        public override string ComponentLabel => "SpecialCases";

        public string CustomBucket { get; set; }
        public Reference Career { get; set; } = new Reference(207004, "Career_OddJob");
        public bool NoTimeLimit { get; set; }

        protected internal override void OnExport(OddJobExportContext context)
        {
        }
    }
}
