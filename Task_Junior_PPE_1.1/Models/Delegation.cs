using System;
using System.Collections.Generic;
using Task_PPE.Models;

namespace Task_PPE.Models
{
    public partial class Delegation
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public int Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Description { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public string CreatedBy { get; set; }
    }
}
