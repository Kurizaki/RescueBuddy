using Plugin.Maui.Audio;

namespace RescueBuddy;

public partial class AlarmPage : ContentPage
{
    private readonly IAudioManager _audioManager;
    private readonly IAudioRecorder _audioRecorder;
    public AlarmPage(IAudioManager audioManager)
	{
		InitializeComponent();
        _audioManager = audioManager;
        _audioRecorder = audioManager.CreateRecorder();

        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PlayAudio();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    public async void PlayAudio()
    {
        var player = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("mixkit-morning-clock-alarm-1003.wav"));
        player.Play();
    }

    async void OnEndRescueButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PopToRootAsync();
    }
    async void OnRecordAudioButtonClicked(object sender, EventArgs args)
    {
        //needs to be asked at the first time using the app and not when trying to push an alarm and add a good filepath or storage system
        if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
        {
            return;
        }

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
    }
}