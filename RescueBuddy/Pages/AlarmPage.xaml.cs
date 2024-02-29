using Plugin.Maui.Audio;

namespace RescueBuddy.Pages
{
    public partial class AlarmPage
    {
        private readonly string _contactsFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.txt");
        private readonly string _logFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Logs");
        private readonly IAudioManager _audioManager;
        private readonly IAudioRecorder _audioRecorder;
        private IAudioPlayer? _audioPlayer;
        private string? _audioFileName;
        private string? _logFileName;
        private int _timesClicked;

        private DateTime _recordingStartTime;

        public AlarmPage(IAudioManager audioManager)
        {
            InitializeComponent();
            _audioManager = audioManager;
            _audioRecorder = audioManager.CreateRecorder();
            InitializeAudioPlayer();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartAudio();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            StopAudio();
            if (_audioRecorder.IsRecording)
            {
                await StopRecording();
            }
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

        public async Task StartRecording()
        {
            _recordingStartTime = DateTime.Now;
            string baseFileName = $"{_recordingStartTime:yyyyMMdd_HHmmss}.wav";
            string audioFilePath = Path.Combine(_logFolder, baseFileName);

            int counter = 1;
            while (File.Exists(audioFilePath))
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(baseFileName);
                string extension = Path.GetExtension(baseFileName);
                string numberedFileName = $"{fileNameWithoutExtension} ({counter}){extension}";
                audioFilePath = Path.Combine(_logFolder, numberedFileName);
                counter++;
            }

            _audioFileName = Path.GetFileName(audioFilePath);

            await this._audioRecorder.StartAsync(audioFilePath);
        }


        public async Task StopRecording()
        {
            await this._audioRecorder.StopAsync();
            Log($"Audio recorded: {_audioFileName}, Date: {_recordingStartTime}, Duration: {(DateTime.Now - _recordingStartTime)}");
        }

        private async void OnEndRescueButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnRecordAudioButtonClicked(object sender, EventArgs args)
        {
            if (!_audioRecorder.IsRecording)
            {
                await StartRecording();
                RecordAudioButton.Text = "Stop Record Audio";
            }
            else
            {
                RecordAudioButton.Text = "Record Audio";
                await StopRecording();
            }
        }

        private async void OnCallEmergencyContactsButtonClicked(object sender, EventArgs args)
        {
            List<Models.Contact> contacts = ReadContactsFromFile();

            if (contacts.Count == 0)
            {
                await DisplayAlert("No Contacts", "There are no emergency contacts available.", "OK");
                return;
            }

            if (contacts.Count >= _timesClicked)
            {
                MakePhoneCall(contacts[_timesClicked].Phone);
                _timesClicked++;
                if (contacts.Count == _timesClicked)
                {
                    _timesClicked = 0;
                }
            }
        }

        private List<Models.Contact> ReadContactsFromFile()
        {
            List<Models.Contact> contacts = new();

            if (File.Exists(_contactsFileName))
            {
                string[] lines = File.ReadAllLines(_contactsFileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        string phone = parts[1];
                        contacts.Add(new Models.Contact(name, phone));
                    }
                }
            }

            return contacts;
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
                    DisplayAlert("Not Supported", "Phone calls not supported on this device.", "OK");
                }
            }
            catch (ArgumentNullException ex)
            {
                DisplayAlert("Invalid Number", $"Invalid phone number: {ex.Message}", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                DisplayAlert("Not Supported", "Phone calls not supported on this device.", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }

        private void Log(string message)
        {
            try
            {
                string timestamp = $"{_recordingStartTime:yyyyMMdd_HHmmss}";
                _logFileName = $"{timestamp}.txt";
                string logFolderPath = Path.Combine(_logFolder);

                if (!Directory.Exists(logFolderPath))
                {
                    Directory.CreateDirectory(logFolderPath);
                }

                string logFilePath = Path.Combine(logFolderPath, _logFileName);
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Error logging: {ex.Message}", "OK");
            }
        }
    }
}
