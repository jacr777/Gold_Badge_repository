using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> Doors { get; set; } 
        public string Name { get; set; }

        public Badge() {
            Doors = new List<string>();//Instantiate the instance of the list
        }
        
        public Badge(int badgeId,List<string> doors,string name)
        {
            BadgeId = badgeId;
            Doors = doors;
            Name = name;
        }
        

    }
}
