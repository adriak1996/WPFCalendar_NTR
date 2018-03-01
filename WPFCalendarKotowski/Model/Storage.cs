using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows;

namespace WPFCalendarKotowski.Model
{
    public class Storage
    {
        public DbSet<Person> getPersons()
        {
            using (var db = new NTRModel()) return db.People;
        }
        public DbSet<Attendance> getAttendances()
        {
            using (var db = new NTRModel())  return db.Attendances;
        }

        public DbSet<Appointment> getAppointments()
        {
            using (var db = new NTRModel())  return db.Appointments;
        }

        public void createPerson(string firstName, string lastName, string indexNo)
        {
            using (var db = new NTRModel())
            {
                var person = new Person
                {
                    PersonID = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    UserID = indexNo,
                    
                };
                db.People.Add(person);
                db.SaveChangesAsync();
            }
        }

        public bool addAppointment(string title, DateTime datetime, String starttime, String endtime)
        {
            using (var db = new NTRModel())
            {
                try
                { 

                var appointment = new Appointment
                {
                    AppointmentID = Guid.NewGuid(),
                    Title = title,
                    Description = " ",
                    StartTime = new TimeSpan(Int32.Parse(starttime.Substring(0,2)), Int32.Parse(starttime.Substring(3, 2)), 00),
                    EndTime = new TimeSpan(Int32.Parse(endtime.Substring(0, 2)), Int32.Parse(endtime.Substring(3, 2)), 00),
                    AppointmentDate = new DateTime(datetime.Year,datetime.Month,datetime.Day)

                };

                Person user = db.People.Where(b => b.UserID == ViewModel.CalendarViewModel.userName)
                  .FirstOrDefault();

                Console.Out.WriteLine(user.PersonID);
                db.Appointments.Add(appointment);

                    foreach (var person in db.People)
                    {
                        var attendance = new Attendance
                        {
                            AppointmentID = appointment.AppointmentID,
                            PersonID = person.PersonID,
                            Accepted = false
                        };

                        if (person.PersonID == user.PersonID)
                            attendance.Accepted = true;

                        db.Attendances.Add(attendance);
                    }

                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    return true;

                }
                catch(ArgumentOutOfRangeException oe)
                {
                    MessageBox.Show("Wrong input data of time field");
                    return false;
                }
                catch ( FormatException   oe)
                {
                    MessageBox.Show("Wrong input data of time field");
                    return false;
                }

                catch (OverflowException oe)
                {
                    MessageBox.Show("Wrong scope of time in input data");
                    return false;
                }
                catch (UpdateException oe)
                {
                    MessageBox.Show("Wrong scope of time in input data");
                    return false;
                }
                catch (Exception oe)
                {
                    MessageBox.Show("Wrong input data of time field");
                    return false;
                }
            }
        }

        public bool EditEvent(DateTime dateIN, String TitleIN, String timeStartIN, String timeEndIN, DateTime dateOUT, String TitleOUT, String timeStartOUT, String timeEndOUT, bool attendance, String UserID, String prevAttendance)
        {
            var db = new NTRModel();

            try
            {
                TimeSpan startIN = new TimeSpan(Int32.Parse(timeStartIN.Substring(0, 2)), Int32.Parse(timeStartIN.Substring(3, 2)), 00);
                TimeSpan endIN = new TimeSpan(Int32.Parse(timeEndIN.Substring(0, 2)), Int32.Parse(timeEndIN.Substring(3, 2)), 00);
                DateTime tempDate = new DateTime(dateIN.Year, dateIN.Month, dateIN.Day);

                Appointment temp = db.Appointments.Where(b => b.AppointmentDate == tempDate)
                .Where(b => b.Title == TitleIN)
                .Where(b => b.StartTime == startIN)
                .Where(b => b.EndTime == endIN)
                .FirstOrDefault();

                bool prevAcceptedBool;
                if (prevAttendance == "YES") prevAcceptedBool = true;
                else prevAcceptedBool = false;

                temp.Title = TitleOUT;
                temp.AppointmentDate = dateOUT;
                temp.StartTime = new TimeSpan(Int32.Parse(timeStartOUT.Substring(0, 2)), Int32.Parse(timeStartOUT.Substring(3, 2)), 00);
                temp.EndTime = new TimeSpan(Int32.Parse(timeEndOUT.Substring(0, 2)), Int32.Parse(timeEndOUT.Substring(3, 2)), 00);

                Person user = db.People.Where(b => b.UserID == UserID)
                .FirstOrDefault();

                Attendance att = db.Attendances.Where(b => b.PersonID == user.PersonID)
                 .Where(b => b.AppointmentID == temp.AppointmentID)
                 .Where(b => b.Accepted == prevAcceptedBool)
                 .FirstOrDefault();
                att.Accepted = attendance;

            }
            catch (ArgumentOutOfRangeException oe)
            {
                MessageBox.Show("Wrong input data of time field");
                return false;
            }
            catch (FormatException oe)
            {
                MessageBox.Show("Wrong input data of time field");
                return false;
            }
            catch (NullReferenceException oe)
            {
                MessageBox.Show("Sorry, but your modification must be rejected.\nThe appointment has been edited by other user while you were looking at\n the event dialog and you could not see the newest update\n Try again");
                return false;
            }

            db.SaveChanges();
            return true;
        }

        public String ThrowAttendance(DateTime dateIN, String TitleIN, String timeStartIN, String timeEndIN, String UserID)
        {
            var db = new NTRModel();

            TimeSpan startIN = new TimeSpan(Int32.Parse(timeStartIN.Substring(0, 2)), Int32.Parse(timeStartIN.Substring(3, 2)), 00);
            TimeSpan endIN = new TimeSpan(Int32.Parse(timeEndIN.Substring(0, 2)), Int32.Parse(timeEndIN.Substring(3, 2)), 00);
            DateTime tempDate = new DateTime(dateIN.Year, dateIN.Month, dateIN.Day);

            Appointment temp = db.Appointments.Where(b => b.AppointmentDate == tempDate)
            .Where(b => b.Title == TitleIN)
            .Where(b => b.StartTime == startIN)
            .Where(b => b.EndTime == endIN)
            .FirstOrDefault();

            Person user = db.People.Where(b => b.UserID == UserID)
            .FirstOrDefault();

            if (temp == null)
            {
                MessageBox.Show("This appointment has beed changed or removed by another user earlier. Try againg!");
                return null;
            }

            Attendance att = db.Attendances.Where(b => b.PersonID == user.PersonID)
             .Where(b => b.AppointmentID == temp.AppointmentID)
             .FirstOrDefault();

            if (att.Accepted == true) return "YES";
            else return "NO";

            db.SaveChanges();
        }

        public void DeleteEvent(DateTime date, String Title, String timeStart, String timeEnd)
        {
            var db = new NTRModel();
            TimeSpan start = new TimeSpan(Int32.Parse(timeStart.Substring(0, 2)), Int32.Parse(timeStart.Substring(3, 2)), 00);
            TimeSpan end = new TimeSpan(Int32.Parse(timeEnd.Substring(0, 2)), Int32.Parse(timeEnd.Substring(3, 2)), 00);
            DateTime tempDate = new DateTime(date.Year, date.Month, date.Day);

            Appointment temp = db.Appointments.Where(b => b.AppointmentDate == tempDate)
           .Where(b => b.Title == Title)
           .Where(b => b.StartTime == start)
           .Where(b => b.EndTime == end)
           .FirstOrDefault();

            foreach(Attendance att in db.Attendances)
            {   if (att.AppointmentID == temp.AppointmentID)  db.Attendances.Remove(att); }

            db.Appointments.Remove(temp);
            db.SaveChanges();
        }
    }
}
