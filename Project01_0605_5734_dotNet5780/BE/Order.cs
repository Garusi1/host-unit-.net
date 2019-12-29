using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order //מחלקה בשם Order שמייצגת הזמנה )כלומר את הקשר בין לקוח ליחידת אירוח( ותכלול:
    {
        public int HostingUnitKey { get; private set; }
        public int GuestRequestKey { get; private set; }


        private static int serialKey = 10000000;
        public int OrderKey { get; private set; }
        //ctor 
        public Order()
        {
            this.OrderKey = serialKey++;
        }

        ///eunm -
        public StatusEnum Status{ get; private set; }   //טרם טופל, נשלח מייל, נסגר מחוסר הענות של הלקוח ,נסגר בהיענות של הלקוח


        public DateTime CreateDate { get; }  //לממש == ליום יצירת ההזמנה
        public DateTime OrderDate { get; } //לממש == תאריך משלוח המייל ללקוח


    }
}
