using System;

namespace Reunion2020.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int NoOfSignups { get; set; }
        public string Status { get; set; }
        public int TargetGroupMin { get; set; }
        public int TargetGroupMax { get; set; }
        public string ImageID { get; set; }
    }
}