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
        public ObservableCollection<Event> EventsList { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command LoadNextItemsCommand { get; set; }
        public Command LoadPrevItemsCommand { get; set; }

        public int position;
        public int pageNo;


        public string Uri = "https://genforeningen-api.azurewebsites.net/events?position=";

        private HttpClient _client = new HttpClient();
        public ItemsViewModel()
        { 
            PageTitle = "Events";
            EventsList = new ObservableCollection<Event>();
            pageNo = 1;
            position = 0;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadNextItemsCommand = new Command(async () => await ExecuteLoadNextItemsCommand());
            LoadPrevItemsCommand = new Command(async () => await ExecuteLoadPrevItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {

            EventsList.Clear();

            try
            {
                var response = await _client.GetAsync(Uri);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<Event> items = JsonConvert.DeserializeObject<List<Event>>(content);

                    foreach (var item in items)
                    {
                        EventsList.Add(item);
                        Console.WriteLine(item.Title);  
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        async Task ExecuteLoadNextItemsCommand()
        {
            position = position + 3;
            pageNo++;
            EventsList.Clear();

            try
            {
                var response = await _client.GetAsync(Uri + position);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<Event> items = JsonConvert.DeserializeObject<List<Event>>(content);

                    foreach (var item in items)
                    {
                        EventsList.Add(item);
                        Console.WriteLine(item.Title);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        async Task ExecuteLoadPrevItemsCommand()
        {

            position = position - 3;
            pageNo--;
            EventsList.Clear();

            try
            {
                var response = await _client.GetAsync(Uri + position);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<Event> items = JsonConvert.DeserializeObject<List<Event>>(content);

                    foreach (var item in items)
                    {
                        EventsList.Add(item);
                        Console.WriteLine(item.Title);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}