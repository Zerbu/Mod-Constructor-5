﻿using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationJobs.Components
{
    [ObjectEditor(typeof(SituationJobSimFilterComponent))]
    public partial class SituationJobSimFilterComponentEditor : UserControl, IObjectEditor
    {
        public SituationJobSimFilterComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}