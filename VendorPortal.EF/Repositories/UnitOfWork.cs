using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext context { get; }
        public IBaseRepository<OrderStatus> orderStatus { get; set; }
        public IBaseRepository<OrdersXsc> ordersXsc { get; set; }
        public IBaseRepository<OrdersFlag> ordersFlag { get; set; } 
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            orderStatus = new BaseRepository<OrderStatus>(context);
            ordersXsc = new BaseRepository<OrdersXsc>(context);
            ordersFlag = new BaseRepository<OrdersFlag>(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
