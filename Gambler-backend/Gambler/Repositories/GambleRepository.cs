namespace Gambler.PoC.Repositories
{
    using Gambler.PoC.Data;
    using Gambler.PoC.Business.Entities;
    using System.Collections.Generic;

    public interface IGamblerRepository : IRepository<Gambler>
    {
        IEnumerable<Gambler> GetTopGamblers();
    }

    public class GamblerRepository : Repository<Gambler>, IGamblerRepository
    {
        public GamblerRepository(DataContext context) : base(context) { }

        public DataContext DataContext { get { return Context as DataContext; } }

        public IEnumerable<Gambler> GetTopGamblers()
        {
            return DataContext.Gamblers
                .Take(25)
                .OrderByDescending(g => g.Score);
        }
    }
}
