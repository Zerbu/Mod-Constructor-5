using Constructor5.Base;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Startup;
using Constructor5.Elements.HolidayTraditions.Components;
using Constructor5.Elements.TestConditions;
using System;

namespace Constructor5.TestConditionTypes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HolidayTraditionPresetsActionAttribute : StartupTypeAttribute
    {
        public override void Invoke(Type type)
        {
            HolidayTraditionPreferencesComponent.AddToddlerPreference += (preference) =>
            {
                preference.Conditions.Add(new TestConditionListItem
                {
                    Condition = new TraitCondition
                    {
                        Whitelist = new ReferenceList()
                        {
                            Items =
                            {
                                new ReferenceListItem
                                {
                                    Reference = new Reference(133125, "trait_toddler")
                                }
                            }
                        }
                    }
                });
            };

            HolidayTraditionPreferencesEditor.AddChildPreference += (preference) =>
            {
                preference.Conditions.Add(new TestConditionListItem
                {
                    Condition = new TraitCondition
                    {
                        Whitelist = new ReferenceList()
                        {
                            Items =
                            {
                                new ReferenceListItem
                                {
                                    Reference = new Reference(34316, "trait_child")
                                }
                            }
                        }
                    }
                });
            };
        }
    }
}
