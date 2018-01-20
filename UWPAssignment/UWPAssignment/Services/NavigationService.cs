using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPAssignment.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPAssignment.Services
{
    public class NavigationService
    {
        private static Frame frame = Window.Current.Content as Frame;

        public static void NavigateToDescriptionPage()
        {
            frame.Navigate(typeof(DescriptionPage));
        }

        public static void NavigateToMainPage()
        {
            frame.Navigate(typeof(MainPage));
        }
    }
}
