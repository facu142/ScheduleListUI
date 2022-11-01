using ScheduleListUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleListUI.Services
{
    public interface IScheduleService
    {
        Task<List<ScheduleModel>> GetScheduleList();
        Task<int> AddSchedule(ScheduleModel scheduleModel);

        Task<int> DeleteSchedule(ScheduleModel scheduleModel);

        Task<int> UpdateSchedule(ScheduleModel scheduleModel);

    }
}
