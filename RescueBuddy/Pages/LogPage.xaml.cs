using Plugin.Maui.Audio;

namespace RescueBuddy.Pages
{
    public partial class LogPage : ContentPage
    {
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
            }
        }

        private readonly string _logFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Logs");

        public LogPage()
        {
            InitializeComponent();
            BindingContext = this;
            Logs = new List<LogItem>();
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

        public class LogItem
        {
            public string LogText { get; set; }
            public List<string> LogDetails { get; set; }
            public string AudioFile { get; set; }
        }
    }
}
