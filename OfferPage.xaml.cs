using IdealHolidayApp.Models;

namespace IdealHolidayApp
{
    public partial class OfferPage : ContentPage
    {
        HolidayPlan sl;
        public OfferPage(HolidayPlan slist)
        {
            InitializeComponent();
            sl = slist;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var offer = (Offer)BindingContext;
            await App.Database.SaveOfferAsync(offer);
            listView.ItemsSource = await App.Database.GetOffersAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var offer = (Offer)BindingContext;
            await App.Database.DeleteOfferAsync(offer);
            listView.ItemsSource = await App.Database.GetOffersAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OfferPage((HolidayPlan)this.BindingContext)
            {
                BindingContext = new Offer()
            });
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            Offer p;
            if (listView.SelectedItem != null)
            {
                p = listView.SelectedItem as Offer;
                var lp = new PlanOffer()
                {
                    HolidayPlanId = sl.Id,
                    OfferId = p.Id
                };
                await App.Database.SavePlanOfferAsync(lp);
                p.PlanOffers = new List<PlanOffer> { lp };
                await Navigation.PopAsync();
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (HolidayPlan)BindingContext;

            listView.ItemsSource = await App.Database.GetPlanOffersAsync(shopl.Id);
        }
    }
}
