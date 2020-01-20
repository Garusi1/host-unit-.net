using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// add GuestRequest to DataBase
        /// </summary>
        /// <param name="guest"></param>
        void addGuestRequest(BE.GuestRequest guest);
        /// <summary>
        /// update GuestRequest on DataBase
        /// </summary>
        /// <param name="guest"></param>
        void updateGuestRequest(BE.GuestRequest guest);

        //HostingUnit

        /// add HostingUnit to DataBase
        void addHostingUnit(BE.HostingUnit hostUnit);
        /// del HostingUnit to DataBase
        void delHostingUnit(int hostUnitID);
        /// update HostingUnit on DataBase
        void updateHostingUnit(BE.HostingUnit hostUnit);

        //Order
        ///add Order to DataBase

        void addOrder(BE.Order order);
        ///update Order on DataBase
        void UpdateOrder(BE.Order order);


        //lists

        //get lists from DataBase
        IEnumerable<BE.GuestRequest> GetGuestRequestList();
        IEnumerable<BE.HostingUnit> GetHostingUnitList();
        IEnumerable<BE.Order> GetOrderList();
        IEnumerable<BE.BankBranch> GetBankBranchList();



        //תוספות

         BE.HostingUnit getHostingUnitByID(int ID);




        /// <summary>
        /// פונקציה שיכולה להחזיר את כל דרישות הלקוח המתאימות לתנאי מסויים.
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
       IEnumerable<BE.GuestRequest> getAllGRwithCondition(Func<BE.GuestRequest, bool> predicat = null);

        BE.Order getOrderByID(int ID);

        BE.GuestRequest getGuestRequestByID(int ID);

        /// <summary>
        /// //פונקציה שמקבלת תאריך ומספר ימי נופש ומחזירה את רשימת היחידות הפנויות בתאריך זה
        /// </summary>
        /// <param name="enteryDate">תאריך כניסה</param>
        /// <param name="numOfDayes">מספר ימים לשהות</param>
        /// <returns></returns>
        IEnumerable<BE.HostingUnit> availableUnits(DateTime enteryDate, int numOfDayes);


        /// <summary>
        /// פונקציה שמחשבת את מספר הימים שעברו בטווח תאריכים מסוים או מתאריך מסוים ועד היום.
        /// </summary>
        /// <param name="start">תאריך התחלה</param>
        /// <param name="end">תאריך סיום. במידה ולא הוזן קלט, תאריך ברירת מחדל - היום</param>
        /// <returns></returns>
        int numberOfDayes(DateTime start, DateTime end = default(DateTime));


        /// <summary>
        ///    //פונקציה שמקבלת מספר ימים ומחזירה רשימה של הזמנות שמשך הזמן שעבר מאז שנוצרו ועד היום גדול או שווה למספר שהתקבל
        /// </summary>
        /// <param name="numOfDays">מספר ימים</param>
        /// <returns>רשימת הזמנות שעונות לדרישה</returns>
        IEnumerable<BE.Order> ordersDayesPast(int numOfDays);



        /// <summary>
        /// פונקציה שמקבלת דרישת לקוח ומחזירה מספר הזמנות שנשלחו אליו.
        /// </summary>
        /// <param name="guest">מקבלת דרישת לקוח</param>
        /// <returns>מחזירה מספר הזמנות שנשלחו אליו</returns>
        int numeberOfOrderSendToGuestRequest(BE.GuestRequest guest);



        /// <summary>
        /// פונקציה שמקבלת יחידת אירוח ומחזירה את מספר ההזמנות שנשלחו / מספר ההזמנות
        ///שנסגרו בהצלחה עבור יחידה זו דרך האתר.
        /// </summary>
        /// <param name="HU"></param>
        /// <returns> מספר הזמנות שנסגרו בהצלחה</returns>
        int numeberOfOrderSendFromHostingUnit(BE.HostingUnit HU);




        /// <summary>
        /// רשימת דרישות לקוח מקובצת ע"פ אזור הנופש הנדרש.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<BE.AreaEnum, BE.GuestRequest>> groupByAreaGR();


        /// <summary>
        /// רשימת דרישות לקוח מקובצת ע"פ מספר הנופשים.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, BE.GuestRequest>> groupByNumberOfPeopleInGR(); // סידור לפי מספר הנופשים - מבוגרים וילדים



        /// <summary>
        /// רשימת מארחים מקובצת ע"פ מספר יחידות האירוח שהם מחזיקים
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, BE.Host>> groupByNumberOfHosintgUnitForHost();





        /// <summary>
        /// רשימת יחידות אירוח מקובצת  ע"פ אזור הנופש הנדרש.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<BE.AreaEnum, BE.HostingUnit>> groupByAreaHostingUnit();



        /// <summary>
        ///  מחזיר רשימת יחידות אירוח עבור מאחר ספיצפי
        /// </summary>
        /// <returns> ערך אחד. יש לבצע בפונקציה המזמנת forech</returns>
        IEnumerable<BE.HostingUnit> hostsHostingUnit(string IDHost);


        }
    }
