using Plugin.Maui.Audio;

namespace RescueBuddy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnExplainationButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ExplainationPage());
        }
        async void OnAlarmButtonClicked(object sender, EventArgs args)
        {
            var alarmPage = new AlarmPage(new AudioManager());

            alarmPage.PlayAudio();

            // Navigate to the AlarmPage
            await Navigation.PushAsync(alarmPage);
        }

        async void OnSafetyTipsButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SafetyTipsPage());
        }
    }

}
