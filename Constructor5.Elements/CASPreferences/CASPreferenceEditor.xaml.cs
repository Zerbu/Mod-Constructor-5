using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Traits;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CASPreferences
{
    [ObjectEditor(typeof(CASPreference))]
    public partial class CASPreferenceEditor : UserControl, IObjectEditor
    {
        public CASPreferenceEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element CreateDislikeBuff()
        {
            var result = (Buff)ElementManager.Create(typeof(Buff), null, true);
            result.AddContextModifier(new CASPreferenceContextModifier
            {
                CASPreference = new Reference((Element)DataContext),
                IsDislike = true,
                IsBuff = true
            });
            return result;
        }

        private Element CreateLikeBuff()
        {
            var result = (Buff)ElementManager.Create(typeof(Buff), null, true);
            result.AddContextModifier(new CASPreferenceContextModifier
            {
                CASPreference = new Reference((Element)DataContext),
                IsBuff = true
            });
            return result;
        }
    }
}