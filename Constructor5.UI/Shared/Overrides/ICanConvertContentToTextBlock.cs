using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public interface ICanConvertContentToTextBlock
    {
        object ContentToConvert { get; set; }
        bool ShouldConvertStringToTextBlock { get; set; }
    }
}
