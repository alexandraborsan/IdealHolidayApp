using IdealHolidayApp.Models;
namespace IdealHolidayApp;

public partial class PlanPage : ContentPage
{
	public PlanPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (HolidayPlan)BindingContext;
        await App.Database.SaveHolidayPlanAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (HolidayPlan)BindingContext;
        await App.Database.DeleteHolidayPlanAsync(slist);
        await Navigation.PopAsync();
    }
}