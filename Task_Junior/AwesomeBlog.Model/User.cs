﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeBlog.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public User()
        {

        }
        public User(Guid id, string userName, string password, DateTime createdOn)
        {
            Id = id;
            UserName = userName;
            Password = password;
            CreatedOn = createdOn;
        }

    }
}

