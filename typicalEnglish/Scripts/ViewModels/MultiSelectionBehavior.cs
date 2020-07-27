using System.Windows;
using System.Windows.Controls;

namespace typicalEnglish.Scripts.ViewModels
{
    public static class MultiSelectionBehavior
    {

        public static readonly DependencyProperty ClickSelectionProperty =
            DependencyProperty.RegisterAttached("ClickSelection",
                                                typeof(bool),
                                                typeof(MultiSelectionBehavior),
                                                new UIPropertyMetadata(false, OnClickSelectionChanged));
        public static bool GetClickSelection(DependencyObject obj)
        {
            return (bool)obj.GetValue(ClickSelectionProperty);
        }
        public static void SetClickSelection(DependencyObject obj, bool value)
        {
            obj.SetValue(ClickSelectionProperty, value);
        }
        private static void OnClickSelectionChanged(DependencyObject dpo,
                                                                 DependencyPropertyChangedEventArgs e)
        {
            if (dpo is ListView listView)
            {
                if ((bool)e.NewValue == true)
                {
                    listView.SelectionChanged += OnSelectionChanged;
                }
                else
                {
                    listView.SelectionChanged -= OnSelectionChanged;
                }
            }
        }
        static void OnSelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}
