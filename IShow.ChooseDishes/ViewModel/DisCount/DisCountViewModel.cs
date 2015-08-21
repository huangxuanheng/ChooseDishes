using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Model.Discount;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.Discount;
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


namespace IShow.ChooseDishes.ViewModel.DisCount
{

    public class DisCountViewModel : ViewModelBase
    {
        IDiscountDataService _DataService;
        int Line = 0;
        int LineDetail = 0;
        int LineAdd = 0;
        ObservableCollection<DiscountProgramBean> _ProgramV;
        //折扣方案绑定数据
        public ObservableCollection<DiscountProgramBean> ProgramV
        {
            get
            {
                return _ProgramV ?? (_ProgramV = new ObservableCollection<DiscountProgramBean>());
            }
            set
            {
                Set("ProgramV", ref _ProgramV, value);
            }
        }

        ObservableCollection<DiscountDetailBean> _DetailV;
        //折扣明细绑定数据
        public ObservableCollection<DiscountDetailBean> DetailV
        {
            get
            {
                return _DetailV ?? (_DetailV = new ObservableCollection<DiscountDetailBean>());
            }
            set
            {
                Set("DetailV", ref _DetailV, value);
            }
        }



        ObservableCollection<DiscountDetailBean> _AddDisCountV;
        //子窗口折扣方案明细绑定数据
        public ObservableCollection<DiscountDetailBean> AddDisCountV
        {
            get
            {
                return _AddDisCountV ?? (_AddDisCountV = new ObservableCollection<DiscountDetailBean>());
            }
            set
            {
                Set("AddDisCountV", ref _AddDisCountV, value);
            }
        }

        //子窗口折扣方案绑定对象
        DiscountProgramBean _Programxaml;
        public DiscountProgramBean Programxaml
        {
            get
            {
                return _Programxaml;
            }
            set
            {
                Set("Programxaml", ref _Programxaml, value);
            }
        }

        

        //主窗体初始化
        public DisCountViewModel(IDiscountDataService dataService)
        {
            _DataService = dataService;
            //查询折扣方案绑定grid
            ProgramV = new ObservableCollection<DiscountProgramBean>();
            DetailV = new ObservableCollection<DiscountDetailBean>();
            
           
            List<DiscountProgram> dis = _DataService.queryAll();
            bool a = dis != null;
            if (a)
            {
                foreach (var d in dis)
                {
                    DiscountProgramBean bean = new DiscountProgramBean();
                    bean = bean.CreateDiscountProgramBean(d);
                    Line = Line + 1;
                    ProgramV.Add(new DiscountProgramBean
                    {
                        LineNumber = Line,
                        DiscountId = bean.DiscountId,
                        Code = bean.Code,
                        Name = bean.Name,
                        ByDish = bean.ByDish,
                        Rate = bean.Rate
                    });
                }
            }
    }
        
        
        //刷新事件
        RelayCommand _Refresh;
        public RelayCommand Refresh
        {
            get
            {
                return _Refresh ?? (_Refresh = new RelayCommand(() =>
                {
                    DetailV.Clear();
                    ProgramV.Clear();
                    SelectedProgram = null;
                    SelectedDetail = null;
                    Line = 0;
                    LineDetail = 0;
                    List<DiscountProgram> dis = _DataService.queryAll();
                    bool a = dis != null;
                    if (a)
                    {
                        foreach (var d in dis)
                        {
                            DiscountProgramBean bean = new DiscountProgramBean();
                            bean = bean.CreateDiscountProgramBean(d);
                            Line = Line + 1;
                            ProgramV.Add(new DiscountProgramBean
                            {
                                LineNumber = Line,
                                DiscountId = bean.DiscountId,
                                Code = bean.Code,
                                Name = bean.Name,
                                ByDish = bean.ByDish,
                                Rate = bean.Rate
                            });
                        }
                    }

                }));
            }
        }
        



        //折扣方案grid选中事件
        DiscountProgramBean _SelectedProgram;
        public DiscountProgramBean SelectedProgram
        {
            get
            {
                return _SelectedProgram;
            }
            set
            {
                Set("SelectedProgram", ref _SelectedProgram, value);
                //查询方案明细
                DetailV = new ObservableCollection<DiscountDetailBean>();
                //是否选中
                if (SelectedProgram != null)
                {
                    //查询当前方案下的折扣方案明细
                    List<DiscountDetail> program = _DataService.queryByDetailId(SelectedProgram.DiscountId);
                    //查询所有小类
                    List<DishType> stype = _DataService.LoadSmallTypeAll();
                    //查询所有大类
                    List<DishType> btype = _DataService.LoadBigTypeAll();
                    LineDetail = 0;

                    foreach (var s in stype)
                    {
                        double DiscountValue = 100;
                        int id = 0;
                        LineDetail = LineDetail + 1;
                        foreach (var b in btype)
                        {
                            if (s.ParentId == b.DishTypeId)
                            {
                                foreach (var p in program)
                                {
                                    DiscountDetailBean bean = new DiscountDetailBean();
                                    bean = bean.CreateDiscountDetailBean(p);
                                    if (s.DishTypeId == bean.DishId)
                                    {
                                        DiscountValue = bean.DiscountValue;
                                        id=bean.Id;
                                    }
                                }
                                DetailV.Add(new DiscountDetailBean
                                         {
                                             LineNumber = LineDetail,
                                             Id=id,
                                             DishId = s.DishTypeId,
                                             DiscountId = SelectedProgram.DiscountId,
                                             DiscountValue = DiscountValue,
                                             BigType = s.Name,
                                             SmallType = b.Name

                                         });
                            }
                        }
                    }
                }
            }
        }

        //折扣明细grid选中事件
        DishDetailBean _SelectedDetail;
        public DishDetailBean SelectedDetail
        {
            get
            {
                return _SelectedDetail;
            }
            set
            {
                Set("SelectedDetail", ref _SelectedDetail, value);
               
            }
        }
        

        
        //方案删除
        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    if (SelectedProgram != null)
                    {
                        //删除方案
                        bool detail = _DataService.DeleteDetail(SelectedProgram.DiscountId);
                        //删除方案明细
                        bool program=_DataService.DeleteProgram(SelectedProgram.DiscountId);
                        if (detail) {
                            DetailV.Clear();
                        }
                        if (program) {
                            ProgramV.RemoveAt(ProgramV.IndexOf(SelectedProgram));
                            SelectedProgram = null;
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("请选择需要删除的折扣方案！");
                    }
                }));
            }
        }
       
      


        //方案新增页面
        AddDiscountView aw { get; set; }

        //方案修改页面
        EditDiscountView ew { get; set; }

        //打开新增方案窗口
        RelayCommand _Add;
        public RelayCommand Add
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    AddDisCountV = new ObservableCollection<DiscountDetailBean>();
                    _Programxaml = new DiscountProgramBean();
                    List<DishType> stype=_DataService.LoadSmallTypeAll();
                    List<DishType> btype = _DataService.LoadBigTypeAll();
                    if (stype != null && btype != null) {
                        foreach (var s in stype) {
                            LineAdd = LineAdd + 1;
                            foreach (var b in btype) {
                                if (s.ParentId == b.DishTypeId) { 
                                  AddDisCountV.Add(new DiscountDetailBean
                                  {
                                    LineNumber = LineAdd,
                                    Code = s.Code,
                                    SmallType = s.Name,
                                    DishId=s.DishTypeId,
                                    BigType = b.Name,
                                    DiscountValue = 100
                                  });
                                }
                            }
                        }
                    }
                    aw = new AddDiscountView();
                    aw.ShowDialog();
                }));
            }
        }

        //新增方案窗口保存
        RelayCommand _AddWin;
        public RelayCommand AddWin
        {
            get
            {
                return _AddWin ?? (_AddWin = new RelayCommand(() =>
                {
                    DiscountProgram pro=_Programxaml.CreateDiscountProgram(_Programxaml);
                    pro.CreateDatetime = DateTime.Now;
                    pro.CreateBy = SubjectUtils.GetAuthenticationId();
                    int i= _DataService.AddProgram(pro);
                    if(i>0){
                      foreach(var d in AddDisCountV){
                       d.CreateDatetime = DateTime.Now;
                       d.CreateBy = SubjectUtils.GetAuthenticationId();
                       d.DiscountId = i;
                       DiscountDetail det=d.CreateDiscountDetail(d);
                       _DataService.AddDetail(det);
                      }
                    }
                    _Programxaml.LineNumber = Line + 1;
                    ProgramV.Add(_Programxaml);
                    aw.Close();
                 }));
            }
        }

        //打开修改方案窗口
        RelayCommand _Edit;
        public RelayCommand Edit
        {
            get
            {
                return _Edit ?? (_Edit = new RelayCommand(() =>
                {
                    if (SelectedProgram == null) {
                        MessageBox.Show("请选中需要修改的折扣方案！");
                        return;
                    }
                        _Programxaml = SelectedProgram;
                        AddDisCountV = DetailV;
                    ew = new EditDiscountView();
                    ew.ShowDialog();
                }));
            }
        }

        //修改方案窗口保存
        RelayCommand _EditWin;
        public RelayCommand EditWin
        {
            get
            {
                return _EditWin ?? (_EditWin = new RelayCommand(() =>
                {
                    DiscountProgram pro = _Programxaml.CreateDiscountProgram(_Programxaml);
                    pro.UpdateDatetime = DateTime.Now;
                    pro.UpdateBy = SubjectUtils.GetAuthenticationId();
                    int i =_DataService.UpdateProgram(pro);
                    if (i > 0)
                    {
                        foreach (var d in AddDisCountV)
                        {
                           
                            d.DiscountId = pro.DiscountId;
                            
                            if (d.Id == 0) {
                                d.CreateDatetime = DateTime.Now;
                                d.CreateBy = SubjectUtils.GetAuthenticationId();
                                DiscountDetail det = d.CreateDiscountDetail(d);
                                _DataService.AddDetail(det);
                         }
                            else {
                                d.UpdateDatetime = DateTime.Now;
                                d.UpdateBy = SubjectUtils.GetAuthenticationId();
                                DiscountDetail det = d.CreateDiscountDetail(d);
                                _DataService.UpdateDetail(det);
                            }
                        }
                    }
                    ew.Close();
                }));
            }
        }


     }
                
}
