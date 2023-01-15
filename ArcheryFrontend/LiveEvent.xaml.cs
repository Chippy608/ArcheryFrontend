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
        //Funktion einfügen um Tabelle zu kürzen
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