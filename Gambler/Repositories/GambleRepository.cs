namespace Gambler.PoC.Repositories
{
    using Gambler.PoC.Data;
    using Gambler.PoC.Business.Entities;
    using System.Collections.Generic;

    public interface IGamblerRepository : IRepository<Gambler>
    {
        IEnumerable<Gambler> GetTop10Gamblers();
    }

    public class GamblerRepository : Repository<Gambler>, IGamblerRepository
    {
        public GamblerRepository(DataContext context) : base(context) { }

        public DataContext DataContext { get { return Context as DataContext; } }

        public IEnumerable<Gambler> GetTop10Gamblers()
        {
            return DataContext.Gamblers
                .Take(10)
                .OrderByDescending(g => g.Score);
        }
    }
}
