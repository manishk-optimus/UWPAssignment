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
        public static void NavigateToDescriptionPage()
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(DescriptionPage));
        }

        public static void NavigateToMainPage()
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(MainPage));
        }
    }
}
