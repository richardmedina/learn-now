using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Contracts
{
    public class ErrorMessage
    {
        public string Message { get; set; }

        public ErrorMessage() : this(string.Empty)
        {
        }

        public ErrorMessage(string message)
        {
            Message = message;
        }
    }
}
