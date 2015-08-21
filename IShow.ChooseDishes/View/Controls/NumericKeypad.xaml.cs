using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.View.Controls
{


    public class NumericKeypadEventArgs:EventArgs {
        /// <summary>
        /// 输入字符
        /// </summary>
        public char Input{get;set;}
        /// <summary>
        /// 是否为命令
        /// </summary>
        public bool Back{get;set;}

        public NumericKeypadEventArgs(char input, bool isCommand) {
            this.Input = input;
            this.Back = isCommand;
        }
    
    }

    /// <summary>
    /// NumberKeyBoard.xaml 的交互逻辑
    /// </summary>
    public partial class NumericKeypad : UserControl
    {
        private const string ElementNumber0 = "PART_Number0";
        private const string ElementNumber1 = "PART_Number1";
        private const string ElementNumber2 = "PART_Number2";
        private const string ElementNumber3 = "PART_Number3";
        private const string ElementNumber4 = "PART_Number4";
        private const string ElementNumber5 = "PART_Number5";
        private const string ElementNumber6 = "PART_Number6";
        private const string ElementNumber7 = "PART_Number7";
        private const string ElementNumber8 = "PART_Number8";
        private const string ElementNumber9 = "PART_Number9";

        private const string ElementDot = "PART_NumberDot";
        private const string ElementBack = "PART_Back";


        public NumericKeypad()
        {
            InitializeComponent();
        }

     

        public delegate void NumericKeypadHandler(object sender, NumericKeypadEventArgs args);

        /// <summary>
        /// 用户点击时间
        /// </summary>
        public event NumericKeypadHandler ClickedCommand;



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            PART_Number0.Click += (o, e) => OnKeypadButtonClick('0', false);
            PART_Number1.Click += (o, e) => OnKeypadButtonClick('1', false);
            PART_Number2.Click += (o, e) => OnKeypadButtonClick('2', false);
            PART_Number3.Click += (o, e) => OnKeypadButtonClick('3', false);
            PART_Number4.Click += (o, e) => OnKeypadButtonClick('4', false);
            PART_Number5.Click += (o, e) => OnKeypadButtonClick('5', false);
            PART_Number6.Click += (o, e) => OnKeypadButtonClick('6', false);
            PART_Number7.Click += (o, e) => OnKeypadButtonClick('7', false);
            PART_Number8.Click += (o, e) => OnKeypadButtonClick('8', false);
            PART_Number9.Click += (o, e) => OnKeypadButtonClick('9', false);
            PART_NumberDot.Click += (o, e) => OnKeypadButtonClick('.', false);
            PART_CommandBack.Click += (o, e) => OnKeypadButtonClick('D', true);


        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.Key)
            {
                case Key.NumPad0:
                    OnKeypadButtonClick('0',false);
                    e.Handled = true;
                    break;
                case Key.NumPad1:
                    OnKeypadButtonClick('1', false);
                    e.Handled = true;
                    break;
                case Key.NumPad2:
                    OnKeypadButtonClick('2', false);
                    e.Handled = true;
                    break;
                case Key.NumPad3:
                    OnKeypadButtonClick('3', false);
                    e.Handled = true;
                    break;
                case Key.NumPad4:
                    OnKeypadButtonClick('4', false);
                    e.Handled = true;
                    break;
                case Key.NumPad5:
                    OnKeypadButtonClick('5', false);
                    e.Handled = true;
                    break;
                case Key.NumPad6:
                    OnKeypadButtonClick('6', false);
                    e.Handled = true;
                    break;
                case Key.NumPad7:
                    OnKeypadButtonClick('7', false);
                    e.Handled = true;
                    break;
                case Key.NumPad8:
                    OnKeypadButtonClick('8', false);
                    e.Handled = true;
                    break;
                case Key.NumPad9:
                    OnKeypadButtonClick('9', false);
                    e.Handled = true;
                    break;
                case Key.OemPlus:
                    OnKeypadButtonClick('.', false);
                    e.Handled = true;
                    break;
                case Key.Back:
                    OnKeypadButtonClick('D', true);
                    e.Handled = true;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">输入的字符</param>
        /// <param name="backCommand">是否为退格键，如果为退格键，则输入无效</param>
        public void OnKeypadButtonClick(char input,bool backCommand) {

            this.Dispatcher.BeginInvoke((Action)delegate
            {
                if (this.ClickedCommand != null)
                {
                    NumericKeypadEventArgs args = new NumericKeypadEventArgs(input, backCommand);
                    this.ClickedCommand(this, args);
                }
            });
            
        }
    }
}
