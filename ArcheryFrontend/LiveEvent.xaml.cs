namespace ArcheryFrontend;

public partial class LiveEvent : ContentPage
{
    int activeplayercount;
    List<string> activenicknames = new List<string>();

	public LiveEvent(int playercount, List<string> nicknamelist)
	{
        activeplayercount = playercount;
        activenicknames = nicknamelist;
		InitializeComponent();
        //Funktion einf�gen um Tabelle zu k�rzen
	}

    private void LiveEventFinished_Clicked(object sender, EventArgs e)
    {
        LeaderboardGrid.IsVisible= false;
        Navigation.PushAsync(new Statistics());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}