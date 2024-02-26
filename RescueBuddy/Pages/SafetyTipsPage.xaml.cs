namespace RescueBuddy.Pages;

public partial class SafetyTipsPage
{
	public SafetyTipsPage()
	{
		InitializeComponent();
	}

    private async void OnGoHomeButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PopToRootAsync();
    }
}