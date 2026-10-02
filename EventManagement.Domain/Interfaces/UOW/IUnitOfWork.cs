using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Interfaces.UOW
{
    public interface IUnitOfWork
    {
        public Task Save();
    }
}
