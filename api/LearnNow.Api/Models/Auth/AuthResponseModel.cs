﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnNow.Api.Models.Auth
{
    public class AuthResponseModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}