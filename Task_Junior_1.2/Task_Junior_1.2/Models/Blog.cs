using System;
using System.Collections.Generic;

namespace Task_Junior_1._2.Models
{
    public partial class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Author { get; set; }
    }
}
