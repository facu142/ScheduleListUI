using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleListUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleListUI.ViewModels
{
    public partial class ScheduleListViewModel : ObservableObject
    {
        public ObservableCollection<DaysModel> Weekdays { get; set; } = new ObservableCollection<DaysModel>();  

        public ObservableCollection<ScheduleModel> ScheduleList { get; set; } = new ObservableCollection<ScheduleModel>();
        private List<ScheduleModel> _allScheduleList = new List<ScheduleModel>();

        [ObservableProperty]
        private DateTime _currentDate = DateTime.Now;


        [ObservableProperty]
        private bool _isBusy;

        public ScheduleListViewModel()
        {
            AddAllScheduleList();
        }

        private void AddAllScheduleList()
        {
            var scheduleList = new List<ScheduleModel>();
            scheduleList.Add(new ScheduleModel
            {
                Title = "Project Setup",
                Description = "Description 1",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(5),
                BackgroundColor = Color.FromArgb("#68c6da"),
            });

            scheduleList.Add(new ScheduleModel
            {
                Title = "App Design",
                Description = "Description 1",
                StartDateTime = DateTime.Now.Date.AddDays(1).Add(new TimeSpan(13, 0, 0)),
                EndDateTime = DateTime.Now.Date.AddDays(1).Add(new TimeSpan(14, 0, 0, 0)),
                BackgroundColor = Color.FromArgb("#e87a3d"),
            });

            scheduleList.Add(new ScheduleModel
            {
                Title = "App Design",
                Description = "Description 1",
                StartDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(15, 0, 0)),
                EndDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(16, 0, 0)),
                BackgroundColor = Color.FromArgb("#9a6ead"),
            });

            scheduleList.Add(new ScheduleModel
            {
                Title = "App Design",
                Description = "Description 1",
                StartDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(17, 0, 0)),
                EndDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(18, 0, 0)),
                BackgroundColor = Color.FromArgb("#eaab43"),
            });

            _allScheduleList.AddRange(scheduleList);
            BindDataToScheduleList();
        }


        public void BindDataToScheduleList()
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                await Task.Delay(3);
                var filterScheduleList = _allScheduleList.Where(schedule => schedule.StartDateTime.Date == CurrentDate.Date).ToList();

                App.Current.Dispatcher.Dispatch(() =>
                {

                    ScheduleList.Clear();
                    foreach (var schedule in filterScheduleList)
                    {
                        ScheduleList.Add(schedule);
                    }
                    GetWeekDaysInfo();
                    IsBusy = false;
                });

            });



        }

        private void GetWeekDaysInfo()
        {
            // obtener el dia de inicio de la semana basado en la seleccion de fecha
            DateTime startDayOfWeek = CurrentDate.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)CurrentDate.DayOfWeek);
            Weekdays.Clear();
            for(int i= 0; i < 7; i++)
            {
                var recordToAdd = new DaysModel
                {
                    DayName = DayOfWeekChar((int)startDayOfWeek.DayOfWeek),
                    Date = startDayOfWeek.Date,
                    IsSelected = startDayOfWeek.Date == CurrentDate.Date
                };

                Weekdays.Add(recordToAdd);
                startDayOfWeek = startDayOfWeek.AddDays(1);
            }
        }

        private char DayOfWeekChar(int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 0:
                    return 'S';
                case 1:
                    return 'M';
                case 2:
                    return 'T';
                case 3:
                    return 'W';
                case 4:
                    return 'T';
                case 5:
                    return 'F';
                case 6:
                    return 'S';
            }
            return ' ';
        }


        [RelayCommand]
        public void WeekDaysSelected(DaysModel item)
        {
            Weekdays.ToList().ForEach(f => f.IsSelected = false);
            item.IsSelected = true;
            CurrentDate = item.Date;

            BindDataToScheduleList();
        }

    }
}
