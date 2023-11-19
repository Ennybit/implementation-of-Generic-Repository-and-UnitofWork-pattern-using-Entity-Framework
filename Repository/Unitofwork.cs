using GenericRepo.IRepository;

namespace GenericRepo.Repository
{
    public class Unitofwork : IUnitofWork
    {
        private readonly datacontext _context;
        private IGenericRepository<Home>? _home;
        public Unitofwork(datacontext context)
        {
            _context = context;
        }

        public IGenericRepository<Home> Homess => _home ??= new GenericRepository<Home>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
