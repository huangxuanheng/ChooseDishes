using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;

namespace IShow.Common.Controls
{
    public class WindowBehaviors
    {
        public static readonly DependencyProperty BorderlessWindowBehaviorProperty = DependencyProperty.RegisterAttached(
            @"BorderlessWindowBehavior",
            typeof(BorderlessWindowBehavior),
            typeof(WindowBehaviors),
            new FrameworkPropertyMetadata(null, OnPropertyChanged));

        public static BorderlessWindowBehavior GetBorderlessWindowBehavior(DependencyObject uie)
        {
            return (BorderlessWindowBehavior)uie.GetValue(BorderlessWindowBehaviorProperty);
        }

        public static void SetBorderlessWindowBehavior(DependencyObject uie, BorderlessWindowBehavior value)
        {
            uie.SetValue(BorderlessWindowBehaviorProperty, value);
        }

        private static void OnPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            var uie = dpo as UIElement;

            if (uie == null)
            {
                return;
            }

            BehaviorCollection itemBehaviors = Interaction.GetBehaviors(uie);
            itemBehaviors.Clear();
            var clone = (Behavior)(e.NewValue as BorderlessWindowBehavior).Clone();
            itemBehaviors.Add(clone);

        }

    }
}
