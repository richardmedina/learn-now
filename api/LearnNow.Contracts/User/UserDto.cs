﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Contracts.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
