using Base.Services.CustomerServices;

namespace Base.Services.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        
        public ICustomerRepo customerRepo { get; }


    }
}
