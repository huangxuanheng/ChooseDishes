using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel.Home
{
    public class BaoBiaoZhongXinViewModel : ViewModelBase
    {
        #region Command
        RelayCommand _ShuJuChaXun;    //数据查询
        public RelayCommand ShuJuChaXun
        {
            get
            {
                return _ShuJuChaXun ?? (_ShuJuChaXun = new RelayCommand(() =>
                {
                    MessageBox.Show("数据查询");
                }));
            }
        }
        #endregion
        #region private
        private void _Initialize()
        {
            try
            {
               



            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        public BaoBiaoZhongXinViewModel(IMessenger messenger)
            : base(messenger)
        {
            _Initialize();
        }
    }
}
