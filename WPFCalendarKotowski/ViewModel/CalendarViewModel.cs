using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCalendarKotowski.Model;
using WPFCalendarKotowski.View;

namespace WPFCalendarKotowski.ViewModel
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        [assembly: XmlConfigurator(Watch = true)]

        private static readonly ILog log = LogManager.GetLogger(typeof(CalendarViewModel));
        public static string userName = getUserName();
        public string titletext = "WPFCalendarKotowski - Logged in: " + userName;
        
        ObservableCollection<Day> days;
        ObservableCollection<Event> events;
        List<ListView> ListViews = new List<ListView>();
        Event chosenevent, previousevent;
        Day chosenday;
        public MainWindow mainwindow;// = new MainWindow();
        string color, fontstyle, buttoncolor;
        string attendance, prevAttendance;
        
        public CalendarViewModel(MainWindow mw) { mainwindow = mw; }
        public CalendarViewModel(){ }

        public string Titletext
        {
            get   { return titletext; }
            set
            {
                if (titletext != value)
                {
                    titletext = value;
                    RaisePropertyChanged("Titletext");
                    log.Info("Titletext has been changed");
                }
            }
        }
        
        public string Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    RaisePropertyChanged("Color");
                    log.Info("Color has been changed");
                }
            }
        }
        
        public string FontStyle
        {
            get { return fontstyle; }
            set
            {
                if (fontstyle != value)
                {
                    fontstyle = value;
                    RaisePropertyChanged("FontStyle");
                    log.Info("FontStyle has been changed");
                }
            }
        }
        
        public string ButtonColor
        {
            get { return buttoncolor; }
            set
            {
                if (buttoncolor != value)
                {
                    buttoncolor = value;
                    RaisePropertyChanged("ButtonColor");
                    log.Info("FontStyle has been changed");
                }
            }
        }
        
        public Event ChosenEvent
        {
            get { return chosenevent; }
            set
            {
                if (chosenevent != value)
                {
                    chosenevent = value;
                    RaisePropertyChanged("ChosenEvent");
                    log.Info("New event has been selected");
                }
            }
        }

        public Event PreviousEvent
        {
            get { return previousevent; }
            set
            {
                if (previousevent != value)
                {
                    previousevent = value;
                    RaisePropertyChanged("PreviousEvent");
                }
            }
        }

        public ObservableCollection<Day> Days
        {
            get { return days; }
            set
            {
                if (days != value)
                {
                    days = value;
                    RaisePropertyChanged("Days");
                    log.Info("Day list has been changed");
                }
            }
        }


        public Day ChosenDay
        {
            get { return chosenday; }
            set
            {
                if (chosenday != value)
                {
                    chosenday = value;
                    RaisePropertyChanged("ChosenDay");
                    log.Info("New day has been selected");
                }
            }
        }
        
        public ObservableCollection<Event> Events
        {
            get { return events; }
            set
            {
                if (events != value)
                {
                    events = value;
                    RaisePropertyChanged("Events");
                    log.Info("Event list has been changed ");
                }
            }
        }

        private void RaisePropertyChanged(string property){ if (PropertyChanged != null){  PropertyChanged(this, new PropertyChangedEventArgs(property)); } }

        public DateTime currentDate  { get; set; }
        public DateTime observedDate { get; set; }
        
        public string Attendance
        {
            get  {  return attendance;  }
            set
            {
                if (attendance != value)
                {
                    attendance = value;
                    RaisePropertyChanged("Attendance");
                    log.Info("FontStyle has been changed");
                }
            }
        }

        public ICommand GoPrev { get; set; }
        public ICommand GoNext { get; set; }
        public ICommand AddNewEvent { get; set; }
        public ICommand EditDeleteEvent { get; set; }
        public ICommand AddEventCommand { get; set; }
        public ICommand EditEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand ShowPopUp { get; set; }
        public ICommand GetAzureCSS { get; set; }
        public ICommand GetGoldCSS { get; set; }
        public ICommand GetGreenCSS { get; set; }
        public ICommand GetNormal { get; set; }
        public ICommand GetItalics { get; set; }
        public ICommand GetOblique { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetInitDate()
        {
            log.Info("Initialization has been prepared");
            Color = "Azure";
            FontStyle = "Normal";
            ButtonColor = "LightBlue";
            Titletext = titletext;

            GoPrev = new RelayCommand(new Action<object>(GoPrevMeth));
            GoNext = new RelayCommand(new Action<object>(GoNextMeth));
            AddNewEvent = new RelayCommand(new Action<object>(AddEvent));
            EditDeleteEvent = new RelayCommand(new Action<object>(ModifyOrDeleteEvent));
            AddEventCommand = new RelayCommand(new Action<object>(AddEventMethod));
            EditEventCommand = new RelayCommand(new Action<object>(EditEventMethod));
            DeleteEventCommand = new RelayCommand(new Action<object>(DeleteEventMethod));
            ShowPopUp = new RelayCommand(new Action<object>(PopUpMethod));
            GetAzureCSS = new RelayCommand(new Action<object>(AzureCSSMethod));
            GetGoldCSS = new RelayCommand(new Action<object>(GoldCSSMethod));
            GetGreenCSS = new RelayCommand(new Action<object>(GreenCSSMethod));
            GetNormal = new RelayCommand(new Action<object>(GetNormalMethod));
            GetItalics = new RelayCommand(new Action<object>(GetItalicsMethod));
            GetOblique = new RelayCommand(new Action<object>(GetObliqueMethod));
            
            currentDate = DateTime.Now;
            observedDate = DateTime.Now;
            ObservableCollection<Day> days = new ObservableCollection<Day>();
            ObservableCollection<Event> events = new ObservableCollection<Event>();
            DateTime temp = currentDate;

            while (true)
            {
                if (!temp.DayOfWeek.ToString().Equals(DayOfWeek.Monday.ToString()))   { temp = temp.AddDays(-1); }
                else  {  break; }
            }
            
            Events = events;
            LoadFromDB();
            Storage storage = new Storage();
            log.Info("Initialization of data prepared");
        }

        public static string getUserName()
        {
            string filename = "..\\..\\username.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            string line;

            if ((line = file.ReadLine()) != null)   { userName = line;  }

            file.Close();
            return userName;
        }
        
        public void LoadDays()
        {
            FillDateOfDays(observedDate);
            LoadEventsToDays();
            log.Info("Reloading days has been done");
        }
        
        public void FillDateOfDays(DateTime temp)
        {
            log.Info("Filling callendar with day has been prepared");
            ObservableCollection<Day> days = new ObservableCollection<Day>();
            ObservableCollection<Event> events = new ObservableCollection<Event>();

            while (true)
            {
                if (!temp.DayOfWeek.ToString().Equals(DayOfWeek.Monday.ToString())) { temp = temp.AddDays(-1); }
                else  {  break; }
            }

            for (int i = 0; i < 28; i++)
            {
                if (temp.Date.ToString().Equals(DateTime.Now.Date.ToString()))
                { days.Add(new Day { DateOfDay = temp, DayColor = "Red" }); }
                else days.Add(new Day { DateOfDay = temp, DayColor = "Black" });

                temp = temp.AddDays(1);
            }
            Days = days;
        }
        
        void LoadFromDB()
        {
            var db = new NTRModel();
            Events.Clear();
            Person user = db.People.Where(b => b.UserID == userName).FirstOrDefault();
            
            foreach (var appointment in db.Appointments)
            {
                Attendance att = db.Attendances.Where(b => b.AppointmentID == appointment.AppointmentID)
                    .Where(b => b.PersonID == user.PersonID).FirstOrDefault();

                if (att != null)
                {
                    Event newevent = new Event();
                    newevent.EventDate = DateTime.ParseExact(appointment.AppointmentDate.ToString(), "dd/MM/yyyy HH:mm:ss",
                                            System.Globalization.CultureInfo.InvariantCulture);
                    newevent.Start = appointment.StartTime.ToString(@"hh\:mm");
                    newevent.End = appointment.EndTime.ToString(@"hh\:mm");
                    newevent.EventName = appointment.Title;
                    newevent.FullText = appointment.StartTime + "-" + appointment.EndTime + " " + appointment.Title;
                    Events.Add(newevent);
                }
            }
        }

        void LoadFromFile()
        {
            string filename = "..\\..\\data.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            string line;

            while ((line = file.ReadLine()) != null)
            {
                Event newevent = new Event();
                newevent.EventDate = DateTime.ParseExact(line, "dd/MM/yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

                if ((line = file.ReadLine()) != null) newevent.Start = line;
                else break;

                if ((line = file.ReadLine()) != null)   newevent.End = line;
                else break;

                if ((line = file.ReadLine()) != null) newevent.EventName = line;
                else break;

                if ((line = file.ReadLine()) != null)  newevent.FullText = line;
                else break;

                Events.Add(newevent);
            }
            
            file.Close();
            log.Info("Loading from file has been done");
        }



        public void GoPrevMeth(object obj)
        {
            observedDate = observedDate.AddDays(-7);
            LoadFromDB();
            LoadDays();
            log.Info("Moving to previous week option have been chosen");
        }

        public void GoNextMeth(object obj)
        {
            observedDate = observedDate.AddDays(7);
            LoadFromDB();
            LoadDays();
            log.Info("Moving to next week option have been chosen");
        }
        
        public void AddEvent(object obj)
        {
            Day chosenday = ((Day)obj);
            ChosenEvent = new Event();
            ChosenDay = new Day();
            Event chosenevent = new Event();

            chosenevent.EventDate = chosenday.DateOfDay;
            ChosenDay = chosenday;
            ChosenEvent = chosenevent;
            AddEventWindow addeventwindow = new AddEventWindow(this);
            LoadFromDB();
            LoadDays();
            addeventwindow.ShowDialog();

            log.Info("Event adding option option have been chosen");
        }

        public void ModifyOrDeleteEvent(object obj)
        {
            Event chosenevent = new Event();
            Event previusevent = new Event();
            Day chosenday = new Day();

            if (obj == "NTR1") return;

            previusevent.Start = ((Event)obj).Start;
            previusevent.End = ((Event)obj).End;
            previusevent.EventName = ((Event)obj).EventName;
            previusevent.EventDate = ((Event)obj).EventDate;

            Storage storage = new Storage();
            attendance = storage.ThrowAttendance(previusevent.EventDate, previusevent.EventName, previusevent.Start, previusevent.End, userName);
            if (attendance == null)
            {
                LoadFromDB();
                LoadDays();
                return;
            }

            prevAttendance = attendance;
            Attendance = attendance;
            chosenevent.Start = ((Event)obj).Start;
            chosenevent.End = ((Event)obj).End;
            chosenevent.EventName = ((Event)obj).EventName;
            chosenevent.EventDate = ((Event)obj).EventDate;
            chosenday.DateOfDay = ((Event)obj).EventDate;
            
            ChosenEvent = chosenevent;
            PreviousEvent = previusevent;
            ChosenDay = chosenday;
            Attendance = attendance;
            LoadFromDB();
            LoadDays();
            UpdateDeleteWindow updatedeletewindow = new UpdateDeleteWindow(this);
            updatedeletewindow.ShowDialog();
            log.Info("Editing or deleting option have been chosen");
        }

        public void AddEventMethod(object obj)
        {
            log.Info("Adding new event command has been being started");
            Event temp = new Event();
            temp.EventDate = ChosenDay.DateOfDay;
            temp.Start = ChosenEvent.Start;
            temp.End = ChosenEvent.End;
            temp.EventName = ChosenEvent.EventName;
            ObservableCollection<Event> events = new ObservableCollection<Event>();
            events = Events;

            if ((ChosenEvent.Start != null) && (ChosenEvent.End != null) && (ChosenEvent.EventName != null))
            {
                Storage storage = new Storage();
                bool test = storage.addAppointment(ChosenEvent.EventName, ChosenDay.DateOfDay, ChosenEvent.Start, ChosenEvent.End);
                LoadFromDB();
                events = new ObservableCollection<Event>(from i in events orderby i.FullText select i);
                
                Events = events;
                LoadDays();

                if (test == true)
                {
                    mainwindow.IsEnabled = true;
                    ((AddEventWindow)obj).Close();
                    log.Info("Adding new event have been succeded");
                }
            }
            else
            {
                log.Warn("Adding new event have been failed");
                MessageBox.Show("Operation failed! You cannot remain an empty space in the form!");
            }

            LoadFromDB();
            LoadDays();
        }


        public void EditEventMethod(object obj)
        {
            log.Info("Editing new event command has been being started");
            Event temp = new Event();
            temp.EventDate = ChosenDay.DateOfDay;
            temp.Start = ChosenEvent.Start;
            temp.End = ChosenEvent.End;
            temp.EventName = ChosenEvent.EventName;
            
            ObservableCollection<Event> events = new ObservableCollection<Event>();
            events = Events;

            if ((ChosenEvent.Start != null) && (ChosenEvent.End != null) && (ChosenEvent.EventName != null))
            {
                events = new ObservableCollection<Event>(from i in events orderby i.FullText select i);
                Storage storage = new Storage();
                bool flag;
                if (Attendance == "YES") flag = true;
                else flag = false;
                bool test = storage.EditEvent(PreviousEvent.EventDate, PreviousEvent.EventName, PreviousEvent.Start, PreviousEvent.End, temp.EventDate, temp.EventName, temp.Start, temp.End, flag, userName, prevAttendance);
                
                if (test == true)
                {
                    mainwindow.IsEnabled = true;
                    ((UpdateDeleteWindow)obj).Close();
                    log.Info("Adding the event have been succeded");
                }
            }
            else
            {
                MessageBox.Show("You cannot remain an empty space in the form!");
                log.Warn("Editing the event have been failed");
            }

            LoadFromDB();
            LoadDays();
        }
        
        public void DeleteEventMethod(object obj)
        {

            log.Info("Deleting new event command has been being started");
            Event temp = new Event();
            
            temp.EventDate = ChosenDay.DateOfDay;
            temp.Start = ChosenEvent.Start;
            temp.End = ChosenEvent.End;
            temp.EventName = ChosenEvent.EventName;
            
            ObservableCollection<Event> events = new ObservableCollection<Event>();
            events = Events;
            Event editedevent = new Event();

            foreach (Event ev in events)
            {
                if ((ev.EventDate.Date.ToString().Equals(PreviousEvent.EventDate.Date.ToString()) && (ev.FullText.Equals(PreviousEvent.FullText))))
                {
                    Storage storage = new Storage();
                    storage.DeleteEvent(ev.EventDate, ev.EventName, ev.Start, ev.End);
                    MessageBox.Show("The chosen event have been removed from the calendar!");
                    LoadFromDB();
                    break;

                }
            }

            LoadFromDB();
            Events = events;
            LoadDays();
            ((UpdateDeleteWindow)obj).Close();
            log.Info("Removing the event have been succeded");
        }
        
        public void PopUpMethod(object obj)
        {
            PopUp popup = new PopUp(this);
            popup.Show();
        }

        public void AzureCSSMethod(object obj)
        {
            Color = "Azure";
            ButtonColor = "LightBlue";
        }


        public void GoldCSSMethod(object obj)
        {
            Color = "Gold";
            ButtonColor = "Goldenrod";
        }

        public void GreenCSSMethod(object obj)
        {
            Color = "LightGreen";
            ButtonColor = "MediumSeaGreen";
        }

        public void GetNormalMethod(object obj)
        {
            FontStyle = "Normal";
        }
        
        public void GetItalicsMethod(object obj)
        {
            FontStyle = "Italic";
        }

        public void GetObliqueMethod(object obj)
        {
            FontStyle = "Oblique";
        }

        public void LoadEventsToDays()
        {
            for (int i = 0; i < Days.Count; i++)
            {
                if (Days[i].ListElements != null)
                    Days[i].ListElements.Clear();
                else Days[i].ListElements = new ObservableCollection<Event>();
                
                for (int j = 0; j < Events.Count; j++)
                {
                    if (Days[i].DateOfDay.ToString("MMMM dd, yyyy").Equals(Events[j].EventDate.ToString("MMMM dd, yyyy")))
                    { Days[i].ListElements.Add(Events[j]); }
                }
            }
        }
    }
}