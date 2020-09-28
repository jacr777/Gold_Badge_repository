using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;

namespace Komodo_Claims_AC
{
    class ProgramUI
    {
        private Claim_Repository _claimrepo = new Claim_Repository();

        public void Run()
        {
            ClaimMenu();
            //SeedClaimList();
        }
        private void ClaimMenu()
        {
            bool keepClaimRunning = true;
            while (keepClaimRunning)
            {


                //Display Options to the user
                Console.WriteLine("Select menu option:\n" +

                    "\t1. Add a new claim\n" +
                    "\t2. See all claims\n" +
                    "\t3. Update a claim\n" +
                    "\t4. Remove a claim\n\n" +
                    "\t0. Exit");
                //Get Users Input
                string input = Console.ReadLine();

                //Evaluate the user's Input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateClaim(); //Create New Claim
                        break;
                    case "2":
                        ReadAllClaims(); //See All Claims
                        break;
                    case "3":
                        UpdateClaim(); //Update A Claim
                        break;
                    case "4":
                        DeleteClaim(); //Remove a Claim
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!!!"); //Exit
                        keepClaimRunning = false;
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
        //1 Create a Claim
        private void CreateClaim()
        {

            Console.Clear();
            Claim newClaim = new Claim();

            //Claim Number Id
            Console.WriteLine("Enter the claim Id;");
            string claimIdAsString = Console.ReadLine();
            int claimIdAsInt = int.Parse(claimIdAsString);
            newClaim.ClaimId = claimIdAsInt;

            //Claim Type
            Console.WriteLine("Enter the claim Type;\n" +
                "\t1. Car\n" +
                "\t2. Home\n" +
                "\t3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);

            //Claim Description
            Console.WriteLine("Enter Description;");
            string description = Console.ReadLine();
            newClaim.Description = description;


            //Claim Amount
            Console.WriteLine("Enter the claim Amount;");
            string claimAmountAsString = Console.ReadLine();
            decimal claimAmountAsDecimal = decimal.Parse(claimAmountAsString);
            newClaim.ClaimAmount = claimAmountAsDecimal;

            //Date Of the Incident
            Console.WriteLine("Enter the date of the incident;\n" +
                "\tDay(DD):");
            var dayI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tMonth(MM): ");
            var monthI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tYear(YYYY): ");
            var yearI = Convert.ToInt32(Console.ReadLine());
            DateTime dateI = new DateTime(yearI, monthI, dayI,0,0,0);
            newClaim.DateOfIncident = dateI;

            //Date Of the Claim
            Console.WriteLine("Enter the date of the claim;\n" +
                "\tDay(DD):");
            var dayC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tMonth(MM): ");
            var monthC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tYear(YYYY): ");
            var yearC = Convert.ToInt32(Console.ReadLine());
            DateTime dateC = new DateTime(yearC, monthC, dayC,0,0,0);                     
            newClaim.DateOfClaim = dateC;

            //Is Claim Valid
            int daysBetween = (int)(dateC - dateI).TotalDays;
         
            if (daysBetween < 30)
            {
                newClaim.IsValid = true;
                Console.WriteLine("\tClaim is Valid\n" +
                    "\tPress any Key to continue");
            }
            else
            {
                newClaim.IsValid = false;
                Console.WriteLine("\tClaim is Invalid\n" +
                        "\tPress any Key to continue");

            }
            _claimrepo.AddClaim(newClaim);
        }
        //2 See all Claims
        private void ReadAllClaims()
        {
            Console.Clear();
            List<Claim> claimList = _claimrepo.GetClaims();

            Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-10} {4,-20} {5,-20} {6,-15}", "Claim ID","Claim Type","Description","Amount $","Date of Incident","Date of Claim","Is Valid?");
            foreach (Claim id in claimList)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-10} {4,-20} {5,-20} {6,-15}",$"{id.ClaimId}",$"{id.ClaimType}",$"{id.Description}",$"${id.ClaimAmount}",$"{id.DateOfIncident.ToString("d")}",$"{id.DateOfClaim.ToString("d")}",$"{id.IsValid}");
            }

        }
        //3 Update a Claim
        private void UpdateClaim()
        {
            //Display All Claims
            ReadAllClaims();
            //Ask for the title to update
            Console.WriteLine("\n Enter the claim you want to update:");
            //Get that title
            string oldclaimIdAsString = Console.ReadLine();
            int oldId = int.Parse(oldclaimIdAsString);

            //We build a new object
            Claim newClaim = new Claim();

            //Claim Number Id
            Console.WriteLine("Enter the claim Id;");
            string claimIdAsString = Console.ReadLine();
            int claimIdAsInt = int.Parse(claimIdAsString);
            newClaim.ClaimId = claimIdAsInt;

            //Claim Type
            Console.WriteLine("Enter the claim Type;\n" +
                "\t1. Car\n" +
                "\t2. Home\n" +
                "\t3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);

            //Claim Description
            Console.WriteLine("Enter Description;");
            string description = Console.ReadLine();
            newClaim.Description = description;

            //Claim Amount
            Console.WriteLine("Enter the claim Amount;");
            string claimAmountAsString = Console.ReadLine();
            decimal claimAmountAsDecimal = decimal.Parse(claimAmountAsString);
            newClaim.ClaimAmount = claimAmountAsDecimal;

            //Date Of the Incident
            Console.WriteLine("Enter the date of the incident;\n" +
                "\tDay(DD):");
            var dayI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tMonth(MM): ");
            var monthI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tYear(YYYY): ");
            var yearI = Convert.ToInt32(Console.ReadLine());
            DateTime dateI = new DateTime(yearI, monthI, dayI, 0, 0, 0);
            newClaim.DateOfIncident = dateI;

            //Date Of the Claim
            Console.WriteLine("Enter the date of the claim;\n" +
                "\tDay(DD):");
            var dayC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tMonth(MM): ");
            var monthC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tYear(YYYY): ");
            var yearC = Convert.ToInt32(Console.ReadLine());
            DateTime dateC = new DateTime(yearC, monthC, dayC, 0, 0, 0);
            newClaim.DateOfClaim = dateC;

            //Is Claim Valid
            int daysBetween = (int)(dateC - dateI).TotalDays;

            if (daysBetween < 30)
            {
                newClaim.IsValid = true;
                Console.WriteLine("\tClaim is Valid\n" +
                    "\tPress any Key to continue");
            }
            else
            {
                newClaim.IsValid = false;
                Console.WriteLine("\tClaim is Invalid\n" +
                        "\tPress any Key to continue");

            }
    
            //Verify the update worked
            bool wasUpdated = _claimrepo.UpdateClaim(oldId, newClaim);
            if (wasUpdated)
            {
                Console.WriteLine("The claim was updated.");
            }
            //Otherwise state it was not deleted(not found)
            else
            {
                Console.WriteLine("Claim not found");
            }
        }
            //4 Delete a claim
            public void DeleteClaim()
        {
            ReadAllClaims();

            //Get the Team to delete
            Console.WriteLine("\n Enter the Claim ID you want to delete:");
            string claimIdAsString = Console.ReadLine();
            int claimIdAsInt = int.Parse(claimIdAsString);
            //Call delete method
            bool wasDeleted = _claimrepo.RemoveClaim(claimIdAsInt);
            //If the menu was deleted say so
            if (wasDeleted)
            {
                Console.WriteLine("The claim was deleted.");
            }
            //Otherwise state it was not deleted(not found)
            else
            {
                Console.WriteLine("The claim was not found");
            }

        }
        //Seed Methond
       
    }
}
