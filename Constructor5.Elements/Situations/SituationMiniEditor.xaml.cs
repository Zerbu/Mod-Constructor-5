using Constructor5.Elements.Situations.Components;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations
{
    //[ObjectEditor(typeof(Situation), "ElementMini")]
    // currently disabled - doesn't work as intended
    public partial class SituationMiniEditor : UserControl, IObjectEditor
    {
        public static readonly DependencyProperty GoaledEventComponentProperty =
            DependencyProperty.Register("GoaledEventComponent", typeof(SituationGoaledEventComponent), typeof(SituationMiniEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty TemplateComponentProperty =
            DependencyProperty.Register("TemplateComponent", typeof(SituationTemplateComponent), typeof(SituationMiniEditor), new PropertyMetadata(null));

        public SituationMiniEditor() => InitializeComponent();

        public SituationGoaledEventComponent GoaledEventComponent
        {
            get { return (SituationGoaledEventComponent)GetValue(GoaledEventComponentProperty); }
            set { SetValue(GoaledEventComponentProperty, value); }
        }

        public SituationTemplateComponent TemplateComponent
        {
            get { return (SituationTemplateComponent)GetValue(TemplateComponentProperty); }
            set { SetValue(TemplateComponentProperty, value); }
        }

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            GoaledEventComponent = ((Situation)obj).GetComponent<SituationGoaledEventComponent>();
            TemplateComponent = ((Situation)obj).GetComponent<SituationTemplateComponent>();
        }
    }
}