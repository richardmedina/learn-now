﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Contracts.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
