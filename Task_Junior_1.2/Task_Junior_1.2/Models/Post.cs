using System;
using System.Collections.Generic;

namespace Task_Junior_1._2.Models
{
    public partial class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
