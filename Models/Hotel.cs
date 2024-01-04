using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealHolidayApp.Models
{
    public class Hotel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string Adress { get; set; }
        public string HotelDetails
        { get { return HotelName + " " + Adress; } }

        [OneToMany]
        public List<HolidayPlan> HolidayPlans { get; set; }
    }
        
}
