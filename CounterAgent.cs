using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    class CounterAgent
    {
        public Guid Id { get; }
        public string Iin { get; set; }
        public DateTime DateOfCreaction { get; set; }
        public string Creator { get; set; } 
        public DateTime DateOfChange { get; set; } 
        public string ChangeAuthor { get; private set; }

        public CounterAgent(string creator, string iin)
        {
            this.Creator = creator;
            this.DateOfCreaction = DateTime.Now;
            this.Id = Guid.NewGuid();
            if (iin.Length == 12)
            {
                this.Iin = iin;
            }
            else throw new ArgumentException("ИИН должен состоять из 12 символов!");
        }   




    }
}
