using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Navigation;

namespace IShow.Common.Controls
{
    public class BorderlessWindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.WindowStyle = WindowStyle.None;
            AssociatedObject.AllowsTransparency = true;
            AssociatedObject.ResizeMode = ResizeMode.NoResize;
            AssociatedObject.MouseDown += TitleBarMouseDown;
            base.OnAttached();
        }


        protected void TitleBarMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (AssociatedObject.WindowState == WindowState.Maximized)
                return;
            var mousePosition = e.GetPosition(AssociatedObject);
            if (e.ChangedButton == MouseButton.Left)
            {
                IntPtr windowHandle = new WindowInteropHelper(AssociatedObject).Handle;
                var wpfPoint = AssociatedObject.PointToScreen(Mouse.GetPosition(AssociatedObject));
                short x = Convert.ToInt16(wpfPoint.X);
                short y = Convert.ToInt16(wpfPoint.Y);
                int lParam = x | (y << 16);
                SendMessage(windowHandle, WM_NCLBUTTONDOWN, HT_CAPTION, lParam);
            }
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int HT_CAPTION = 0x2;
    }
}
