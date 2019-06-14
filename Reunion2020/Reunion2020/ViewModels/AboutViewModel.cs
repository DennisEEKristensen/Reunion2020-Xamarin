using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Reunion2020.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            PageTitle = "Contacts";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.facebook.com/genforeningen2020/?__tn__=%2Cd%2CP-R&eid=ARA2DTG-LQn76UPRJM0LYaZS9kdLxcHrt9TGV6XW_itH2FcpALA19j5j9yaZOzdsdh17y4gMrjV9Gox_")));
        }

        public ICommand OpenWebCommand { get; }
    }
}