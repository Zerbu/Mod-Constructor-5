﻿using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.WeeklyScheduleSituationSets
{
    [ObjectEditor(typeof(WeeklyScheduleSituationSet))]
    public partial class WeeklyScheduleSituationSetEditor : UserControl, IObjectEditor
    {
        public WeeklyScheduleSituationSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}