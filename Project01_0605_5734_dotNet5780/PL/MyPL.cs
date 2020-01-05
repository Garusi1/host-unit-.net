using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace UI
{
    class MyUI
    {
        static void Main(string[] args)
        {
            CultureInfo CultureInfo = new CultureInfo("de-DE");

            string input = "";
            while (!input.Equals("x"))
            {
                //date input / exit
                Console.WriteLine("for client menu press 1 for host menu press 2 \n for exit press x" );
                input = Console.ReadLine();
                
                //client nemu
                if (input.Equals("1"))
                {
                    string data = "";
                    BE.GuestRequest gr = new GuestRequest();
                    Console.WriteLine("\n please enter your private name");
                    data= Console.ReadLine();
                    gr.PrivateName = data;
                    
                    Console.WriteLine("\n please enter your last name");
                    data = Console.ReadLine();
                    gr.FamilyName = data;

                    Console.WriteLine("\n please enter your e-mail");
                    data = Console.ReadLine();
                    gr.MailAddress = data;

                   
                    
                    Console.WriteLine("\n please enter your registration date");
                    data = Console.ReadLine();
                    DateTime mydateTime;
                    try
                    {
                         mydateTime = DateTime.Parse(data, CultureInfo);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse '{"error wrong input, enter date in this format: dd mm yyyy"}'");
                    }

                    gr.RegistrationDate = mydateTime;

                    string dateOfA = "0";
                    date = Console.ReadLine();
                }
                //host menu
                if (input.Equals("2"))
                {

                }

                //exit
                if (input.Equals("x"))
                {
                    break;
                }
                Console.WriteLine("\n please enter date of arrivel \n for exit press x");
                string date = "0";
                date = Console.ReadLine();

                //exit the loop

                if (date.Equals("x")) break;


                //parse the input (string) to date

                CultureInfo MyCultureInfo = new CultureInfo("de-DE");
                DateTime MyDateTime = DateTime.Parse(date, MyCultureInfo);
                int monthInt = MyDateTime.Month - 1;
                int dayInMonthInt = MyDateTime.Day - 1;

                // days input

                Console.WriteLine("please enter number of days for staying");
                string days = Console.ReadLine();

                //parse the number of days from string to integer

                int numberOfDaysInt = parseToInt(days);

                // check if the date is free:
                //      yes - book
                //      no - show the dates which not avalable

                bool isClear = false;
                int dayInMonthUpdated = 0;
                int monthUpdated = 0;
                //Console.WriteLine("day " + dayInMonthUpdated + " month: " + monthUpdated + " isclear=" + isClear);

                //calc the booked days:

                isBooked(year, MyDateTime, numberOfDaysInt, ref isClear, ref dayInMonthUpdated, ref monthUpdated);

                int firstOccupiedDay = 0;
                int firstOccupiedMonth = 0;
                int lastOccupiedDay = 0;
                int lastOccupiedMonth = 0;
                int count = 0;


                //if the input date is not clear
                if (isClear == false)
                {
                    dateBookedActions(year, MyDateTime, numberOfDaysInt, ref dayInMonthUpdated, ref monthUpdated, ref firstOccupiedDay, ref firstOccupiedMonth, ref lastOccupiedDay, ref lastOccupiedMonth);
                }

                // mark the occupied days as booked, eccept the last day
                else
                {
                    markOccupiedDays(year, MyDateTime, numberOfDaysInt, ref dayInMonthUpdated, ref monthUpdated);
                    Console.WriteLine("request confirmed");
                }

                // printBookedDates(year, MyDateTime, numberOfDaysInt, isClear, ref dayInMonthUpdated, ref monthUpdated, ref firstOccupiedDay, ref firstOccupiedMonth, out lastOccupiedDay, out lastOccupiedMonth, ref count);



                Console.WriteLine("**menu**   \n1. for booked dates list press 1 \n" +
                   "2. for statistics press 2 \n" +
                   "3. to exit press 9 \n" +
                   "4. to continue to another order press any key");
                string inp = Console.ReadLine();
                if (inp.Equals("1"))
                {
                    printBookedDates(year, MyDateTime, numberOfDaysInt, isClear, ref dayInMonthUpdated, ref monthUpdated, ref firstOccupiedDay, ref firstOccupiedMonth, out lastOccupiedDay, out lastOccupiedMonth, ref count);

                }
                else if (inp.Equals("2"))
                {
                    percentInYear(daysBooked(year));
                }
                else if (inp.Equals("9")) break;
                Console.ReadKey();
            }


        }
    }
}
