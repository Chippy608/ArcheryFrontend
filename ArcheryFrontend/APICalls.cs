using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestAPI_Archery.DB;

namespace ArcheryFrontend
{
    public class APICalls
    {
        private static string url = "http://10.0.2.2:5283/Archery";
        private static HttpClient httpClient = new HttpClient();
        #region API Calls
        //GetUser
        public static async Task GetUser()
        {
            var httpResponse = await httpClient.GetAsync("http://10.0.2.2:5283/Archery/GetUser");

            if (httpResponse.IsSuccessStatusCode)
            {

                IEnumerable<User>? tmpResult = JsonConvert.DeserializeObject<IEnumerable<User>>(
                    await httpResponse.Content.ReadAsStringAsync());

                foreach (User user in tmpResult)
                {
                    App.users.Add(user);
                }
            }
        }


        //Post User
        public static async void PostUser(User model)
        {
            string tmpData = JsonConvert.SerializeObject(model);

            StringContent restContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(url + "/UpdateUser", restContent);

            if (httpResponse.IsSuccessStatusCode)
            {
            }

        }

        //GetParcour
        public static async Task GetParcour()
        {
            var httpResponse = await httpClient.GetAsync("http://10.0.2.2:5283/Archery/GetParcour");

            if (httpResponse.IsSuccessStatusCode)
            {
                IEnumerable<Parcour>? tmpResult = JsonConvert.DeserializeObject<IEnumerable<Parcour>>(
                    await httpResponse.Content.ReadAsStringAsync());

                App.parcours.Clear();
                foreach (Parcour parcour in tmpResult)
                {
                    App.parcours.Add(parcour);
                }
            }
        }

        //PostParcour
        public static async void PostParcour(Parcour model)
        {
            string tmpData = JsonConvert.SerializeObject(model);

            StringContent restContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(url + "UpdateParcour", restContent);

            if (httpResponse.IsSuccessStatusCode)
            {
            }
        }

        //GetEvent
        public static async Task GetEvent()
        {
            var httpResponse = await httpClient.GetAsync(url + "/GetEvent");

            if (httpResponse.IsSuccessStatusCode)
            {
                IEnumerable<Event>? tmpResult = JsonConvert.DeserializeObject<IEnumerable<Event>>(
                    await httpResponse.Content.ReadAsStringAsync());

                foreach (Event ev in tmpResult)
                {
                    App.events.Add(ev);
                }
            }
        }

        //PostEvent
        public static async void PostEvent(Event model)
        {
            string tmpData = JsonConvert.SerializeObject(model);

            StringContent restContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(url + "AddOrUpdateEvent", restContent);

            if (httpResponse.IsSuccessStatusCode)
            {
            }
        }

        //PostShots
        public static async void PostShots(PointCounting model)
        {
            string tmpData = JsonConvert.SerializeObject(model);

            StringContent restContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(url + "AddOrUpdatePoints", restContent);

            if (httpResponse.IsSuccessStatusCode)
            {
            }
        }
        #endregion

    }
}
