using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPAssignment.Data;
using UWPAssignment.Models;
using UWPAssignment.Services;

namespace UWPAssignment.ViewModels
{
    public class MenuViewModel:ViewModelBase
    {
        private MenuData menu = new MenuData();
        private string searchValue = "none";
        private MenuModel searchedItem = null;
        private bool notAvailable = false;

        private string message = "not available";
        ObservableCollection<MenuModel> item = null;


        //ViewModelBase.MessengerInsta

        public ObservableCollection<MenuModel> MenuItem
        {
            get
            {
                item = menu.GetMenu();
                return item;
            }

        }

        public string Message
        {
            get
            {
                return message;
            }
        }

        public string SearchValue
        {
            get
            {
                return searchValue;
            }
            set
            {
                if (searchValue != value)
                {
                    searchValue = value;
                    RaisePropertyChanged(SearchValue);
                }
            }
        }

        public bool NotAvailable
        {
            get
            {
                return notAvailable;
            }
            set
            {
                if (notAvailable != value)
                {
                    notAvailable = value;
                    RaisePropertyChanged("NotAvailable");
                }
            }
        }

        public RelayCommand OkButtonClicked
        {
            get
            {
                return new RelayCommand(FindResult);
            }
        }

        public void FindResult()
        {
            searchedItem = item.Where(x => x.Name == SearchValue).FirstOrDefault();

            if (searchedItem == null)
            {
                NotAvailable = true;
            }
            else
            {
                //Messenger.Default.Send(searchedItem);

                //MenuSearched = searchedItem;
                NotAvailable = false;
                NavigationService.NavigateToDescriptionPage();
                MessengerInstance.Send(new NotificationMessage(SearchValue));
            }
        }



        private RelayCommand<string> _name;

        public RelayCommand<string> ImageClickCommand
        {
            get
            {
                if (_name == null)
                    _name = new RelayCommand<string>(i => ItemSearch(i));
                return _name;
            }
        }

        private void ItemSearch(string i)
        {
            NavigationService.NavigateToDescriptionPage();
            MessengerInstance.Send(new NotificationMessage(i));
        }
    }
}
