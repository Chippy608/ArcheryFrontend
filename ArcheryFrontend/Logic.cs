using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI_Archery.DB;

namespace ArcheryFrontend
{
    public class Logic
    {
        #region Events
        public static void CreateNewEvent(string parcourname, string eventname)
        {
            Event tmpResult = new Event();

            foreach (Parcour item in App.parcours)
            {
                if (item.name == parcourname)
                {
                    tmpResult.parcour_id = item.id;
                    tmpResult.eventname = eventname;
                    break;
                }
            }

            App.Ievent = new InteractiveEvent(tmpResult);

            APICalls.PostEvent(tmpResult);
        }

        public static PointCounting CreateShot(int tmpUserId, int tmpEventId, string tmpring, int tmparrownum, int tmpdeernum)
        {
            PointCounting shot = new PointCounting
            {
                user_id = tmpUserId,
                event_id = tmpEventId,
                ring = tmpring,
                arrownum = tmparrownum,
                deernum = tmpdeernum
            };

            return shot;
        }

        public static void AddUserToEvent(string tmpusername)
        {
            int tmpUserId = 0;

            foreach (User user in App.users)
            {
                if (user.fullname == tmpusername || user.nickname == tmpusername)
                {
                    tmpUserId = user.Id;

                    if (App.Ievent.OrgEvent.Id == App.Ievent.OrgEvent.Id)
                    {
                        App.Ievent.Users.Add(new InteractiveUser(user));
                    }
                }
            }

            //Initialize Shot, to get a dataset in n:m in database.
            CreateShot(tmpUserId, App.Ievent.OrgEvent.Id, "0", 0, 0);
        }

        public static void ShotsFired(int tmpUserId, int tmpring, int tmparrownum, int tmpdeernum)
        {
            //Write Points into event structure

            foreach (InteractiveUser user in App.Ievent.Users)
            {
                if (user.orgUser.Id == tmpUserId)
                {
                    user.points.Add(new Points() { arrownumber = tmparrownum, ring = tmpring, deernum = tmpdeernum });
                }
            }

            //write data into database
            APICalls.PostShots(CreateShot(tmpUserId, App.Ievent.OrgEvent.Id, tmpring.ToString(), tmparrownum, tmpdeernum));
        }

        //inner ring = 1
        //middle ring = 2
        //outer ring = 3

        //first Shot = 20/18/16
        //secondShot = 14/12/10
        //thirdShot = 8/6/4
        public static int CalculatePoints(int tmpShot, int ring)
        {
            switch (tmpShot)
            {
                case 1:
                    if (ring == 1)
                        return 20;
                    else if (ring == 2)
                        return 18;
                    else
                        return 16;
                case 2:
                    if (ring == 1)
                        return 14;
                    else if (ring == 2)
                        return 12;
                    else
                        return 10;
                case 3:
                    if (ring == 1)
                        return 8;
                    else if (ring == 2)
                        return 6;
                    else
                        return 4;
                default:
                    return 0;
            }
        }

        public static string GetUserNameFromID(int tmpUserId)
        {
            foreach (User user in App.users)
            {
                if (user.Id == tmpUserId)
                {
                    return user.nickname;
                }
            }
            return "";
        }

        public static void CreateParcour(string tmpname, string tmplocation, string tmptargetcount)
        {
            APICalls.PostParcour(new Parcour { location = tmplocation, name = tmpname, targetCount = tmptargetcount });
            APICalls.GetParcour();
        }
        #endregion

        #region EventAnalization
        //Leaderboard
        public static Dictionary<int, string> CreateLeaderboard()
        {
            Dictionary<int, string> tmpdic = new Dictionary<int, string>();
            Dictionary<int, string> leaderboard = new Dictionary<int, string>();


            foreach (InteractiveUser user in App.Ievent.Users)
            {
                user.CalculateSum();
                tmpdic.Add(user.points_sum, user.orgUser.nickname);
            }

            var list = tmpdic.Keys.ToList();
            list.Sort();

            foreach (var key in list)
            {
                leaderboard.Add(key, tmpdic[key]);
            }
            return leaderboard;
        }

        //Stats for Player
        public static int[] Stats()
        {
            int[] tmpArr = new int[App.activePlayer.points.Count];
            for (int i = 0; i < 10; i++)
            {
                tmpArr[i] = CalculatePoints(App.activePlayer.points[i].arrownumber, App.activePlayer.points[i].ring);
            }
            return tmpArr;
        }

        #endregion
    }
}
