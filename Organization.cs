using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    class Organization : CounterAgent
    {
        public string OrganizationName { get; set; }        

        public Organization(string orgName, string creator, string iin) : base(creator, iin)
        {
            this.OrganizationName = orgName;
        }
    }
}
