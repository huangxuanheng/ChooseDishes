using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace IShow.ChooseDishes.ViewModel.Home.Setting
{

    /// <summary>
    /// 按条件筛选桌台
    /// </summary>
    public class ChooseShowTableViewModel:ViewModelBase
    {
        private int _selector;

        public int Selector {
            get {
                return _selector;
            }
            set {
                Set("Selector", ref _selector, value);
            }
        }

    }
}
