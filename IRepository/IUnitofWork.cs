namespace GenericRepo.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<Home> Homess { get; }
        Task Save();
    }
}
