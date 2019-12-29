using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {
        // capital letter its for the public function.
        private int bankNumber;
        public int BankNumber
        {
            get { return bankNumber; }
            set
            {
                //to define
            }
        }


        private string bankName;
        public string BankName
        {
            get { return bankName; }
            set
            {
                //to define
            }

        }


        private int branchNumber; //Branch = סניף
        public int BranchNumber
        {
            get { return branchNumber; }
            set
            {
                //to define
            }

        }



        private string branchAddress;
        public string BranchAddress
        {
            get { return branchAddress; }
            set
            {
                //to define
            }

        }


        private string branchCity;
        public string BranchCity
        {
            get { return branchCity; }
            set
            {
                //to define
            }

        }



        public override string ToString()
        {
            string output = "";
            output += "Bank Number: " + BankNumber + "\n" +
                "Bank Name: " + BankName + "\n" +
                "Branch Number:" + BranchNumber + "\n" +
                "Branch Address: " + BranchAddress + "\n" +
                "Branch City: " + BranchCity;


            return "output";
        }


    }
}
