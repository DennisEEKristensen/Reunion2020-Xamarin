using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;

using Reunion2020.Models;
using Reunion2020.Views;
using System.Collections.Generic;

namespace Reunion2020.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Events { get; set; }
        public Command LoadItemsCommand { get; set; }

        private const string Uri = "https://genforeningen-api.azurewebsites.net/events";

        private HttpClient _client = new HttpClient();
        public ItemsViewModel()
        {
            Title = "Events";
            Events = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {

            try
            {
                var response = await _client.GetAsync(Uri);
                Debug.WriteLine(_client.GetAsync(Uri).Result);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Item> items = JsonConvert.DeserializeObject<List<Item>>(content);
                    Events = new ObservableCollection<Item>(items);
                    foreach (var item in Events)
                    {
                        Console.WriteLine(item.Title);
                    }
                }


               
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Events.Clear();
            }
            

        }
    }
}