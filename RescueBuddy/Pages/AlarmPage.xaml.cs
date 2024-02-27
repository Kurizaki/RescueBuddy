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
            Console.WriteLine("AlarmPage instance initialized.");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartAudio();
            Console.WriteLine("AlarmPage appeared.");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StopAudio();
            if (_audioRecorder.IsRecording)
            {
                StopRecording();
            }
            Console.WriteLine("AlarmPage disappeared.");
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
            _audioFileName = $"{_recordingStartTime:yyyyMMdd_HHmmss}.wav";
            string audioFilePath = Path.Combine(_logFolder, _audioFileName);
            await this._audioRecorder.StartAsync(audioFilePath);
            Console.WriteLine($"Recording started. File: {_audioFileName}, Path: {audioFilePath}");
        }

        public async Task StopRecording()
        {
            await this._audioRecorder.StopAsync();
            Log($"Audio recorded: {_audioFileName}, Date: {_recordingStartTime}, Duration: {(DateTime.Now - _recordingStartTime)}");
            Console.WriteLine($"Recording stopped. File: {_audioFileName}");
        }

        private async void OnEndRescueButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        private void OnRecordAudioButtonClicked(object sender, EventArgs args)
        {
            if (!_audioRecorder.IsRecording)
            {
                StartRecording();
                RecordAudioButton.Text = "Stop Record Audio";
            }
            else
            {
                RecordAudioButton.Text = "Record Audio";
                StopRecording();
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
                Console.WriteLine($"Logged: {logMessage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex.Message}");
            }
        }
    }
}
