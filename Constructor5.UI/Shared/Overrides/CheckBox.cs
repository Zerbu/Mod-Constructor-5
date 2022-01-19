using System.Windows;

namespace Constructor5.UI.Shared
{
    public class CheckBox : System.Windows.Controls.CheckBox
    {
        static CheckBox()
        {
            ContentProperty.OverrideMetadata(typeof(CheckBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback((dp, e) =>
            {
                var control = ((CheckBox)dp);
                if (control.Content == null || !(control.Content is string))
                {
                    return;
                }

                control.Content = new TextBlock
                {
                    Text = (string)control.Content
                };
            })));
        }

        public CheckBox() => Style = (Style)Application.Current.Resources["CheckBoxStyle"];
    }
}