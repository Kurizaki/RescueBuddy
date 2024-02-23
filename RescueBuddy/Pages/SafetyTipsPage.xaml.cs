namespace RescueBuddy;

public partial class SafetyTipsPage : ContentPage
{
	public SafetyTipsPage()
	{
		InitializeComponent();
	}

    async void OnGoHomeButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PopToRootAsync();
    }
}