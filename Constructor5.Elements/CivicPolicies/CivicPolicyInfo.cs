using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.CivicPolicies
{
    [XmlSerializerExtraType]
    public class CivicPolicyInfo : CivicPolicyComponent
    {
        public override string ComponentLabel => "CivicPolicyInfo";

        public STBLString Name { get; set; } = new STBLString();
        public STBLString Description { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();

        public int DailyVoteLowerBound { get; set; } = 0;
        public int DailyVoteUpperBound { get; set; } = 3;

        public int InitialVoteLowerBound { get; set; } = 1;
        public int InitialVoteUpperBound { get; set; } = 3;

        public Reference VoteStatistic { get; set; } // do not add = new Reference();

        protected internal override void OnExport(CivicPolicyExportContext context)
        {
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("_display_data", "optional_display_mixin");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("optional_display_mixin");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("instance_display_description", "enabled_display_description");
            tunableVariant2.Set<TunableBasic>("enabled_display_description", Description);
            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("instance_display_icon", "enabled_display_icon");
            tunableVariant3.Set<TunableBasic>("enabled_display_icon", Icon);
            var tunableVariant4 = tunableTuple1.Set<TunableVariant>("instance_display_name", "enabled_display_name");
            tunableVariant4.Set<TunableBasic>("enabled_display_name", Name);
            var tunableVariant5 = tunableTuple1.Set<TunableVariant>("instance_display_tooltip", "disabled");
            var tunableTuple2 = context.Tuning.Get<TunableTuple>("daily_vote_random_range");
            tunableTuple2.Set<TunableBasic>("lower_bound", DailyVoteLowerBound);
            tunableTuple2.Set<TunableBasic>("upper_bound", DailyVoteUpperBound);
            var tunableTuple3 = context.Tuning.Get<TunableTuple>("initial_vote_random_range");
            tunableTuple3.Set<TunableBasic>("lower_bound", InitialVoteLowerBound);
            tunableTuple3.Set<TunableBasic>("upper_bound", InitialVoteUpperBound);
            context.Tuning.Set<TunableBasic>("vote_count_statistic", ElementTuning.GetSingleInstanceKey(VoteStatistic));

            if (Exporter.Current.STBLBuilder != null)
            {
                var header = (TuningHeader)context.Tuning;
                header.SimDataHandler.WriteText(244, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
                header.SimDataHandler.WriteText(240, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
                header.SimDataHandler.WriteTGI(256, Icon.GetUncommentedText(), Element);
            }
        }
    }
}
