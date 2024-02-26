using Plugin.Maui.Audio;

namespace RescueBuddy.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainPage.PermissionRequest();
        }

        private static async void PermissionRequest()
        {
            if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
            {
            }
            else if (await Permissions.RequestAsync<Permissions.ContactsRead>() != PermissionStatus.Granted)
            {
            }
        }

        private async void OnExplainationButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ExplainationPage());
        }

        private async void OnAlarmButtonClicked(object sender, EventArgs args)
        {
            var alarmPage = new AlarmPage(new AudioManager());
            await Navigation.PushAsync(alarmPage);
        }

        private async void OnSafetyTipsButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SafetyTipsPage());
        }
    }

}
