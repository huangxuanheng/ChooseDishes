using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.Dishes;
using IShow.ChooseDishes.View.PromotionsDish;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class PromotionsDishWiewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        IMarketTypeDataService _IMarketTypeDataService;
        bool _IsNotEdit;
        public bool IsNotEdit
        {
            get
            {
                return _IsNotEdit;
            }
            set
            {
                Set("IsNotEdit", ref _IsNotEdit, value);
            }
        }

        public PromotionsDishWiewModel(IChooseDishesDataService dataService,IMarketTypeDataService  IMarketTypeDataService ,IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            _IMarketTypeDataService = IMarketTypeDataService;
            IsNotEdit = true;
            //加载市别
            MarketTypeItems = _IMarketTypeDataService.FindAllMarketTypeByDeletedStatus();
            //Init();
            
        }
        /// <summary>
        /// 
        /// 加载数据
        /// </summary>
        public void Init()
        {
            List<PromotionsDish> list = _DataService.FindPromotionsDishByObject(SelectStartDate, SelectEndDate, SelectStatus);
            PromotionsDishLists.Clear();
            foreach (var element in list) {
                PromotionsDishBean PDB = new PromotionsDishBean().CreatePromotionsDishBean(element);
                PDB.MarketTypeName = GetMarketType(PDB.MarketTypeId)==null?"": GetMarketType(PDB.MarketTypeId).Name;
                PDB.Code = element.Dish.Code;
                PDB.DishName = element.Dish.DishName;
                PromotionsDishLists.Add(PDB);
            }
            if (PromotionsDishLists.Count > 0) {
                PromotionsDishSelected = PromotionsDishLists[0];
            }
            JeiXiDetail(PromotionsDishSelected);
        }
        //加载 菜品促销 信息明细
        public void JeiXiDetail(PromotionsDishBean bean) {
            DishLists.Clear();
            if (bean != null) {
                if (bean.PromotionsDishDetail != null && bean.PromotionsDishDetail.Count > 0) {
                    foreach (var element in bean.PromotionsDishDetail) {
                        if (element.Deleted == 0) { 
                            PromotionsDishDetailBean  PDDB = new PromotionsDishDetailBean().CreatePromotionsDishDetailBean(element);
                            PDDB.DishName = _DataService.FindDishByDishId(element.DishId).DishName;
                            DishLists.Add(PDDB);
                        }
                    }
                }
            }
        }
        //根据市别编号 得到市别名称
        public MarketType GetMarketType(int MarketTypeId)
        {
            foreach (var element in MarketTypeItems) {
                if (element.Id == MarketTypeId) {
                    return element;
                }
            }
            return null;
        }
        DateTime? _SelectStartDate = null;
        public DateTime? SelectStartDate {
            get {
                return _SelectStartDate;
            }
            set {
                Set("SelectStartDate", ref _SelectStartDate, value);
            }
        }
        DateTime?    _SelectEndDate;
        public DateTime? SelectEndDate
        {
            get
            {
                return _SelectEndDate;
            }
            set
            {
                Set("SelectEndDate", ref _SelectEndDate, value);
            }
        }
        int _SelectStatus = 2;
        public int SelectStatus
        {
            get
            {
                return _SelectStatus;
            }
            set
            {
                Set("SelectStatus", ref _SelectStatus, value);
            }
        }
        RelayCommand<int> _InputStatus;
        public RelayCommand<int> InputStatus
        {
            get
            {
                return _InputStatus ?? (_InputStatus = new RelayCommand<int>(num =>
                {
                    _SelectStatus = num;
                }));
            }
        }
        //保存 PromotionsDish 集合
        public ObservableCollection<PromotionsDishBean> _PromotionsDishLists = new ObservableCollection<PromotionsDishBean>();
        public ObservableCollection<PromotionsDishBean> PromotionsDishLists
        {
            get
            {
                return _PromotionsDishLists;
            }
            set
            {
                Set("PromotionsDishLists", ref _PromotionsDishLists, value);
            }
        }
        //促销明细集合
        public ObservableCollection<PromotionsDishDetailBean> _DishLists = new ObservableCollection<PromotionsDishDetailBean>();
        public ObservableCollection<PromotionsDishDetailBean> DishLists
        {
            get
            {
                return _DishLists;
            }
            set
            {
                Set("DishLists", ref _DishLists, value);
            }
        }
        //设置默认选择项 PromotionsDishSelected
        PromotionsDishBean _PromotionsDishSelected;
        public PromotionsDishBean PromotionsDishSelected
        {
            get
            {
                return _PromotionsDishSelected;
            }
            set
            {
                JeiXiDetail(value);
                Set("PromotionsDishSelected", ref _PromotionsDishSelected, value);
            }
        }
        //新增时候用到的对象值
        PromotionsDishBean _PromotionsDishBean;
        public PromotionsDishBean PromotionsDishBean
        {
            get
            {
                return _PromotionsDishBean;
            }
            set
            {
                Set("PromotionsDishBean", ref _PromotionsDishBean, value);
            }
        }
        //索引 SelectPromotion
        RelayCommand _SelectPromotion;
        public RelayCommand SelectPromotion
        {
            get
            {
                return _SelectPromotion ?? (_SelectPromotion = new RelayCommand(() =>
                {
                    Init();
                }));
            }
        }
        List<MarketType> _MarketTypeItems;
        public List<MarketType> MarketTypeItems
        {
            get
            {
                return _MarketTypeItems;
            }
            set
            {
                Set("MarketTypeItems", ref _MarketTypeItems, value);
            }
        }

        //保存窗口实例
        AddPromotionsDishWin _AddPromotionsDishWin;

        //打开 新建窗口OpenSaveWin
        RelayCommand _OpenSaveWin;
        public RelayCommand OpenSaveWin
        {
            get
            {
                return _OpenSaveWin ?? (_OpenSaveWin = new RelayCommand(() =>
                {
                    _AddPromotionsDishWin = new AddPromotionsDishWin();
                    PromotionsDishBean = new PromotionsDishBean();
                    IsNotEdit = true;
                    //生成单据号码
                    PromotionsDishBean.TradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //操作人
                    PromotionsDishBean.CreateBy = SubjectUtils.GetAuthenticationId();
                    //清空集合
                    SelectDishLists.Clear();
                    //市别归零
                    _AddPromotionsDishWin.MarketTypeComboBox.SelectedValue = null;
                    //影藏 上一条 下一条 显示 新增单据 取消单据
                    _AddPromotionsDishWin.XinZhengDanJuButtom.Visibility = System.Windows.Visibility.Visible;
                    _AddPromotionsDishWin.QuXiaoDanJuButtom.Visibility = System.Windows.Visibility.Visible;
                    _AddPromotionsDishWin.ShangYiTiaoButtom.Visibility = System.Windows.Visibility.Hidden;
                    _AddPromotionsDishWin.NextButtom.Visibility = System.Windows.Visibility.Hidden;
                    _AddPromotionsDishWin.ShowDialog();
                }));
            }
        }


        //public void InitAddWin() {

        //    //_AddPromotionsDishWin = new AddPromotionsDishWin();
        //    PromotionsDishBean = new PromotionsDishBean();
        //    IsNotEdit = true;
        //    //生成单据号码
        //    PromotionsDishBean.TradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");
        //    //操作人
        //    PromotionsDishBean.CreateBy = SubjectUtils.GetAuthenticationId();
        //    //清空集合
        //    SelectDishLists.Clear();
        //    //市别归零
        //    _AddPromotionsDishWin.MarketTypeComboBox.SelectedValue = null;
        //    //影藏 上一条 下一条 显示 新增单据 取消单据
        //    _AddPromotionsDishWin.XinZhengDanJuButtom.Visibility = System.Windows.Visibility.Visible;
        //    _AddPromotionsDishWin.QuXiaoDanJuButtom.Visibility = System.Windows.Visibility.Visible;
        //    _AddPromotionsDishWin.ShangYiTiaoButtom.Visibility = System.Windows.Visibility.Hidden;
        //    _AddPromotionsDishWin.NextButtom.Visibility = System.Windows.Visibility.Hidden;
        //    //_AddPromotionsDishWin.ShowDialog();
        //}

        //保存 选择的 PromotionsDishDetailBean 对象
        public ObservableCollection<PromotionsDishDetailBean> _SelectDishLists = new ObservableCollection<PromotionsDishDetailBean>();
        public ObservableCollection<PromotionsDishDetailBean> SelectDishLists
        {
            get
            {
                return _SelectDishLists;
            }
            set
            {
                Set("SelectDishLists", ref _SelectDishLists, value);
            }
        }
        //OpenSelectDish
        RelayCommand _OpenSelectDish;
        public RelayCommand OpenSelectDish
        {
            get
            {
                return _OpenSelectDish ?? (_OpenSelectDish = new RelayCommand(() =>
                {
                    DishesSelectBeanWin _DishesSelectBeanWin = new DishesSelectBeanWin();
                    _DishesSelectBeanWin.ShowDialog();
                    List<DishBeanUtil> list = ViewModelDeliver.Get() as List<DishBeanUtil>;
                    if (list != null)
                    {
                        foreach (var element in list)
                        {
                            bool flag = false;
                            //判断 是否已经选择
                            foreach (var elem in SelectDishLists) {
                                if (element.DishId == elem.DishId) {
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag) { 
                                PromotionsDishDetailBean pdb = new PromotionsDishDetailBean().CreatePromotionsDishDetailBeanByDishBeanUtil(element);
                                pdb.IsModify = true ;
                                SelectDishLists.Add(pdb);
                            }
                        }
                    }
                }));
            }
        }
        //选择主菜  SelectMainDish
        RelayCommand _SelectMainDish;
        public RelayCommand SelectMainDish
        {
            get
            {
                return _SelectMainDish ?? (_SelectMainDish = new RelayCommand(() =>
                {
                    DishesSelectBeanSeginWin _DishesSelectBeanWin = new DishesSelectBeanSeginWin();
                    _DishesSelectBeanWin.ShowDialog();
                    DishBeanUtil DB = ViewModelDeliver.Get() as DishBeanUtil;
                    if (DB != null)
                    {
                        PromotionsDishBean.DishName = DB.DishName;
                        PromotionsDishBean.DishFormat = DB.DishFormat;
                        PromotionsDishBean.DishId = DB.DishId;
                    }
                }));
            }
        }

        //新增数据 取消新增 RefreshPDish
        RelayCommand _RefreshPDish;
        public RelayCommand RefreshPDish
        {
            get
            {
                return _RefreshPDish ?? (_RefreshPDish = new RelayCommand(() =>
                {
                    PromotionsDishBean = new PromotionsDishBean();
                    IsNotEdit = true;
                    SelectDishLists.Clear();
                    //生成单据号码
                    PromotionsDishBean.TradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");
                    //操作人
                    PromotionsDishBean.CreateBy = SubjectUtils.GetAuthenticationId();
                }));
            }
        }
        //保存选择菜品 
        PromotionsDishDetailBean _PDishSelected;
        public PromotionsDishDetailBean PDishSelected {
            get
            {
                return _PDishSelected;
            }
            set
            {
                Set("PDishSelected", ref _PDishSelected, value);
            }
        }
        //选择市别逻辑 保存市别编号 SelectedMarketTypeItem
        MarketType _SelectedMarketTypeItem;
        public MarketType SelectedMarketTypeItem
        {
            get
            {
                return _SelectedMarketTypeItem;
            }
            set
            {
                if (value != null) {
                    PromotionsDishBean.MarketTypeId = value.Id;
                }
                Set("SelectedMarketTypeItem", ref _SelectedMarketTypeItem, value);
            }
        }
        
        // 删除选择菜品 DeleteSelectDish
        RelayCommand _DeleteSelectDish;
        public RelayCommand DeleteSelectDish
        {
            get
            {
                return _DeleteSelectDish ?? (_DeleteSelectDish = new RelayCommand(() =>
                {
                    if (PDishSelected == null) {
                        MessageBox.Show("请选择要删除的菜品!");
                        return;
                    }
                    SelectDishLists.Remove(PDishSelected);
                    if (SelectDishLists != null && SelectDishLists.Count > 0) {
                        PDishSelected = SelectDishLists[SelectDishLists.Count - 1];
                    }  
                }));
            }
        }
        //审核菜品促销单 审核后的不能修改数据
        RelayCommand _CheckPromotionsDish;
        public RelayCommand CheckPromotionsDish
        {
            get
            {
                return _CheckPromotionsDish ?? (_CheckPromotionsDish = new RelayCommand(() =>
                {
                    if (PromotionsDishSelected == null)
                    {
                        if (PromotionsDishBean.PromotionsDishId == 0)
                        {
                            MessageBox.Show("请保存后再审核!");
                            return;
                        }
                        else
                        {
                            PromotionsDishSelected = PromotionsDishBean;
                        }
                    }
                    else {
                        if (!CheckIsChange())
                        {
                            MessageBox.Show("数据有修改 ,  请保存后再审核!");
                            return;
                        }
                    
                    }
                    if (PromotionsDishSelected.Status == 2) {
                        MessageBox.Show("此数据已审核 !");
                        return;
                    }
                    if (PromotionsDishSelected.Status == 3)
                    {
                        MessageBox.Show("此数据已作废不能再审核 !");
                        return;
                    }
                    //改变数据库字段
                    bool flag = _DataService.CheckPromotionsDish(PromotionsDishSelected.PromotionsDishId, PromotionsDishSelected.DishId,2);
                    Init();
                    _AddPromotionsDishWin.DisPlayYiShenHeLabel.Visibility = System.Windows.Visibility.Visible;
                }));
            }
        }
        //查看数据是否被修改 
        public bool CheckIsChange() {
            if (PromotionsDishSelected == null||PromotionsDishSelected.IsModify) {
                return false;
            }
            foreach (var element in SelectDishLists) {
                if (element.IsModify) {
                    return false;
                }
            }
            return true ;
        }
        // 作废菜品促销单 作废后的不能修改数据 OutPromotionsDish
        RelayCommand _OutPromotionsDish;
        public RelayCommand OutPromotionsDish
        {
            get
            {
                return _OutPromotionsDish ?? (_OutPromotionsDish = new RelayCommand(() =>
                {
                    if (PromotionsDishSelected == null)
                    {
                        if (PromotionsDishBean.PromotionsDishId == 0)
                        {
                            MessageBox.Show("请保存后再作废!");
                            return;
                        }
                        else
                        {
                            PromotionsDishSelected = PromotionsDishBean;
                        }
                    }
                    if (PromotionsDishSelected.Status == 3)
                    {
                        MessageBox.Show("此数据已作废 !");
                        return;
                    }
                    if (PromotionsDishSelected.Status == 2)
                    {
                        MessageBox.Show("此数据已审核 不能再作废 !");
                        return;
                    }
                    //改变数据库字段
                    bool flag = _DataService.CheckPromotionsDish(PromotionsDishSelected.PromotionsDishId, PromotionsDishSelected.DishId, 3);
                    Init();
                    _AddPromotionsDishWin.DisPlayYiZuoFeiLabel.Visibility = System.Windows.Visibility.Visible;
                }));
            }
        }
        //保存 促销单 SavePromotionsDish
        RelayCommand _SavePromotionsDish;
        public RelayCommand SavePromotionsDish
        {
            get
            {
                return _SavePromotionsDish ?? (_SavePromotionsDish = new RelayCommand(() =>
                {
                    if (!IsNotEdit) {
                        return;
                    }
                    //数据验证
                    if (!CheckSavePromotionsDish())
                    {
                        return;
                    }
                    //如果有 PromotionsDishBean 的id 及为 修改保存 
                    if (PromotionsDishBean.PromotionsDishId != 0) { 
                        //修改数据 
                        UpdatePromotionsDishFun();
                        return;
                    }
                    //数据组装
                    PromotionsDish PD = PromotionsDishBean.CreatePromotionsDishObject(SelectDishLists.ToArray());
                    PromotionsDish result = _DataService.SavePromotionsDish(PD);
                    if (result != null)
                    {
                        IsNotEdit = false;
                        //PromotionsDishBean.IsModify = false;
                        //PromotionsDishBean.PromotionsDishId = result.PromotionsDishId;
                        _AddPromotionsDishWin.Close();
                        Init();
                        MessageBox.Show("数据保存成功");
                    }
                    else {
                        MessageBox.Show("数据保存失败");
                    }
                }));
            }
        }
        //修改菜品促销规则
        public void UpdatePromotionsDishFun() {
            //数据组装
            PromotionsDish PD = PromotionsDishBean.CreatePromotionsDishObject(SelectDishLists.ToArray());
            //修改数据
            bool flag = _DataService.UpdatePromotionsDish(PD);
            if (flag)
            {
                IsNotEdit = false;
                PromotionsDishBean.IsModify = false;
                PromotionsDishSelected.IsModify = false;
                SetSelectDishesModify(SelectDishLists);
                //Init();
                MessageBox.Show("数据修改成功");
            }
            else {
                MessageBox.Show("数据修改失败");
            }

        }
        //将赠送菜品全部设置为 isModify 为false;
        public void SetSelectDishesModify(ObservableCollection<PromotionsDishDetailBean>  selectDishListes)
        {
            if (selectDishListes == null) {
                return;
            }
            foreach (var element in selectDishListes) {
                element.IsModify = false;
            }
        }
        //停用   StopPromotionsDish
        RelayCommand _StopPromotionsDish;
        public RelayCommand StopPromotionsDish
        {
            get
            {
                return _StopPromotionsDish ?? (_StopPromotionsDish = new RelayCommand(() =>
                {
                    //数据验证
                    if (PromotionsDishSelected == null) {
                        MessageBox.Show("请选择 一行数据!");
                        return;
                    }
                    //0 为启用 1 为停用
                    if (PromotionsDishSelected.Usering == 1) {
                        MessageBox.Show("选择数据已经停用");
                        return;
                    }
                    bool flag =  _DataService.StartOrStopPromotionsDish(PromotionsDishSelected.PromotionsDishId, PromotionsDishSelected.DishId, 1);
                    if (flag)
                    {
                        Init();
                        MessageBox.Show("选择数据停用成功");
                    }
                    else
                    {
                        MessageBox.Show("选择数据停用失败");
                    }
                }));
            }
        }
        //启用 0 为启用 1 为停用
        RelayCommand _StartUpPromotionsDish;
        public RelayCommand StartUpPromotionsDish
        {
            get
            {
                return _StartUpPromotionsDish ?? (_StartUpPromotionsDish = new RelayCommand(() =>
                {
                    if (PromotionsDishSelected == null)
                    {
                        MessageBox.Show("请选择 一行数据!");
                        return;
                    }
                    if (PromotionsDishSelected.Usering == 0 )
                    {
                        MessageBox.Show("选择数据已经是启用状态");
                        return;
                    }
                    bool flag = _DataService.StartOrStopPromotionsDish(PromotionsDishSelected.PromotionsDishId, PromotionsDishSelected.DishId, 0);
                    if (flag)
                    {
                        Init();
                        MessageBox.Show("选择数据启用成功");
                    }
                    else {
                        MessageBox.Show("选择数据启用失败");
                    }

                }));
            }
        }
        //打开单据审核 OpenCheckPromotionsDish
        RelayCommand _OpenCheckPromotionsDish;
        public RelayCommand OpenCheckPromotionsDish
        {
            get
            {
                return _OpenCheckPromotionsDish ?? (_OpenCheckPromotionsDish = new RelayCommand(() =>
                {
                    if (PromotionsDishSelected == null)
                    {
                        MessageBox.Show("请选择 一行数据!");
                        return;
                    }
                    PromotionsDishBean = PromotionsDishSelected;
                    IndexAll = PromotionsDishLists.Count;
                    IndexTiao = PromotionsDishLists.IndexOf(PromotionsDishSelected) + 1;
                    _AddPromotionsDishWin = new AddPromotionsDishWin();
                    //改变赠菜明细 集合
                    CreateDatas(PromotionsDishBean);
                    //影藏 新增单据 取消单据  显示 上一条 下一条
                    _AddPromotionsDishWin.ShangYiTiaoButtom.Visibility = System.Windows.Visibility.Visible;
                    _AddPromotionsDishWin.NextButtom.Visibility = System.Windows.Visibility.Visible;
                    _AddPromotionsDishWin.XinZhengDanJuButtom.Visibility = System.Windows.Visibility.Hidden;
                    _AddPromotionsDishWin.QuXiaoDanJuButtom.Visibility = System.Windows.Visibility.Hidden;
                    //检查是否是已审核,是否已作废
                    if (PromotionsDishSelected.Status == 2)
                    {
                        _AddPromotionsDishWin.DisPlayYiShenHeLabel.Visibility = System.Windows.Visibility.Visible;
                    }
                    else if (PromotionsDishSelected.Status == 3)
                    {
                        _AddPromotionsDishWin.DisPlayYiZuoFeiLabel.Visibility = System.Windows.Visibility.Visible;
                    }
                    IsNotEdit = true;
                    PromotionsDishSelected.IsModify = false;
                    //打开窗口
                    _AddPromotionsDishWin.ShowDialog();

                }));
            }
        }
        //修改时候 数据组装
        public void CreateDatas(PromotionsDishBean bean) { 
            //改变赠菜明细 集合
            SelectDishLists.Clear();
            foreach (var element in bean.PromotionsDishDetail)
            {
                if (element.Deleted == 0) { 
                    PromotionsDishDetailBean PDDB = (new PromotionsDishDetailBean()).CreatePromotionsDishDetailBean(element);
                    PDDB.DishName = _DataService.FindDishByDishId(element.DishId).DishName;
                    PDDB.IsModify = false;
                    SelectDishLists.Add(PDDB);
                }
            }
            //注入市别
            SelectedMarketTypeItem = GetMarketType(bean.MarketTypeId);
        }

        //刷新 RefreshPromotionsDish
        RelayCommand _RefreshPromotionsDish;
        public RelayCommand RefreshPromotionsDish
        {
            get
            {
                return _RefreshPromotionsDish ?? (_RefreshPromotionsDish = new RelayCommand(() =>
                {
                    SelectStartDate = null;
                    SelectEndDate = null;
                    Init();
                }));
            }
        }
        //显示条数
        int IndexTiao = 1;
        //总条数 IndexAll
        int IndexAll;
        //上一条 UpperPDish
        RelayCommand _UpperPDish;
        public RelayCommand UpperPDish
        {
            get
            {
                return _UpperPDish ?? (_UpperPDish = new RelayCommand(() =>
                {
                    if (IndexTiao > 1)
                    {
                        IndexTiao--;
                        PromotionsDishSelected = PromotionsDishLists[IndexTiao - 1];
                        PromotionsDishBean = PromotionsDishSelected;
                        CreateDatas(PromotionsDishBean);
                    }
                   
                }));
            }
        }
        //下一条 NextPDish
        RelayCommand _NextPDish;
        public RelayCommand NextPDish
        {
            get
            {
                return _NextPDish ?? (_NextPDish = new RelayCommand(() =>
                {
                    if (IndexTiao < IndexAll)
                    {
                        IndexTiao++;
                        PromotionsDishSelected = PromotionsDishLists[IndexTiao - 1];
                        PromotionsDishBean = PromotionsDishSelected;
                        CreateDatas(PromotionsDishBean);
                    }
                }));
            }
        }
        //复制单据 复制单据 CopyPromotionsDish
        RelayCommand _CopyPromotionsDish;
        public RelayCommand CopyPromotionsDish
        {
            get
            {
                return _CopyPromotionsDish ?? (_CopyPromotionsDish = new RelayCommand(() =>
                {
                    if (PromotionsDishSelected == null)
                    {
                        MessageBox.Show("请选择 一行数据!");
                        return;
                    }
                    //数据库复制单据
                     PromotionsDish pd =  _DataService.CopyPromotionsDish(PromotionsDishSelected.PromotionsDishId, PromotionsDishSelected.DishId);
                     if (pd!=null)
                     {
                         Init();
                         MessageBox.Show("选择数据复制成功");
                     }
                     else
                     {
                         MessageBox.Show("选择数据复制失败");
                     }
                }));
            }
        }

        public bool CheckSavePromotionsDish(){
            if (PromotionsDishBean == null) { 
                return  false ;
            }
            if (PromotionsDishBean.MarketTypeId == 0) {
                MessageBox.Show("请选择市别 ! ");
                return false;
            }
            if (PromotionsDishBean.DishId == 0)
            {
                MessageBox.Show("请选择主菜品 ! ");
                return false;
            }
            if (SelectDishLists.Count<=0)
            {
                MessageBox.Show("请选择赠送菜品 ! ");
                return false;
            }
            return true;
        }
    }
}
