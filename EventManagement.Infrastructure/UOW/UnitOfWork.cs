using EventManagement.Domain.Interfaces.UOW;
using EventManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Infrastructure.UOW
{
    internal class UnitOfWork: IUnitOfWork
    {
        private EventDBContext _context;
        public UnitOfWork( EventDBContext context) 
        {
            _context = context;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
