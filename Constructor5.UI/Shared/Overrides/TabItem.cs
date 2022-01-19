using System.Windows;

namespace Constructor5.UI.Shared
{
    public class TabItem : System.Windows.Controls.TabItem
    {
        static TabItem()
        {
            HeaderProperty.OverrideMetadata(typeof(TabItem), new FrameworkPropertyMetadata(null, new PropertyChangedCallback((dp, e) =>
            {
                var control = ((TabItem)dp);
                if (control.Header == null || !(control.Header is string))
                {
                    return;
                }

                control.Header = new TextBlock
                {
                    Text = (string)control.Header
                };
            })));
        }

        public TabItem() => Style = (Style)Application.Current.Resources["TabItemStyle"];

        public bool TopMargin
        {
            set => Margin = value ? new Thickness(15, 0, 0, 0) : new Thickness(0, 0, 0, 0);
        }
    }
}