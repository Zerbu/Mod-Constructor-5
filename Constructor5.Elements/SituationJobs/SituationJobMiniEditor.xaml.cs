using Constructor5.Elements.SituationJobs.Components;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationJobs
{
    [ObjectEditor(typeof(SituationJob), "ElementMini")]
    public partial class SituationJobMiniEditor : UserControl, IObjectEditor
    {
        public static readonly DependencyProperty FilterComponentProperty =
            DependencyProperty.Register("FilterComponent", typeof(SituationJobSimFilterComponent), typeof(SituationJobMiniEditor), new PropertyMetadata(null));

        public SituationJobMiniEditor() => InitializeComponent();

        public SituationJobSimFilterComponent FilterComponent
        {
            get => (SituationJobSimFilterComponent)GetValue(FilterComponentProperty);
            set => SetValue(FilterComponentProperty, value);
        }

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;

            var job = (SituationJob)obj;
            InfoEditor.DataContext = job.GetComponent<SituationJobInfoComponent>();
            FilterComponent = job.GetComponent<SituationJobSimFilterComponent>();
            RewardsEditor.DataContext = job.GetComponent<SituationJobRewardsComponent>();
        }
    }
}