using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Python;
using Constructor5.Core;
using Constructor5.Elements.EnumExtensions.PythonSteps;
using Constructor5.Elements.HolidayTraditions.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.EnumExtensions
{
    [XmlSerializerExtraType]
    public class EnumExtensionCustomTags : EnumExtensionComponent
    {
        public override string ComponentLabel => "CustomTags";

        public ObservableCollection<EnumExtensionTag> Tags { get; } = new ObservableCollection<EnumExtensionTag>();

        protected internal override void OnExport(EnumExtensionExportContext context)
        {
            PythonBuilder.AddStep(EnumTagsPythonStep.Current);
            foreach(var tag in Tags)
            {
                var injections = new List<ulong>();
                foreach(var injectionId in ElementTuning.GetInstanceKeys(tag.InjectToInteractions))
                {
                    injections.Add(injectionId);
                }
                EnumTagsPythonStep.Current.AddTag(tag.ItemName, FNVHasher.FNV32(tag.ItemName, true), injections.ToArray());
            }
        }
    }
}
