namespace ArcheryFrontend;

public partial class Create : ContentPage
{
	public Create()
	{
		InitializeComponent();
	}

    private void NavigationButton_Clicked(object sender, EventArgs e)
    {
        string tempbtn = ((Button)sender).Text;

        switch (tempbtn)
        {
            case "Notification": Navigation.PushAsync(new Notification()); break;
            case "Settings": Navigation.PushAsync(new Settings()); break;
            case "Home": Navigation.PushAsync(new Home()); break;
            case "Create": Navigation.PushAsync(new Create()); break;
            case "Statistics": Navigation.PushAsync(new Statistics()); break;
            case "User": Navigation.PushAsync(new User()); break;

            default:
                break;
        }
    }
}