using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core;

namespace VendorPortal.EF.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext context { get; }
        IBaseRepository<OrderStatus> orderStatus { get; } 
        IBaseRepository<OrdersXsc> ordersXsc { get; }
        IBaseRepository<OrdersFlag> ordersFlag { get; }

        int Complete();
    }
}
