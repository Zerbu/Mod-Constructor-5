using Constructor5.UI.Shared;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards
{
    [ObjectEditor(typeof(RewardSet))]
    public partial class RewardSetEditor : UserControl, IObjectEditor
    {
        public RewardSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
