using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using BE;

namespace PL
{
    public class ConsoleMenus
    {
        BL.IBL bl;

        /// <summary>
        /// start menu
        /// </summary>
        public void clientMenu()//עבור לקוח ...
        {
            bl = BL.Factory.GetInstance();


            CultureInfo CultureInfo = new CultureInfo("de-DE");

            string data = "";
            BE.GuestRequest gr = new GuestRequest();

            while (!data.Equals("0"))
            {
                Console.WriteLine("add geust request, for exit click 0");
                if (data.Equals("0")) break;
                //  private name

                Console.WriteLine("\n please enter your private name");
                data = Console.ReadLine();
                gr.PrivateName = data;

                //  last name

                Console.WriteLine("\n please enter your last name");
                data = Console.ReadLine();
                gr.FamilyName = data;

                // email

                Console.WriteLine("\n please enter your e-mail");
                data = Console.ReadLine(); // להוסיף בדיקת מייל
                gr.MailAddress = data;

                //  Registration date

                DateTime RegistrationddateTime = new DateTime();
                RegistrationddateTime = DateTime.Now;
                gr.RegistrationDate = RegistrationddateTime;


                //  entry date

                Console.WriteLine("\n please enter your entry date");
                data = Console.ReadLine();
                DateTime entryDate = new DateTime();
                try
                {
                    entryDate = DateTime.Parse(data, CultureInfo);
                    gr.RegistrationDate = entryDate;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{"error wrong input, enter date in this format: dd mm yyyy"}'");
                }


                //  releaseDate


                Console.WriteLine("\n please enter your release date");
                data = Console.ReadLine();
                DateTime releaseDate = new DateTime();
                try
                {
                    releaseDate = DateTime.Parse(data, CultureInfo);
                    gr.RegistrationDate = releaseDate;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{"error wrong input, enter date in this format: dd mm yyyy"}'");
                }


                //  children 


                Console.WriteLine("\n please enter number of children");
                data = Console.ReadLine();
                int number = -1;
                if (!Int32.TryParse(data, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                }
                else if (number < 0)
                {
                    Console.WriteLine("Wrong input");
                }
                else
                {
                    gr.Children = number;
                }

                // adults

                Console.WriteLine("\n please enter number of adults");
                data = Console.ReadLine();
                number = -1;
                if (!Int32.TryParse(data, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                }
                else if (number < 0)
                {
                    Console.WriteLine("Wrong input");
                }
                else
                {
                    gr.Adults = number;
                }

                //  area

                Console.WriteLine("please enter the area:");
                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 0 for All areas");
                Console.WriteLine("Enter 1 for North area");
                Console.WriteLine("Enter 2 for South area");
                Console.WriteLine("Enter 3 for Center area");
                Console.WriteLine("Enter 4 for Jerusalem area");

                data = Console.ReadLine();

                if (!Int32.TryParse(data, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    break;

                }
                else if (number > 4 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    break;

                }
                else
                {

                    BE.AreaEnum choosEnum;
                    choosEnum = (BE.AreaEnum)number;
                    gr.Area = choosEnum;


                }

                // TYPE
                
                Console.WriteLine("please enter the Type:");
                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 0 for Unknown");
                Console.WriteLine("Enter 1 for Zimmer");
                Console.WriteLine("Enter 2 for Hotel");
                Console.WriteLine("Enter 3 for Camping");

                data = Console.ReadLine();

                if (!Int32.TryParse(data, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    break;

                }
                else if (number > 3 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    break;
                }
                else
                {
                    BE.TypeEnum choosEnum1;
                    choosEnum1 = (BE.TypeEnum)number;
                    gr.Type = choosEnum1;
                }


                //  pool

                Console.WriteLine("do you want to have a pool:");
                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 0 for Unknown");
                Console.WriteLine("Enter 1 for הכרחי");
                Console.WriteLine("Enter 2 for אפשרי");
                Console.WriteLine("Enter 3 for לא_מעוניין");

                data = Console.ReadLine();

                if (!Int32.TryParse(data, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    break;

                }
                else if (number > 3 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    break;
                }
                else
                {
                    BE.AttractionsEnum choosEnum2;
                    choosEnum2 = (BE.AttractionsEnum)number;
                    gr.Pool = choosEnum2;
                }

                // jacuzzi


                Console.WriteLine("do you want to have a jacuzzi:");
                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 0 for Unknown");
                Console.WriteLine("Enter 1 for הכרחי");
                Console.WriteLine("Enter 2 for אפשרי");
                Console.WriteLine("Enter 3 for לא_מעוניין");

                data = Console.ReadLine();

                if (!Int32.TryParse(data, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    break;

                }
                else if (number > 3 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    break;
                }
                else
                {
                    BE.AttractionsEnum choosEnum3;
                    choosEnum3 = (BE.AttractionsEnum)number;
                    gr.Pool = choosEnum3;
                }


                //  garden


                Console.WriteLine("do you want to have a garden:");
                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 0 for Unknown");
                Console.WriteLine("Enter 1 for הכרחי");
                Console.WriteLine("Enter 2 for אפשרי");
                Console.WriteLine("Enter 3 for לא_מעוניין");

                data = Console.ReadLine();

                if (!Int32.TryParse(data, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    break;

                }
                else if (number > 3 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    break;
                }
                else
                {
                    BE.AttractionsEnum choosEnum4;
                    choosEnum4 = (BE.AttractionsEnum)number;
                    gr.Pool = choosEnum4;
                }

                // 
                
            }



            // לממש הוספה של דרישת אירות ולשלוח לשכבת ביסניס לוגיק
        }


        public void HostingUnitMenu()//2.0
        {
            int number = -1;
            HostingUnitMenuEnum choosMenuEnum;

            do
            {


                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 1 to add new Hosting Unit");
                Console.WriteLine("Enter 2 to to enter to personal area");
                Console.WriteLine("Enter 0 to return to the previous menu");

                string input = Console.ReadLine();


                if (!Int32.TryParse(input, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    continue;
                }
                if (number > 2 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    continue;
                }

                choosMenuEnum = (HostingUnitMenuEnum)number;

                ConsoleMenus conMenu = new ConsoleMenus();
                switch (choosMenuEnum)
                {
                    case HostingUnitMenuEnum.Add_Hosting_Unit:
                        conMenu.Pl_AddHostingUnit();//2.1
                        break;
                    case HostingUnitMenuEnum.Personal_Area:
                        conMenu.PersonalArea();//2.2
                        break;
                    case HostingUnitMenuEnum.Exit:
                        break;
                }


            } while (number != 0);





        }






        //Hosting Unit Menu 
        public void Pl_AddHostingUnit() //2.1
        {

            Console.WriteLine("add Hosting Unit, for exit click 0");
            string data = "";
            BE.GuestRequest gr = new GuestRequest();

            while (!data.Equals("0"))
            {
                //לממש הוספת יחידת אירוח ולשלוח לביסניס לוגיק
            }
        }
        
        public void PersonalArea() //2.2
        {
            int number = -1;
            PersoanlAreaEnum choosMenuEnum;

            do
            {



                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 1 to update Hosting Unit");
                Console.WriteLine("Enter 2 to to delete Hosting Unit");
                Console.WriteLine("Enter 3 to to enter to orders menu");
                Console.WriteLine("Enter 0 to return to the previous menu");

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

                choosMenuEnum = (PersoanlAreaEnum)number;

                ConsoleMenus conMenu = new ConsoleMenus();
                switch (choosMenuEnum)
                {
                    case PersoanlAreaEnum.Update_Hosting_Unit:
                        conMenu.PL_UpdateHostingUnit();//2.2.1
                        break;
                    case PersoanlAreaEnum.Delete_Hosting_Unit:
                        conMenu.PL_DeleteHostingUnit();//2.3
                        break;
                    case PersoanlAreaEnum.Orders_Menu:
                        conMenu.PL_OrdersMenu();//3.0
                        break;
                    case PersoanlAreaEnum.Exit:
                        break;
                }


            } while (number != 0);



        }

        public void PL_UpdateHostingUnit() //2.2.1
        {
            //לקבל יחידת אירוח כמובן בהעתק
            //לממש עדכון יחידת אירוח ולשלוח לביסניס לוגיק
        }

        public void PL_DeleteHostingUnit()//2.3
        {
            //לקבל יחידת אירוח כמובן בהעתק
            //לממש מחיקת יחידת אירוח ולשלוח לביסניס לוגיק
        }

        public void PL_OrdersMenu()//3.0
        {
            int number = -1;
            OrdersMenuEnum choosMenuEnum;

            do
            {


                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 1 to enter to Queries For Customer List");
                Console.WriteLine("Enter 2 to to enter to List of Orders");
                Console.WriteLine("Enter 0 to return to the previous menu");

                string input = Console.ReadLine();


                if (!Int32.TryParse(input, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    continue;
                }
                if (number > 2 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    continue;
                }

                choosMenuEnum = (OrdersMenuEnum)number;

                ConsoleMenus conMenu = new ConsoleMenus();
                switch (choosMenuEnum)
                {
                    case OrdersMenuEnum.Queries_For_Customer_List:
                        conMenu.PL_QueriesForCustomerList();//4.1
                        break;
                    case OrdersMenuEnum.Orders_List:
                        conMenu.PL_OrdersList();//3.4
                        break;
                    case OrdersMenuEnum.Exit:
                        break;
                }


            } while (number != 0);






        }






        //Web  Manager  Menu


        public void WebManagerMenu() //4.0
        {
            int number = -1;
            ManagMenuEnum choosMenuEnum;

            do
            {



                Console.WriteLine("Choose one from the following options");
                Console.WriteLine("Enter 1 to enter to Queries For Customer List");
                Console.WriteLine("Enter 2 to enter to Queries For HostingUnit List");
                Console.WriteLine("Enter 3 to to enter to Queries For Order List ");
                Console.WriteLine("Enter 4 to to enter to Additional Queries");
                Console.WriteLine("Enter 0 to return to the previous menu");

                string input = Console.ReadLine();


                if (!Int32.TryParse(input, out number))
                {
                    number = -1;
                    Console.WriteLine("Wrong input");
                    continue;
                }
                if (number > 4 || number < 0)
                {
                    Console.WriteLine("Wrong number");
                    continue;
                }

                choosMenuEnum = (ManagMenuEnum)number;

                ConsoleMenus conMenu = new ConsoleMenus();
                switch (choosMenuEnum)
                {
                    case ManagMenuEnum.Queries_For_Customer_List:
                        conMenu.PL_QueriesForCustomerList();//4.1
                        break;
                    case ManagMenuEnum.Queries_For_HostingUnit_List:
                        conMenu.PL_QueriesForHostingUnitList();//4.2
                        break;
                    case ManagMenuEnum.Queries_For_Order_List:
                        conMenu.PL_QueriesForOrderList();//4.3
                        break;
                    case ManagMenuEnum.Additional_Queries:
                        conMenu.PL_AdditionalQueries();//4.4
                        break;
                    case ManagMenuEnum.Exit:
                        break;
                }


            } while (number != 0);




        }



        public void PL_OrdersList()//3.4
        {

                ///לקבל יחידת רשימת הזמנות כמובן בהעתק
                ///לבצע הדפסה למסך של רשימת ההזמנות 
              
            //3.2  
                ///לאפשר עדכון הזמנה וכמובן להוריד לביסניס לוגיק
            

        }


        public void PL_QueriesForCustomerList()//4.1
        {
            ///3.1
            // לממש אפשרת להוספת הזמנה 
        }

        public void PL_QueriesForHostingUnitList()//4.2
        {

        }

        public void PL_QueriesForOrderList()//4.3
        {

        }

        public void PL_AdditionalQueries()//4.4
        {

        }



    }
}
