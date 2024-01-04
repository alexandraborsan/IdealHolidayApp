namespace IdealHolidayApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"{count} Holiday you could've planned";
            else
                CounterBtn.Text = $"{count} Holidays you could've planned";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}