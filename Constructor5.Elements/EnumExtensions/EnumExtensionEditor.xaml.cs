using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.EnumExtensions
{
    [ObjectEditor(typeof(EnumExtension))]
    public partial class EnumExtensionEditor : UserControl, IObjectEditor
    {
        public EnumExtensionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}