using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge
{
    class BadgeRepository
    {
        Dictionary<int, Badge> Badges = new Dictionary<int, Badge>{}; //Instantiate Dictionary

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
        public void AddDoors(int BadgeId,Badge badge)
        {

        }

        //Delete Doors
        //public bool RemoveDoors(int BadgeId, Badge badge)
        //{
        //    Badge content = GetBadgeById(BadgeId);
        //    if (content == null)
        //    {
        //        return false;
        //    }
        //    int intialCount = Badges.Count;
        //    Badges.Remove(content,badge); /////////////////HELP
        //    if(intialCount > Badges.Count)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }


        //}

        //Badge Helper
        public Badge GetBadgeById(int badgeId)
        {
            return Badges[badgeId];
        }
    }
}
