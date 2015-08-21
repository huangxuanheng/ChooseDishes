using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.Dishes;
using IShow.ChooseDishes.View.OrgInfo;
using IShow.ChooseDishes.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace IShow.ChooseDishes.ViewModel
{

    public class DishPackagesViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        int Line = 0;
        ObservableCollection<DishBean> _DishV;
        //套菜窗口绑定数据
        public ObservableCollection<DishBean> DishV
        {
            get
            {
                return _DishV ?? (_DishV = new ObservableCollection<DishBean>());
            }
            set
            {
                Set("DishV", ref _DishV, value);
            }
        }

        ObservableCollection<DishDaoBean> _DishDaoV;
        //道菜窗口绑定数据
        public ObservableCollection<DishDaoBean> DishDaoV
        {
            get
            {
                return _DishDaoV ?? (_DishDaoV = new ObservableCollection<DishDaoBean>());
            }
            set
            {
                Set("DishDaoV", ref _DishDaoV, value);
            }
        }

        ObservableCollection<DishDetailBean> _DishDetailV;
        //道菜明细窗口绑定数据
        public ObservableCollection<DishDetailBean> DishDetailV
        {
            get
            {
                return _DishDetailV ?? (_DishDetailV = new ObservableCollection<DishDetailBean>());
            }
            set
            {
                Set("DishDetailV", ref _DishDetailV, value);
            }
        }



        //主窗体初始化
        public DishPackagesViewModel(IChooseDishesDataService dataService)
        {
            _DataService = dataService;
            //查询套菜绑定grid
            DishV = new ObservableCollection<DishBean>();
            DishDaoV = new ObservableCollection<DishDaoBean>();
            DishDetailV = new ObservableCollection<DishDetailBean>();
            Dish dish = new Dish();
            List<Dish> loooo = _DataService.queryByDish(dish);
            bool a = loooo != null;
            if (a)
            {
                foreach (var loca in loooo)
                {
                    DishBean bean = new DishBean();
                    bean=bean.CreateDishBean(loca);
                    bean.InjectBeanPrice();
                    DishV.Add(new DishBean
                    {
                        DishId=bean.DishId,
                        Code = bean.Code,
                        DishName = bean.DishName,
                        DishFormatName = bean.DishFormatName,
                        Price1=bean.Price1
                     });
                }
            }
    }

        //套菜grid选中事件
        DishBean _SelectedDish;
        public DishBean SelectedDish
        {
            get
            {
                return _SelectedDish;
            }
            set
            {
                if (Change()&&ChangeDetail())
                {
                    Set("SelectedDish", ref _SelectedDish, value);
                    //查询套菜绑定grid
                    DishDaoV = new ObservableCollection<DishDaoBean>();
                    DishDao dish = new DishDao();
                    dish.DishId = SelectedDish.DishId;
                    List<DishDao> loooo = _DataService.queryByDishDaoID(dish);
                    bool a = loooo != null;
                    DishDaoXaml = 0;
                    if (a)
                    {
                        Line = 0;
                        foreach (var loca in loooo)
                        {
                            DishDaoBean bean = new DishDaoBean();
                            bean = bean.CreateDishDaoBean(loca);
                            DishDetail detail = _DataService.queryByDishDetail(loca.DishDaoId);
                            if (detail!=null)
                            {
                                Dish d = _DataService.queryByDishId(detail.DishId);
                                DishBean db = new DishBean();
                                db = db.CreateDishBean(d);
                                db.InjectBeanPrice();
                                bean.DefaultName = db.DishName;
                                bean.DefaultPrice = db.Price1;
                            }
                            
                            Line = Line + 1;
                            DishDaoV.Add(new DishDaoBean
                            {
                               
                                LineNumber = Line,
                                Code = SelectedDish.Code,
                                DishDaoId = bean.DishDaoId,
                                Name = bean.Name,
                                OptionalNumber = bean.OptionalNumber,
                                DefaultName = bean.DefaultName,
                                DefaultPrice = bean.DefaultPrice
                            });
                            DishDaoXaml = DishDaoXaml + bean.DefaultPrice;
                        }
                    }
                }
                else {
                    MessageBox.Show("您有数据未保存，请保存后在进行操作！");
                }
            }
 }

        //道菜合计
        double _DishDaoXaml;
        public double DishDaoXaml
        {
            get
            {
                return _DishDaoXaml;
            }
            set
            {
                Set("DishDaoXaml", ref _DishDaoXaml, value);
            }
        }

        //道菜明细合计
        double _DishDishesXaml;
        public double DishDishesXaml
        {
            get
            {
                return _DishDishesXaml;
            }
            set
            {
                Set("DishDishesXaml", ref _DishDishesXaml, value);
            }
        }


        //道菜grid选中事件
        DishDaoBean _SelectedDishDao;
        public DishDaoBean SelectedDishDao
        {
            get
            {
                return _SelectedDishDao;
            }
            set
            {
                if (ChangeDetail())
                {
                   Set("SelectedDishDao", ref _SelectedDishDao, value);
                    //查询道菜绑定grid
                    DishDetailV = new ObservableCollection<DishDetailBean>();
                    if (SelectedDishDao != null) { 
                    DishDetail dish = new DishDetail();
                    dish.DishDaoId = SelectedDishDao._DishDaoId;
                    List<DishDetail> loooo = _DataService.queryByDishDetail(dish);
                    bool a = loooo != null;
                    DishDishesXaml = 0;
                    if (a)
                    {
                        Line = 0;
                        foreach (var detail in loooo)
                        {
                            if (detail.IsMain == 1) {
                               Dish d= _DataService.queryByDishId(detail.DishId);
                               DishBean db = new DishBean();
                               db = db.CreateDishBean(d);
                               db.InjectBeanPrice();
                               SelectedDishDao.DefaultName=db.DishName;
                               SelectedDishDao.DefaultPrice=db.Price1;
                            }

                            DishBean bean = new DishBean();
                            bean = bean.CreateDishBean(detail.Dish);
                            bean.InjectBeanPrice();

                            DishDetailV.Add(new DishDetailBean
                            {
                                LineNumber = SelectedDishDao.LineNumber,
                                Code = detail.Dish.Code,
                                DishName = detail.Dish.DishName,
                                DishFormatName = bean.DishFormatName,
                                DishUnitName = detail.Dish.DishUnit.Name,
                                DishDetailId=detail.DishDetailId,
                                DishDaoId=detail.DishDaoId,
                                Num = detail.Num,
                                DishId = detail.DishId,
                                Price1 = bean.Price1,
                                IsMain = detail.IsMain
                              });

                            DishDishesXaml = DishDishesXaml + bean.Price1 * detail.Num;
                        }
                    }
                }
                }
                else {
                    MessageBox.Show("您有数据未保存，请保存后在进行操作！");
                }
            }
        }

        //道菜明细grid选中事件
        DishDetailBean _SelectedDishDetail;
        public DishDetailBean SelectedDishDetail
        {
            get
            {
                return _SelectedDishDetail;
            }
            set
            {
                Set("SelectedDishDetail", ref _SelectedDishDetail, value);
               
            }
        }
        

        //道菜新增
        RelayCommand _Add;
        public RelayCommand Add
        {
           get
                {
                    return _Add ?? (_Add = new RelayCommand(() =>
                    {
                         if(SelectedDish!=null){
                            Line = Line + 1;
                            DishDaoV.Add(new DishDaoBean { DishId = SelectedDish.DishId, LineNumber = Line, Code = SelectedDish.Code, OptionalNumber = 1 });
                         }
                         else
                         {
                            MessageBox.Show("请选择需要添加道菜的套菜！");
                        }
                    }));
                }
          }

        //监听道菜窗口是否编辑
        bool Change (){
            bool flag=true;
           foreach(var dish in DishDaoV){
               if (dish.Change == true)
               {
              flag=false;
              break;
              }
           }
           return flag;
        }
        //监听道菜窗口是否编辑
        bool ChangeDetail()
        {
            bool flag = true;
            foreach (var dish in DishDetailV)
            {
                if (dish.Change == true)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

         //道菜取消修改
        RelayCommand _CancelChange;
        public RelayCommand CancelChange
        {
            get
            {
                return _CancelChange ?? (_CancelChange = new RelayCommand(() =>
                {
                    DishDetailV.Clear();
                    DishDaoV.Clear();
                    foreach (var d in DishDaoV)
                    {
                        d.Change = false;
                    }
                    foreach (var d in DishDetailV)
                    {
                        d.Change = false;
                    }
                    DishDao dish = new DishDao();
                    dish.DishId = SelectedDish.DishId;
                    List<DishDao> loooo = _DataService.queryByDishDaoID(dish);
                    bool a = loooo != null;
                    if (a)
                    {
                        Line = 0;
                        foreach (var loca in loooo)
                        {
                            DishDaoBean bean = new DishDaoBean();
                            bean = bean.CreateDishDaoBean(loca);
                            Line = Line + 1;
                            DishDaoV.Add(new DishDaoBean
                            {
                               
                                LineNumber = Line,
                                Code = SelectedDish.Code,
                                DishId=bean.DishId,
                                DishDaoId = bean.DishDaoId,
                                Name = bean.Name,
                                OptionalNumber = bean.OptionalNumber
                             });
                        }
                    }
                }));
            }
        }
        
        //道菜删除
        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    if (SelectedDishDao != null)
                    {
                        if (SelectedDishDao.DishDaoId > 0)
                        {
                            SelectedDishDao.UpdateBy = SubjectUtils.GetAuthenticationId();
                            SelectedDishDao.UpdateDatetime=DateTime.Now;
                            SelectedDishDao.Deleted=1;
                            int i=_DataService.delDishDao(SelectedDishDao.CreateDishDao(SelectedDishDao));
                            if (i > 0)
                            {
                                //删除道菜明细
                                _DataService.delDishDetail(SelectedDishDao.DishDaoId, 1);
                                DishDetailV.Clear();
                             }
                            else
                            {
                                MessageBox.Show("删除道菜失败，请联系管理员！");
                                return;
                            }
                            DishDaoV.RemoveAt(DishDaoV.IndexOf(SelectedDishDao));
                        }
                     }
                    else {
                        MessageBox.Show("请选择需要删除的道菜！");
                    }
                }));
            }
        }
       
        //道菜明细删除
        RelayCommand _RemoveDetail;
        public RelayCommand RemoveDetail
        {
            get
            {
                return _RemoveDetail ?? (_RemoveDetail = new RelayCommand(() =>
                {
                    if (SelectedDishDetail != null)
                    {
                        if (SelectedDishDetail.DishDetailId > 0)
                        {
                            int i = _DataService.delDishDetail(SelectedDishDetail.DishDetailId,0);
                             if (i > 0)
                                {
                                    DishDetailV.RemoveAt(DishDetailV.IndexOf(SelectedDishDetail));
                                }
                                else
                                {
                                    MessageBox.Show("删除失败，请联系管理员!");
                                }
                        }
                        else { 
                                 DishDetailV.RemoveAt(DishDetailV.IndexOf(SelectedDishDetail));
                        }
                     }
                    else {
                        MessageBox.Show("请选择需要删除的道菜！");
                    }
                }));
            }
        }

        


        //选择道菜明细页面
        DishDetailView dw { get; set; }

        //打开新增道菜明细窗口
        RelayCommand _AddDetail;
        public RelayCommand AddDetail
        {
            get
            {
                return _AddDetail ?? (_AddDetail = new RelayCommand(() =>
                {
                    if (SelectedDishDao != null)
                    {
                        
                        //加载菜品大类
                        _DishTypeBig = _DataService.FindDishTypeByType(0);
                        //加载菜品小类
                        _DishTypeSmail = new ObservableCollection<DishType>();
                        List<DishType> listsmail = _DataService.FindDishTypeByType(-1);
                        _DishTypeSmail.Clear();
                        foreach (var element in listsmail)
                        {
                            _DishTypeSmail.Add(element);
                        }
                        //加载菜品
                        List<Dish> list = _DataService.FindDishPackages(0);
                        _DishesMenusSelected.Clear();

                        foreach (var element in list)
                        {
                            DishBean dishBean = new DishBean();
                            dishBean = dishBean.CreateDishBean(element);
                            dishBean.InjectBeanPrice();
                           //注入大类,小类
                            for (int i = 0; i < _DishTypeSmail.Count; i++)
                            {
                                if (element.DishTypeId == _DishTypeSmail[i].DishTypeId)
                                {
                                    dishBean.DishTypeName = _DishTypeSmail[i].Name;
                                    bool flag = false;
                                    for (int j = 0; j < _DishTypeBig.Count; j++)
                                    {
                                        if (_DishTypeSmail[i].ParentId == _DishTypeBig[j].DishTypeId)
                                        {
                                            dishBean.DishTypeBigName = _DishTypeBig[j].Name;
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (flag) break;
                                }
                            }

                            DishesMenusSelected.Add(dishBean);
                        }


                        dw = new DishDetailView();
                        dw.ShowDialog();
                    }
                     else
                     {
                         MessageBox.Show("请选择一个道菜!");
                     }
                }));
            }
        }


        //模糊搜索
        string _MoFuSouSuo;
        public string MoFuSouSuo
        {

            get
            {
                return _MoFuSouSuo;
            }
            set
            {
                Set("MoFuSouSuo", ref _MoFuSouSuo, value);
            }
        }

        //条件重置  ResetSelectValue
        RelayCommand _ResetSelectValue;
        public RelayCommand ResetSelectValue
        {
            get
            {
                return _ResetSelectValue ?? (_ResetSelectValue = new RelayCommand(() =>
                {
                    MoFuSouSuo = null;
                    dw.DishTypeBigComBoBox.SelectedItem = null;
                    dw.DishTypeSmailComBoBox.SelectedItem = null;
                    //加载菜品大类
                    _DishTypeBig = _DataService.FindDishTypeByType(0);
                    //加载菜品小类
                    _DishTypeSmail = new ObservableCollection<DishType>();
                    List<DishType> listsmail = _DataService.FindDishTypeByType(-1);
                    _DishTypeSmail.Clear();
                    foreach (var element in listsmail)
                    {
                        _DishTypeSmail.Add(element);
                    }
                }));

            }
        }

        //运用  进行模糊搜索  YunYongSelectValue
        RelayCommand _YunYongSelectValue;
        public RelayCommand YunYongSelectValue
        {
            get
            {
                return _YunYongSelectValue ?? (_YunYongSelectValue = new RelayCommand(() =>
                {
                    //搜索更新菜品
                    List<Dish> list = _DataService.FindDishsByDishName(_MoFuSouSuo);
                    _DishesMenusSelected.Clear();

                    foreach (var element in list)
                    {
                        DishBean dishBean = new DishBean();
                        dishBean = dishBean.CreateDishBean(element);
                        dishBean.InjectBeanPrice();
                        DishesMenusSelected.Add(dishBean);
                    }

                }));

            }
        }

        //选中事件
        public void DisChecked() {
            foreach (var t in DishDetailV) {
                if (t != SelectedDishDetail) {
                    t.IsMain = 0;
                }
            }
            if (SelectedDishDetail.IsMain == 1)
            {
                SelectedDishDao.DefaultPrice = SelectedDishDetail.Price1;
                SelectedDishDao.DefaultName = SelectedDishDetail.DishName;
            }
            else {
                SelectedDishDao.DefaultPrice = 0;
                SelectedDishDao.DefaultName = "";
            }
        }


        //道菜明细保存
        RelayCommand _OkSelect;
        public RelayCommand OkSelect
        {
            get
            {
                return _OkSelect ?? (_OkSelect = new RelayCommand(() =>
                {
                   
                    foreach(var detail in DishesMenusSelected){
                        bool flag = false;
                        if (detail.IsSelectedMenus) {
                            foreach (var dishDao in DishDetailV) {
                                if (dishDao.DishId == detail.DishId)
                                {
                                    flag = true;

                                }
                            }
                            if (!flag) { 
                                DishDetailV.Add(new DishDetailBean
                                {
                                    LineNumber = SelectedDishDao.LineNumber,
                                    Code = detail.Code,
                                    DishName = detail.DishName,
                                    DishFormatName = detail.DishFormat,
                                    DishUnitName = ""+detail.DishUnitId,
                                    Num = 1,
                                    DishDaoId=SelectedDishDao.DishDaoId,
                                    Price1 = detail.Price1,
                                    DishId = detail.DishId,
                                    IsMain = 0,
                                    Type=1

                                });
                            }
                        }
                    }
                    dw.Close();

                }));

            }
        }


        //保存
        RelayCommand _Save;
        public RelayCommand Save
        {
            get
            {
                return _Save ?? (_Save = new RelayCommand(() =>
                {
                    //数据验证
                    bool flag = true;
                     foreach (var d in DishDaoV)
                    {
                        if (d.Name==null||d.Name.Trim().Length==0) {
                            flag = false;
                        }
                    }

                     foreach (var d in DishDetailV)
                     {
                         if (d.LineNumber == 0 || d.Code==null)
                         {
                             flag = false;
                         }
                     }

                     if (flag)
                     {
                         //道菜入库
                         foreach (var d in DishDaoV)
                         {
                             DishDao dish = d.CreateDishDao(d);
                             dish.UpdateBy = SubjectUtils.GetAuthenticationId(); ;
                             dish.CreateBy = SubjectUtils.GetAuthenticationId(); ;
                             dish.UpdateDatetime = DateTime.Now;
                             dish.CreateDatetime = DateTime.Now;
                             _DataService.EditByDishDao(dish);
                             d.Change = false;

                         }
                         //道菜明细入库
                         foreach (var d in DishDetailV)
                         {
                             DishDetail dish = d.CreateDishDetail(d);
                             dish.UpdateBy = SubjectUtils.GetAuthenticationId(); ;
                             dish.CreateBy = SubjectUtils.GetAuthenticationId(); ;
                             dish.UpdateDatetime = DateTime.Now;
                             dish.CreateDatetime = DateTime.Now;
                             _DataService.EditByDishDetail(dish);
                             d.Change = false;
                         }
                     }
                     else {
                         MessageBox.Show("请输入完整信息！");
                     }
                    
                   
                }));

            }
        }



        //点击菜品大类 SelectedItemBig
        DishType _SelectedItemBig;
        public DishType SelectedItemBig
        {
            get
            {
                return _SelectedItemBig;
            }
            set
            {
                if (value == null)
                {
                    LoadDishObject();
                    return;
                }

                List<DishType> listsmail = _DataService.FindDishTypeByType(value.DishTypeId);
                DishTypeSmail.Clear();
                foreach (var element in listsmail)
                {
                    DishTypeSmail.Add(element);
                }
                //更新菜品
                List<Dish> list = _DataService.FindDishPackages(value.DishTypeId);
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishBean dishBean = new DishBean();
                    dishBean = dishBean.CreateDishBean(element);
                    dishBean.InjectBeanPrice();
                    DishesMenusSelected.Add(dishBean);
                }

                Set("SelectedItemBig", ref _SelectedItemBig, value);
            }
        }
        //点击菜品小类 SelectedItemSmail
        DishType _SelectedItemSmail;
        public DishType SelectedItemSmail
        {
            get
            {
                return _SelectedItemSmail;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                //更新菜品
                List<Dish> list = _DataService.FindDishPackages(value.DishTypeId);
               
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishBean bean = new DishBean();
                    bean = bean.CreateDishBean(element);
                    bean.InjectBeanPrice();
                    DishesMenusSelected.Add(bean);
                }

                Set("SelectedItemSmail", ref _SelectedItemSmail, value);
            }
        }

        //加载所有的 菜品 大类 小类 
        public void LoadDishObject()
        {
            //加载所有小类
            _DishTypeSmail = new ObservableCollection<DishType>();
            List<DishType> listsmail = _DataService.FindDishTypeByType(-1);
            _DishTypeSmail.Clear();
            foreach (var element in listsmail)
            {
                _DishTypeSmail.Add(element);
            }

            //加载所有的菜品
            List<Dish> list = _DataService.FindDishPackages(0);
            _DishesMenusSelected.Clear();

            foreach (var element in list)
            {
                DishBean dishBean = new DishBean();
                dishBean = dishBean.CreateDishBean(element);
                dishBean.InjectBeanPrice();
                //注入大类,小类
                for (int i = 0; i < _DishTypeSmail.Count; i++)
                {
                    if (element.DishTypeId == _DishTypeSmail[i].DishTypeId)
                    {
                        dishBean.DishTypeName = _DishTypeSmail[i].Name;
                        bool flag = false;
                        for (int j = 0; j < _DishTypeBig.Count; j++)
                        {
                            if (_DishTypeSmail[i].ParentId == _DishTypeBig[j].DishTypeId)
                            {
                                dishBean.DishTypeBigName = _DishTypeBig[j].Name;
                                flag = true;
                                break;
                            }
                        }
                        if (flag) break;
                    }
                }
                DishesMenusSelected.Add(dishBean);
            }


        }

        //菜品大类
        List<DishType> _DishTypeBig;
        public List<DishType> DishTypeBig
        {
            get
            {
                return _DishTypeBig;
            }
            set
            {
                Set("DishTypeBig", ref _DishTypeBig, value);
            }
        }
        //菜品小类
        ObservableCollection<DishType> _DishTypeSmail;
        public ObservableCollection<DishType> DishTypeSmail
        {
            get
            {
                return _DishTypeSmail;
            }
            set
            {
                Set("DishTypeSmail", ref _DishTypeSmail, value);
            }
        }

        //选择菜品
        ObservableCollection<DishBean> _DishesMenusSelected = new ObservableCollection<DishBean>();
        public ObservableCollection<DishBean> DishesMenusSelected
        {
            get
            {
                return _DishesMenusSelected;
            }
            set
            {
                Set("DishesMenusSelected", ref _DishesMenusSelected, value);
            }
        }



        


    }
                
}
