namespace RescueBuddy;

public partial class SettingsPage : ContentPage
{
    private ContactsPage _contactsPage;

    public SettingsPage()
    {
        InitializeComponent();
        var route = Shell.Current.CurrentState.Location;
        var contactsPageTypeName = Uri.UnescapeDataString(route.ToString().Split('?').LastOrDefault()?.Split('=')?.LastOrDefault());

        var contactsPageType = Type.GetType(contactsPageTypeName);
        if (contactsPageType != null)
        {
            _contactsPage = (ContactsPage)Activator.CreateInstance(contactsPageType);
        }
    }


    async void OnChangeEmergencyContactsButtonClicked(object sender, EventArgs args)
    {
            await Navigation.PushAsync(_contactsPage);
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