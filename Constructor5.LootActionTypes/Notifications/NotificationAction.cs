using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.UI.Shared;
using Constructor5.Xml;

namespace Constructor5.LootActionTypes.Notifications
{
    [SelectableObjectType("LootActionTypes", "Notification or Dialog")]
    [XmlSerializerExtraType]
    public class NotificationAction : LootAction
    {
        public NotificationAction() => GeneratedLabel = "Notification or Dialog";

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public NotificationOrDialog NotificationOrDialog { get; set; } = new NotificationOrDialog();

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = LootTuning.GetActionTuple(newContext.LootListTunable, "notification_and_dialog");

            TuningActionInvoker.InvokeFromFile("Notification Loot",
                new TuningActionContext
                {
                    Tuning = mainTuple.GetVariant<TunableTuple>("dialog",
                    NotificationOrDialog.NotificationType == NotificationTypes.Notification ? "notification" : "dialog"),
                    DataContext = NotificationOrDialog
                });

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");

            AutoTunerInvoker.Invoke(this, mainTuple);
        }
    }
}