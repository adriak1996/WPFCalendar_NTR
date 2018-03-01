using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalendarKotowski.Model
{
    class DayModel {}

    public class Day : INotifyPropertyChanged
    {
        private DateTime dateOfDay;
        private string shortname;
        private ObservableCollection<Event> listelements;
        private string weekofyear;
        private string daycolor;

        public DateTime DateOfDay
        {
            get
            {
                return dateOfDay;
            }

            set
            {
                if (dateOfDay != value)
                {
                    dateOfDay = value;
                    RaisePropertyChanged("DateOfDay");
                    RaisePropertyChanged("ShortName");
                }
            }
        }

       

        public string ShortName
        {
            get
            {
                return dateOfDay.ToString("MMMM dd"); ;
            }

            set
            {
                if (shortname != value)
                {
                    shortname = value;
                    RaisePropertyChanged("DateOfDay");
                    RaisePropertyChanged("ShortName");
                }
            }

        }


        public string WeekOfYear
        {
            get
            {
                int week = ((DateOfDay.DayOfYear / 7)+1);

                if (week!=53)
                return weekofyear= "W "+ (week) + "\n" + (DateOfDay.Year);
                else
                return weekofyear = "W 52" + "\n" + (DateOfDay.Year);
            }

            set
            {
                if (weekofyear != value)
                {
                    weekofyear = value;
                    RaisePropertyChanged("WeekOfYear");
                }
            }

        }


        public string DayColor
        {
            get
            {
                return daycolor;
            }

            set
            {
                if (daycolor != value)
                {
                    daycolor = value;
                    RaisePropertyChanged("DayColor");
                    RaisePropertyChanged("DayColor2");
                }
            }

        }

        

        public ObservableCollection<Event> ListElements
        {
            get
            {
                return listelements;
            }

            set
            {
                if (listelements != value)
                {
                    listelements = value;
                    RaisePropertyChanged("ListElements");
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

