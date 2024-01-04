using IdealHolidayApp.Models;
using Microsoft.Maui.Devices.Sensors;

namespace IdealHolidayApp;

public partial class HotelPage : ContentPage
{
    public HotelPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var hotel = (Hotel)BindingContext;
        await App.Database.SaveHotelAsync(hotel);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var hotel = (Hotel)BindingContext;
        var address = hotel.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Hotelul meu preferat" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }


}