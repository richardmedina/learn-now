using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Contracts
{
    public class GenericServiceResult<TResult>: ServiceResult
    {
        public TResult Result { get; set; }
    }
}
