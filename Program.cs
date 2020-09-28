using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Program
    {
            //The Menu Items:
            //A meal number, so customers can say "I'll have the #5"
            //A meal name
            //A description
            //A list of ingredients,
            //A price



            //Your Task:
            //Create a Menu Class with properties, constructors, and fields.
            //Create a MenuRepository Class that has methods needed.
            //Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
            //Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.


            //Notes:
            //We don't need to be able to update items right now.
        static void Main(string[] args)
        {
            ProgramUI program = new ProgramUI();
            program.Run();
        }
    }
}
