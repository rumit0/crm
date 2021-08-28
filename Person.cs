using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    class Person : CounterAgent
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Person(string creator, string name ,string lastName, string iin) : base(creator, iin)
        {
            this.Name = name;
            this.LastName = lastName;
        }
    }
}
