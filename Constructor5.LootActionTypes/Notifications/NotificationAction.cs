using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using Constructor5.Base.Icons;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.TestConditionTypes.Traits;
using Constructor5.TestConditionTypes.Buffs;
using Constructor5.Base.ElementSystem;
using Constructor5.TestConditionTypes;

namespace Constructor5.LootActionTypes.Notifications
{
    [SelectableObjectType("LootActionTypes", "NotificationorDialog")]
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

            var tuningDialogType = "notification";
            switch (NotificationOrDialog.NotificationType)
            {
                case NotificationTypes.Dialog:
                    tuningDialogType = "dialog_ok";
                    break;
            }

            if (NotificationOrDialog.NotificationType == NotificationTypes.YesNo)
            {
                TuneYesNoDialog(newContext, mainTuple);
            }
            else
            {
                TuningActionInvoker.InvokeFromFile("Notification Loot",
                    new TuningActionContext
                    {
                        Tuning = mainTuple.GetVariant<TunableTuple>("dialog", tuningDialogType),
                        DataContext = NotificationOrDialog
                    });
                TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
            }

            AutoTunerInvoker.Invoke(this, mainTuple);
        }

        private void TuneYesNoDialog(LASExportContext originalContext, TunableTuple mainTuple)
        {
            var newContext = new LASExportContext(originalContext);

            var tunableVariant1 = mainTuple.Set<TunableVariant>("dialog", "dialog_icon");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("dialog_icon");
            var tunableList1 = tunableTuple1.Get<TunableList>("content_icons");

            if (NotificationOrDialog.HasLeftIcon)
            {
                TuneYesNoIcon(tunableList1, NotificationOrDialog.YesNoLeftIcon, NotificationOrDialog.YesNoLeftIconText);
            }
            if (NotificationOrDialog.HasMiddleIcon)
            {
                TuneYesNoIcon(tunableList1, NotificationOrDialog.YesNoMiddleIcon, NotificationOrDialog.YesNoMiddleIconText);
            }
            if (NotificationOrDialog.HasRightIcon)
            {
                TuneYesNoIcon(tunableList1, NotificationOrDialog.YesNoRightIcon, NotificationOrDialog.YesNoRightIconText);
            }

            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("icon", "enabled");
            var tunableVariant4 = tunableVariant3.Set<TunableVariant>("enabled", "participant");
            var tunableVariant5 = tunableTuple1.Set<TunableVariant>("icon_override_participant", "enabled");
            tunableVariant5.Set<TunableEnum>("enabled", "Actor");
            var tunableVariant6 = tunableTuple1.Set<TunableVariant>("text", "single");
            tunableVariant6.Set<TunableBasic>("single", NotificationOrDialog.Text);
            var tunableVariant7 = tunableTuple1.Set<TunableVariant>("title", "enabled");
            tunableVariant7.Set<TunableBasic>("enabled", NotificationOrDialog.Title);
            var tunableList2 = tunableTuple1.Get<TunableList>("ui_responses");
            var tunableTuple3 = tunableList2.Get<TunableTuple>(null);
            var tunableVariant8 = tunableTuple3.Set<TunableVariant>("loots_for_response", "enabled");
            var tunableTuple4 = tunableVariant8.Get<TunableTuple>("enabled");

            var tunableList3 = tunableTuple4.Get<TunableList>("loots");
            foreach(var action in ElementTuning.GetInstanceKeys(NotificationOrDialog.YesActions))
            {
                tunableList3.Set<TunableBasic>(null, action);
            }
            

            tunableTuple3.Set<TunableBasic>("text", "0xEA4E6A22");
            var tunableTuple5 = tunableList2.Get<TunableTuple>(null);
            var tunableVariant9 = tunableTuple5.Set<TunableVariant>("loots_for_response", "enabled");
            var tunableTuple6 = tunableVariant9.Get<TunableTuple>("enabled");
            tunableTuple6.Set<TunableEnum>("dialog_response_id_override", "DIALOG_RESPONSE_CUSTOM_2");
            var tunableList4 = tunableTuple6.Get<TunableList>("loots");

            foreach (var action in ElementTuning.GetInstanceKeys(NotificationOrDialog.NoActions))
            {
                tunableList4.Set<TunableBasic>(null, action);
            }

            tunableTuple5.Set<TunableBasic>("text", "0x16A19A06");

            if (NotificationOrDialog.RequireSelfDiscovery)
            {
                newContext.TestConditions.Add(new SelfDiscoveryEnabledCondition());

                var buffCondition = new BuffCondition();
                buffCondition.Blacklist.Items.Add(new ReferenceListItem() { Reference = new Reference(318344) });
                newContext.TestConditions.Add(buffCondition);

                var traitCondition = new TraitCondition();
                traitCondition.Blacklist.Items.Add(new ReferenceListItem() { Reference = new Reference(315699) });
                newContext.TestConditions.Add(traitCondition);
            }

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }

        private void TuneYesNoIcon(TunableList listTunable, ElementIcon icon, STBLString text)
        {
            var tunableTuple1 = listTunable.Get<TunableTuple>(null);
            tunableTuple1.Set<TunableBasic>("icon", icon);
            if (!string.IsNullOrEmpty(text.CustomText))
            {
                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("label", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", text);
            }
        }
    }
}