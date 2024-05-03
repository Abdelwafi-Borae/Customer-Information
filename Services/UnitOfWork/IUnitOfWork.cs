using Customer_Information.Services.AddressServices;
using Customer_Information.Services.CustomerServices;

namespace Customer_Information.Services.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        
        public ICustomerRepo customerRepo { get; }
        public IAddressRepo addressRepo { get; }

    }
}
