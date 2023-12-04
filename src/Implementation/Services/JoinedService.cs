using Abstraction;
using Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class JoinedService:IJoinedService
    {
        private readonly IUnitOfWorkService _uowService;
        public JoinedService(IUnitOfWorkService uowService)
        {
            _uowService = uowService;
        }
    }
}
