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

namespace IShow.ChooseDishes.ViewModel.Dishes
{
    public class DishesUnitViewModel:ViewModelBase
    {

        IDishService _DishService=new DishService();
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
                   
                    List<DishUnit> PerDishUnits= new List<DishUnit>();
                    foreach(var du in DishesUnits){
                        if (du.DishUnitId==null) { 
                            PerDishUnits.Add(du.To());
                        }
                    }
                    //保存
                    int[] resultArray=_DishService.BatchAddDishesUnit(PerDishUnits.ToArray());
                    IsNotEditModel = true;
                }));
            }
        }
        public RelayCommand NewCommand {
            get {
                return _NewCommand ?? (_NewCommand = new RelayCommand(() =>
                {
                    _IsNotEditModel = false;

                }));
            }
        }

        public RelayCommand ModifiedCommand
        {
            get
            {
                return _ModifiedCommand ?? (_ModifiedCommand = new RelayCommand(() =>
                {


                }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(() =>
                {
                    if (SelectedDishesUnit == null) {
                        MessageBox.Show("请先选择需要删除的单位!");
                        return;
                    }
                   bool result= _DishService.RemoveDishesUnitById(SelectedDishesUnit.DishUnitId);
                   if (result) {
                       DishesUnits.Remove(SelectedDishesUnit);
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


        public DishesUnitViewModel() {

            this.Init();
        }


        public void Init() {
           // List<DishUnit> dishUnits = _DishService.QueryAllDishesUnits();
            //
            List<DishUnit> dishUnits = new List<DishUnit>();
            dishUnits.Add(new DishUnit() { DishUnitId=100,Name="盘",SaleType=2,OrderNum=1});
            dishUnits.Add(new DishUnit() { DishUnitId = 100, Name = "盘", SaleType = 1, OrderNum = 1 });
            dishUnits.Add(new DishUnit() { DishUnitId = 100, Name = "盘", SaleType =1, OrderNum = 1 });
            foreach(var unit in dishUnits){
                DishesUnits.Add(new DishesUnitModel(unit.DishUnitId,unit.Name,unit.SaleType,unit.OrderNum,unit.CreateDatetime,unit.CreateBy,unit.Status,unit.UpdateDatetime,unit.UpdateBy));
            }
        
        }
    }


}
