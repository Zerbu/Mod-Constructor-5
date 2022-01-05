namespace Constructor5.UI.Dialogs.ObjectTypeSelector
{
    public interface IObjectTypeSelectorExtraTab
    {
        string TabName { get; }

        void Initialize(ObjectTypeSelectorWindow selectorWindow);
    }
}