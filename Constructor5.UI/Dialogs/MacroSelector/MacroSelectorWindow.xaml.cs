using Constructor5.Base.ElementSystem;
using Constructor5.Base.MacroSystem;
using Constructor5.Base.ProjectSystem;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Constructor5.UI.Dialogs.MacroSelector
{
    /// <summary>
    /// Interaction logic for MacroSelectorWindow.xaml
    /// </summary>
    public partial class MacroSelectorWindow : Window
    {
        public MacroSelectorWindow() => InitializeComponent();

        public MacroSelectorWindow(Element element)
        {
            InitializeComponent();
            Element = element;

            var choices = new List<string>();
            foreach(var file in DirectoryUtility.GetCombinedUserAndProgramFiles($"Macros/{TypeName}"))
            {
                choices.Add(Path.GetFileNameWithoutExtension(file));
            }

            SelectableMacrosControl.ItemsSource = choices;
        }

        public string TypeName => Element.GetType().Name;

        public Element Element
        {
            get { return (Element)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Element.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(Element), typeof(MacroSelectorWindow), new PropertyMetadata(null));



        private void AddMacroButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in SelectableMacrosControl.SelectedItems)
            {
                Element.MacroFiles.Add(item.ToString());
            }
        }

        private void RemoveMacroButton_Click(object sender, RoutedEventArgs e)
        {
            Element.MacroFiles.RemoveAt(CurrentMacrosControl.SelectedIndex);
        }

        private void RunNowButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectableMacrosControl.SelectedItem == null)
            {
                return;
            }

            var file = DirectoryUtility.GetUserOrProgramFile($"Macros/{TypeName}", $"{SelectableMacrosControl.SelectedItem}.xml");
            Macro.RunMacroFromFile(file, Element);

            Close();
        }
    }
}