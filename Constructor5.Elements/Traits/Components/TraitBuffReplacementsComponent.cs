using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Traits.Components
{
    [XmlSerializerExtraType]
    public class TraitBuffReplacementsComponent : TraitComponent
    {
        public override string ComponentLabel => "Buff Replacements";

        public ObservableCollection<BuffReplacement> Replacements { get; } = new ObservableCollection<BuffReplacement>();

        protected internal override void OnExport(TraitExportContext context)
        {
            foreach(var replacement in Replacements)
            {
                var tunableList1 = context.Tuning.Get<TunableList>("buff_replacements");
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("key", replacement.OriginalBuff);
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("value");
                tunableTuple2.Set<TunableBasic>("buff_type", replacement.ReplacementBuff);
            }
        }
    }
}
