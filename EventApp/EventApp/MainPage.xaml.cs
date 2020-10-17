using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Setup();



        }

        private List<Event> AllEvents { get; set; }

        private List<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event{ EventTitle = "Vacation", BgColor = "#23F0C7", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, 1, 0).Ticks)},
                new Event{ EventTitle = "Camping Trip", BgColor = "#EF767A", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, 0, 30).Ticks)},
                new Event{ EventTitle = "Joe Blogs Birthday", BgColor = "#7D7ABC", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(25, 6, 2, 1).Ticks)},
                new Event{ EventTitle = "Professional Development", BgColor = "#6457A6", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(25, 6, 2, 1).Ticks)}
            };
        }

        private void Setup()
        {
            AllEvents = GetEvents();
            eventList.ItemsSource = AllEvents;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                foreach (var evt in AllEvents)
                {
                    var timespan = evt.Date - DateTime.Now;
                    evt.Timespan = timespan;
                }

                eventList.ItemsSource = null;
                eventList.ItemsSource = AllEvents;

                return true;
            });
        }
    }

    public class Event
    {
        public DateTime Date { get; set; }
        public String EventTitle { get; set; }
        public TimeSpan Timespan { get; set; }
        public string Days => Timespan.Days.ToString("00");
        public string Hours => Timespan.Hours.ToString("00");
        public string Minutes => Timespan.Minutes.ToString("00");
        public string Seconds => Timespan.Seconds.ToString("00");
        public string BgColor { get; set; }

    }
}
