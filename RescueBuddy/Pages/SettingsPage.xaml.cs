namespace RescueBuddy;

public partial class SettingsPage : ContentPage
{
    public SettingsPage() => InitializeComponent();

    async void OnChangeEmergencyContactsButtonClicked(object sender, EventArgs args)
    {
    }

    private async void OnVisitMyHomePageButtonClicked(object sender, EventArgs args)
    {
        try
        {
            Uri uri = new("https://kurizaki.github.io/Resume/");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
            await DisplayAlert("Error", "Failed to open the website. Please try again later.", "OK");
        }


    }
}