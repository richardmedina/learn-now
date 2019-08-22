using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Contracts.Auth
{
    public class AuthorizeDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
