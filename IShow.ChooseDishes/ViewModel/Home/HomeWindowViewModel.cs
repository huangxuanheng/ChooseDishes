using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.ViewModel.Home
{
    public class MainFrameWindowViewModel : ViewModelBase
    {
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
        public MainFrameWindowViewModel(IMessenger messenger)
            : base(messenger)
        {
            _Initialize();
        }
    }
}
