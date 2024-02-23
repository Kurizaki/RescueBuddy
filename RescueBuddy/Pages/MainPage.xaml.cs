using Plugin.Maui.Audio;

namespace RescueBuddy
{
    public partial class MainPage : ContentPage
    {
        private ContactsPage _contactsPage;
        public MainPage()
        {
            InitializeComponent();
            MainPage.PermissionRequest();
            _contactsPage = new();
        }
        static async void PermissionRequest()
        {
            if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
            {
                return;
            }
            if (await Permissions.RequestAsync<Permissions.ContactsRead>() != PermissionStatus.Granted)
            {
                return;
            }
        }
        async void OnExplainationButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ExplainationPage());
        }
        async void OnAlarmButtonClicked(object sender, EventArgs args)
        {
            var alarmPage = new AlarmPage(new AudioManager(), _contactsPage);

            alarmPage.StartAudio();

            // Navigate to the AlarmPage
            await Navigation.PushAsync(alarmPage);
        }

        async void OnSafetyTipsButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SafetyTipsPage());
        }
    }

}
