using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCalendarKotowski.View;
using WPFCalendarKotowski.ViewModel;
using log4net;

namespace WPFCalendarKotowski.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private readonly ILog logger = LogManager.GetLogger(typeof(MainWindow));



        private CalendarViewModel calendarViewModelObject
        {
            get;
            set;
        }

       //[assembly: log4net.Config.XmlConfigurator(Watch = true)]


        public MainWindow()
        {

            log4net.Config.XmlConfigurator.Configure();





            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            calendarViewModelObject =
           new CalendarViewModel(this);
            

            calendarViewModelObject.SetInitDate();
            



        }

        private void ViewLoad(object sender, RoutedEventArgs e)
        {
            logger.Info("Main window has been loaded first time");

            calendarViewModelObject.LoadDays();

           

            CalendarViewControl.DataContext = calendarViewModelObject;

        }

        public void reload()
        {
            logger.Info("Data context reloaded");
            CalendarViewControl.DataContext = calendarViewModelObject;
        }

    }
}
