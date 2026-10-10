using TaskManagement.Domain.Interfaces.UOW;
using TaskManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.UOW
{
    internal class UnitOfWork: IUnitOfWork
    {
        private TaskDBContext _context;
        public UnitOfWork( TaskDBContext context) 
        {
            _context = context;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
