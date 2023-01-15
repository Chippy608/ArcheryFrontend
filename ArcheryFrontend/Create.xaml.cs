namespace ArcheryFrontend;

public partial class Create : ContentPage
{
    int activeplayercount = 1;
    List<string> nicknamelist = new List<string>();

	public Create()
	{
		InitializeComponent();
	}

    private void NavigationButton_Clicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        string ClassId = button.ClassId;
        //string tempbtn = ((Button)sender).Name;

        switch (ClassId)
        {
            case "1" : Navigation.PushAsync(new Notification()); break;
            case "2": Navigation.PushAsync(new Settings()); break;
            case "3": Navigation.PushAsync(new Home()); break;
            case "4": Navigation.PushAsync(new Create()); break;
            case "5": Navigation.PushAsync(new Statistics()); break;
            case "6": Navigation.PushAsync(new User()); break;

            default:
                break;
        }
    }

    private void NewEventButton_Clicked(object sender, EventArgs e)
    {
        EventGrid.IsVisible= true;
    }

    private void ParkourErstellenButton_Clicked(object sender, EventArgs e)
    {
        ParcourCreateGrid.IsVisible= true;
    }

    private void ParkourErstellen_Clicked(object sender, EventArgs e)
    {
        ParcourCreateGrid.IsVisible= false;
    }

    private void EventParkourBestätigen_Clicked(object sender, EventArgs e)
    {
        EventGridStarten.IsVisible= true;
        nicknamelist.Add("Jonathan");
    }

    private void EventStartenButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LiveEvent(activeplayercount, nicknamelist));
    }

    private void AddPlayer_Clicked(object sender, EventArgs e)
    {
        if (FirstName.Text != "" && Name.Text !="" && Nickname.Text != "") {
            activeplayercount++;

            switch (activeplayercount)
            {
                case 2: nicknamelist.Add(Nickname.Text); Player2Name.Text =  FirstName.Text + " " + Name.Text + ": " + Nickname.Text; FirstName.Text = ""; Name.Text = ""; Nickname.Text = "";
                    break;
                case 3: nicknamelist.Add(Nickname.Text); Player3Name.Text = FirstName.Text + " " + Name.Text + ": " + Nickname.Text; FirstName.Text = ""; Name.Text = ""; Nickname.Text = "";
                    break;
                case 4: nicknamelist.Add(Nickname.Text); Player4Name.Text = FirstName.Text + " " + Name.Text + ": " + Nickname.Text; FirstName.Text = ""; Name.Text = ""; Nickname.Text = "";
                    break;
                case 5: nicknamelist.Add(Nickname.Text); Player5Name.Text = FirstName.Text + " " + Name.Text + ": " + Nickname.Text; FirstName.Text = ""; Name.Text = ""; Nickname.Text = ""; AddPlayer.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }
    }
}