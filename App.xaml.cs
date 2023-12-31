using System;
using IdealHolidayApp.Data;
using System.IO;

namespace IdealHolidayApp
{
    public partial class App : Application
    {
        static HolidayPlanDatabase database;
        public static HolidayPlanDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   HolidayPlanDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "HolidayPlan.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}