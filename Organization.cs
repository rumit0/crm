using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    [Serializable]
    class Organization : CounterAgent
    {
        public string OrganizationName { get; set; }

        private string contactphone;
        public string ContactPhone
        {
            get
            {
                return contactphone;
            }
            set
            {
                contactphone = value;
                DateOfChange = DateTime.Now;
            }
        }
        public DateTime DateOfChange { get; set; }
        public List<Person> contacts = new List<Person>();
        public Organization(string orgName, string creator, string iin) : base(creator, iin)
        {
            this.OrganizationName = orgName;
        }
    }
}
