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
        MenuData data = new MenuData();
        private string _name;

        public DescriptionViewModel()
        {
            MessengerInstance.Register<NotificationMessage>(this, NotifyMe);
        }

        private void NotifyMe(NotificationMessage obj)
        {
            _name = obj.Notification;
            var item = data.GetMenu();
            MenuClick = item.Where(x => x.Name == _name).FirstOrDefault();
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

        public RelayCommand BackButtonCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            NavigationService.NavigateToMainPage();
        }
    }
}
