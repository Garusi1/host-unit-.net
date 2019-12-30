using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class imp_BL : IBL
    {

        DAL.IDAL IDAL;

        internal BL_imp()
        {
            IDAL = DAL.Factory.GetInstance();
        }


        public void addGuestRequest(GuestRequest guest)
        {
            throw new NotImplementedException();
        }

        public void addHostingUnit(HostingUnit hostUnit)
        {
            throw new NotImplementedException();
        }

        public void addOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void delHostingUnit(int hostUnitID)
        {
            throw new NotImplementedException();
        }

        public void GetBankBranchList(List<BankBranch> BankBranchList)
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> GetGuestRequestList(List<GuestRequest> GuestRequestList)
        {
            throw new NotImplementedException();
        }

        public void GetHostingUnit(List<HostingUnit> HostingUnitList)
        {
            throw new NotImplementedException();
        }

        public void GetOrderList(List<Order> OrderList)
        {
            throw new NotImplementedException();
        }

        public void updateGuestRequest(GuestRequest guest)
        {
            throw new NotImplementedException();
        }

        public void updateHostingUnit(HostingUnit hostUnit)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
