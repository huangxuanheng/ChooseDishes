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
    public class QianTaiGuanLiViewModel : ViewModelBase
    {
        #region Command
        RelayCommand _CaiPinShiJIa;    //菜品时价
        public RelayCommand CaiPinShiJIa
        {
            get
            {
                return _CaiPinShiJIa ?? (_CaiPinShiJIa = new RelayCommand(() =>
                {
                    MessageBox.Show("菜品时价");
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
        public QianTaiGuanLiViewModel(IMessenger messenger)
            : base(messenger)
        {
            _Initialize();
        }
    }
}
