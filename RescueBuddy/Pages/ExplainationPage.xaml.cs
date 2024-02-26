namespace RescueBuddy.Pages;

public partial class ExplainationPage
{
	public ExplainationPage()
	{
		InitializeComponent();
	}

    private async void OnGoHomeButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PopToRootAsync();
    }
}