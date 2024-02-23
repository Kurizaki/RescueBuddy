
namespace RescueBuddy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        }

        async void OnChangeEmergencyContactsButtonClicked(object sender, EventArgs e)
        {
            var contactsPage = new ContactsPage();
            await Shell.Current.GoToAsync($"{nameof(SettingsPage)}?contactsPage={Uri.EscapeDataString(contactsPage.GetType().AssemblyQualifiedName)}");
        }
    }
}
