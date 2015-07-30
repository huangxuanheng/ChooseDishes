using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Collections.ObjectModel;
using IShow.Service.Data;
using IShow.ChooseDishes.View.OrgTable;

namespace IShow.ChooseDishes.ViewModel
{
   
    public class OrgLocatinModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;

        #region Observable
       
        RelayCommand _Add;
        public RelayCommand Add
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    addLocation aw = new addLocation();
                    bool? bresult = aw.ShowDialog();
                    if (bresult != null && bresult == true)
                    {
                       Locations.Add(aw.Location);
                    }

                }));
            }
        }

        RelayCommand _Edit;
        public RelayCommand Edit
        {
            get
            {
                return _Edit ?? (_Edit = new RelayCommand(() =>
                {
                    if (SelectedLocations != null)
                    {
                        editLocation aw = new editLocation(SelectedLocations);
                        bool? bresult = aw.ShowDialog();
                        if (bresult != null && bresult == true)
                        {
                            //SelectedPersons = aw.CurPerson;
                        }
                    }
                }));
            }
        }

        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    
                    bool b=_DataService.delByLocation(SelectedLocations.LocationId.ToString());
                    if (b.Equals(1))
                    {
                        Locations.Remove(SelectedLocations);
                    }
                }));
            }
        }


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
      
        public ObservableCollection<Location> Locations { get; set; }
       
        
        public OrgLocatinModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
          
            Locations = new ObservableCollection<Location>();
          // Location[] loooo=_DataService.queryByLocation();

           //bool a = loooo == null;
            
          //  foreach (var loca in loooo)
            //{
             // Locations.Add(new Location { LocationId = loooo, Name = "二楼", Code = "el" });
    //            Locations.Add(new Location { LocationId = loca.LocationId, Name = loca.Name, Code = loca.Code });
           // }
            Locations.Add(new Location { LocationId = 2, Name = "", Code = "yl" });
           // Locations.Add(new Location { LocationId = 3, Name = "包间", Code = "bg" });
        }
        #endregion Command
    }
}
