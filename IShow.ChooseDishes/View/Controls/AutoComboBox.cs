using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IShow.ChooseDishes.View.Controls
{

    public class AutoComboBoxEventAgs : EventArgs {
        //搜索关键字
        public string _pattern;
        //是否取消绑定
        public bool _cancel;
        //
        public IEnumerable<object> _dataSource;


        public string Pattern
        {
            get {
                return _pattern;
            }
        }
        public bool Cancel {
            get
            {
                return _cancel;
            }
            set
            {
                this._cancel = value;
            }
        }

        public IEnumerable<object> DataSource {
            get {
                return _dataSource;
            }
            set {
                this._dataSource = value;
            }
        
        }

        public AutoComboBoxEventAgs(string _pattern)
        {
            this._pattern = _pattern;
        }
    
    }

    /// <summary>
    /// 自动补全combobox
    /// </summary>
    public class AutoComboBox : ComboBox
    {
        public static readonly RoutedEvent DelayChangedEvent = EventManager.RegisterRoutedEvent("DelayChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AutoComboBox));

        //最大记录数
        public static readonly RoutedEvent MaxRecordsChangedEvent = EventManager.RegisterRoutedEvent("MaxRecordsChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AutoComboBox));

        //最大记录数
        public static readonly RoutedEvent TypeAheadChangedEvent = EventManager.RegisterRoutedEvent("TypeAheadChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AutoComboBox));


        public static readonly DependencyProperty InterceptArrowKeysProperty = DependencyProperty.Register(
           "InterceptArrowKeys",
           typeof(bool),
           typeof(AutoComboBox),
           new FrameworkPropertyMetadata(true));
     
        public static readonly DependencyProperty DelayProperty = DependencyProperty.Register(
           "Delay",
           typeof(int),
           typeof(AutoComboBox),
           new FrameworkPropertyMetadata(DefaultDelay, OnDelayChanged),
           ValidateInt);


        public static readonly DependencyProperty MaxRecordsProperty = DependencyProperty.Register(
          "MaxRecords",
          typeof(int),
          typeof(AutoComboBox),
          new FrameworkPropertyMetadata(DefaultMaxRecords, OnMaxRecordsChanged),
          ValidateInt);


        public static readonly DependencyProperty TypeAheadProperty = DependencyProperty.Register(
         "TypeAhead",
         typeof(bool),
         typeof(AutoComboBox),
         new FrameworkPropertyMetadata(DefaultTypeAhead, OnTypeAheadChanged),
         ValidateInt);

        //拦截鼠标滚轮
        public static readonly DependencyProperty InterceptMouseWheelProperty = DependencyProperty.Register(
         "AutoInterceptMouseWheel",
         typeof(bool),
         typeof(AutoComboBox),
         new FrameworkPropertyMetadata(true));

        //
        public static readonly DependencyProperty TrackMouseWheelWhenMouseOverProperty = DependencyProperty.Register(
            "AutoTrackMouseWheelWhenMouseOver",
            typeof(bool),
            typeof(AutoComboBox),
            new FrameworkPropertyMetadata(true));

        /// <summary>
        /// event handler for auto complete pattern changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void AutoComboBoxHandler(object sender, AutoComboBoxEventAgs args);
        /// <summary>
        /// Event for when pattern has been changed
        /// </summary>
        public event AutoComboBoxHandler PatternChanged;
        private Timer _interval;
        private const int DefaultDelay = 500;
        private const bool DefaultTypeAhead = false;
        private const int DefaultMaxRecords = 10;
        private TextBox _editableTextBox;

        private bool IsKeyEvent = false;
        private bool _clearOnEmpty = false;
        private bool _typeAhead = false;
  

        private const string ElementEditableTextBox = "PART_EditableTextBox";

        static AutoComboBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutoComboBox), new FrameworkPropertyMetadata(typeof(AutoComboBox)));

            EventManager.RegisterClassHandler(typeof(AutoComboBox), UIElement.LostFocusEvent, new RoutedEventHandler(OnLostFocus));
            EventManager.RegisterClassHandler(typeof(AutoComboBox), UIElement.GotFocusEvent, new RoutedEventHandler(OnGotFocus));
        
        }

        public TextBox EditableTextBox {
            get {
                return _editableTextBox;
            }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool InterceptArrowKeys
        {
            get { return (bool)GetValue(InterceptArrowKeysProperty); }
            set { SetValue(InterceptArrowKeysProperty, value); }
        }

        protected void ChangedSelectedUpDown(bool up)
        {
            if (this.IsDropDownOpen) {
                if (up)
                {
                    if (this.SelectedIndex < this.MaxRecords) { 
                        this.SelectedIndex = this.SelectedIndex + 1;
                    }
                }
                else {
                    if (this.SelectedIndex > 1) {
                        this.SelectedIndex = this.SelectedIndex - 1;
                    }
                    
                }
            }

        }

        protected void EnterSelected() {
            if (this.IsDropDownOpen) {
                if (this.SelectedIndex > 0) {
                    this.Text = this.SelectedText;
                }
            }
        
        }

        //按建
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (!InterceptArrowKeys)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Up:
                    ChangedSelectedUpDown(true);
                    e.Handled = true;
                    break;
                case Key.Down:
                    ChangedSelectedUpDown(false);
                    e.Handled = true;
                    break;
                case Key.Enter:
                    EnterSelected();
                    e.Handled = true;
                    break;
            }
        }

        public bool TypeAhead {
            get {
                return _typeAhead;
            }
            set {
                _typeAhead = value;
            }
        }


        public event RoutedPropertyChangedEventHandler<bool> TypeAheadChanged
        {
            add { AddHandler(TypeAheadChangedEvent, value); }
            remove { RemoveHandler(TypeAheadChangedEvent, value);}
        }

        public event RoutedPropertyChangedEventHandler<int> DelayChanged
        {
            add { AddHandler(DelayChangedEvent, value); }
            remove { RemoveHandler(DelayChangedEvent, value); }
        }

        public event RoutedPropertyChangedEventHandler<int> MaxRecordsChanged
        {
            add { AddHandler(MaxRecordsChangedEvent, value); }
            remove { RemoveHandler(MaxRecordsChangedEvent, value); }
        }


        /// <summary>
        ///     Gets or sets a value indicating whether the user can use the mouse wheel to change values.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool InterceptMouseWheel
        {
            get { return (bool)GetValue(InterceptMouseWheelProperty); }
            set { SetValue(InterceptMouseWheelProperty, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the control must have the focus in order to change values using the mouse wheel.
        /// <remarks>
        ///     If the value is true then the value changes when the mouse wheel is over the control. If the value is false then the value changes only if the control has the focus. If <see cref="InterceptMouseWheel"/> is set to "false" then this property has no effect.
        /// </remarks>
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool TrackMouseWheelWhenMouseOver
        {
            get { return (bool)GetValue(TrackMouseWheelWhenMouseOverProperty); }
            set { SetValue(TrackMouseWheelWhenMouseOverProperty, value); }
        }

        [Bindable(true)]
        [DefaultValue(DefaultDelay)]
        [Category("Behavior")]
        public int Delay
        {
            get { return (int)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        [Bindable(true)]
        [DefaultValue(DefaultMaxRecords)]
        [Category("Behavior")]
        public int MaxRecords
        {
            get { return (int)GetValue(MaxRecordsProperty); }
            set { SetValue(MaxRecordsProperty, value); }
        }

        //验证是否为整数
        public static bool ValidateInt(object value) {
            return Convert.ToInt32(value) >= 0;
        }

        private static void OnMaxRecordsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutoComboBox ctrl = (AutoComboBox)d;
            ctrl.OnMaxRecordsChanged((int)e.OldValue, (int)e.NewValue);
        }

        private static void OnTypeAheadChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
        }

        protected virtual void OnMaxRecordsChanged(int oldDelay, int newDelay)
        {
            if (oldDelay != newDelay)
            {

            }
        } 
        private static void OnDelayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutoComboBox ctrl = (AutoComboBox)d;
            ctrl.OnDelayChanged((int)e.OldValue, (int)e.NewValue);
        }

        protected virtual void OnDelayChanged(int oldDelay, int newDelay)
        {
            if (oldDelay != newDelay)
            {
               
            }
        }

        /// <summary>
        /// 当失去焦点时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static  void OnLostFocus(object sender, RoutedEventArgs e) {
            AutoComboBox Box = sender as AutoComboBox;
            Box.IsKeyEvent = false;
            Box.IsDropDownOpen = false;
            // to prevent misunderstanding that user has entered some information
            if (Box.SelectedIndex == -1)
                Box.Text = string.Empty;
            // 同步文本
            else
                Box.Text = Box.SelectedText;
            // 释放计时器资源
            Box._interval.Close();

            try
            {
                Box.EditableTextBox.CaretIndex = 0;
            }
            catch { }
        }

        private static void OnGotFocus(object sender, RoutedEventArgs e)
        { 

        }

        /// <summary>
        /// 选择区域发生改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectionChanged(object sender, RoutedEventArgs e) {
            this.IsKeyEvent = false;
            this.IsDropDownOpen = false;
            if (this.SelectedIndex == -1)
            {
                this.Text = string.Empty;
            }
            else {
                this.Text = this.SelectedText;
            }
        }

        public string SelectedText {
            get {
                if (this.SelectedIndex == -1) {
                    return string.Empty;
                }
                if (this.SelectedItem==null) {
                    return string.Empty;
                }
                return this.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// 当模板应用时
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this._editableTextBox = GetTemplateChild(ElementEditableTextBox) as TextBox;

            if (_editableTextBox == null)
            {
                throw new InvalidOperationException(string.Format("You have missed to specify {0}, in your template", ElementEditableTextBox));
            }
            this._editableTextBox.PreviewKeyDown += new KeyEventHandler(OnPriviewKeyDown);
            this._editableTextBox.TextChanged += new TextChangedEventHandler(OnTextChanged);
            //构件定时器
            this._interval = new Timer(this.Delay);
            this._interval.AutoReset = true;
            this._interval.Elapsed += new ElapsedEventHandler(OnIntervalElapsed);
        }

        private void OnIntervalElapsed(object sender, ElapsedEventArgs e) {

            this.IsKeyEvent = false;
            // pause the timer
            this._interval.Stop();

            this.Dispatcher.BeginInvoke((Action)delegate
            {
                this.IsDropDownOpen = true;
                if (this.PatternChanged != null)
                {
                    AutoComboBoxEventAgs args = new AutoComboBoxEventAgs(this.Text);
                    this.PatternChanged(this, args);
                    if (!args.Cancel) {
                        this.ItemsSource = args.DataSource;
                        if (this.TypeAhead) 
                        {
                            this.Text = args.Pattern;
                            this.EditableTextBox.CaretIndex = args.Pattern.Length;
                        }
                    }
                }
            });
        }

        private void OnPriviewKeyDown(object sender, KeyEventArgs e)
        {
            this.IsKeyEvent = true;
        }



        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            base.OnPreviewMouseWheel(e);

            if (InterceptMouseWheel &&  TrackMouseWheelWhenMouseOver)
            {
                bool increment = e.Delta > 0;
                ChangedSelectedUpDown(increment);
               
            }
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e){
        
            // clear the itemsource when text is empty
            if (this.ClearOnEmpty && string.IsNullOrEmpty(this._editableTextBox.Text.Trim())){
                this.ItemsSource = null; // this should also clear selection
            }
            else if (IsKeyEvent)
            { 
                this.ResetTimer();
            }
        
        }

        public bool ClearOnEmpty {
            get {
                return this._clearOnEmpty;
            }
        }

        protected void ResetTimer()
        {
            this._interval.Stop();
            this._interval.Start();
        }
    }
}
