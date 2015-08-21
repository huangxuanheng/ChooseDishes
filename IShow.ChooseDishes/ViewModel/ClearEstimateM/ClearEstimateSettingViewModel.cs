using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShow.ChooseDishes.ViewModel.ClearEstimateM
{
    public class ClearEstimateSettingViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        ClearEstimateModel _ClearEstimateModel;
        public ClearEstimateModel ClearEstimateModel
        {
            get { return _ClearEstimateModel; }
            set { Set("ClearEstimateModel", ref _ClearEstimateModel, value); }
        }

        RelayCommand _AddClearEstimateDish;
        public RelayCommand AddClearEstimateDish
        {
            get
            {
                return _AddClearEstimateDish ?? (_AddClearEstimateDish = new RelayCommand(() =>
                {
                    if (_ClearEstimateModel.Id == 0)
                    {//新增操作
                        //ClearEstimateViewModel clearEstimateViewModel = new ClearEstimateViewModel();
                        //数据组装
                        ClearEstimate CE = ClearEstimateModel.CreateClearEstimateDishObject(_ClearEstimateModel);
                        ClearEstimate result = _DataService.AddClearEstimateDish(CE);
                        if (result != null)
                        {
                            MessageBox.Show("数据保存成功");
                            ViewModelDeliver.Set(result);
                            //clearEstimateViewModel.ClearEstimateDishesList.Add((new ClearEstimateModel()).CreateClearEstimateDishModel(result));
                        }
                        else
                        {
                            MessageBox.Show("数据保存失败");
                        }
                    }
                    else
                    {//修改操作
                        //数据组装
                        ClearEstimate CE = ClearEstimateModel.CreateClearEstimateDishObject(_ClearEstimateModel);
                        bool result = _DataService.UpdataClearEstimateDish(CE);
                        if (result == true)
                        {
                            MessageBox.Show("数据保存成功");
                        }
                        else
                        {
                            MessageBox.Show("数据保存失败");
                        }
                    }
                }));
            }
        }

        public ClearEstimateSettingViewModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;

            ClearEstimateModel clearEstimateModel = new ClearEstimateModel();
            clearEstimateModel = (ClearEstimateModel)ViewModelDeliver.Get();
            _ClearEstimateModel = clearEstimateModel;

        }
    }
}
