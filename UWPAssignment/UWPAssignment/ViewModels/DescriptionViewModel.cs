using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPAssignment.Data;
using UWPAssignment.Models;
using UWPAssignment.Services;

namespace UWPAssignment.ViewModels
{
    public class DescriptionViewModel:ViewModelBase
    {
        private MenuModel _searchedItem;
        private MenuData _data = new MenuData();
        private string _name;
        private RelayCommand _backButtonCommand { get; set;}

        public DescriptionViewModel()
        {
            MessengerInstance.Register<NotificationMessage>(this, GetMenuClicked);
            _backButtonCommand = new RelayCommand(NavigateToMainPage);
        }

        private void GetMenuClicked(NotificationMessage _menuName)
        {
            _name = _menuName.Notification;
            var item = _data.GetMenu();
            MenuClick = item.FirstOrDefault(x => x.Name == _name);
        }

        public MenuModel MenuClick
        {
            get
            {
                return _searchedItem;
            }
            set
            {
                if (_searchedItem != value)
                {
                    _searchedItem = value;
                    RaisePropertyChanged("MenuClick");
                }
            }
        }

     //   private RelayCommand _relayCommand;

        public RelayCommand BackButtonCommand
        {
            get
            {
                return _backButtonCommand;
            }
        }

        private void NavigateToMainPage()
        {
            NavigationService.NavigateToMainPage();
        }
    }
}
