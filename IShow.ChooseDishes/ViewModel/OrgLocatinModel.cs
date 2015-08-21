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
   
    public class OrgLocatinModel : ViewModelBase
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
                    _Locationxaml = new LocationBean();
                    aw = new addLocation();
                    aw.ShowDialog();

                }));
            }
        }

        //子窗口绑定对象
        LocationBean _Locationxaml;
        public LocationBean Locationxaml
        {
            get
            {
                return _Locationxaml;
            }
            set
            {
                Set("Locationxaml", ref _Locationxaml, value);
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
                    Location location = new Location();
                    location.Name = _Locationxaml.Name;
                    location.Code = _Locationxaml.Code;
                    location.Deleted = 0;
                    location.CreateBy = 1;
                    location.CreateDatetime = DateTime.Now;
                    int flag=_DataService.addLocation(location);
                    if (flag > 0) {
                        Locations.Add(location);
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
        addLocation aw { get; set; }

        //修改子窗口对象
        editLocation ew { get; set; }

        //打开修改窗口
        RelayCommand _Edit;
        public RelayCommand Edit
        {
            get
            {
                return _Edit ?? (_Edit = new RelayCommand(() =>
                {
                    if (SelectedLocations != null)
                    {
                        _Locationxaml = new LocationBean();
                        _Locationxaml.Code = SelectedLocations.Code;
                        _Locationxaml.Name = SelectedLocations.Name;
                        _Locationxaml.LocationId = SelectedLocations.LocationId;
                        ew = new editLocation();
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
                    Location location = new Location();
                    location.Name = _Locationxaml.Name;
                    location.Code = _Locationxaml.Code;
                    location.LocationId = _Locationxaml.LocationId;
                    location.UpdateBy = 1;
                    location.UpdateDatetime = DateTime.Now;
                    int flag = _DataService.editByLocation(location);
                    if (flag > 0)
                    {
                        Locations.Clear();
                        List<Location> loooo = _DataService.queryByLocation();
                        foreach (var loca in loooo)
                        {
                            Locations.Add(new Location { LocationId = loca.LocationId, Name = loca.Name, Code = loca.Code });
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
                    if (SelectedLocations != null)
                    {
                        Location location = new Location();
                        location.LocationId = SelectedLocations.LocationId;
                        location.UpdateBy = 8;
                        location.Deleted = 1;
                        location.UpdateDatetime = DateTime.Now;

                        int b = _DataService.delByLocation(location);
                        if (b.Equals(1))
                        {
                            Locations.Remove(SelectedLocations);
                        }
                    }
                    else {
                        MessageBox.Show("请选中一条数据!");
                    }
                }));
            }
        }

        //主窗口选中绑定方法
        Location _SelectedLocations;
        public Location SelectedLocations
        {
            get
            {
                return _SelectedLocations;
            }
            set
            {
                Set("SelectedLocations", ref _SelectedLocations, value);
            }
        }

        #endregion Observable

        #region Command
      
        //主窗口绑定数据
        public ObservableCollection<Location> Locations { get; set; }
       
        //初始化窗口
        public OrgLocatinModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
          
            Locations = new ObservableCollection<Location>();
            List<Location> loooo= _DataService.queryByLocation();
           
           bool a = loooo != null;
           if (a) { 
                foreach (var loca in loooo)
                {
                    Locations.Add(new Location { LocationId = loca.LocationId, Name = loca.Name, Code = loca.Code });
                }
           }
        }
        #endregion Command
    }
}
