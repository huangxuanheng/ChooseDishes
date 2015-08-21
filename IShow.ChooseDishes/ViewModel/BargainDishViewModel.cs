using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View;
using IShow.ChooseDishes.View.BargainDish;
using IShow.ChooseDishes.View.Dishes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IShow.ChooseDishes.ViewModel
{
    public class BargainDishViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        IDishService _IDishService;
        
        public BargainDishViewModel(IChooseDishesDataService dataService, IDishService DishService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            _IDishService = DishService;
            //Init();
            
        }
        
        public void Init()
        {

            List<BargainDish> list = _DataService.findBargainDishAll();
            BargainDishList.Clear();
            foreach(var element in list){
                BargainDishList.Add((new BargainDishBean()).CreateBargainDishBean(element));
            }
        }
        private ObservableCollection<BargainDishBean> _BargainDishList = new ObservableCollection<BargainDishBean>();
        public ObservableCollection<BargainDishBean> BargainDishList
        {
            get {
                return _BargainDishList;
            }
            set
            {
                Set("DisheList", ref _BargainDishList, value);
            }
        } 
        //新增折扣菜品 打开新增页面
        AddBargainDish _AddBargainDish;
        //新增 BargainDish 保留对象
        public BargainDishBean _BargainDishBean ;
        public BargainDishBean BargainDishBean
        {
            get
            {
                return _BargainDishBean;
            }
            set
            {
                Set("BargainDishBean", ref _BargainDishBean, value);
            }
        }
        public RelayCommand _OpenAddWin;
        public RelayCommand OpenAddWin {
            get {
                return _OpenAddWin ?? (_OpenAddWin = new RelayCommand(() => {
                    CompareType = 0;
                    _BargainDishBean = new BargainDishBean();
                    _AddBargainDish = new AddBargainDish();
                    BargainDiahSelectList.Clear();
                    _AddBargainDish.ShowDialog();
                    Init();
                }));
            }
        }
        //选择增加菜品 ImportDishes
        //选择菜品页面 DishesSelectBeanWin
        DishesSelectBeanWin _DishesSelectBeanWin;
        //选择菜品后 到 特价菜设置页面 保存数据
        ObservableCollection<DishBeanUtil> _BargainDiahSelectList= new ObservableCollection<DishBeanUtil>();
        public ObservableCollection<DishBeanUtil> BargainDiahSelectList
        {
            get
            {
                return _BargainDiahSelectList;
            }
            set
            {
                Set("BargainDiahSelectList", ref _BargainDiahSelectList, value);
            }
        }
        public RelayCommand _ImportDishes;
        public RelayCommand ImportDishes
        {
            get
            {
                return _ImportDishes ?? (_ImportDishes = new RelayCommand(() =>
                {
                    _DishesSelectBeanWin = new DishesSelectBeanWin();
                    ViewModelDeliver.Set(_DishesSelectBeanWin);
                    bool? flag = _DishesSelectBeanWin.ShowDialog();

                    List<DishBeanUtil>  list  = ViewModelDeliver.Get() as List<DishBeanUtil>;
                    if (list != null) { 
                        foreach (var element in list) {
                            BargainDiahSelectList.Add(element);
                        }
                    }
                }));
            }
        }
        //选择相应的 菜品 规格 列
        public DishBeanUtil _SelectedDish;
        public DishBeanUtil SelectedDish
        {
            get
            {
                return _SelectedDish;
            }
            set
            {
                Set("SelectedDish", ref _SelectedDish, value);
            }
        }
        //删除所选择的菜品
        public RelayCommand _DeleteDishes;
        public RelayCommand DeleteDishes
        {
            get
            {
                return _DeleteDishes ?? (_DeleteDishes = new RelayCommand(() =>
                {
                    if (SelectedDish != null) {
                        BargainDiahSelectList.Remove(SelectedDish);
                        if ( BargainDiahSelectList.Count >0) {
                            if (BargainDiahSelectList.Count == 1)
                            {
                                SelectedDish = BargainDiahSelectList[0];
                            }
                            else {
                                SelectedDish = BargainDiahSelectList[BargainDiahSelectList.Count-1];
                            }
                        }
                    }
                }));
            }

        }
        //保存设置 SaveBargainDish
        public RelayCommand _SaveBargainDish;
        public RelayCommand SaveBargainDish
        {
            get
            {
                return _SaveBargainDish ?? (_SaveBargainDish = new RelayCommand(() =>
                {
                    if (BargainDiahSelectList != null && BargainDiahSelectList.Count > 0)
                    {
                        //看是否有特价冲突
                        bool flag = CheckBargainDish(_BargainDishBean);
                        if (BargainDishBean != null)
                        {
                            if (flag)
                            {
                                //组装数据 
                                List<BargainDish> list = BargainDishBean.CreateBargainDishList(_BargainDiahSelectList.ToArray());
                                //插入数据库
                                _DataService.BatchSaveBargainDish(list.ToArray());
                                _AddBargainDish.Close();
                            }
                            else
                            {
                                MessageBox.Show("规则有冲突,请检查!");
                            }
                        }
                    }
                    else {
                        MessageBox.Show("请选择相应菜品 ! ");
                    }
                }));
            }
        }
        //比较类型设定
        int CompareType = 0;
        //看是否有特价冲突
        public bool CheckBargainDish(BargainDishBean dargainDish)
        {
            if (dargainDish == null) {
                return false;
            }
            List<BargainDish>list =  _DataService.findBargainDishAllAll();
            bool flag = true;
            foreach (var element in list) {
                if (CompareType == 1) {
                    if (element.Id == dargainDish.Id) {
                        continue;
                    }
                }
                if (element.DishId == dargainDish.DishId && element.BargainDishPrice.First().DishSpecification.Equals(dargainDish.DishFormat))
                { 
                    if ((DateTime.Compare(element.StartDate, dargainDish.StartDate) <= 0 && DateTime.Compare(element.EndDate, dargainDish.StartDate) >= 0) ||
                        (DateTime.Compare(element.StartDate, dargainDish.EndDate) <= 0 && DateTime.Compare(element.EndDate, dargainDish.EndDate) >= 0))
                    {
                        if ((element.StartTime.CompareTo(dargainDish.StartTime) <= 0 && element.EndTime.CompareTo(dargainDish.StartTime) >= 0) ||
                        (element.StartTime.CompareTo(dargainDish.EndTime) <= 0 && element.EndTime.CompareTo(dargainDish.EndTime) >= 0))
                        {
                            flag = flag && false;
                        }
                    }
                }
            }
            return flag;
        }
        //根据日期查找对应的特价菜品
        //public DateTime _SelectedDateFind;
        //public DateTime SelectedDateFind
        //{
        //    get
        //    {
        //        return _SelectedDateFind;
        //    }
        //    set
        //    {
        //        Debug.WriteLine("=============");
        //        Set("SelectedDateFind", ref _SelectedDateFind, value);
        //    }
        //}
        //点击当前有效时间查询
        public RelayCommand _DanQianYouXiaoFun;
        public RelayCommand DanQianYouXiaoFun
        {
            get
            {
                return _DanQianYouXiaoFun ?? (_DanQianYouXiaoFun = new RelayCommand(() =>
                {
                    List<BargainDish> list = _DataService.findBargainDishAll();
                    BargainDishList.Clear();
                    foreach (var element in list)
                    {
                        BargainDishList.Add((new BargainDishBean()).CreateBargainDishBean(element));

                    }
                }));
            }

        }
        //批量设置价格 的窗口 
        public BatchMathPrice _BatchMathPrice;
        //折扣值
        int _ZheKouZhi = 80 ;
        public int ZheKouZhi {
            get {
                return _ZheKouZhi;
            }
            set {
                Set("ZheKouZhi", ref _ZheKouZhi, value);
            }
        }
        //保留位数
        int _BaoLiuWeiShu = 1 ;
        public int BaoLiuWeiShu
        {
            get
            {
                return _BaoLiuWeiShu;
            }
            set
            {
                Set("BaoLiuWeiShu", ref _BaoLiuWeiShu, value);
            }
        }
        //批量设置价格  打开页面  BatchPriceWin
        public RelayCommand _BatchPriceWin;
        public RelayCommand BatchPriceWin
        {
            get
            {
                return _BatchPriceWin ?? (_BatchPriceWin = new RelayCommand(() =>
                {
                    _BatchMathPrice = new BatchMathPrice();
                    _BatchMathPrice.ShowDialog();
                    //进行数据计算 
                }));
            }

        }
        //  进行数据计算    BatchMathPriceOK
        public RelayCommand _BatchMathPriceOK;
        public RelayCommand BatchMathPriceOK
        {
            get
            {
                return _BatchMathPriceOK ?? (_BatchMathPriceOK = new RelayCommand(() =>
                {
                    _BatchMathPrice.Close();
                    //进行数据计算 
                    if (BargainDiahSelectList != null && BargainDiahSelectList.Count > 0)
                    {
                        foreach (var element in BargainDiahSelectList) {
                            element.RoundMathPrice(_ZheKouZhi, _BaoLiuWeiShu);
                        }
                    }
                }));
            }

        }
        //保存点击选中的行
        BargainDishBean _SelectedBargainDish;
        public BargainDishBean SelectedBargainDish
        {
            get
            {
                return _SelectedBargainDish;
            }
            set
            {
                Set("SelectedBargainDish", ref _SelectedBargainDish, value);
            }
        }
        //修改 特价菜品 数据  OpenUpdateWin
        //保存 修改特价菜品的页面对象
        UpdateBarGainDish _UpdateBarGainDish;
        public RelayCommand _OpenUpdateWin;
        public RelayCommand OpenUpdateWin
        {
            get
            {
                return _OpenUpdateWin ?? (_OpenUpdateWin = new RelayCommand(() =>
                {
                    if (SelectedBargainDish == null) {
                        MessageBox.Show("请选择要修改的特价菜品!");
                        return;
                    }
                    IndexAll = BargainDishList.Count;
                    IndexTiao = BargainDishList.IndexOf(SelectedBargainDish)+1;
                    CompareType = 1;
                    _UpdateBarGainDish = new UpdateBarGainDish();
                    _UpdateBarGainDish.ShowDialog();

                }));
            }

        }
        //保存修改的 数据  UpdateOk
        public RelayCommand _UpdateOk;
        public RelayCommand UpdateOk
        {
            get
            {
                return _UpdateOk ?? (_UpdateOk = new RelayCommand(() =>
                {
                    if (SelectedBargainDish == null)
                    {
                        return;
                    }
                    //时间校验
                    //看是否有特价冲突
                    if (CheckBargainDish(SelectedBargainDish))
                    {
                        //组装数据
                        BargainDish  bd = SelectedBargainDish.CreateBargainDish(SelectedBargainDish);
                        bd.UpdateTime = DateTime.Now;
                        bd.Update_by = SubjectUtils.GetAuthenticationId();
                        BargainDishPrice bdp = SelectedBargainDish.CreateBargainDishPrice(SelectedBargainDish);
                        bd.BargainDishPrice.Add(bdp);
                        //修改数据
                        bool flag = _DataService.UpdateBargainDish(bd);
                        //刷新页面
                        Init();
                        //关闭窗口
                        if (flag) { 
                            _UpdateBarGainDish.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("规则中 时间有冲突,请检查!");
                    }
                    
                }));
            }

        }
        //DeleteBargainDish 删除特价记录
        public RelayCommand _DeleteBargainDish;
        public RelayCommand DeleteBargainDish
        {
            get
            {
                return _DeleteBargainDish ?? (_DeleteBargainDish = new RelayCommand(() =>
                {
                    if (SelectedBargainDish == null)
                    {
                        MessageBox.Show("请选择要删除的特价菜品!");
                        return;
                    }
                    //删除特价记录
                    bool flag = _DataService.DeleteBargainDish(SelectedBargainDish.Id, SelectedBargainDish.DishId);
                    if (flag)
                    {
                        BargainDishList.Remove(SelectedBargainDish);
                        if (BargainDishList.Count == 1)
                        {
                            SelectedBargainDish = BargainDishList[0];
                        }
                        else if (BargainDishList.Count > 1) 
                        {
                            SelectedBargainDish = BargainDishList[BargainDishList.Count-1];
                        }
                    }
                    else {
                        MessageBox.Show("删除操作失败,请联系管理员!");
                    }
                }));
            }

        }
        //群删 BatchDeleteBargainDish
        public RelayCommand _BatchDeleteBargainDish;
        public RelayCommand BatchDeleteBargainDish
        {
            get
            {
                return _BatchDeleteBargainDish ?? (_BatchDeleteBargainDish = new RelayCommand(() =>
                {
                    
                    //删除特价记录
                    AlertWin alertWin = new AlertWin();
                    alertWin.ShowDialog();
                    alertWin.AlertMsgLabel.Content = "  是否确定全部删除 ! ";
                    String flagWin = ViewModelDeliver.Get() as String ;
                    if ("1".Equals(flagWin)) { 
                        bool flag = _DataService.BatchDeleteBargainDish();
                        Init();
                    }
                }));
            }

        }
        //显示条数
        int _IndexTiao = 1;
        public int IndexTiao
        {
            get
            {
                return _IndexTiao;
            }
            set
            {
                Set("IndexTiao", ref _IndexTiao, value);
            }
        }
        //总条数 IndexAll
        int _IndexAll;
        public int IndexAll
        {
            get
            {
                return _IndexAll;
            }
            set
            {
                Set("IndexAll", ref _IndexAll, value);
            }
        }
        //刷新页面 ReloadDates
        public RelayCommand _ReloadDates;
        public RelayCommand ReloadDates
        {
            get
            {
                return _ReloadDates ?? (_ReloadDates = new RelayCommand(() =>
                {
                    Init();
                }));
            }

        }
        //OnOneIndex  上一页
        RelayCommand _OnOneIndex;
        public RelayCommand OnOneIndex
        {
            get
            {
                return _OnOneIndex ?? (_OnOneIndex = new RelayCommand(() =>
                {
                    if (_IndexTiao > 1)
                    {
                        IndexTiao--;
                        SelectedBargainDish = BargainDishList[_IndexTiao - 1];
                    }
                }));
            }
        }
        //NextIndex 下一页
        RelayCommand _NextIndex;
        public RelayCommand NextIndex
        {
            get
            {
                return _NextIndex ?? (_NextIndex = new RelayCommand(() =>
                {
                    if (_IndexTiao < _IndexAll)
                    {
                        IndexTiao++;
                        SelectedBargainDish = BargainDishList[_IndexTiao - 1];
                    }
                }));
            }
        }
        ///
        /// 
        /// <summary>
        /// 
        /// 回调方法
        /// </summary>
        /// <param name="dt"></param>
        public void SelectedItemChanged(DateTime dt) {
            //更新页面数据
            BargainDishList.Clear();
            List<BargainDish> list  = _DataService.findBargainDishList(dt);
            foreach (var element in list)
            {
                BargainDishList.Add((new BargainDishBean()).CreateBargainDishBean(element));
            }
        }
    }
}
