using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Model.EnumSet;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.View.Dishes;
using IShow.ChooseDishes.Security;

namespace IShow.ChooseDishes.ViewModel.Dishes
{
    public class DishesUnitViewModel:ViewModelBase
    {

        IDishService _DishService;
        #region command 
        RelayCommand _NewCommand;
        RelayCommand _ModifiedCommand;
        RelayCommand _DeleteCommand;
        RelayCommand _PersistenceCommand;
        RelayCommand _ExitCommand;

        bool _IsNotEditModel;

        DishesUnitModel _SelectedDishesUnit;



        Dictionary<SaleType,string> _SaleTypes;

        public Dictionary<SaleType, string> SaleTypes
        {
            get
            {
                return _SaleTypes ?? (_SaleTypes = new Dictionary<SaleType, string>() { 
                    {SaleType.ONE,"整数"},
                     {SaleType.TWO,"小数"},
                });
            }
        }


        public DishesUnitModel SelectedDishesUnit {
            get {
                return _SelectedDishesUnit;
            }set{
                Set("SelectedDishedUnit", ref _SelectedDishesUnit, value);
        }
        }

        public bool IsNotEditModel {
            get { return _IsNotEditModel; }
            set {
                Set("IsNotEditModel", ref _IsNotEditModel, value);
            }
        }
        public RelayCommand PersistenceCommand
        {
            get
            {
                return _PersistenceCommand ?? (_PersistenceCommand = new RelayCommand(() =>
                {

                    if (SaveAndUpdate == 2) { //修改数据
                        UpdateDishesUnit();
                        return;
                    
                    }
                    DishUnit du = DishesUnitModelNew.CreateDishUnit(DishesUnitModelNew);
                    du.CreateBy = SubjectUtils.GetAuthenticationId();
                    du.CreateDatetime = DateTime.Now;
                    //保存
                    bool flag  = _DishService.BatchAddDishesUnit(new DishUnit[] { du });
                    if (flag)
                    {
                        Init();
                        _AddDishUnitWin.Close();
                        MessageBox.Show("保存成功!");
                    }
                    else {
                        MessageBox.Show("保存失败!");
                    }
                }));
            }
        }
        //修改数据
        public void UpdateDishesUnit() {
            DishUnit du = DishesUnitModelNew.CreateDishUnit(DishesUnitModelNew);
            bool flag = _DishService.UpdateDishUnit(du.DishUnitId,du.Name,du.SaleType,du.OrderNum);
            if (flag)
            {
                Init();
                _AddDishUnitWin.Close();
                MessageBox.Show("修改成功!");
            }
            else
            {
                MessageBox.Show("修改失败!");
            }
        }
        //DishesUnitModel
        DishesUnitModel _DishesUnitModelNew;
        public DishesUnitModel DishesUnitModelNew
        {
            get { return _DishesUnitModelNew; }
            set
            {
                Set("DishesUnitModelNew", ref _DishesUnitModelNew, value);
            }
        }
        //SelectedDishUnit
        DishesUnitModel _SelectedDishUnit;
        public DishesUnitModel SelectedDishUnit
        {
            get { return _SelectedDishUnit; }
            set
            {
                Set("SelectedDishUnit", ref _SelectedDishUnit, value);
            }
        }
        //RadioButtonBut 点击按钮
        RelayCommand _RadioButtonBut;
        public RelayCommand RadioButtonBut
        {
            get
            {
                return _RadioButtonBut ?? (_RadioButtonBut = new RelayCommand(() =>
                {
                    if (_AddDishUnitWin.ChickZhengShu.IsChecked ?? false)
                    {
                        DishesUnitModelNew.SaleType = 1;

                    }
                    else {
                        DishesUnitModelNew.SaleType = 2;
                    }

                }));
            }
        }
        //注入售量选择
        public void ZhuRuSaleTypeCss() {
            if (DishesUnitModelNew.SaleType == 1)
            {
                _AddDishUnitWin.ChickZhengShu.IsChecked = true;
            }
            else if (DishesUnitModelNew.SaleType == 2)
            {
                _AddDishUnitWin.ChickXiaoShu.IsChecked = true;
            }
        
        }
        //记录是新增 还是修改
        int SaveAndUpdate;//当为1 为新增 当为二 修改
        AddDishUnitWin _AddDishUnitWin;
        public RelayCommand NewCommand {
            get {
                return _NewCommand ?? (_NewCommand = new RelayCommand(() =>
                {
                    SaveAndUpdate = 1;
                    DishesUnitModelNew = new DishesUnitModel();
                    DishesUnitModelNew.SaleType = 1;
                    DishesUnitModelNew.OrderNum = 1;
                    _AddDishUnitWin = new AddDishUnitWin();
                    ZhuRuSaleTypeCss();
                    _AddDishUnitWin.ShowDialog();

                }));
            }
        }

        public RelayCommand ModifiedCommand
        {
            get
            {
                return _ModifiedCommand ?? (_ModifiedCommand = new RelayCommand(() =>
                {
                    if (SelectedDishUnit == null)
                    {
                        MessageBox.Show("请选择要修改的数据!");
                        return;
                    }
                    SaveAndUpdate = 2;
                    DishesUnitModelNew = SelectedDishUnit;
                    _AddDishUnitWin =  new AddDishUnitWin();
                    ZhuRuSaleTypeCss();
                    _AddDishUnitWin.ShowDialog();
                }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(() =>
                {
                    if (SelectedDishUnit == null)
                    {
                        MessageBox.Show("请先选择需要删除的单位!");
                        return;
                    }
                    bool result = _DishService.RemoveDishesUnitById(SelectedDishUnit.DishUnitId);
                   if (result) {
                       DishesUnits.Remove(SelectedDishUnit);
                       if (DishesUnits.Count > 0)
                       {
                           SelectedDishUnit = DishesUnits[DishesUnits.Count - 1];
                       }
                   }
                }));
            }
        }

        public RelayCommand ExitCommand
        {
            get
            {
                return _ExitCommand ?? (_ExitCommand = new RelayCommand(() =>
                {


                }));
            }
        }


        #endregion command

        #region binding
        ObservableCollection<DishesUnitModel> _DishesUnits;

        public ObservableCollection<DishesUnitModel> DishesUnits {
            get {
                return _DishesUnits ?? (_DishesUnits = new ObservableCollection<DishesUnitModel>());
            }
            set {
                Set("DishesUnits", ref _DishesUnits, value);
            }
        }

        #endregion binding


        public DishesUnitViewModel(IDishService _IDishService, IMessenger messenger)
            : base(messenger)
        {
            this._DishService = _IDishService;

            this.Init();
        }


        public void Init() {
           // List<DishUnit> dishUnits = _DishService.QueryAllDishesUnits();
            //
            List<DishUnit> dishUnits = _DishService.QueryAllDishesUnits();
            DishesUnits.Clear();
            foreach(var unit in dishUnits){
                DishesUnits.Add(new DishesUnitModel().CreateDishUnitBean(unit));
            }
        
        }
    }


}
