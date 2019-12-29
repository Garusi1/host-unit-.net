using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {

        private int BankNumber { get;  set; }
        public string BankName { get;  set; }
        public int BranchNumber { get; private set; } //Branch = סניף
        public string BranchAddress { get; private set; }
        public string BranchCity { get; private set; }

    }
}
