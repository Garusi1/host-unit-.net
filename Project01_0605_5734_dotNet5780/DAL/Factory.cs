using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL
{
    static public class Factory
    {
        static IDAL show = null;
        public static IDAL GetInstance()
        {
            if (show == null)
                show = new imp_Dal();
            return show;
        }

    }
}
