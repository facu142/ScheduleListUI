using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Plugin.LocalNotification;
using ScheduleListUI.Models;
using ScheduleListUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleListUI.ViewModels
{

    // Aca es donde recibe por parametro los datos del evento a editar
    [QueryProperty(nameof(ScheduleDetail), "ScheduleDetail")]

    public partial class AddUpdateScheduleDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private ScheduleModel _scheduleDetail = new ScheduleModel();

        private readonly IScheduleService _scheduleService;

        [ObservableProperty]
        private DateTime _currentDate = DateTime.Now;
        public AddUpdateScheduleDetailViewModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        /* Propiedades comentadas porque ya estan en ScheduleDetail
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private DateTime _startDateTime;

        [ObservableProperty]
        private DateTime _endDateTime;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private string _location;
         
         */

        [RelayCommand]
        public async void AddUpdateEvent()
        {
            int response = -1;
            if (ScheduleDetail.Id > 0)
            {
                response = await _scheduleService.UpdateSchedule(ScheduleDetail);
            }
            else
            {
                response = await _scheduleService.AddSchedule(new Models.ScheduleModel
                {
                    Title = ScheduleDetail.Title,
                    StartDate = ScheduleDetail.StartDate,
                    StartTime = ScheduleDetail.StartTime,
                    EndTime = ScheduleDetail.EndTime,
                    Description = ScheduleDetail.Description,
                    Location = ScheduleDetail.Location,
                });
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Event Info saved", "Record saved", "OK");

                DateTime dt = new DateTime(ScheduleDetail.StartDate.Year,
                    ScheduleDetail.StartDate.Month,
                    ScheduleDetail.StartDate.Day,
                    ScheduleDetail.StartTime.Hours,
                    ScheduleDetail.StartTime.Minutes,
                    ScheduleDetail.StartTime.Seconds);


                var request = new NotificationRequest
                {
                    NotificationId = 1337,
                    Title = ScheduleDetail.Title,
                    Description = ScheduleDetail.Description,
                    BadgeNumber = 42,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = dt,
                        NotifyRepeatInterval = TimeSpan.FromDays(1)
                    },
                };

                await LocalNotificationCenter.Current.Show(request);

            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }
    }
}
