using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //public ApplicationDbContext context { get; }
        //public IBaseRepository<RefreshToken> refreshTokens { get; set; }
        //public UnitOfWork(ApplicationDbContext context)
        //{
        //    //this.context = context;
        //    //refreshTokens = new BaseRepository<RefreshToken>(context);
        //}

        //public int Complete()
        //{
        //    return context.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    context.Dispose();
        //}
    }
}
