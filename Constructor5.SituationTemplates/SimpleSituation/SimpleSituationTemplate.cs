using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Situations;
using Constructor5.Xml;

namespace Constructor5.SituationTemplates.SimpleSituation
{
    [SelectableObjectType("SituationTemplates", "*Simple Situation")]
    [XmlSerializerExtraType]
    public class SimpleSituationTemplate : SituationTemplate
    {
        public ReferenceList Jobs { get; set; } = new ReferenceList();
        public override string Label => "Simple Situation";

        protected override void OnExport(SituationExportContext context)
        {
            var phaseList = context.Tuning.Get<TunableList>("_phases");

            var zeroTuple = phaseList.Get<TunableTuple>(null);
            var zeroDuration = zeroTuple.Set<TunableBasic>("duration", 0);
            
            foreach(var job in Jobs.GetOfType<SimpleSituationJobItem>())
            {
                foreach(var key in ElementTuning.GetInstanceKeys(job.Reference))
                {
                    {
                        var tunableList1 = zeroTuple.Get<TunableList>("job_list");
                        var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                        tunableTuple1.Set<TunableBasic>("job", key);
                        tunableTuple1.Set<TunableBasic>("role", job.RoleState);
                    }
                    {
                        var tunableVariant1 = context.Tuning.Set<TunableVariant>("job_display_ordering", "enabled");
                        var tunableList1 = tunableVariant1.Get<TunableList>("enabled");
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }
            }
        }
    }
}