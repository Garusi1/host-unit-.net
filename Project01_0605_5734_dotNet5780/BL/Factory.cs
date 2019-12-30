using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    /// <summary>
    /// get the singelton instance of BL
    /// </summary>
     static public class Factory
    {
         static IBL show = null;
        public static IBL GetShow()
        {
            if (show == null)
                show = new imp_BL();
            return show;
        }
    }

}
