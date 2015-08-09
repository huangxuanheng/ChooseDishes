using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Collections.ObjectModel;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.View.Table;
using IShow.ChooseDishes.Api;
using System.Windows.Documents;
using IShow.Service.Data;

namespace IShow.ChooseDishes.ViewModel
{
   
    public class OrgBearingModel  : ViewModelBase
    {
        IChooseDishesDataService _DataService;

        #region Observable
       //添加打开新窗口
        RelayCommand _Add;
        public RelayCommand Add
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    _Bearingxaml = new BearingBean();
                    aw = new AddBearing();
                    aw.ShowDialog();

                }));
            }
        }

        //子窗口绑定对象
        BearingBean _Bearingxaml;
        public BearingBean Bearingxaml
        {
            get
            {
                return _Bearingxaml;
            }
            set
            {
                Set("Bearingxaml", ref _Bearingxaml, value);
            }
        }
        //子窗口新增
        RelayCommand _AddWin;
        public RelayCommand AddWin
        {
            get
            {
                return _AddWin ?? (_AddWin = new RelayCommand(() =>
                {
                    Bearing Bearing = new Bearing();
                    Bearing.Name = _Bearingxaml.Name;
                    Bearing.Code = _Bearingxaml.Code;
                    Bearing.Deleted = 0;
                    Bearing.CreateBy = 1;
                    Bearing.CreateDatetime = DateTime.Now;
                    int flag=_DataService.addBearing(Bearing);
                    if (flag > 0) {
                        Bearings.Add(Bearing);
                        aw.Close();
                    }else if(flag == 0){
                        MessageBox.Show("添加失败，请联系管理员");
                    }else if(flag == -1){
                         MessageBox.Show("添加失败，编码重复");
                    }
                }));
            }
        }

        //新增子窗口对象
        AddBearing aw { get; set; }

        //修改子窗口对象
        EditBearing ew { get; set; }

        //打开修改窗口
        RelayCommand _Edit;
        public RelayCommand Edit
        {
            get
            {
                return _Edit ?? (_Edit = new RelayCommand(() =>
                {
                    if (SelectedBearings != null)
                    {
                        _Bearingxaml = new BearingBean();
                        _Bearingxaml.Code = SelectedBearings.Code;
                        _Bearingxaml.Name = SelectedBearings.Name;
                        _Bearingxaml.BearingId = SelectedBearings.BearingId;
                        ew = new EditBearing();
                        ew.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("请选中一条数据！");
                    }
                }));
            }
        }

        //子窗口修改
        RelayCommand _EditWin;
        public RelayCommand EditWin
        {
            get
            {
                return _EditWin ?? (_EditWin = new RelayCommand(() =>
                {
                    Bearing Bearing = new Bearing();
                    Bearing.Name = _Bearingxaml.Name;
                    Bearing.Code = _Bearingxaml.Code;
                    Bearing.BearingId = _Bearingxaml.BearingId;
                    Bearing.UpdateBy = 1;
                    Bearing.UpdateDatetime = DateTime.Now;
                    int flag = _DataService.editByBearing(Bearing);
                    if (flag > 0)
                    {
                        Bearings.Clear();
                        List<Bearing> loooo = _DataService.queryByBearing();
                        foreach (var loca in loooo)
                        {
                            Bearings.Add(new Bearing { BearingId = loca.BearingId, Name = loca.Name, Code = loca.Code });
                        }
                        ew.Close();
                    }
                    else if (flag == 0)
                    {
                        MessageBox.Show("修改失败，请联系管理员");
                    }
                    else if (flag == -1)
                    {
                        MessageBox.Show("修改失败，编码重复");
                    }
                }));
            }
        }

        //删除数据
        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    if (SelectedBearings != null)
                    {
                        Bearing Bearing = new Bearing();
                        Bearing.BearingId = SelectedBearings.BearingId;
                        Bearing.UpdateBy = 8;
                        Bearing.Deleted = 1;
                        Bearing.UpdateDatetime = DateTime.Now;

                        int b = _DataService.delByBearing(Bearing);
                        if (b.Equals(1))
                        {
                            Bearings.Remove(SelectedBearings);
                        }
                    }
                    else {
                        MessageBox.Show("请选中一条数据!");
                    }
                }));
            }
        }

        //主窗口选中绑定方法
        Bearing _SelectedBearings;
        public Bearing SelectedBearings
        {
            get
            {
                return _SelectedBearings;
            }
            set
            {
                Set("SelectedBearings", ref _SelectedBearings, value);
            }
        }

        #endregion Observable

        #region Command
      
        //主窗口绑定数据
        public ObservableCollection<Bearing> Bearings { get; set; }
       
        //初始化窗口
        public OrgBearingModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;

            Bearings = new ObservableCollection<Bearing>();
            List<Bearing> loooo = _DataService.queryByBearing();
           
           bool a = loooo != null;
           if (a) { 
                foreach (var loca in loooo)
                {
                    Bearings.Add(new Bearing { BearingId = loca.BearingId, Name = loca.Name, Code = loca.Code });
                }
           }
        }
        #endregion Command
    }
}
