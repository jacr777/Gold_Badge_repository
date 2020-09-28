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

            //Display all badges
            ListBadges();
            Console.WriteLine("What badge would you like to update?");
            string badgeIdAsString = Console.ReadLine();
            int badgeAsInt = int.Parse(badgeIdAsString);


            bool keepEditingBadge = true;
            while (keepEditingBadge)
            {
                Console.Clear();
                //Display update options
                
                


                Console.WriteLine("What would you like to do?\n" +
                    "\t1. Remove a door\n" +
                    "\t2. Add a door\n" +
                    
                    "\t0. Exit");
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



    }
}
