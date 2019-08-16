using LearnNow.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Services.Abstract
{
    public class AbstractService
    {
        protected LearnNowDbContext Context { get; }
        public AbstractService(LearnNowDbContext context)
        {
            Context = context;
        }
    }
}
