using Newtonsoft.Json;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using TestAPI_Archery.DB;

namespace ArcheryFrontend;

public partial class App : Application
{
    public static List<Parcour> parcours;

    public static List<User> users;

    public static InteractiveUser activePlayer;

    public static List<Event> events;

    public static InteractiveEvent _Ievent;

    public static InteractiveEvent Ievent { get => _Ievent; set => _Ievent = value; }

    


    //When User subscribes to an Event, a pseudo Shot will make an insert intro database


    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Home());

        users = new List<User>();
        parcours = new List<Parcour>();
        events = new List<Event>();


        Initialize();
    }

    public static void Initialize()
    {
        APICalls.GetUser();
        APICalls.GetParcour();
        APICalls.GetEvent();
    }



 

}
