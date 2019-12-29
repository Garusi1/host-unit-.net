using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {

        public int BankNumber { get; private set; }
        public string BankName { get; private set; }
        public int BranchNumber { get; private set; } //Branch = סניף
        public string BranchAddress { get; private set; }
        public string BranchCity { get; private set; }

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
