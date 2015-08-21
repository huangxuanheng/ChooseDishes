using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.Uitls.UI
{
    public class ListViewSelectionHelper : FrameworkElement
    {
        #region MultiSelect
        public static readonly DependencyProperty MultiSelectProperty
            = DependencyProperty.RegisterAttached("MultiSelect",
                typeof(bool), typeof(ListViewSelectionHelper),
                new PropertyMetadata(new PropertyChangedCallback(OnMultiSelectInvalidated)));

        public static bool GetMultiSelect(DependencyObject sender)
        {
            return (bool)sender.GetValue(MultiSelectProperty);
        }

        public static void SetMultiSelect(DependencyObject sender, bool value)
        {
            sender.SetValue(MultiSelectProperty, value);
        }
        #endregion
        #region PreviewDrag
        public static readonly DependencyProperty PreviewDragProperty
            = DependencyProperty.RegisterAttached("PreviewDrag",
                typeof(bool), typeof(ListViewSelectionHelper));

        public static bool GetPreviewDrag(DependencyObject sender)
        {
            return (bool)sender.GetValue(PreviewDragProperty);
        }

        public static void SetPreviewDrag(DependencyObject sender, bool value)
        {
            sender.SetValue(PreviewDragProperty, value);
        }
        #endregion
        #region isDragging
        protected static readonly DependencyProperty IsDraggingProperty
            = DependencyProperty.RegisterAttached("isDragging",
                typeof(bool), typeof(ListViewSelectionHelper));

        protected static bool GetIsDragging(DependencyObject sender)
        {
            return (bool)sender.GetValue(IsDraggingProperty);
        }

        protected static void SetIsDragging(DependencyObject sender, bool value)
        {
            sender.SetValue(IsDraggingProperty, value);
        }
        #endregion
        #region Background
        protected static readonly DependencyProperty BackgroundProperty
            = DependencyProperty.RegisterAttached("Background",
                typeof(Color), typeof(ListViewSelectionHelper));

        protected static Color GetBackground(DependencyObject sender)
        {
            return (Color)sender.GetValue(BackgroundProperty);
        }

        protected static void SetBackground(DependencyObject sender, Color value)
        {
            sender.SetValue(BackgroundProperty, value);
        }
        #endregion

        private static List<ListViewItem> _selectedItem = new List<ListViewItem>();
        private static Point _startPos;
        private static Point _lastPos;

        private static void OnMultiSelectInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)dependencyObject;

            if (!(element is ListView))
                throw new ArgumentException("Element not ListView");

            ListView lvElement = (ListView)element;
            if ((bool)e.NewValue == true)
            {
                SetMultiSelect(element, true);
                if (lvElement.Background is SolidColorBrush)
                    SetBackground(lvElement, (lvElement.Background as SolidColorBrush).Color);
                else SetPreviewDrag(lvElement, false);

                //Fix: 05-02-08 Multiple ---> Extended, or Shift+Select not work as intended.
                lvElement.SelectionMode = SelectionMode.Extended;
                lvElement.PreviewMouseDown += new MouseButtonEventHandler(lvElement_PreviewMouseDown);
                lvElement.MouseDown += new MouseButtonEventHandler(lvElement_MouseDown);
                lvElement.MouseMove += new MouseEventHandler(lvElement_MouseMove);
                lvElement.MouseUp += new MouseButtonEventHandler(lvElement_MouseUp);
            }
            else
            {
                SetMultiSelect(element, false);
                lvElement.PreviewMouseDown -= new MouseButtonEventHandler(lvElement_PreviewMouseDown);
                lvElement.MouseDown -= new MouseButtonEventHandler(lvElement_MouseDown);
                lvElement.MouseMove -= new MouseEventHandler(lvElement_MouseMove);
                lvElement.MouseUp -= new MouseButtonEventHandler(lvElement_MouseUp);
            }
        }

       public   static void lvElement_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ListView lvSender = sender as ListView;

            //Ignore if click on scroll bar.
            string controlName = e.MouseDevice.DirectlyOver.GetType().Name;

            if (!(controlName == "ScrollChrome") && !(controlName == "Rectangle"))
                if (!(Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)
                         || Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)
                        ))
                {
                    lvSender.SelectedItems.Clear();
                }
        }


       public static void lvElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {

                ListView lvSender = sender as ListView;

                double xPos = e.MouseDevice.GetPosition(lvSender).X;
                //System.Diagnostics.Debug.WriteLine(VisualTreeHelper.HitTest(lvSender, e.MouseDevice.GetPosition(lvSender)).VisualHit);
                //bool _dragging = (VisualTreeHelper.HitTest(lvSender, e.MouseDevice.GetPosition(lvSender)).VisualHit is ScrollViewer);
                //Fixed : 05-04-08 Cannot drag if Scrollbar not visible (VisialHit = ScrollChome)
                bool _dragging = true;
                SetIsDragging(lvSender, _dragging);

                if (_dragging)
                {
                    lvSender.CaptureMouse();
                    lvSender.SelectionMode = SelectionMode.Multiple;
                    lvSender.SelectedItems.Clear();

                    _startPos = e.MouseDevice.GetPosition(lvSender);
                    _lastPos = _startPos;
                    _selectedItem.Clear();
                }
            }
        }

       public static void lvElement_MouseMove(object sender, MouseEventArgs e)
        {
            ListView lvSender = sender as ListView;

            if (GetIsDragging(lvSender))
            {
                Point current = e.MouseDevice.GetPosition(lvSender);
                Rect selectRect = new Rect(_startPos, current);
                Rect unselectRect = new Rect(_startPos, _lastPos);
                _lastPos = current;

                //Unselect all visible selected items (by using _lastPos) no matter it's current selected or not.
                VisualTreeHelper.HitTest(lvSender, UnselectHitTestFilterFunc,
                    new HitTestResultCallback(SelectResultCallback),
                    new GeometryHitTestParameters(new RectangleGeometry(unselectRect)));

                //Select all visible items in select region.
                VisualTreeHelper.HitTest(lvSender, SelectHitTestFilterFunc,
                    new HitTestResultCallback(SelectResultCallback),
                    new GeometryHitTestParameters(new RectangleGeometry(selectRect)));

                if (!GetPreviewDrag(lvSender))
                {
                    lvSender.SelectedItems.Clear();
                    foreach (ListViewItem item in _selectedItem)
                        item.IsSelected = true;
                    lvSender.Focus();
                }
                else lvSender.Background =
                    new DrawingBrush(DrawRectangle(selectRect, lvSender.ActualWidth, lvSender.ActualHeight, GetBackground(lvSender)));

            }
        }

       public static void lvElement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListView lvSender = sender as ListView;

            if (e.ChangedButton == MouseButton.Left)
            {
                if (GetPreviewDrag(lvSender))
                    lvSender.Background = new SolidColorBrush(GetBackground(lvSender));

                if (GetIsDragging(lvSender))
                {
                    SetIsDragging(lvSender, false);

                    if (GetPreviewDrag(lvSender))
                    {
                        lvSender.SelectedItems.Clear();
                        foreach (ListViewItem item in _selectedItem)
                            item.IsSelected = true;
                    }
                    _selectedItem.Clear();

                    lvSender.Focus();
                }

                //Fixed: 05-09-08 Prevent strange selection effect.
                lvSender.SelectionMode = SelectionMode.Extended;
            }
        }

        public static HitTestResultBehavior SelectResultCallback(HitTestResult result)
        {
            return HitTestResultBehavior.Continue;
        }

        public static HitTestFilterBehavior SelectHitTestFilterFunc(DependencyObject potentialHitTestTarget)
        {
            if (potentialHitTestTarget is ListViewItem)
            {
                ListViewItem item = potentialHitTestTarget as ListViewItem;
                //item.IsSelected = true;                
                _selectedItem.Add(item);

                return HitTestFilterBehavior.ContinueSkipChildren;
            }

            return HitTestFilterBehavior.Continue;
        }

        public static HitTestFilterBehavior UnselectHitTestFilterFunc(DependencyObject potentialHitTestTarget)
        {
            if (potentialHitTestTarget is ListViewItem)
            {
                ListViewItem item = potentialHitTestTarget as ListViewItem;
                //item.IsSelected = true;                
                _selectedItem.Remove(item);

                return HitTestFilterBehavior.ContinueSkipChildren;
            }

            return HitTestFilterBehavior.Continue;
        }

        protected static Drawing DrawRectangle(Rect rect, double actualWidth, double actualHeight, Color background)
        {
            DrawingGroup drawingGroup = new DrawingGroup();
            using (DrawingContext drawingContext = drawingGroup.Open())
            {

                drawingContext.DrawRectangle(new SolidColorBrush(background), null,
                    new Rect(0, 0, actualWidth, actualHeight));

                Brush selectionBrush = new SolidColorBrush(SystemColors.HighlightColor);
                selectionBrush.Opacity = 0.5;

                double x = Math.Max(0, rect.X);
                double y = Math.Max(0, rect.Y);
                double width = rect.X > 0 ? rect.Width : rect.Width + rect.X;
                double height = rect.Y > 0 ? rect.Height : rect.Height + rect.Y;

                drawingContext.DrawRectangle(selectionBrush, new Pen(SystemColors.ActiveBorderBrush, 1.0),
                    new Rect(x, y, width, height));
                return drawingGroup;
            }
        }

    }
}
