using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Objectives;
using Constructor5.Elements.ObjectiveSets;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ComplexWhimSets
{
    [ObjectEditor(typeof(ComplexWhimSet))]
    public partial class ComplexWhimSetEditor : UserControl, IObjectEditor
    {
        public ComplexWhimSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private void PresetCareerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (ComplexWhimSet)DataContext;
            element.ActivatedPriority = 3;
            element.ChainedPriority = 5;
            element.CooldownTimer = 1;
            element.PriorityDecayRate = 0.00833;
        }

        private void PresetChildSkillButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (ComplexWhimSet)DataContext;
            element.ActivatedPriority = 6;
            element.ChainedPriority = 7;
            element.CooldownTimer = 1;
            element.PriorityDecayRate = 0.00833;
        }

        private void PresetDefaultButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (ComplexWhimSet)DataContext;
            element.ActivatedPriority = 6;
            element.ChainedPriority = 11;
            element.CooldownTimer = 60;
            element.PriorityDecayRate = 0.00833;
        }

        private void PresetSkillButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (ComplexWhimSet)DataContext;
            element.ActivatedPriority = 4;
            element.ChainedPriority = 10;
            element.CooldownTimer = 1;
            element.PriorityDecayRate = 0.00833;
        }

        private void PresetSocialButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (ComplexWhimSet)DataContext;
            element.ActivatedPriority = 6;
            element.ChainedPriority = 10;
            element.CooldownTimer = 1;
            element.PriorityDecayRate = 0.00833;
        }

        private Element ReferenceListControl_CreateElementFunction()
        {
            var element = (Objective)ElementManager.Create(typeof(Objective), null, true);
            return element;
        }
    }
}