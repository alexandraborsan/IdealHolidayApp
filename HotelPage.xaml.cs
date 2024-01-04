using IdealHolidayApp.Models;

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
 
}