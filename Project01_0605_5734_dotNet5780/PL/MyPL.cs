using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace PL
{
    class MyPL
    {
        public static void Main(string[] args)
        {
            int number = -1;
            mainMenu choosM1;

            do
            {



                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 1 to add new Guest Request");
                Console.WriteLine("Enter 2 to to enter to HostingUnit menu");
                Console.WriteLine("Enter 3 to to enter to web manger menu");
                Console.WriteLine("Enter 0 to exit from the program");

                string input = Console.ReadLine();


                if (!Int32.TryParse(input, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    continue;
                }
                if (number > 3 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    continue;
                }

                choosM1 = (mainMenu)number;

                ConsoleMenus conMenu = new ConsoleMenus();
                switch (choosM1)
                {
                    case mainMenu.Add_Guest_Request:
                        conMenu.clientMenu();
                        break;
                    case mainMenu.Hosting_Unit_Menu:
                        conMenu.HostingUnitMenu();
                        break;
                    case mainMenu.WebManager:
                        conMenu.WebManagerMenu();
                        break;
                    case mainMenu.Exit:
                        break;
                }


            } while (number != 0);


        }
    }
}

