using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace IShow.Common.Controls
{
    public class SlideShow : ItemsControl
    {
        static SlideShow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SlideShow), new FrameworkPropertyMetadata(typeof(SlideShow)));
        }

        ItemsPresenter _Items;
        ListBox _Indexs;
        DispatcherTimer _Timer;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _Items = Template.FindName("items", this) as ItemsPresenter;
            _Indexs = Template.FindName("indexs", this) as ListBox;
            if (_Indexs != null)
            {
                _Indexs.SelectionChanged += OnIndexsSelectionChanged;
            }
            _Timer = new DispatcherTimer();
            _Timer.Interval = TimeSpan.FromSeconds(4);
            _Timer.Tick += OnTimerTick;
            _Timer.Start();

        }

        protected void OnIndexsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Index = _Indexs.SelectedIndex;
        }

        protected void OnTimerTick(object sender, EventArgs e)
        {
            Index++;
            Index %= Items.Count;
        }

        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(SlideShow), new PropertyMetadata(0, OnIndexChanged));
        private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slide = d as SlideShow;
            if (slide._Items == null)
            {
                return;
            }
            slide._Items.BeginAnimation(ItemsPresenter.MarginProperty, new ThicknessAnimation()
            {
                To = new Thickness(-slide.ActualWidth * (int)e.NewValue, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(0.3),
            });
        }



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SlideShow), new PropertyMetadata(null));

        

    }
}
