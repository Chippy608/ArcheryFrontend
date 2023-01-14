namespace ArcheryFrontend;

public partial class Settings : ContentPage
{
	public Settings()
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
            case "1": Navigation.PushAsync(new Notification()); break;
            case "2": Navigation.PushAsync(new Settings()); break;
            case "3": Navigation.PushAsync(new Home()); break;
            case "4": Navigation.PushAsync(new Create()); break;
            case "5": Navigation.PushAsync(new Statistics()); break;
            case "6": Navigation.PushAsync(new User()); break;

            default:
                break;
        }
    }
}