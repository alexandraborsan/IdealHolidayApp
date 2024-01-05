using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdealHolidayApp.Models;
using System.Collections;

namespace IdealHolidayApp.Data
{
    public class HolidayPlanDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public HolidayPlanDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<HolidayPlan>().Wait();
            _database.CreateTableAsync<Offer>().Wait();
            _database.CreateTableAsync<PlanOffer>().Wait();
            _database.CreateTableAsync<Hotel>().Wait();

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
        public Task<int> SaveOfferAsync(Offer offer)
        {
            if (offer.Id != 0)
            {
                return _database.UpdateAsync(offer);
            }
            else
            {
                return _database.InsertAsync(offer);
            }
        }
        public Task<int> DeleteOfferAsync(Offer offer)
        {
            return _database.DeleteAsync(offer);
        }
        public Task<List<Offer>> GetProductsAsync()
        {
            return _database.Table<Offer>().ToListAsync();
        }
        public Task<int> SavePlanOfferAsync(PlanOffer listp)
        {
            if (listp.Id != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Offer>> GetPlanOffersAsync(int holidayPlanId)
        {
            return _database.QueryAsync<Offer>(
                "SELECT P.ID, P.Description FROM Offer P"
                + " INNER JOIN PlanOffer LP"
                + " ON P.ID = LP.OfferId WHERE LP.HolidayPlanId = ?",
                holidayPlanId);
        }



        public Task<List<Offer>> GetOffersAsync()
        {
            return _database.Table<Offer>().ToListAsync();
        }

        public Task<List<Hotel>> GetHotelsAsync()
        {
            return _database.Table<Hotel>().ToListAsync();
        }
        public Task<int> SaveHotelAsync(Hotel hotel)
        {
            if (hotel.Id != 0)
            {
                return _database.UpdateAsync(hotel);
            }
            else
            {
                return _database.InsertAsync(hotel);
            }
        }
        public Task DeleteHotelAsync(Hotel hotel)
        {
            return _database.DeleteAsync(hotel);
        }



    }
}

    

