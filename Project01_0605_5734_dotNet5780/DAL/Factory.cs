using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL
{
    public class Factory
    {
        static IDAL Show = null;
        public static IDAL GetInstance()
        {
            if (Show == null)
                Show = new imp_Dal();
            return Show;
        }

    }
}
