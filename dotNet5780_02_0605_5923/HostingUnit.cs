using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_0605_5923
{
    class HostingUnit : IComparable
    {
        private static int stSerialKey = 10000000;
        public int HostingUnitKey { get; private set; } ///  נקבע        בבנאי ע"פ השדה הסטטי.
        public bool[,] Diary = new bool[31, 12]; //C# reset automaticly the values .

        public bool this[DateTime generalDate] // define indexer 
        {
            private set => Diary[generalDate.Day - 1, generalDate.Month - 1] = value;
            get => Diary[generalDate.Day - 1, generalDate.Month - 1];
        }

        //ctor 
        public HostingUnit()
        {
            this.HostingUnitKey = stSerialKey++;
        }


        //overrides
        public override string ToString()  //יש לדרוס את מתודת ToString – כך שתציג עבור הבקשה את כל מאפייניה. 
        {
            string str = "Serial number of the hosting unit: " + this.HostingUnitKey + "\n";
            bool flag = false;
            int year = GuestRequest.year;
            DateTime beginDate = new DateTime(year, 01, 01);


            for (DateTime tempDate = beginDate; tempDate.Year == year; tempDate = tempDate.AddDays(1))
            {
                if (this[tempDate])
                {
                    if (!flag) { beginDate = tempDate; }
                    flag = true;
                }
                else if (flag)
                {
                    string begingDate = beginDate.ToString("dd/MM/yyyy");
                    string endDate = tempDate.AddDays(1).ToString("dd/MM/yyyy");
                    str += begingDate + " , " + endDate + "\n";

                    flag = false;
                }
            }
            return str;
        }

        // Methods
        public bool ApproveRequest(GuestRequest guestReq)
        {
            for (DateTime tempDate = guestReq.EntryDate; tempDate <= guestReq.LastNight; tempDate = tempDate.AddDays(1))
                if (this[tempDate]) { return false; }// check if the days are avaiable

            for (DateTime tempDate = guestReq.EntryDate; tempDate <= guestReq.LastNight; tempDate = tempDate.AddDays(1))
                this[tempDate] = true;//put the nights on matrix

            guestReq.IsApproved = true;

            return guestReq.IsApproved;
        }
        public int GetAnnualBusyDays()
        {
            int countNights = 0;
            int year = GuestRequest.year;

            for (DateTime tempDate = new DateTime(year, 1, 1); tempDate.Year == year; tempDate = tempDate.AddDays(1))
            { if (this[tempDate] == true) countNights++; }

            return countNights;
        }
        public float GetAnnualBusyPercentage()
        {
            int year = GuestRequest.year;

            DateTime tempStartYear = new DateTime(year, 1, 1);
            DateTime tempEndYear = new DateTime(year, 12, 31);

            float countDays = (float)GetAnnualBusyDays();

            //////TimeSpan span = tempEndYear.Subtract(tempStartYear); //span -> begin date- end date 
            //////float theCurrentYearDaysNumber = (float)span.Days;

            countDays /= (tempEndYear.DayOfYear);
            return countDays; //return the % 

        }
        public int CompareTo(Object other)
        {
            if (other == null) return 1;//if other not exist.
            HostingUnit otherHostingUnit = other as HostingUnit;
            if (otherHostingUnit != null)
                return this.GetAnnualBusyDays().CompareTo(otherHostingUnit.GetAnnualBusyDays());
            else
                throw new NotImplementedException();
        }


    }
}
