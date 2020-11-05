using System;
using System.Collections.Generic;

namespace Task_Junior_1._2.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

}
