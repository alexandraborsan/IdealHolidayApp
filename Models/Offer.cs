using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace IdealHolidayApp.Models
{
    public class Offer
    {
        
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Description { get; set; }
            [OneToMany]
            public List<PlanOffer> PlanOffers { get; set; }

        
    }
}
