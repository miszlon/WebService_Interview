using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeBlog.Model
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author()
        {

        }
        public Author(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
    }


}
