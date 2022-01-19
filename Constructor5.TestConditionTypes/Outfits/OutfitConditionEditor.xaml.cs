using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Outfits
{
    [ObjectEditor(typeof(OutfitCondition))]
    public partial class OutfitConditionEditor : UserControl, IObjectEditor
    {
        public OutfitConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}