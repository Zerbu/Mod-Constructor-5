using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    public class HolidayTraditionPreference
    {
        public HolidayTraditionPreferenceType Type { get; set; }

        public ObservableCollection<TestConditionListItem> Conditions { get; set; } = new ObservableCollection<TestConditionListItem>();

        public STBLString Reason { get; set; } = new STBLString() { CustomText = "(From Custom Condition)" };
    }
}