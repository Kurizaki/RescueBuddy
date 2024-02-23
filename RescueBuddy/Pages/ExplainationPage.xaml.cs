namespace RescueBuddy;

public partial class ExplainationPage : ContentPage
{
	public ExplainationPage()
	{
		InitializeComponent();
	}

    async void OnGoHomeButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PopToRootAsync();
    }
}