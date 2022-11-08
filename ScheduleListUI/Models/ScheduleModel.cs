using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleListUI.Models
{
    //[Table("nombreTabla")]
    public class ScheduleModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
