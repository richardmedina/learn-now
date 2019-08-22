using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnNow.Api.Models.Auth
{
    public class AuthRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
