using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcheryFrontend
{
    public class InteractiveUser
    {
        public string vname;
        public string lname;
        public User orgUser;
        public List<Points> points;
        public int points_sum;
        public List<InteractiveEvent> myEvents = new List<InteractiveEvent>();

        public InteractiveUser(User org)
        {
            orgUser = org;
            vname = org.vname;
            lname = org.lname;
            points = new List<Points>();
        }

        public void CalculateSum()
        {
            points_sum = 0;

            foreach (Points point in points)
            {
                points_sum += Logic.CalculatePoints(point.arrownumber, point.ring);
            }
        }
    }
}
