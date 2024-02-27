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
            get { return _logs; }
            set
            {
                _logs = value;
                OnPropertyChanged(nameof(Logs));
            }
        }

        private LogItem _selectedLog;
        public LogItem SelectedLog
        {
            get { return _selectedLog; }
            set
            {
                _selectedLog = value;
                OnPropertyChanged(nameof(SelectedLog));
            }
        }

        public LogPage()
        {
            InitializeComponent();
            Logs = new List<LogItem>();
            LoadLogs();
            BindingContext = this;
        }

        private readonly string _logFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Logs");

        private async void LoadLogs()
        {
            var logs = new List<LogItem>();

            try
            {
                Console.WriteLine("Checking log folder existence...");
                if (Directory.Exists(_logFolder))
                {
                    Console.WriteLine($"Log folder {_logFolder} exists.");

                    string[] logFiles = Directory.GetFiles(_logFolder);

                    Console.WriteLine($"Found {logFiles.Length} log files.");

                    foreach (string logFile in logFiles)
                    {
                        Console.WriteLine($"Reading log file: {logFile}");

                        string logName = Path.GetFileNameWithoutExtension(logFile);
                        string[] logDetailsArray = File.ReadAllLines(logFile);
                        List<string> logDetailsList = new List<string>(logDetailsArray);
                        string audioFile = Path.Combine(_logFolder, $"{logName}.wav");
                        bool audioExists = File.Exists(audioFile);

                        Console.WriteLine($"Adding log item: {logName}");

                        logs.Add(new LogItem { LogText = logName, LogDetails = logDetailsList, AudioFile = audioExists ? audioFile : null });
                    }
                }
                else
                {
                    Console.WriteLine($"Log folder {_logFolder} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading logs: {ex.Message}");
            }

            Logs = logs;

            Console.WriteLine("Loading logs completed.");
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

        private void LogsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedLog = e.Item as LogItem;
            if (SelectedLog != null)
            {
                PlayAudio(SelectedLog.AudioFile);
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
