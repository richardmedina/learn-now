using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Contracts
{
    public class ServiceResult
    {
        public CodeResult CodeResult { get; set; }
        public IEnumerable<ErrorMessage> ErrorMessages { get; set; }
    }
}
