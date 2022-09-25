using System.Collections.ObjectModel;

namespace Constructor5.Elements.InteractionBasicExtras
{
    public class BasicExtrasList
    {
        public ObservableCollection<BasicExtrasConditionGroup> ConditionGroups { get; } = new ObservableCollection<BasicExtrasConditionGroup>();

        public void ExportConditionGroup(BasicExtrasConditionGroup group, BasicExtraExportContext originalContext)
        {
            var newContext = new BasicExtraExportContext(originalContext)
            {
            };

            newContext.TestConditions.Add(group.Condition);

            foreach (var item in group.Items)
            {
                if (item is BasicExtrasConditionGroup nestedGroup)
                {
                    ExportConditionGroup(nestedGroup, newContext);
                }

                if (item is BasicExtrasConditionGroupAction action)
                {
                    action.Action.OnExport(newContext);
                }
            }
        }
    }
}