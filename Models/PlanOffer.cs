using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace IdealHolidayApp.Models
{
    public class PlanOffer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(HolidayPlan))]
        public int HolidayPlanId { get; set; }
        public int OfferId { get; set; }

    }
}
