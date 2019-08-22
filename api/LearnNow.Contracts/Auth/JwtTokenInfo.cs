using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Contracts.Auth
{
    public class JwtTokenInfo
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
