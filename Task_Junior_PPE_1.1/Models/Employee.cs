using System;
using System.Collections.Generic;
using Task_PPE.Models;

namespace Task_PPE.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Delegation = new HashSet<Delegation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string JoinName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Delegation> Delegation { get; set; }
    }
}
