using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdealHolidayApp.Models;


namespace IdealHolidayApp.Data
{
    public class HolidayPlanDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public HolidayPlanDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<HolidayPlan>().Wait();
        }
        public Task<List<HolidayPlan>> GetHolidayPlanAsync()
        {
            return _database.Table<HolidayPlan>().ToListAsync();
        }
        public Task<HolidayPlan> GetHolidayPlanAsync(int id)
        {
            return _database.Table<HolidayPlan>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveHolidayPlanAsync(HolidayPlan slist)
        {
            if (slist.Id != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteHolidayPlanAsync(HolidayPlan slist)
        {
            return _database.DeleteAsync(slist);
        }

    }
}
