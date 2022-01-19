using Constructor5.Base.ElementSystem;
using Constructor5.UI.Bases;

namespace Constructor5.UI.Dialogs.AddElement
{
    public class ElementAddCommand : CommandBase
    {
        public string ElementName { get; set; }
        public ElementTypeData ElementTypeData { get; set; }

        public override bool CanExecute(object parameter) => ElementTypeData != null && !string.IsNullOrEmpty(ElementName);

        public override void Execute(object parameter)
        {
            ElementManager.Create(ElementTypeData.Type, ElementName);
        }
    }
}
