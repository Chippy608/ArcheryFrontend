using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TestAPI_Archery.DB;

namespace ArcheryFrontend
{
    public class InteractiveEvent
    {
        #region Default Properties
        private Event orgEvent;
        private List<InteractiveUser> users;
        private Parcour parcour;

        public Event OrgEvent { get => orgEvent; set => orgEvent = value; }
        public List<InteractiveUser> Users { get => users; set => users = value; }
        public Parcour Parcour { get => parcour; set => parcour = value; }



        #endregion

        #region Interactive Properties
        private List<PointCounting> allPoints;

        public List<PointCounting> AllPoints
        {   get => allPoints;
            set
            {
                allPoints = value;

                foreach (PointCounting item in allPoints)
                {
                    foreach (InteractiveUser user in Users)
                    {
                        if (item.user_id == user.orgUser.Id && !user.points.Contains(TransformPoints(item)))
                        {
                            user.points.Add(TransformPoints(item));
                        }
                    }
                }
            }
        }
        #endregion


        public InteractiveEvent(Event org)
        {
            OrgEvent = org;
            foreach (Parcour parcour in App.parcours)
            {
                if (parcour.id == org.parcour_id)
                {
                    Parcour = parcour;
                }
            }
        }

        private static Points TransformPoints(PointCounting model)
        {
            return new Points { 
                ring = int.Parse(model.ring),
                arrownumber = model.arrownum,
                deernum = model.deernum
            };
        }

    }
}
