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
        Hotel selectedHotel = (HotelPicker.SelectedItem as Hotel);
        slist.HotelId = selectedHotel.Id;
        await App.Database.SaveHolidayPlanAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (HolidayPlan)BindingContext;
        await App.Database.DeleteHolidayPlanAsync(slist);
        await Navigation.PopAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetHotelsAsync();
        HotelPicker.ItemsSource = (System.Collections.IList)items;
        HotelPicker.ItemDisplayBinding = new Binding("HotelDetails");

        var hotell = (HolidayPlan)BindingContext;

        listView.ItemsSource = await App.Database.GetPlanOffersAsync(hotell.Id);
    }
}