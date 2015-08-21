using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View.ClearEstimate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShow.ChooseDishes.ViewModel.ClearEstimateM
{
    public class ClearEstimateViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        IDishService _IDishService;

        public ClearEstimateViewModel(IChooseDishesDataService dataService, IDishService DishService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            _IDishService = DishService;
            Init();
        }
        
        public void Init()
        {
            List<ClearEstimate> list = _DataService.QueryClearEstimateDishesList();
            ClearEstimateDishesList.Clear();
            foreach (var element in list)
            {
                ClearEstimateDishesList.Add((new ClearEstimateModel()).CreateClearEstimateDishModel(element));
            }
        }
        private ObservableCollection<ClearEstimateModel> _ClearEstimateDishesList = new ObservableCollection<ClearEstimateModel>();
        public ObservableCollection<ClearEstimateModel> ClearEstimateDishesList
        {
            get {
                return _ClearEstimateDishesList;
            }
            set
            {
                Set("ClearEstimateDishesList", ref _ClearEstimateDishesList, value);
            }
        } 

        //估清菜品中途取消
        public void MidwayCancleClearEstimate(ClearEstimateModel model)
        {

            ClearEstimateModel ClearEstimateModel = new ClearEstimateModel();
            if (model.MidwayCancle == 0)
            {
                ClearEstimate CE = ClearEstimateModel.CreateClearEstimateDishObject(model);
                bool result = _DataService.UpdataClearEstimateDish(CE);
                if (result == true)
                {
                    MessageBox.Show("中途取消成功");
                }
                else
                {
                    MessageBox.Show("中途取消失败");
                }
            }
            else
            {
                MessageBox.Show("该菜品已取消估清");
            }
            
        }
        //估清菜品资料选择
        DishesDataSeletedWindow _DishesDataSeletedWin;
        RelayCommand _AddClearEstimateDishes;
        public RelayCommand AddClearEstimateDishes
        {
            get
            {
                return _AddClearEstimateDishes ?? (_AddClearEstimateDishes = new RelayCommand(() =>
                {
                    _DishesDataSeletedWin = new DishesDataSeletedWindow();
                    _DishesDataSeletedWin.ShowDialog();

                    ClearEstimate CE = (ClearEstimate)ViewModelDeliver.Get();
                    if (CE.Id != 0)
                    {
                        ClearEstimateDishesList.Add((new ClearEstimateModel()).CreateClearEstimateDishModel(CE));
                    }
                }));
            }
        }
        //修改菜品估清设置
        ClearEstimateSettingWindow _ClearEstimateSettingWindow;
        RelayCommand _UpdataBuyGivingDishes;
        public RelayCommand UpdataBuyGivingDishes
        {
            get
            {
                return _UpdataBuyGivingDishes ?? (_UpdataBuyGivingDishes = new RelayCommand(() =>
                {
                    _ClearEstimateSettingWindow = new ClearEstimateSettingWindow();
                    _ClearEstimateSettingWindow.ShowDifferentStyleWin(1);//修改操作，显示上下记录按钮
                    _ClearEstimateSettingWindow.ShowDialog();
                }));
            }
        }
    }
}
