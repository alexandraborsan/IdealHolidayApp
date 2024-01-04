namespace IdealHolidayApp;
using IdealHolidayApp.Models;

public partial class HotelEntryPage : ContentPage
{
	public HotelEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetHotelsAsync();
    }
    async void OnHotelAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HotelPage
        {
            BindingContext = new Hotel()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new HotelPage
            {
                BindingContext = e.SelectedItem as Hotel
            });
        }
    }
}