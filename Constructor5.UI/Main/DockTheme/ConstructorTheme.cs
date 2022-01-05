using System;
using Xceed.Wpf.AvalonDock.Themes;

namespace Constructor.Resources.DockTheme
{
    public class ConstructorTheme : Theme
    {
        public override Uri GetResourceUri() => new Uri("pack://application:,,,/Constructor5.UI;component/Main/DockTheme/Theme.xaml");
    }
}