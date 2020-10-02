using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> Badges = new Dictionary<int, Badge>{}; //Instantiate Dictionary)

        //Create Badges
        public void AddBadge(int badgeId,Badge badge)
        {
            Badges.Add(badgeId,badge);          
        }
        //Read Bagdes
        public Dictionary<int, Badge> GetListOfBadges()
        {
            return Badges;
        }
        //Add Doors
        public void AddDoors(int badgeId, string door)
        {
            //BadgeRepo(all badges)->Badge(single badge based on Id)->Doors(internal list of strings)
            Badges[badgeId].Doors.Add(door);            

        }

        //Delete Doors
        public void RemoveDoors(int badgeId, string door)
        {
            Badges[badgeId].Doors.Remove(door);

        }
    }
}
