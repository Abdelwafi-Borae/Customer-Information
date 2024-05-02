using AutoMapper;
using Base.Data;
using Base.Services.CustomerServices;

namespace Base.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {   protected readonly IMapper mapper;
        protected readonly ApplicationDbContext context;
        public ICustomerRepo customerRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext _context ,IMapper _mapper )
        {
            mapper = _mapper;
            this.context = _context;
            customerRepo=new CustomerRepo(context,mapper);
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
