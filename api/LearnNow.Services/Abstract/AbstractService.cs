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
    }
}
