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
    public class XiTongSheZhiViewModel : ViewModelBase
    {
        #region Command
        RelayCommand _GongSiXinXi;    //公司信息
        public RelayCommand GongSiXinXi
        {
            get
            {
                return _GongSiXinXi ?? (_GongSiXinXi = new RelayCommand(() =>
                {
                    MessageBox.Show("公司信息");
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
        public XiTongSheZhiViewModel(IMessenger messenger)
            : base(messenger)
        {
            _Initialize();
        }
    }
}
