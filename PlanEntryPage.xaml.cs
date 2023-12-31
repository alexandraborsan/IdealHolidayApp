using IdealHolidayApp.Models;
namespace IdealHolidayApp;

public partial class PlanEntryPage : ContentPage
{
	public PlanEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetHolidayPlanAsync();
    }
    async void OnHolidayPlanAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlanPage
        {
            BindingContext = new HolidayPlan()
        });
    }
    async void OnPlanViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new PlanPage
            {
                BindingContext = e.SelectedItem as HolidayPlan
            });
        }
    }
}