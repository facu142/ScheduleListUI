using ScheduleListUI.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleListUI.Services
{
    public class ScheduleService : IScheduleService
    {
        // db setup
        private SQLiteAsyncConnection _dbConnection;

        public ScheduleService()
        {
            SetUpDb();
        }


        private async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Schedule.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ScheduleModel>();
            }
        }
        public Task<int> AddSchedule(ScheduleModel scheduleModel)
        {
            return _dbConnection.InsertAsync(scheduleModel);
        }

        public Task<int> DeleteSchedule(ScheduleModel scheduleModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScheduleModel>> GetScheduleList()
        {
            var scheduleList = await _dbConnection.Table<ScheduleModel>().ToListAsync();
            return scheduleList;
        }
       
        public Task<int> UpdateSchedule(ScheduleModel scheduleModel)
        {
            return _dbConnection.UpdateAsync(scheduleModel);
        }
    }
}
