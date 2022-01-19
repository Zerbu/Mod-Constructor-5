namespace Constructor5.UI.Shared
{
    public interface IObjectEditor
    {
        //object DataContext { get; set; }
        object Content { get; }

        void SetObject(object obj, string tag);
    }
}