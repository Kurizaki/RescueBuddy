using Plugin.Maui.Audio;

namespace RescueBuddy
{
    public partial class AlarmPage : ContentPage
    {
         private ContactsPage _contactsPage;
        private readonly IAudioManager _audioManager;
        private readonly IAudioRecorder _audioRecorder;
        private IAudioPlayer? _audioPlayer;

        public AlarmPage(IAudioManager audioManager, ContactsPage contactsPage)
        {
            InitializeComponent();
            _audioManager = audioManager;
            _audioRecorder = audioManager.CreateRecorder();
            InitializeAudioPlayer();
            _contactsPage = contactsPage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartAudio();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StopAudio();
        }

        private async void InitializeAudioPlayer()
        {
            var audioFile = await FileSystem.OpenAppPackageFileAsync("mixkit-morning-clock-alarm-1003.wav");
            _audioPlayer = _audioManager.CreatePlayer(audioFile);
            _audioPlayer.Loop = true;
        }

        public void StartAudio()
        {
            _audioPlayer?.Play();
        }

        private void StopAudio()
        {
            _audioPlayer?.Stop();
        }

        async void OnEndRescueButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        async void OnRecordAudioButtonClicked(object sender, EventArgs args)
        {
            if (!_audioRecorder.IsRecording)
            {
                await _audioRecorder.StartAsync();
            }
            else
            {
                var recordedAudio = await _audioRecorder.StopAsync();
                recordedAudio.GetAudioStream();
            }
        }

        async void OnCallEmergencyContactsButtonClicked(object sender, EventArgs args)
        {
            if (_contactsPage != null && _contactsPage.contacts != null)
            {
                for (int i = 0; i < Math.Min(_contactsPage.contacts.Count, 5); i++)
                {
                    MakePhoneCall(_contactsPage.contacts[i].Phone);
                }
            }
            else
            {
                Console.WriteLine("Contacts not available or not properly initialized.");
            }
        }

        public void MakePhoneCall(string phoneNumber)
        {
            try
            {
                if (PhoneDialer.IsSupported)
                {
                    PhoneDialer.Open(phoneNumber);
                }
                else
                {
                    Console.WriteLine("Phone calls not supported on this device.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Invalid phone number: {ex.Message}");
            }
            catch (FeatureNotSupportedException)
            {
                Console.WriteLine("Phone calls not supported on this device.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
