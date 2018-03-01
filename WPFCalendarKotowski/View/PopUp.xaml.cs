using log4net;
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
using System.Windows.Shapes;
using WPFCalendarKotowski.ViewModel;

namespace WPFCalendarKotowski.View
{
    /// <summary>
    /// Logika interakcji dla klasy PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(CalendarViewModel));


        public PopUp(CalendarViewModel cvm)
        {
            InitializeComponent();

            log.Info("Window for calendar visual setting has been created");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            this.DataContext = cvm;
            new CalendarViewModel();
        }

       


    }
}
