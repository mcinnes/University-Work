/*
 Description : Practical Test 3 solution
 Written by : Matt McInnes 214119048
 Date : Sep 2014
 This program collects user data and their hours worked, 
 calculates their pay and outputs the results.
*/

using System;
using System.IO;

namespace PT3
{
    class Pay
    {

        public static class var
        {
			//Yes im aware I should have used a 2d array, I lost 8 hours of work and this was easier. Sorry
            public static double [] taxRate = new double[50];
            public static double [] payRate = new double[50];
            public static string [] full_name =  new string[50];
            public static string [] street_number = new string[50];
            public static string [] address = new string[50];
            public static string [] state = new string[50];
            public static string [] post_code = new string[50];
            public static string [] phone_number = new string[50];
            public static float [] annual_salary = new float [50];
			//Index of used when adding people. If a single index was used than after a seach names would get overwritten
            public static int addIndex = 0;
			//Index used for searching
            public static int findIndex = 0;
      
            
           

        }



        static void AddPerson() 
        {
               // Initialise the data
             
			//Reset Variables
                        var.full_name[var.addIndex] = "";
                        var.street_number[var.addIndex] = "";
                        var.address[var.addIndex] = "";
                        var.state[var.addIndex] = "";
                        var.post_code[var.addIndex] = "";
                        var.phone_number[var.addIndex] = "";
                        var.annual_salary[var.addIndex] = 0.0F;


                 
                      
                        // Temporary variable used to store ReadLine value
                        string vtemp = "";
                        bool validValue = false;
                        string response = "";
                        vtemp = "";
                        validValue = false;

			//Data input and validation
			while (validValue == false)
                        {
                            Console.Write("Enter the Full Name: > ");
                            vtemp = Console.ReadLine();
                            // Validate the data entered
                            // Check value is not empty
                            if (vtemp == "")
                            {
                                Console.WriteLine("Error : Full Name cannot be empty. Please try again...");
                                validValue = false;
                            }
                            else
                            {
                                // Check alphanumeric
                                // Check each character
                                for (int c = 0; c < vtemp.Length; c++)
                                {
                                    // If not a valid character
                                    if ((vtemp[c] >= 'a' && vtemp[c] <= 'z') || (vtemp[c] >= 'A' && vtemp[c] <= 'Z') || (vtemp[c] >= '0' && vtemp[c] <= '9') || vtemp[c] == ' ')
                                    {
                                        validValue = true;
                                    }
                                    else
                                    {
                                        // If not a valid character
                                        Console.WriteLine("Error : Full Name must be alphanumeric characters only (a-z, A-Z, 0-9). Please try again...");
                                        validValue = false;
                                        break;
                                    }
                                }
                            }
                        }
                        // Assign the value to the variable
                        var.full_name[var.addIndex] = vtemp;

                        // Get Street Number
                        // Reset the variables to their defaults
                        vtemp = "";
                        validValue = false;
                        while (validValue == false)
                        {
                            Console.Write("Enter the Street Number: > ");
                            vtemp = Console.ReadLine();
                            // Validate the data entered
                            // Check value is not empty
                            if (vtemp == "")
                            {
                                Console.WriteLine("Error : Street Number cannot be empty. Please try again...");
                                validValue = false;
                            }
                            else
                            {
                                // Check alphanumeric
                                // Check each character
                                for (int c = 0; c < vtemp.Length; c++)
                                {
                                    // If not a valid character
                                    if ((vtemp[c] >= 'a' && vtemp[c] <= 'z') || (vtemp[c] >= 'A' && vtemp[c] <= 'Z') || (vtemp[c] >= '0' && vtemp[c] <= '9') || vtemp[c] == ' ')
                                    {
                                        validValue = true;
                                    }
                                    else
                                    {
                                        // If not a valid character
                                        Console.WriteLine("Error : Street Number must be alphanumeric characters only (a-z, A-Z, 0-9). Please try again...");
                                        validValue = false;
                                        break;
                                    }
                                }
                            }
                        }
                        // Assign the value to the variable
                        var.street_number[var.addIndex] = vtemp;

                        // Get Street Address
                        // Reset the variables to their defaults
                        vtemp = "";
                        validValue = false;
                        while (validValue == false)
                        {
                            Console.Write("Enter the Street Address > ");
                            vtemp = Console.ReadLine();
                            // Validate the data entered
                            // Check value is not empty
                            if (vtemp == "")
                            {
                                Console.WriteLine("Error : Street Address cannot be empty. Please try again...");
                                validValue = false;
                            }
                            else
                            {
                                // Check alphanumeric
                                // Check each character
                                for (int c = 0; c < vtemp.Length; c++)
                                {
                                    // If not a valid character
                                    if ((vtemp[c] >= 'a' && vtemp[c] <= 'z') || (vtemp[c] >= 'A' && vtemp[c] <= 'Z') || (vtemp[c] >= '0' && vtemp[c] <= '9') || vtemp[c] == ' ')
                                    {
                                        validValue = true;
                                    }
                                    else
                                    {
                                        // If not a valid character
                                        Console.WriteLine("Error : Street Address must be alphanumeric characters only (a-z, A-Z, 0-9). Please try again...");
                                        validValue = false;
                                        break;
                                    }
                                }
                            }
                        }
                        // Assign the value to the variable
                        var.address[var.addIndex] = vtemp;

                        // Get State
                        // Reset the variables to their defaults
                        vtemp = "";
                        validValue = false;
                        while (validValue == false)
                        {
                            Console.Write("Enter the State > ");
                            vtemp = Console.ReadLine();
                            // Validate the data entered
                            // Check value is not empty
                            if (vtemp == "")
                            {
                                Console.WriteLine("Error : State cannot be empty. Please try again...");
                                validValue = false;
                            }
                            else
                            {
                                // Check alphanumeric
                                // Check each character
                                for (int c = 0; c < vtemp.Length; c++)
                                {
                                    // If not a valid character
                                    if ((vtemp[c] >= 'A' && vtemp[c] <= 'Z'))
                                    {
                                        validValue = true;
                                    }
                                    else
                                    {
                                        // If not a valid character
                                        Console.WriteLine("Error : State must be UPPER case and alphabetic characters only. Please try again...");
                                        validValue = false;
                                        break;
                                    }
                                }
                            }
                        }
                        // Assign the value to the variable
                        var.state[var.addIndex] = vtemp;

                        // Get Post Code
                        // Reset the variables to their defaults
                        vtemp = "";
                        validValue = false;
                        while (validValue == false)
                        {
                            Console.Write("Enter the Post Code > ");
                            vtemp = Console.ReadLine();
                            // Validate the data entered
                            // Check value is not empty
                            if (vtemp == "")
                            {
                                Console.WriteLine("Error : Post Code cannot be empty. Please try again...");
                                validValue = false;
                            }
                            else
                            {
                                // Check alphanumeric
                                // Check each character
                                for (int c = 0; c < vtemp.Length; c++)
                                {
                                    // If not a valid character
                                    if ((vtemp[c] >= '0' && vtemp[c] <= '9'))
                                    {
                                        validValue = true;
                                    }
                                    else
                                    {
                                        // If not a valid character
                                        Console.WriteLine("Error : Post Code must be numeric characters only (0-9). Please try again...");
                                        validValue = false;
                                        break;
                                    }
                                }
                                if (validValue == true && vtemp.Length != 4) // Check the length is 4 chars
                                {
                                    Console.WriteLine("Error : Post Code must be 4 numeric values only. Please try again...");
                                    validValue = false;
                                }
                            }
                        }
                        // Assign the value to the variable
                       var.post_code[var.addIndex] = vtemp;

                        // Get Phone Number
                        // Reset the variables to their defaults
                        vtemp = "";
                        validValue = false;
                        while (validValue == false)
                        {
                            Console.Write("Enter the Phone Number > ");
                            vtemp = Console.ReadLine();
                            // Validate the data entered
                            // Check value is not empty
                            if (vtemp == "")
                            {
                                Console.WriteLine("Error : Phone Number cannot be empty. Please try again...");
                                validValue = false;
                            }
                            else
                            {
                                // Check alphanumeric
                                // Check each character
                                for (int c = 0; c < vtemp.Length; c++)
                                {
                                    // If not a valid character
                                    if ((vtemp[c] >= '0' && vtemp[c] <= '9'))
                                    {
                                        validValue = true;
                                    }
                                    else
                                    {
                                        // If not a valid character
                                        Console.WriteLine("Error : Phone Number must be numeric characters only (0-9). Please try again...");
                                        validValue = false;
                                        break;
                                    }
                                }
                            }
                        }
                        // Assign the value to the variable
                        var.phone_number[var.addIndex] = vtemp;
			//Tidy up
                        Console.Clear();

			//Add to addIndex, ready for the next set of details
            var.addIndex++;

                        }
                
        


		//Function for searching
        static void FindPerson()
        {

            string tempVal = "";

            Console.WriteLine("Please enter a name to search for");
            tempVal = Console.ReadLine();

            var.findIndex = Array.IndexOf(var.full_name, tempVal);
            Console.Write(var.findIndex);

            if (var.findIndex < 0)
            {
                Console.WriteLine("No records found!");

                Console.WriteLine("Please enter a name to search for");
                tempVal = Console.ReadLine();

                var.findIndex = Array.IndexOf(var.full_name, tempVal);
                Console.Write(var.findIndex);
            }
            else
            {
				// Console.Write(var.findIndex);

                DisplayPerson(var.findIndex);

            }


        }
		//Function for displaying people
        static void DisplayPerson(int index)
        {

                        //-----------------------------------------------------------
                        // Output the Person details
                        Console.WriteLine();
                        Console.WriteLine("Pay Information");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Person\t\t{0}", var.full_name[index]);
                        Console.WriteLine("\t\t{0} {1}, {2}, {3}", var.street_number[index], var.address[index], var.state[index], var.post_code[index]);
                        Console.WriteLine("\t\t{0}", var.phone_number[index]);
                        Console.WriteLine();
                        Console.WriteLine("Annual Salary\t{0:C0}", var.annual_salary[index]);
                
                        Console.WriteLine("----------------------------------------------------------");
                        Console.ReadLine();
        }


		//Deletion of people
        static void DeletePerson(int index)
        {
            Console.WriteLine("are you sure you wish to delete the current person? ");
            Console.WriteLine("Press x to return to the menu ");

           string response = Console.ReadLine().ToLower(); ;
 switch (response)
                {
                    case "x": // Get the user data
                        Main();

                        break;
                         default:                       
				Array.removeAt(var.full_name, var.findIndex);      
				Array.removeAt(var.tax_rate, var.findIndex);      
				Array.removeAt(var.payrate, var.findIndex);      
				Array.removeAt(var.street_number, var.findIndex);      
				Array.removeAt(var.address, var.findIndex);      
				Array.removeAt(var.state, var.findIndex); 
				Array.removeAt(var.post_code, var.findIndex); 
				Array.removeAt(var.phone_number, var.findIndex);      
				Array.removeAt(var.annual_salary, var.findIndex);

 break;

Console.WriteLine("Done");
Console.ReadLine();
}


  }


        static void CalaculateDisplayPay(int index)
        {
                 
            
                            // Define and initialise all variables
                        float hours_worked = 0.0F;
                        float gross_pay = 0.0F;
                        float tax = 0.0F;
                        float net_pay = 0.0F;
                        float pay_rate = 0.0F;
                        float tax_rate = 0.0F;

                        // Reset the variables to their defaults
                       string vtemp = "";
                       bool validValue = false;
                        while (validValue == false)
                        {
                            Console.Write("Enter the Total Hours Worked > ");
                            vtemp = Console.ReadLine();
                            // Validate the data entered
                            // Check value is not empty
                            if (vtemp == "")
                            {
                                Console.WriteLine("Error : Total Hours Worked cannot be empty. Please try again...");
                                validValue = false;
                            }
                            else
                            {
                                // Convert the input (text) to a float
                                validValue = float.TryParse(vtemp, out hours_worked);
                                if (validValue == false)
                                {
                                    Console.WriteLine("Error : Total Hours Worked must be decimal value only. Please try again...");
                                }
                                // Check value is positive
                                if (hours_worked < 0)
                                {
                                    Console.WriteLine("Error : Total Hours Worked must be greater than or equal to 0. Please try again...");
                                    validValue = false;
                                }
                            }
                                        }



                       // Get the pay and tax rate
                        tax_rate = 0.0F;
                        pay_rate = 0.0F;
                        if (var.annual_salary[var.findIndex] >= 0F && var.annual_salary[var.findIndex] < 16501F) // Annual Salary $0 - $16,500 : Tax rate is 11.32%, Pay rate is $8.68 per hour
                        {
                            tax_rate = 11.32F;
                            pay_rate = 8.68F;
                        }
                        else
                            if (var.annual_salary[var.findIndex] >= 16501F && var.annual_salary[var.findIndex] < 19501F)  // Annual Salary $16,501 - $19,500 : Tax rate is 15.14%, Pay rate is $10.26 per hour
                            {
                                tax_rate = 15.14F;
                                pay_rate = 10.26F;
                            }
                            else
                                if (var.annual_salary[var.findIndex] >= 19501F && var.annual_salary[var.findIndex] < 29501F)  // Annual Salary $19,501 - $29,500 : Tax rate is 22.65%, Pay rate is $15.54 per hour
                                {
                                    tax_rate = 22.65F;
                                    pay_rate = 15.54F;
                                }
                                else
                                    if (var.annual_salary[var.findIndex] >= 29501F && var.annual_salary[var.findIndex] < 33501F)  // Annual Salary $29,501 - $33,500 : Tax rate is 27.12%, Pay rate is $17.63 per hour
                                    {
                                        tax_rate = 27.12F;
                                        pay_rate = 17.63F;
                                    }
                                    else
                                        if (var.annual_salary[var.findIndex] >= 33501F && var.annual_salary[var.findIndex] < 39501F)  // Annual Salary $33,501 - $39,500 : Tax rate is 30.92%, Pay rate is $20.79 per hour
                                        {
                                            tax_rate = 30.92F;
                                            pay_rate = 20.79F;
                                        }
                                        else
                                            if (var.annual_salary[var.findIndex] >= 39501F && var.annual_salary[var.findIndex] < 59501F)  // Annual Salary $39,501 - $59,500 : Tax rate is 35.72%, Pay rate is $31.31 per hour
                                            {
                                                tax_rate = 35.72F;
                                                pay_rate = 31.31F;
                                            }
                                            else
                                                if (var.annual_salary[var.findIndex] >= 59501F && var.annual_salary[var.findIndex] < 89501F)  // Annual Salary $59,501 - $89,500 : Tax rate is 40.72%, Pay rate is $47.12 per hour
                                                {
                                                    tax_rate = 40.72F;
                                                    pay_rate = 47.12F;
                                                }
                                                else
                                                    if (var.annual_salary[var.findIndex] >= 89501F)  // Annual Salary greater than $89,500 : Tax rate is 50.52%, Pay rate is $55.67 per hour
                                                    {
                                                        tax_rate = 50.52F;
                                                        pay_rate = 55.67F;
                                                    }

            
            
                          // Calculate gross pay
                        gross_pay = hours_worked * pay_rate;
                        // Calculate total tax
                        tax = gross_pay * (tax_rate / 100);
                        // Calculate net pay
                        net_pay = gross_pay - tax;

						// Output the Person details
                        Console.WriteLine();
                        Console.WriteLine("Pay Information");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Person\t\t{0}", var.full_name[index]);
                        Console.WriteLine("\t\t{0} {1}, {2}, {3}", var.street_number[index], var.address[index], var.state[index], var.post_code[index]);
                        Console.WriteLine("\t\t{0}", var.phone_number[index]);
                        Console.WriteLine();
                        Console.WriteLine("Annual Salary\t{0:C0}", var.annual_salary[index]);
                        Console.WriteLine();
                        Console.WriteLine("Hours Worked\t{0} hours", hours_worked);
                        Console.WriteLine();
                        Console.WriteLine("Pay Rate\t{0,10:C2}", pay_rate);
                        Console.WriteLine("Tax Rate\t{0,10}%", tax_rate.ToString("F2"));
                        Console.WriteLine();
                        // Output the Pay details
                        Console.WriteLine("Gross Pay\t{0,10:C2}", gross_pay);
                        Console.WriteLine("Tax\t\t{0,10:C2}", tax);
                        Console.WriteLine("Net Pay\t\t{0,10:C2}\n", net_pay);
    }


        static void Main()
        {
           
            // Define the constants
            string response;
            response = "";
            //-----------------------------------------------------------
            // Get data from user until the user enters an 'x'
            while (response != "x")
            {
                // Display the menu 
                Console.WriteLine("Menu");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Add a person’s details (a)");
                Console.WriteLine("Find a person’s details (s)");
                Console.WriteLine("Display current person’s details (p)");
                Console.WriteLine("Delete current person’s details (d)");
                Console.WriteLine("Calculate and display pay slip  for current person (c) ");
                Console.WriteLine("Exit (x)");
                Console.WriteLine("----------------------------");
                Console.Write("Enter your choice >");
                // Get the response and convert it to lower case
                response = Console.ReadLine().ToLower(); ;
                
                // Process the reasponse
                switch (response)
                {
                    case "a": // Get the user data
                        AddPerson();

                        break;
                    case "s":
                        // find how to delete
                        FindPerson();
                        break;
                         case "d":
                        // find how to delete
                        DeletePerson(var.findIndex);
                        break;
                    case "p":
                        // Check the person is entered and a salary entered
                        DisplayPerson(var.findIndex);
                        break;
                          case "c":
                        // Check the person is entered and a salary entered
                        CalaculateDisplayPay(var.findIndex);
                        break;
                          case "x":
                        // Check the person is entered and a salary entered
					Environment.Exit(0);
					//   Much exit such leave
					break;
                    default:
                        Console.WriteLine("\nError : {0} is not a valid menu option.\n", response);
                        break;
                }
            }
        }
    }
}


