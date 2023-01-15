namespace ArcheryFrontend;

public partial class Statistics : ContentPage
{
	public Statistics()
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

    private void StatisticsSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (StatisticsSwitch.IsToggled)
        {
            GameGrid.IsVisible = false;
            ArrowGrid.IsVisible = true;
            //int totalpoints = InteractiveUser.CalculateSum();
            PointQuoteLabel.Text = Logic.AvgSum().ToString();
            int[] tmphilow = Logic.MaxMinVals();
            HiHitLabel.Text = tmphilow[0].ToString();
            LowHitLabel.Text = tmphilow[1].ToString();
        }
        else if (!StatisticsSwitch.IsToggled)
        {
            ArrowGrid.IsVisible = false;
            GameGrid.IsVisible = true;
        }
    }
}