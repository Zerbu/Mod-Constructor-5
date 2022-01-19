using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.Elements.Buffs.Components;
using Constructor5.UI.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Modifiers
{
    /// <summary>
    /// Interaction logic for BuffStatisticModifiersUI.xaml
    /// </summary>
    public partial class BuffModifiersUI : UserControl
    {
        public BuffModifiersUI()
        {
            InitializeComponent();
            Loaded += (e, args) =>
            {
                ((SimpleBrowsePresetsCommand)Resources["AddMultipliersCommand"]).OwnerWindow = Window.GetWindow(this);
            };
        }

        public double DefaultValue
        {
            get { return (double)GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }

        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.Register("DefaultValue", typeof(double), typeof(BuffModifiersUI), new PropertyMetadata(1d));

        public Type ElementType
        {
            get => _elementType;
            set
            {
                _elementType = value;
                ((SimpleBrowsePresetsCommand)Resources["AddMultipliersCommand"]).Type = _elementType;
            }
        }

        public string ElementTypeName
        {
            get => ElementType.Name;
            set => ElementType = Reflection.GetTypeByName(value);
        }

        public double Increment
        {
            get { return (double)GetValue(IncrementProperty); }
            set { SetValue(IncrementProperty, value); }
        }

        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(double), typeof(BuffModifiersUI), new PropertyMetadata(0.1d));

        public bool IsInt { get; set; }

        public bool IsTag
        {
            get { return (bool)GetValue(IsTagProperty); }
            set { SetValue(IsTagProperty, value); }
        }

        public static readonly DependencyProperty IsTagProperty =
            DependencyProperty.Register("IsTag", typeof(bool), typeof(BuffModifiersUI), new PropertyMetadata(false));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(BuffModifiersUI), new PropertyMetadata(null));

        public string PresetsFolder
        {
            get => ((SimpleBrowsePresetsCommand)Resources["AddMultipliersCommand"]).PresetsFolder;
            set => ((SimpleBrowsePresetsCommand)Resources["AddMultipliersCommand"]).PresetsFolder = value;
        }

        public double SliderMaximum
        {
            get => (double)GetValue(SliderMaximumProperty);
            set => SetValue(SliderMaximumProperty, value);
        }

        public static readonly DependencyProperty SliderMaximumProperty =
            DependencyProperty.Register("SliderMaximum", typeof(double), typeof(BuffModifiersUI), new PropertyMetadata(2d));

        public double SliderMinimum
        {
            get => (double)GetValue(SliderMinimumProperty);
            set => SetValue(SliderMinimumProperty, value);
        }

        public static readonly DependencyProperty SliderMinimumProperty =
            DependencyProperty.Register("SliderMinimum", typeof(double), typeof(BuffModifiersUI), new PropertyMetadata(0d));

        private Type _elementType;

        private void SimpleBrowsePresetsCommand_PresetsSelectedCallback(Preset[] presets)
        {
            foreach (var preset in presets)
            {
                var statisticMulitpliers = ItemsSource as IList<BuffReferenceModifier>;
                if (statisticMulitpliers != null)
                {
                    statisticMulitpliers.Add(new BuffReferenceModifier
                    {
                        Reference = new Reference(preset),
                        Value = DefaultValue
                    });
                }

                var tagModifiers = ItemsSource as IList<BuffTagModifier>;
                if (tagModifiers != null)
                {
                    tagModifiers.Add(new BuffTagModifier
                    {
                        Tag = preset.Value,
                        Value = DefaultValue
                    });
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((System.Windows.Controls.Button)sender).Tag;

            var statisticMulitpliers = ItemsSource as IList<BuffReferenceModifier>;
            if (statisticMulitpliers != null)
            {
                statisticMulitpliers.Remove((BuffReferenceModifier)tag);
            }

            var tagModifiers = ItemsSource as IList<BuffTagModifier>;
            if (tagModifiers != null)
            {
                tagModifiers.Remove((BuffTagModifier)tag);
            }
        }
    }
}
