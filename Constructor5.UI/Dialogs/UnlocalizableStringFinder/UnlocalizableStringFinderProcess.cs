using Constructor5.Base.LocalizationSystem;
using System.Collections.Generic;

namespace Constructor5.UI.Dialogs.UnlocalizableStringFinder
{
    public class UnlocalizableStringFinderProcess : IOnUnlocalizableStringDetected
    {
        public static UnlocalizableStringFinderProcess Current { get; } = new UnlocalizableStringFinderProcess();

        public HashSet<string> FoundStrings { get; set; } = new HashSet<string>();

        void IOnUnlocalizableStringDetected.OnUnlocalizableStringDetected(string text) => FoundStrings.Add(text);

        private UnlocalizableStringFinderProcess()
        {
        }
    }
}