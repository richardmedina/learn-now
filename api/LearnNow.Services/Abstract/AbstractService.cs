using System;
using System.Collections.Generic;
using LearnNow.Contracts;
using LearnNow.Domain;

namespace LearnNow.Services.Abstract
{
    public class AbstractService
    {
        protected LearnNowDbContext Context { get; }
        public AbstractService(LearnNowDbContext context)
        {
            Context = context;
        }

        protected virtual GenericServiceResult<TResult> GetSuccessResult<TResult>(TResult result)
        {
            var instance = new GenericServiceResult<TResult>
            {
                Result = result,
                CodeResult = CodeResult.Success
            };

            return instance;
        }
        protected virtual GenericServiceResult<TResult> GetFailedResult<TResult>(params ErrorMessage[] errorMessages)
        {
            return new GenericServiceResult<TResult>
            {
                CodeResult = CodeResult.Error,
                ErrorMessages = errorMessages
            };
        }
    }
}
