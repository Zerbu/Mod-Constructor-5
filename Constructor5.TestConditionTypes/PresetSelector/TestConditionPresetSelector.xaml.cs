using Constructor5.TestConditionTypes.SimInfo;
using Constructor5.UI.Dialogs.ObjectTypeSelector;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.PresetSelector
{
    // [ObjectTypeExtraTab("TestConditionTypes")] unfinished feature
    public partial class TestConditionPresetSelector : UserControl, IObjectTypeSelectorExtraTab
    {
        public TestConditionPresetSelector() => InitializeComponent();

        public string TabName => "Presets";

        public void Initialize(ObjectTypeSelectorWindow selectorWindow)
        {
            ObjectTypeSelectorWindow = selectorWindow;
            LoadAgePresets();
        }

        private void LoadAgePresets()
        {
            var ages = new[] { "Baby", "Toddler", "Child", "Teen", "YoungAdult", "Adult", "Elder" };

            var agePresets = new List<ConditionAgePreset>();
            foreach(var age in ages)
            {
                // Adult is not commonly used without Young Adult
                if (age == "Adult")
                {
                    continue;
                }

                var olderAges = new List<string>()
                {
                    age
                };
                var youngerAges = new List<string>()
                {
                    age
                };

                var isOlder = false;
                foreach (var relativeAge in ages)
                {
                    if (isOlder)
                    {
                        olderAges.Add(relativeAge);
                    }
                    else
                    {
                        if (relativeAge == age)
                        {
                            isOlder = true;
                            continue;
                        }

                        youngerAges.Add(relativeAge);
                    }
                }

                var ageLabel = age == "YoungAdult" ? "Young Adult" : age;
                
                // Young Adult is not commonly used without Adult
                if (age != "YoungAdult")
                {
                    agePresets.Add(new ConditionAgePreset
                    {
                        Label = ageLabel,
                        Ages = new HashSet<string> { age }
                    });
                }

                if (age != "Baby" && age != "Elder")
                {
                    // "Teen and Young Adult" is not common enough
                    if (age != "Teen")
                    {
                        var nextAge = olderAges[1];
                        var nextAgeLabel = nextAge == "YoungAdult" ? "Young Adult" : nextAge;
                        agePresets.Add(new ConditionAgePreset
                        {
                            Label = $"{ageLabel} or {nextAgeLabel}",
                            Ages = new HashSet<string>() { age, nextAge }
                        });
                    }

                    // disable this for adults since there's only one age after it
                    if (age != "Adult")
                    {
                        agePresets.Add(new ConditionAgePreset
                        {
                            Label = $"{ageLabel} or Older",
                            Ages = new HashSet<string>(olderAges)
                        });
                    }
                }
            }

            AgesControl.ItemsSource = agePresets;
        }

        private ObjectTypeSelectorWindow ObjectTypeSelectorWindow { get; set; }

        private void AgeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var preset = (ConditionAgePreset)((Button)sender).Tag;
            var condition = new SimInfoCondition()
            {
                GeneratedLabel = preset.Label,
                AllowBaby = preset.Ages.Contains("Baby"),
                AllowToddler = preset.Ages.Contains("Toddler"),
                AllowChild = preset.Ages.Contains("Child"),
                AllowTeen = preset.Ages.Contains("Teen"),
                AllowYoungAdult = preset.Ages.Contains("YoungAdult"),
                AllowAdult = preset.Ages.Contains("Adult"),
                AllowElder = preset.Ages.Contains("Elder")
            };
            ObjectTypeSelectorWindow.NotifyObjectChanged(condition);
        }
    }
}