namespace RescueBuddy.Pages
{
    public partial class LogPage : ContentPage
    {
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
                SelectedLogDetails = _selectedLog?.LogDetails;
            }
        }

        private List<string> _selectedLogDetails;
        public List<string> SelectedLogDetails
        {
            get { return _selectedLogDetails; }
            set
            {
                _selectedLogDetails = value;
                OnPropertyChanged(nameof(SelectedLogDetails));
            }
        }

        private readonly string _logFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Logs");

        public LogPage()
        {
            InitializeComponent();
            Logs = new List<LogItem>();
            LoadLogs();
            BindingContext = this;
        }

        private void LoadLogs()
        {
            Logs = new List<LogItem>();

            if (Directory.Exists(_logFolder))
            {
                string[] logFiles = Directory.GetFiles(_logFolder);

                foreach (string logFile in logFiles)
                {
                    string logName = Path.GetFileNameWithoutExtension(logFile);
                    string[] logDetailsArray = File.ReadAllLines(logFile);
                    List<string> logDetailsList = new(logDetailsArray);
                    string audioFile = Path.Combine(_logFolder, $"{logName}.wav");
                    bool audioExists = File.Exists(audioFile);
                    Logs.Add(new LogItem { LogText = logName, LogDetails = logDetailsList, AudioFile = audioExists ? audioFile : null });
                }
            }

            OnPropertyChanged(nameof(Logs)); // Notify UI that Logs have changed
        }


        public class LogItem()
        {
            public string LogText { get; set; }
            public List<string> LogDetails { get; set; }
            public string AudioFile { get; set; }
        }
    }
}
