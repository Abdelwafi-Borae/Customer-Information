using AutoMapper;
using Customer_Information.Data;
using Customer_Information.Services.AddressServices;
using Customer_Information.Services.CustomerServices;

namespace Customer_Information.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {   protected readonly IMapper mapper;
        protected readonly ApplicationDbContext context;
        public ICustomerRepo customerRepo { get; private set; }
        public IAddressRepo addressRepo { get; private set; }
        public UnitOfWork(ApplicationDbContext _context ,IMapper _mapper )
        {
            mapper = _mapper;
            this.context = _context;
            customerRepo=new CustomerRepo(context,mapper);
            addressRepo = new AddressRepo(context,mapper);
        }

       

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
           context.Dispose();
        }
    }
}
