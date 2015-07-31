using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace IShow.ChooseDishes.ViewModel
{
    public  class MainViewModel : ViewModelBase
    {

  
        private ICommand _StartPageCommand;
        private ICommand _ServicePageCommand;

        private TabPageViewModel _SelectedPage;

        public TabPageViewModel SelectedPage
        {
            get {
                return _SelectedPage;
            }
            set {
                this._SelectedPage = value;
                Set("SelectedPage", ref _SelectedPage, value);
            }
        
        }

        public MainViewModel() {
            Pages = new ObservableCollection<TabPageViewModel>
            (
               new [] {
                new TabPageViewModel() { Header = "Tab1"},
                new TabPageViewModel() { Header = "Tab2"}
                }
            );

            SelectedPage = Pages.First();

        }

        public ObservableCollection<TabPageViewModel> Pages { get; private set; }

        public ICommand StartPageCommand {
            get
            {
                return _StartPageCommand ?? (_StartPageCommand = new RelayCommand(() =>
                {
                    this.SelectedPage = Pages.First();
                    MessageBox.Show("111111" + this.SelectedPage.Header);
                }));
            }
        }


        public ICommand ServicePageCommand
        {
            get
            {
                return _ServicePageCommand ?? (_ServicePageCommand = new RelayCommand(() =>
                {
                    this.SelectedPage = Pages.Last();
                    //this.SelectedPage = Pages.ElementAt(2);
                    MessageBox.Show("hell2222"+this.SelectedPage.Header);

                }));
            }
        }
        

    }


    public class TabPageViewModel {
        public string Header
        {
            get;
            set;
        }
    }
}
