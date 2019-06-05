using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Reunion2020.Models;
using Reunion2020.Views;
using Reunion2020.ViewModels;

namespace Reunion2020.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Event;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.EventsList.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
                
        }

        public void OnNext(object sender, EventArgs e)
        {
            viewModel.LoadNextItemsCommand.Execute(null);
        }

        public void OnPrev(object sender, EventArgs e)
        {
            viewModel.LoadPrevItemsCommand.Execute(null);
        }

        
    }
}