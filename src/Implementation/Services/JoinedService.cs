using Abstraction;
using Abstraction.IServices;
using Domain.Models.Chat;
using Helper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class JoinedService : IJoinedService
    {
        private readonly IUnitOfWorkService _uowService;
        private readonly ILogger<GroupService> _logger;

        public JoinedService(IUnitOfWorkService uowService,
                    ILogger<GroupService> logger)
        {
            _uowService = uowService;
            _logger = logger;
        }

        public async Task<ServiceResult> Create(string idGroup, IEnumerable<string> IDUsers)
        {
            try
            {
                var listUser = _uowService.Joined.Search(j => j.IDGroup == idGroup)
                    .Result
                    .Select(j => j.IDUser).ToList();
                var isValid = listUser.Any(i => IDUsers.Contains(i));
                if (isValid)
                {
                    return new FailedResult("A member has been added in this group");
                }
                IEnumerable<Joined> member = new List<Joined>();
                foreach (var id in IDUsers)
                {
                    member.Append(new Joined()
                    {
                        IDUser = id,
                        IDGroup = idGroup,
                        Created = DateTime.Now,
                    });
                }
                var result = await _uowService.Joined.Inserts(member);
                await _uowService.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult("Some error with Database");
            }
        }

        public async Task<ServiceResult> Delete(string idGroup, IEnumerable<string> IDUsers)
        {
            try
            {
                var listUser =  _uowService.Joined.Search(j => j.IDGroup == idGroup)
                    .Result
                    .Select(j => j.IDUser).ToList();
                var isValid = listUser.Any(i => !IDUsers.Contains(i));
                if (isValid)
                {
                    return new FailedResult("A member has been added in this group");
                }
                IEnumerable<Joined> member = new List<Joined>();
                foreach (var id in IDUsers)
                {
                    member.Append(new Joined()
                    {
                        IDUser = id,
                        IDGroup = idGroup,
                        Created = DateTime.Now,
                    });
                }
                var result = await _uowService.Joined.Removes(member);
                await _uowService.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult("Some error with Database");
            }
        }

        public async Task<Joined> GetByID(string id)
        {
            try
            {
                return await _uowService.Joined.GetByID(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new Joined();
            }
        }

        public async Task<IEnumerable<Joined>> GetbyIDGroup(string IDGroup)
        {
            try
            {
                return await _uowService.Joined.Search(x=>x.IDGroup == x.IDGroup);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new List<Joined>();
            }
        }

        public async Task<IEnumerable<Joined>> Search(string searchkey)
        {
            //try
            //{
                //var member = GetbyIDGroup()
                throw new NotImplementedException();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message, ex);
            //    return new List<Joined>();
            //}
        }

        public async Task<ServiceResult> Update(Joined model)
        {
            throw new NotImplementedException();
        }
    }
}
