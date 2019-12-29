using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order //מחלקה בשם Order שמייצגת הזמנה )כלומר את הקשר בין לקוח ליחידת אירוח( ותכלול:
    {
        private int hostingUnitKey;
        public int HostingUnitKey
        {
            get { return hostingUnitKey; }
            set
            {
                //to define
            }

        }



        private int guestRequestKey;
        public int GuestRequestKey
        {
            get { return guestRequestKey; }
            set
            {
                //to define
            }

        }



        private static int serialKey = 10000000;


        private int orderKey;
        public int OrderKey
        {
            get { return orderKey; }
            set
            {
                //to define
                /// put attention
            }
        }




        ///eunm - //טרם טופל, נשלח מייל, נסגר מחוסר הענות של הלקוח ,נסגר בהיענות של הלקוח
        private StatusEnum status;
        public StatusEnum Status
        {
            get { return status; }
            set
            {
                //to define
            }
        }


        private DateTime createDate;
        public DateTime CreateDate  //לממש == ליום יצירת ההזמנה
        {
            get { return createDate; }
            set
            {
                //to define
            }

        }


        private DateTime orderDate;
        public DateTime OrderDate  //לממש == תאריך משלוח המייל ללקוח
        {
            get { return orderDate; }
            set
            {
                //to define
            }

        }


    }
}
