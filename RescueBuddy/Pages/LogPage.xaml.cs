using Plugin.Maui.Audio;
namespace RescueBuddy.Pages
{
    // Log Page is not 100% complete and CHatGPT was used for some functions in here.
    public partial class LogPage
    {
        private readonly string _logFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Logs");
        private IAudioPlayer _audioPlayer;
        private readonly IAudioManager _audioManager;
        private List<LogItem> _logs;

        public List<LogItem> Logs
        {
            get => _logs;
            set
            {
                _logs = value;
                OnPropertyChanged(nameof(Logs));
            }
        }

        private LogItem _selectedLog;
        public LogItem SelectedLog
        {
            get => _selectedLog;
            set
            {
                _selectedLog = value;
                OnPropertyChanged(nameof(SelectedLog));
                UpdateSelectedLogDetails();
                IsAudioButtonEnabled = (value != null);
            }
        }

        private List<string> _selectedLogDetails;
        public List<string> SelectedLogDetails
        {
            get => _selectedLogDetails;
            set
            {
                _selectedLogDetails = value;
                OnPropertyChanged(nameof(SelectedLogDetails));
            }
        }

        private bool _isAudioButtonEnabled;
        public bool IsAudioButtonEnabled
        {
            get => _isAudioButtonEnabled;
            set
            {
                _isAudioButtonEnabled = value;
                OnPropertyChanged(nameof(IsAudioButtonEnabled));
            }
        }

        public LogPage()
        {
            InitializeComponent();
            BindingContext = this;
            Logs = new List<LogItem>();
            _audioManager = DependencyService.Get<IAudioManager>();
            LoadLogs();
        }

        private async void LoadLogs()
        {
            try
            {
                if (Directory.Exists(_logFolder))
                {
                    string[] logFiles = Directory.GetFiles(_logFolder);

                    foreach (string logFile in logFiles)
                    {
                        string logName = Path.GetFileNameWithoutExtension(logFile);
                        string[] logDetailsArray = await Task.Run(() => File.ReadAllLines(logFile));
                        List<string> logDetailsList = new List<string>(logDetailsArray);
                        string audioFile = Path.Combine(_logFolder, $"{logName}.wav");
                        bool audioExists = File.Exists(audioFile);

                        Logs.Add(new LogItem { LogText = logName, LogDetails = logDetailsList, AudioFile = audioExists ? audioFile : null });
                    }
                }
                UpdateListView();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading logs: {ex.Message}");
            }

            UpdateListView();
        }

        private async void PlayAudioButton_Clicked(object sender, EventArgs e)
        {
            if (SelectedLog != null)
            {
                await PlayAudio(SelectedLog.AudioFile);
            }
        }

        private async Task PlayAudio(string audioFilePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(audioFilePath))
                {
                    var audioFile = await FileSystem.OpenAppPackageFileAsync(audioFilePath);
                    _audioPlayer = _audioManager.CreatePlayer(audioFile);
                    _audioPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }

        private void UpdateListView()
        {
            LogsListView.ItemsSource = null;
            LogsListView.ItemsSource = Logs;
        }

        private void UpdateSelectedLogDetails()
        {
            SelectedLogDetails = SelectedLog != null ? SelectedLog.LogDetails : null;
        }

        private async void LogsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                SelectedLog = e.SelectedItem as LogItem;
            }
        }

        public class LogItem
        {
            public string LogText { get; set; }
            public List<string> LogDetails { get; set; }
            public string AudioFile { get; set; }
        }
    }
}
