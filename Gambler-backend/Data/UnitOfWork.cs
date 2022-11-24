namespace Gambler.PoC.Data
{
    using Gambler.PoC.Repositories;
 
    public interface IUnitOfWork : IDisposable
    {
        IGamblerRepository Gamblers { get; }

        int Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IGamblerRepository Gamblers { get; private set; }
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Gamblers = new GamblerRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
