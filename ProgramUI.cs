using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class ProgramUI
    {
        private MenuRepository _menurepo = new MenuRepository();

        public void Run()
        {
            MenuMenu();
        }

        private void MenuMenu()
        {
            bool keepMenuRunning = true;
            while (keepMenuRunning)
            {
                //Display Options to the user
                Console.WriteLine("Select menu option:\n" +
                    "\t1. Create New Menu\n" +
                    "\t2. See All Menu in the Options\n" +
                    "\t3. Delete a Menu\n\n" +
                    "\t4. Exit");
                //Get Users Input
                string input = Console.ReadLine();
                //Evaluate the user's Input and act accordingly
                switch (input)
                {
                    case "1":
                        //  Add A Menu
                        AddMenu();
                        break;
                    case "2":
                        // Display all Menus
                        DisplayAllMenus();
                        break;
                    case "3":
                        //Delete a Menu
                        DeleteMenu();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye!!!");
                        keepMenuRunning = false;
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


        //Add a Menu
        private void AddMenu()
        {
            Console.Clear();
            Menu newMenu = new Menu();   
            //Menu Number Id
            Console.WriteLine("Enter the meal number;");
            string menuNumberAsString = Console.ReadLine();
            int menuNumberAsInt = int.Parse(menuNumberAsString);
            newMenu.MealNumber = menuNumberAsInt;
            //Menu Name
            Console.WriteLine("Enter the meal name;");
            newMenu.MealName = Console.ReadLine();
            //Menu Description
            Console.WriteLine("Enter the meal description;");
            newMenu.Description = Console.ReadLine();
            //Menu Price
            Console.WriteLine("Enter the meal Price;");
            string menuPriceAsString = Console.ReadLine();
            decimal menuPriceAsDecimal = decimal.Parse(menuPriceAsString);
            newMenu.Price = menuPriceAsDecimal;
            //Ingredients
            Console.WriteLine("Enter ingredients(separate by comma)");
            var ingredients = Console.ReadLine();
            List<string> listOfIngredients = ingredients.Split(new char[] {','}).ToList();
            newMenu.Ingredients = listOfIngredients;            
            _menurepo.AddItem(newMenu);
        }
        //Read Menus
        private void DisplayAllMenus()
        {
            Console.Clear();
            List<Menu> menuList = _menurepo.GetMenuList(); 
            foreach (Menu content in menuList)
            {
                Console.WriteLine(
                    $"Meal Number:{content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Meal Price: ${content.Price}\n" +
                    $"Description: {content.Description}\n" +
                    "Ingredients:");             
                foreach(string item in content.Ingredients)
                Console.WriteLine($"\t-{item}");
            }
        }
        //Delete a Menu
        private void DeleteMenu()
        {
            DisplayAllMenus();
            //Get the Menu to delete
            Console.WriteLine("\n Enter the Menu Number you want to delete:");
            string menuNumberAsString = Console.ReadLine();
            int menuNumberAsInt = int.Parse(menuNumberAsString);
            //Call delete method
            bool wasDeleted = _menurepo.DeleteMenu(menuNumberAsInt);
            //If the menu was deleted say so
            if (wasDeleted)
            {
                Console.WriteLine("The Menu Item was deleted.");
            }
            //Otherwise state it was not deleted(not found)
            else
            {
                Console.WriteLine("The Menu Item was not found");
            }
        }        
    }
}
