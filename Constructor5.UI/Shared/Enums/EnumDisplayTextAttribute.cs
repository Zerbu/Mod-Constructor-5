using System;

namespace Constructor5.UI.Shared
{
    public class EnumDisplayTextAttribute : Attribute
    {
        public EnumDisplayTextAttribute(string displayText) => DisplayText = displayText;

        public string DisplayText { get; set; }
    }
}