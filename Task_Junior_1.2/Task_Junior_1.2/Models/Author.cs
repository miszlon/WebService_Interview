using FluentValidation;
using System;
using System.Collections.Generic;

namespace Task_Junior_1._2.Models
{
    public partial class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
