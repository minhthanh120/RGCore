using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Domain.Contexts;
namespace Implementation
{
    public class UnitOfWorkService:IUnitOfWorkService
    {
        private readonly CoreContext _context;
        public UnitOfWorkService(CoreContext context)
        {
            _context = context;
        }
    }
}
