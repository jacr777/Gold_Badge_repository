using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge
{
    class ProgramUI
    {
        private BadgeRepository Badges = new BadgeRepository();

        public void Run()
        {
            BadgeMenu();
            //SeedBadgeList();
        }

        private void BadgeMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //Display Options to the user
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +

                    "\t1. Add a badge\n" +
                    "\t2. Edit a badge.\n" +
                    "\t3. List all Badges\n\n" +

                    "\t0. Exit");
                //Get Users Input
                string input = Console.ReadLine();

                //Evaluate the user's Input and act accordingly
                switch (input)
                {
                    case "1":
                        AddBadge(); //Creates a New Badge
                        break;
                    case "2":
                        EditBadge(); //Edits a Badge
                        break;
                    case "3":
                        ListBadges(); //See all Badges
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!!!"); //Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");

                Console.ReadKey();
                Console.Clear();
            }
        }
        //Add Badge
        private void AddBadge()
        {
            Console.Clear();
            //Instantiate the new badge
            Badge newBadge = new Badge();

            Console.WriteLine("Enter the Badge Id:");
            string badgeIdAsString = Console.ReadLine();
            int badgeAsInt = int.Parse(badgeIdAsString);
            newBadge.BadgeId = badgeAsInt;            

            Console.WriteLine("Enter the Door the badge needs access:");
            string door = Console.ReadLine();
            newBadge.Doors.Add(door);

            bool keepdoorrunning = true;
            while (keepdoorrunning){
                Console.WriteLine("Do you want to enter more doors:(Y/N)");
                string doorQuestion = Console.ReadLine().ToLower();
                                
                if(doorQuestion == "y")
                {
                    Console.WriteLine("Enter the Door the badge needs access:");
                    door = Console.ReadLine();
                    newBadge.Doors.Add(door);                   
                }
                else
                {
                    keepdoorrunning = false;
                }
            }

            Badges.AddBadge(newBadge.BadgeId,newBadge);

        }
        //Edit Badge
        private void EditBadge()
        {
            bool keepbadgerunning = true;
            while (keepbadgerunning)
            {
                //Display all badges
                ListBadges();
                Console.WriteLine("What badge would you like to update?");
                string badgeIdAsString = Console.ReadLine();             
                int badgeAsInt = int.Parse(badgeIdAsString);
                Dictionary<int, Badge> listOfBadges = Badges.GetListOfBadges();
                if (listOfBadges.ContainsKey(badgeAsInt)){
                    List<string> doors;
                    int badge;
                    int doorCount = listOfBadges[badgeAsInt].Doors.Count;
                    doors = listOfBadges[badgeAsInt].Doors;
                    badge = listOfBadges[badgeAsInt].BadgeId;
                    if(doorCount == 1)
                    {
                        Console.WriteLine( $"Badge: {badge} has access to door {string.Format("{0}", string.Join(" & ", doors))}.");
                    }
                    else if(doorCount > 1)
                    {
                        Console.WriteLine($"Badge: {badge} has access to doors {string.Format("{0}", string.Join(" & ", doors))}.");
                    }
                    else
                    {

                    }
                    Console.WriteLine("What would you like to do?\n" +
                    "\t1. Add a door\n" +
                    "\t2. Remove a door\n" +
                    "\t0. Exit");
                    //Get Users Input
                    string input = Console.ReadLine();

                    //Evaluate the user's Input and act accordingly
                    switch (input)
                    {
                        case "1":
                            AddDoor(badge); //Creates a New Badge
                            break;
                        case "2":
                            DeleteDoor(badge); //Edits a Badge
                            break;

                        case "0":
                            Console.WriteLine("Goodbye!!!"); //Exit
                            keepbadgerunning = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid number");
                            break;
                    }
                    
                    Console.WriteLine("Please press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    keepbadgerunning = false;
                }
                else
                {
                    Console.WriteLine("Could not find that badge");
                    Console.WriteLine("Please press any key to exit to the main menu...");
                    Console.ReadKey();
                    Console.Clear();
                    keepbadgerunning = false;
                }
            }

        }
        //See All Badges
        private void ListBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> listOfBadges = Badges.GetListOfBadges();

            Console.WriteLine("{0,-25} {1,-15}", "Badge #", "Door Access");
            foreach (KeyValuePair<int, Badge> b in listOfBadges)
            {
                Console.WriteLine("{0,-25} {1,-15}", $"{b.Value.BadgeId}",string.Format("{0}", string.Join(", ", b.Value.Doors)));               
            }
        }

        //Remove a Door
        private void DeleteDoor(int badge)
        {
            Console.WriteLine("What is the door you want to remove:");
            string doorRemove = Console.ReadLine();
            Badges.RemoveDoors(badge,doorRemove);
            Console.WriteLine("Door was removed");
            
            Dictionary<int, Badge> listOfBadges = Badges.GetListOfBadges();
            List<string> doors;
            int newdoorcount= listOfBadges[badge].Doors.Count;
            doors = listOfBadges[badge].Doors;
            badge = listOfBadges[badge].BadgeId;
            if (newdoorcount == 1)
            {
                Console.WriteLine($"Badge: {badge} has access to door {string.Format("{0}", string.Join(" & ", doors))}.");
            }
            else if (newdoorcount > 1)
            {
                Console.WriteLine($"Badge: {badge} has access to doors {string.Format("{0}", string.Join(" & ", doors))}.");
            }   
        }
        //Add a Door
        private void AddDoor(int badge)
        {
            Console.WriteLine("What is the door you want to Add:");
            string doorAdd = Console.ReadLine();
            Badges.AddDoors(badge, doorAdd);
            Console.WriteLine("Door was Added");

            Dictionary<int, Badge> listOfBadges = Badges.GetListOfBadges();
            List<string> doors;
            int newdoorcount = listOfBadges[badge].Doors.Count;
            doors = listOfBadges[badge].Doors;
            badge = listOfBadges[badge].BadgeId;
            if (newdoorcount == 1)
            {
                Console.WriteLine($"Badge: {badge} has access to door {string.Format("{0}", string.Join(" & ", doors))}.");
            }
            else if (newdoorcount > 1)
            {
                Console.WriteLine($"Badge: {badge} has access to doors {string.Format("{0}", string.Join(" & ", doors))}.");
            }
        }
        
    }
}
