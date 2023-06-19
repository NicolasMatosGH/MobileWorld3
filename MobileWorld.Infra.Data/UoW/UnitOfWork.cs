using MobileWorld.Domain.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.MobileWorldDbContext _context;

        public UnitOfWork(Context.MobileWorldDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
