using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace IShow.ChooseDishes.View.Controls
{

    public enum ButtonsAlignment
    {
        Left,
        Right
    }
    public class TimeUpDownChangedRoutedEventArgs : RoutedEventArgs
    {
        public double Interval { get; set; }

        public TimeUpDownChangedRoutedEventArgs(RoutedEvent routedEvent, double interval)
            : base(routedEvent)
        {
            Interval = interval;
        }

    }


    public delegate void TimeUpDownChangedRoutedEventHandler(object sender, TimeUpDownChangedRoutedEventArgs args);

    [TemplatePart(Name = ElementTimeUp, Type = typeof(RepeatButton))]
    [TemplatePart(Name = ElementTimeDown, Type = typeof(RepeatButton))]
    [TemplatePart(Name = ElementHourTextBox, Type = typeof(TextBox))]
    [TemplatePart(Name = ElementMinuteTextBox, Type = typeof(TextBox))]
    public class TimeBox:Control
    {
        public static readonly RoutedEvent ValueIncrementedEvent = EventManager.RegisterRoutedEvent("ValueIncremented", RoutingStrategy.Bubble, typeof(TimeUpDownChangedRoutedEventHandler), typeof(TimeBox));
        public static readonly RoutedEvent ValueDecrementedEvent = EventManager.RegisterRoutedEvent("ValueDecremented", RoutingStrategy.Bubble, typeof(TimeUpDownChangedRoutedEventHandler), typeof(TimeBox));
        public static readonly RoutedEvent DelayChangedEvent = EventManager.RegisterRoutedEvent("DelayChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TimeBox));
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<string>), typeof(TimeBox));


        public readonly static string[] HOURS = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };

        public readonly static string[] MINUTES = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" };
          
        public static readonly DependencyProperty DelayProperty = DependencyProperty.Register(
            "Delay",
            typeof(int),
            typeof(TimeBox),
            new FrameworkPropertyMetadata(DefaultDelay, OnDelayChanged),
            ValidateDelay);

        public static readonly DependencyProperty TextAlignmentProperty = TextBox.TextAlignmentProperty.AddOwner(typeof(TimeBox));


        /// <summary>
        /// 速度
        /// </summary>
        public static readonly DependencyProperty SpeedupProperty = DependencyProperty.Register(
            "Speedup",
            typeof(bool),
            typeof(TimeBox),
            new FrameworkPropertyMetadata(true, OnSpeedupChanged));

       /// <summary>
       /// 是否只读
       /// </summary>
        public static readonly DependencyProperty IsReadOnlyProperty = System.Windows.Controls.Primitives.TextBoxBase.IsReadOnlyProperty.AddOwner(
            typeof(TimeBox),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, IsReadOnlyPropertyChangedCallback));

        /// <summary>
        /// 至成都属性发生改变时，触发事件处理机制
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <param name="e"></param>
        private static void IsReadOnlyPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && e.NewValue != null) {
                var numUpDown = (TimeBox)dependencyObject;
                numUpDown.ToggleReadOnlyMode((bool)e.NewValue);
            }
        }

        //字符串格式化，暂时没用到
        public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register(
            "StringFormat",
            typeof(string),
            typeof(TimeBox),
            new FrameworkPropertyMetadata(string.Empty, OnStringFormatChanged, CoerceStringFormat));

        public static readonly DependencyProperty InterceptArrowKeysProperty = DependencyProperty.Register(
            "InterceptArrowKeys",
            typeof(bool),
            typeof(TimeBox),
            new FrameworkPropertyMetadata(true));

        //属性
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(string),
            typeof(TimeBox),
            new FrameworkPropertyMetadata(DefaultValue, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));


        public static readonly DependencyProperty ButtonsAlignmentProperty = DependencyProperty.Register(
           "ButtonsAlignment",
           typeof(ButtonsAlignment),
           typeof(TimeBox),
           new FrameworkPropertyMetadata(ButtonsAlignment.Right, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static readonly DependencyProperty IntervalProperty = DependencyProperty.Register(
            "Interval",
            typeof(double),
            typeof(TimeBox),
            new FrameworkPropertyMetadata(DefaultInterval, IntervalChanged));

        public static readonly DependencyProperty InterceptMouseWheelProperty = DependencyProperty.Register(
            "InterceptMouseWheel", 
            typeof(bool), 
            typeof(TimeBox), 
            new FrameworkPropertyMetadata(true));

        public static readonly DependencyProperty TrackMouseWheelWhenMouseOverProperty = DependencyProperty.Register(
            "TrackMouseWheelWhenMouseOver", 
            typeof(bool), 
            typeof(TimeBox), 
            new FrameworkPropertyMetadata(default(bool)));

        public static readonly DependencyProperty HideUpDownButtonsProperty = DependencyProperty.Register(
            "HideUpDownButtons",
            typeof(bool),
            typeof(TimeBox),
            new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty UpDownButtonsWidthProperty = DependencyProperty.Register(
            "UpDownButtonsWidth",
            typeof(double),
            typeof(TimeBox),
            new PropertyMetadata(20d));

        public static readonly DependencyProperty InterceptManualEnterProperty = DependencyProperty.Register(
            "InterceptManualEnter",
            typeof(bool),
            typeof(TimeBox),
            new PropertyMetadata(true));

        public static readonly DependencyProperty CultureProperty = DependencyProperty.Register(
            "Culture",
            typeof(CultureInfo),
            typeof(TimeBox),
            new PropertyMetadata(null, (o, e) => {
                                            if (e.NewValue != e.OldValue)
                                            {
                                                var numUpDown = (TimeBox) o;
                                                numUpDown.OnValueChanged(numUpDown.Value, numUpDown.Value);
                                            }
                                        }));

        public static readonly DependencyProperty SelectAllOnFocusProperty = DependencyProperty.Register(
            "SelectAllOnFocus",
            typeof(bool),
            typeof(TimeBox),
            new PropertyMetadata(true));

        private const double DefaultInterval = 1d;
        private const int DefaultDelay = 500;
        private const string ElementTimeDown = "PART_TimeDown";
        private const string ElementTimeUp = "PART_TimeUp";
        private const string ElementHourTextBox = "PART_HourTextBox";
        private const string ElementMinuteTextBox = "PART_MinuteTextBox";
        private const string ScientificNotationChar = "E";
        private const StringComparison StrComp = StringComparison.InvariantCultureIgnoreCase;
        private const char TimeSeparatorChar=':';
        private  const string DefaultValue = "0:0";
        private const int HourMaxValue = 23;
        private const int MinuteMaxValue = 59;
        private const int MinValue = 0;

        private Tuple<string, string> _removeFromText = new Tuple<string, string>(string.Empty, string.Empty);

        private bool _manualChange;
        private RepeatButton _repeatDown;
        private RepeatButton _repeatUp;
        private TextBox _hourTextBox;
        private TextBox _minuteTextBox;
        private TextBox _editingTextBox;
        private int HourMaximum { get { return HourMaxValue; } }

        private int MinuteMaximum { get { return MinuteMaxValue; } }
        private int Minimum { get { return MinValue; } }

        static TimeBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeBox), new FrameworkPropertyMetadata(typeof(TimeBox)));
            VerticalContentAlignmentProperty.OverrideMetadata(typeof(TimeBox), new FrameworkPropertyMetadata(VerticalAlignment.Center));
            HorizontalContentAlignmentProperty.OverrideMetadata(typeof(TimeBox), new FrameworkPropertyMetadata(HorizontalAlignment.Right));

            //EventManager.RegisterClassHandler(typeof(TimeBox), UIElement.GotFocusEvent, new RoutedEventHandler(OnGotFocus));
            
        }

        public event RoutedPropertyChangedEventHandler<string> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

       

      

        public event TimeUpDownChangedRoutedEventHandler ValueIncremented
        {
            add { AddHandler(ValueIncrementedEvent, value); }
            remove { RemoveHandler(ValueIncrementedEvent, value); }
        }

        public event TimeUpDownChangedRoutedEventHandler ValueDecremented
        {
            add { AddHandler(ValueDecrementedEvent, value); }
            remove { RemoveHandler(ValueDecrementedEvent, value); }
        }

        public event RoutedEventHandler DelayChanged
        {
            add { AddHandler(DelayChangedEvent, value); }
            remove { RemoveHandler(DelayChangedEvent, value); }
        }

        /// <summary>
        ///     Gets or sets the amount of time, in milliseconds, the TimeUpDown waits while the up/down button is pressed
        ///     before it starts increasing/decreasing the
        ///     <see cref="Value" /> for the specified <see cref="Interval" /> . The value must be
        ///     non-negative.
        /// </summary>
        [Bindable(true)]
        [DefaultValue(DefaultDelay)]
        [Category("Behavior")]
        public int Delay
        {
            get { return (int)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the user can use the arrow keys <see cref="Key.Up"/> and <see cref="Key.Down"/> to change values. 
        /// </summary>
        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool InterceptArrowKeys
        {
            get { return (bool)GetValue(InterceptArrowKeysProperty); }
            set { SetValue(InterceptArrowKeysProperty, value); }
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

        /// <summary>
        ///     设置用户是否可以在组件中输入文本
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool InterceptManualEnter
        {
            get { return (bool)GetValue(InterceptManualEnterProperty); }
            set { SetValue(InterceptManualEnterProperty, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating the culture to be used in string formatting operations.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(null)]
        public CultureInfo Culture
        {
            get { return (CultureInfo)GetValue(CultureProperty); }
            set { SetValue(CultureProperty, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the +/- button of the control is visible.
        /// </summary>
        /// <remarks>
        ///     If the value is false then the <see cref="Value" /> of the control can be changed only if one of the following cases is satisfied:
        ///     <list type="bullet">
        ///         <item>
        ///             <description><see cref="InterceptArrowKeys" /> is true.</description>
        ///         </item>
        ///         <item>
        ///             <description><see cref="InterceptMouseWheel" /> is true.</description>
        ///         </item>
        ///         <item>
        ///             <description><see cref="InterceptManualEnter" /> is true.</description>
        ///         </item>
        ///     </list>
        /// </remarks>
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool HideUpDownButtons
        {
            get { return (bool)GetValue(HideUpDownButtonsProperty); }
            set { SetValue(HideUpDownButtonsProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(20d)]
        public double UpDownButtonsWidth
        {
            get { return (double)GetValue(UpDownButtonsWidthProperty); }
            set { SetValue(UpDownButtonsWidthProperty, value); }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(ButtonsAlignment.Right)]
        public Controls.ButtonsAlignment ButtonsAlignment
        {
            get { return (ButtonsAlignment)GetValue(ButtonsAlignmentProperty); }
            set { SetValue(ButtonsAlignmentProperty, value); }
        }

        /// <summary>
        /// 设置每次增长值
        /// </summary>
        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue(DefaultInterval)]
        public double Interval
        {
            get { return (double)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool SelectAllOnFocus
        {
            get { return (bool)GetValue(SelectAllOnFocusProperty); }
            set { SetValue(SelectAllOnFocusProperty, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the text can be changed by the use of the up or down buttons only.
        /// </summary>

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }


        /// <summary>
        ///     Gets or sets a value indicating whether the value to be added to or subtracted from <see cref="Value" /> remains
        ///     always
        ///     <see cref="Interval" /> or if it will increase faster after pressing the up/down button/arrow some time.
        /// </summary>
        [Category("Common")]
        [DefaultValue(true)]
        public bool Speedup
        {
            get { return (bool)GetValue(SpeedupProperty); }
            set { SetValue(SpeedupProperty, value); }
        }

        /// <summary>
        ///     Gets or sets the formatting for the displaying <see cref="Value" />
        /// </summary>
        /// <remarks>
        ///     <see href="http://msdn.microsoft.com/en-us/library/dwhawy9k.aspx"></see>
        /// </remarks>
        [Category("Common")]
        public string StringFormat
        {
            get { return (string)GetValue(StringFormatProperty); }
            set { SetValue(StringFormatProperty, value); }
        }

        /// <summary>
        ///     Gets or sets the horizontal alignment of the contents of the text box.
        /// </summary>
        [Bindable(true)]
        [Category("Common")]
        [DefaultValue(TextAlignment.Right)]
        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        [Bindable(true)]
        [Category("Common")]
        [DefaultValue(null)]
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private CultureInfo SpecificCultureInfo
        {
            get { return Culture ?? Language.GetSpecificCulture(); }
        }

        /// <summary> 
        ///     当元素获得焦点时
        /// </summary>
        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            // When TextBox gets logical focus, select the text inside us.
            TextBox tb = (TextBox)sender;
            // If we're an editable TimeBox, forward focus to the TextBox element
            if (tb != null)
            {
                this._editingTextBox = tb;
                this.SelectAll();
            }
            
        }

        /// <summary>
        ///     When overridden in a derived class, is invoked whenever application code or internal processes call
        ///     <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" />.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _repeatUp = GetTemplateChild(ElementTimeUp) as RepeatButton;
            _repeatDown = GetTemplateChild(ElementTimeDown) as RepeatButton;
            
            _hourTextBox = GetTemplateChild(ElementHourTextBox) as TextBox;
            _minuteTextBox = GetTemplateChild(ElementMinuteTextBox) as TextBox;

            if (_repeatUp == null ||
                _repeatDown == null ||
                _hourTextBox == null || _minuteTextBox == null)
            {
                throw new InvalidOperationException(string.Format("You have missed to specify {0}, {1} or {2} in your template", ElementTimeUp, ElementTimeDown, ElementHourTextBox));
            }

            this.ToggleReadOnlyMode(this.IsReadOnly);

            _repeatUp.Click += (o, e) => ChangeValueWithSpeedUp(true);
            _repeatDown.Click += (o, e) => ChangeValueWithSpeedUp(false);
            _hourTextBox.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(OnGotFocus);
            _minuteTextBox.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(OnGotFocus);
            OnValueChanged(Value, Value);
        }

        /// <summary>
        /// 切换只读模式
        /// </summary>
        /// <param name="isReadOnly"></param>

        private void ToggleReadOnlyMode(bool isReadOnly)
        {
            if (_repeatUp == null || _repeatDown == null || _minuteTextBox == null || _hourTextBox == null)
            {
                return;
            }
            
            if (isReadOnly)
            {
                _hourTextBox.LostFocus -= OnTextBoxLostFocus;
                _hourTextBox.GotFocus -= OnTextBoxGotFocus;
                _hourTextBox.PreviewTextInput -= OnPreviewTextInput;
                _hourTextBox.PreviewKeyDown -= OnTextBoxKeyDown;
                _hourTextBox.TextChanged -= OnTextChanged;

                _minuteTextBox.LostFocus -= OnTextBoxLostFocus;
                _minuteTextBox.GotFocus -= OnTextBoxGotFocus;
                _minuteTextBox.PreviewTextInput -= OnPreviewTextInput;
                _minuteTextBox.PreviewKeyDown -= OnTextBoxKeyDown;
                _minuteTextBox.TextChanged -= OnTextChanged;

                DataObject.RemovePastingHandler(_hourTextBox, OnValueTextBoxPaste);
                DataObject.RemovePastingHandler(_minuteTextBox, OnValueTextBoxPaste);
            }
            else
            {
                //小时
                _hourTextBox.LostFocus += OnTextBoxLostFocus;
                _hourTextBox.GotFocus += OnTextBoxGotFocus;
                _hourTextBox.PreviewTextInput += OnPreviewTextInput;
                _hourTextBox.PreviewKeyDown += OnTextBoxKeyDown;
                _hourTextBox.TextChanged += OnTextChanged;
                //分钟
                _minuteTextBox.LostFocus += OnTextBoxLostFocus;
                _minuteTextBox.GotFocus += OnTextBoxGotFocus;
                _minuteTextBox.PreviewTextInput += OnPreviewTextInput;
                _minuteTextBox.PreviewKeyDown += OnTextBoxKeyDown;
                _minuteTextBox.TextChanged += OnTextChanged;
                DataObject.AddPastingHandler(_hourTextBox, OnValueTextBoxPaste);
                DataObject.AddPastingHandler(_minuteTextBox, OnValueTextBoxPaste);
            }
        }

        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            //设定编辑的文本框
            if (!(sender is TextBox)) {
                return;
            }
            _editingTextBox = sender as TextBox;
            if (!InterceptManualEnter)
            {
                Focus();
            }
            _editingTextBox.SelectAll();

        }

        /// <summary>
        /// 选择所有的值
        /// </summary>
        public void SelectAll()
        {
            if (_editingTextBox != null)
            {
                _editingTextBox.SelectAll();
            }
        }

        protected virtual void OnDelayChanged(int oldDelay, int newDelay)
        {
            if (oldDelay != newDelay)
            {
                if (_repeatDown != null)
                {
                    _repeatDown.Delay = newDelay;
                }
                if (_repeatUp != null)
                {
                    _repeatUp.Delay = newDelay;
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
                    ChangeValueWithSpeedUp(true);
                    e.Handled = true;
                    break;
                case Key.Down:
                    ChangeValueWithSpeedUp(false);
                    e.Handled = true;
                    break;
            }

            if (e.Handled)
            {
                _manualChange = false;
            }
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            base.OnPreviewKeyUp(e);
            if (e.Key == Key.Down ||
                e.Key == Key.Up)
            {
                ResetInternal();
            }
        }


        private TextBox GetTextBoxToFocusOn()
        {
            TextBox textBox= _editingTextBox ?? (_editingTextBox = _hourTextBox);
            textBox.SelectAll();
            return textBox;
        }

       
        /// <summary>
        /// 鼠标滚轮事件到该组件时
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            base.OnPreviewMouseWheel(e);
            TextBox _valueTextBox = GetTextBoxToFocusOn();
            if (InterceptMouseWheel && (IsFocused || _valueTextBox.IsFocused || TrackMouseWheelWhenMouseOver))
            {
                bool increment = e.Delta > 0;
                ChangeValueInternal(increment);
                _valueTextBox.SelectAll();
            }
        }
        
        /// <summary>
        /// 用户输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = false;
            if (string.IsNullOrWhiteSpace(e.Text) ||
                e.Text.Length != 1)
            {
                return;
            }
            TextBox box = sender as TextBox;
            string text = e.Text;
             if (char.IsDigit(text[0]))
            {
                string boxValue= box.Text;
                if (boxValue.Length > 1)
                {
                    boxValue = Convert.ToString(boxValue[boxValue.Length-1]);
                }
                string newValue = LimitInputTextValue(boxValue, Convert.ToString(text[0]));
                box.Text = newValue;
                ChangeValueBy();
                box.SelectAll();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 限制用户输入值
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        private static string LimitInputTextValue(string oldValue, string inputValue) {
            if (string.IsNullOrWhiteSpace(oldValue))
            {
                return inputValue;
            }
            if (oldValue.Length > 1) {
                oldValue = Convert.ToString(oldValue[0]);
                if (oldValue.CompareTo("0")==0) {
                    oldValue = null;
                }
            }
            string newValue = oldValue + inputValue;
            return newValue;

        }

        protected virtual void OnSpeedupChanged(bool oldSpeedup, bool newSpeedup)
        {
        }

        // 值发生改变时调用，ValueChanged触发
        protected virtual void OnValueChanged(string oldValue, string newValue)
        {
            if (!string.IsNullOrEmpty(newValue))
            {
                int[] s = ObtainIntValue(newValue);
                

                _hourTextBox.Text = HOURS[s[0]];
                _minuteTextBox.Text = MINUTES[s[1]];
            }
            if (oldValue != newValue)
            {
                this.RaiseEvent(new RoutedPropertyChangedEventArgs<string>(oldValue, newValue, ValueChangedEvent));
            }
        }

        private static object CoerceMaximum(DependencyObject d, object value)
        {
            double minimum = ((TimeBox)d).Minimum;
            double val = (double)value;
            return val < minimum ? minimum : val;
        }

        private static object CoerceStringFormat(DependencyObject d, object basevalue)
        {
            return basevalue ?? string.Empty;
        }


        public static int[] ObtainIntValue(string value) {

            string[] s = value.Split(TimeSeparatorChar);
            if (s.Length !=2) {
                return new int[] { 0, 0 };
            }
            int[] values = new int[2];
            values[0] = Convert.ToInt32(s[0]);
            values[1] = Convert.ToInt32(s[1]);
            return values;

        }

        public static string AppendStringValue(int hour,int minute) { 
            StringBuilder builder= new StringBuilder();
            builder.Append(HOURS[hour]).Append(TimeSeparatorChar).Append(MINUTES[minute]);
            return builder.ToString();
        }

        private static object CoerceValue(DependencyObject d, object value)
        {
            if (value == null)
            {
                return null;
            }
            var TimeUpDown = (TimeBox)d;
            string val = value as string;
            int[] values = ObtainIntValue(val);
            if (values[0] > TimeUpDown.HourMaximum) {
                values[0] = TimeUpDown.Minimum;
            }
            if (values[0] < TimeUpDown.Minimum)
            {
                values[0] = TimeUpDown.HourMaximum;
            }

            if (values[1] > TimeUpDown.MinuteMaximum)
            {
                values[1] = TimeUpDown.Minimum;
            }
            if (values[1] < TimeUpDown.Minimum)
            {
                values[1] = TimeUpDown.MinuteMaximum;
            }

            return AppendStringValue(values[0],values[1]);
        }

        private static void IntervalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var TimeUpDown = (TimeBox)d;

            TimeUpDown.ResetInternal();
        }

        private static void OnDelayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeBox ctrl = (TimeBox)d;

            ctrl.RaiseChangeDelay();
            ctrl.OnDelayChanged((int)e.OldValue, (int)e.NewValue);
        }

        private static void OnSpeedupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeBox ctrl = (TimeBox)d;

            ctrl.OnSpeedupChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        private static void OnStringFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeBox nud = (TimeBox)d;
            
            nud.SetRemoveStringFormatFromText((string)e.NewValue);
          
        }

    

        /// <summary>
        /// 数据已经事件，触发
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            TimeBox _TimeBox = (TimeBox)d;
            if (null != _TimeBox && e.NewValue is string && _TimeBox._hourTextBox!=null&& null!=_TimeBox._minuteTextBox) { 

                _TimeBox.OnValueChanged((string)e.OldValue,(string)e.NewValue);
            }
        }

      private static bool ValidateDelay(object value)
        {
            return Convert.ToInt32(value) >= 0;
        }

     

        private void ChangeValueWithSpeedUp(bool toPositive)
        {
            if (IsReadOnly)
            {
                return;
            }
            //整数，还是负数
            double direction = toPositive ? 1 : -1;
            if (Speedup)
            {
                ChangeValueInternal(direction);
            }
            else
            {
                ChangeValueInternal(direction * Interval);
            }
        }

        private void ChangeValueInternal(bool addInterval)
        {
            ChangeValueInternal(addInterval ? Interval : -Interval);
        }

        private void ChangeValueInternal(double interval)
        {
            if (IsReadOnly)
            {
                return;
            }
            
            TimeUpDownChangedRoutedEventArgs routedEvent = interval > 0 ?
                new TimeUpDownChangedRoutedEventArgs(ValueIncrementedEvent, interval) :
                new TimeUpDownChangedRoutedEventArgs(ValueDecrementedEvent, interval);

            RaiseEvent(routedEvent);

            if (!routedEvent.Handled)
            {
                TextBox tb = GetTextBoxToFocusOn();
                tb.Text = Convert.ToString(Convert.ToDouble(tb.Text) + interval);
                ChangeValueBy();
                tb.Focus();
                tb.SelectAll();
                
            }
        }

        private void ChangeValueBy()
        {
            string newValue = _hourTextBox.Text + TimeSeparatorChar + _minuteTextBox.Text;
           Value = (string)CoerceValue(this, newValue);
        }

        private void EnableDisableDown()
        {
            if (_repeatDown != null)
            {
               // _repeatDown.IsEnabled = Value > Minimum;
            }
        }

        private void EnableDisableUp()
        {
            if (_repeatUp != null)
            {
               // _repeatUp.IsEnabled = Value < Maximum;
            }
        }

        private void EnableDisableUpDown()
        {
            EnableDisableUp();
            EnableDisableDown();
        }

        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            _manualChange = true;
        }

        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!InterceptManualEnter)
            {
                return;
            }

            TextBox tb = (TextBox)sender;
            _manualChange = false;

            double convertedValue;
            if (ValidateText(tb.Text, out convertedValue))
            {
                //    if (Value == convertedValue)
                //    {
                //        OnValueChanged(Value, Value);
                //    }
                //    if (convertedValue > Maximum)
                //    {
                //        if (Value == Maximum)
                //        {
                //            OnValueChanged(Value, Value);
                //        }
                //        else
                //        {
                //            SetValue(ValueProperty, Maximum);
                //        }
                //    }
                //    else if (convertedValue < Minimum)
                //    {
                //        if (Value == Minimum)
                //        {
                //            OnValueChanged(Value, Value);
                //        }
                //        else
                //        {
                //            SetValue(ValueProperty, Minimum);
                //        }
                //    }
                //    else
                //    {
                //        SetValue(ValueProperty, convertedValue);
                //    }
                //}
                //else
                //{
                //    OnValueChanged(Value, Value);
                //}
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                Value = null;
            }
            else if (_manualChange)
            {
                double convertedValue;
                if (ValidateText(((TextBox)sender).Text, out convertedValue))
                {
                    //Value = (double?)CoerceValue(this, convertedValue);
                    e.Handled = true;
                }
            }
        }

        private void OnValueTextBoxPaste(object sender, DataObjectPastingEventArgs e)
        {
            var textBox = (TextBox)sender;
            string textPresent = textBox.Text;

            var isText = e.SourceDataObject.GetDataPresent(DataFormats.Text, true);
            if (!isText)
            {
                return;
            }

            var text = e.SourceDataObject.GetData(DataFormats.Text) as string;

            string newText = string.Concat(textPresent.Substring(0, textBox.SelectionStart), text, textPresent.Substring(textBox.SelectionStart));
            double number;
            if (!ValidateText(newText, out number))
            {
                e.CancelCommand();
            }
        }

        private void RaiseChangeDelay()
        {
            RaiseEvent(new RoutedEventArgs(DelayChangedEvent));
        }

        private void Role() { 
        
        }


        private void ResetInternal()
        {
            if (IsReadOnly)
            {
                return;
            }
        }

        private bool ValidateText(string text, out double convertedValue)
        {
            text = RemoveStringFormatFromText(text);

            return double.TryParse(text, NumberStyles.Any, SpecificCultureInfo, out convertedValue);
        }

        private string RemoveStringFormatFromText(string text)
        {
            // remove special string formattings in order to be able to parse it to double e.g. StringFormat = "{0:N2} pcs." then remove pcs. from text
            if (!string.IsNullOrEmpty(_removeFromText.Item1))
            {
                text = text.Replace(_removeFromText.Item1, string.Empty);
            }
            if (!string.IsNullOrEmpty(_removeFromText.Item2))
            {
                text = text.Replace(_removeFromText.Item2, string.Empty);
            }
            return text;
        }

        private void SetRemoveStringFormatFromText(string stringFormat)
        {
            string tailing = string.Empty;
            string leading = string.Empty;
            string format = stringFormat;
            int indexOf = format.IndexOf("{", StrComp);
            if (indexOf > -1)
            {
                if (indexOf > 0)
                {
                    // remove beginning e.g.
                    // pcs. from "pcs. {0:N2}"
                    tailing = format.Substring(0, indexOf);
                }

                // remove tailing e.g.
                // pcs. from "{0:N2} pcs."
                leading = new string(format.SkipWhile(i => i != '}').Skip(1).ToArray()).Trim();
            }

            _removeFromText = new Tuple<string, string>(tailing, leading);
        }
    }
}
