using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalendarKotowski.Model

{
    class EventModel { };

    public class Event : INotifyPropertyChanged
    {

       
        private string fulltext;
        private string eventname;
        private string start;
        private string end;
        private DateTime eventdate;


        public DateTime EventDate
        {
            get
            {
                return eventdate;
            }
            set
            {
                if (eventdate != value)
                {
                    eventdate = value;
                }
            }
        }

        public string EventName
        {
            get
            {
                return eventname;
            }

            set
            {
                if (eventname != value)
                {
                    eventname = value;
                    RaisePropertyChanged("EventName");
                    RaisePropertyChanged("FullText");
                }
            }
        }



        public string Start
        {
            get
            {
                return start;
            }

            set
            {
                if (start != value)
                {
                    start = value;
                    RaisePropertyChanged("Start");
                    RaisePropertyChanged("FullText");
                }
            }
        }

        public string End
        {
            get
            {
                return end;
            }

            set
            {
                if (end != value)
                {
                    end = value;
                    RaisePropertyChanged("End");
                    RaisePropertyChanged("FullText");
                }
            }
        }


        public string FullText
        {
            get
            {
                return (start+ "-"+end+" "+eventname ); ;
            }

            set
            {
                if (fulltext != value)
                {
                    fulltext = value;
                    RaisePropertyChanged("FullText");
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    



    }
}
