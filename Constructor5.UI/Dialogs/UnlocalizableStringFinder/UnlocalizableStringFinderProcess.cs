using Constructor5.Base.LocalizationSystem;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Constructor5.UI.Dialogs.UnlocalizableStringFinder
{
    public class UnlocalizableStringFinderProcess : IOnUnlocalizableStringDetected
    {
        public static UnlocalizableStringFinderProcess Current { get; } = new UnlocalizableStringFinderProcess();

        public HashSet<string> FoundStrings { get; set; } = new HashSet<string>();

        void IOnUnlocalizableStringDetected.OnUnlocalizableStringDetected(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            try
            {
                if (!HasShownMessageBox)
                {
                    //MessageBox.Show("Unlocalizable text string found!");
                    HasShownMessageBox = true;
                }
            }
            catch
            {
            }

            FoundStrings.Add(text);
        }

        private UnlocalizableStringFinderProcess()
        {
        }

        private bool HasShownMessageBox { get; set; }
    }
}