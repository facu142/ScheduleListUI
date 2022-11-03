using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleListUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleListUI.ViewModels
{
    public partial class AddUpdateScheduleDetailViewModel : ObservableObject
    {
        private readonly IScheduleService _scheduleService;
        public AddUpdateScheduleDetailViewModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

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

        [RelayCommand]
        public async void AddUpdateEvent()
        {
            var response = await _scheduleService.AddSchedule(new Models.ScheduleModel
            {
                Title = _title,
                StartDateTime = _startDateTime,
                EndDateTime = _endDateTime,
                Description = _description,
                Location = _location,
            });

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Record saved", "Record added to schedule table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }
    }
}
