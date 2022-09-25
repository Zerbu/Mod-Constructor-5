using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Situations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.SituationTemplates.ActiveCareerAutonomySituation
{
    //[SelectableObjectType("SituationTemplates", "ActiveCareerAutonomySituation")]
    [XmlSerializerExtraType]
    public class ActiveCareerAutonomySituationTemplate : SituationTemplate
    {
        public override string Label => "Active Career Autonomy Situation";

        public ReferenceList Jobs { get; set; } = new ReferenceList();

        protected override void OnExport(SituationExportContext context)
        {
            var header = (TuningHeader)context.Tuning;
            header.Class = "CustomStatesSituation";
            header.Module = "situations.custom_states.custom_states_situation";

            var tunableList1 = context.Tuning.Get<TunableList>("_situation_states");
            var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
            tunableTuple1.Set<TunableBasic>("Situation State Key", "DoStuff");
            var tunableVariant1 = tunableTuple1.Set<TunableVariant>("Situation State", "literal");
            var tunableTuple2 = tunableVariant1.Get<TunableTuple>("literal");
            var tunableList2 = tunableTuple2.Get<TunableList>("job_and_role_changes");

            foreach (var job in Jobs.GetOfType<ActiveCareerAutonomySituationJobItem>())
            {
                foreach (var key in ElementTuning.GetInstanceKeys(job.Reference))
                {
                    var tunableTuple3 = tunableList2.Get<TunableTuple>(null);
                    tunableTuple3.Set<TunableBasic>("Situation Job", key);
                    tunableTuple3.Set<TunableBasic>("Role State", job.RoleState);
                }
            }

            var tunableVariant2 = context.Tuning.Set<TunableVariant>("_starting_state", "random_starting_state");
            var tunableTuple4 = tunableVariant2.Get<TunableTuple>("random_starting_state");
            var tunableList3 = tunableTuple4.Get<TunableList>("possible_state_keys");
            var tunableTuple5 = tunableList3.Get<TunableTuple>(null);
            tunableTuple5.Set<TunableBasic>("situation_key", "DoStuff");

            var tunableList5 = context.Tuning.Get<TunableList>("default_job_and_roles");

            foreach (var job in Jobs.GetOfType<ActiveCareerAutonomySituationJobItem>())
            {
                foreach (var key in ElementTuning.GetInstanceKeys(job.Reference))
                {
                    var tunableTuple6 = tunableList5.Get<TunableTuple>(null);
                    tunableTuple6.Set<TunableBasic>("Situation Job", key);
                    tunableTuple6.Set<TunableBasic>("Role State", job.RoleState);
                }
            }

            /*var tunableVariant3 = context.Tuning.Set<TunableVariant>("situation_end_time_string", "show_end_time");
            tunableVariant3.Set<TunableBasic>("show_end_time", "0xA3E17143");*/

            var tunableVariant4 = context.Tuning.Set<TunableVariant>("time_jump", "allow");

        }
    }
}
