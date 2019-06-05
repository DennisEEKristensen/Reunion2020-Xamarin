using System;

using Reunion2020.Models;

namespace Reunion2020.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Event Item { get; set; }
        public ItemDetailViewModel(Event item = null)
        {
            PageTitle = item?.Title;
            Item = item;
        }
    }
}
