using Abstraction;
using Abstraction.IServices;
using Domain.Models.Chat;
using Helper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class GroupService:IGroupService
    {
        private readonly IUnitOfWorkService _uowService;
        private readonly ILogger<GroupService> _logger;
        public GroupService(IUnitOfWorkService uowService, ILogger<GroupService> logger)
        {
            _uowService = uowService;
            _logger = logger;
        }

        public async Task<ServiceResult> Create(Group model)
        {
            try
            {
                await _uowService.Group.Create(model);
                await _uowService.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult();
            }
        }

        public async Task<ServiceResult> Delete(string IDGroup)
        {
            try
            {
                var model = await _uowService.Group.GetByID(IDGroup);
                if (model == null)
                {
                    return new FailedResult("This Group has been deleted or not exist");
                }
                await _uowService.Group.Delete(model);
                await _uowService.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult();
            }
        }

        public async Task<IEnumerable<Group>> GetGroupJoined()
        {
            try
            {
                //await _uowService.Group.GetByID(model);
                //await _uowService.SaveChanges();
                //return new SuccessResult();
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new List<Group>();
            }
        }

        public async Task<ServiceResult> Update(Group model)
        {
            try
            {
                var target = await _uowService.Group.GetByID(model.ID);
                if (model == null)
                {
                    return new FailedResult("This Group has been deleted or not exist");
                }
                target.Updated = DateTime.Now;
                target.Name = model.Name;
                await _uowService.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult();
            }
        }

        public async Task<Group> GetByID(string IDGroup)
        {
            try
            {
                var model = await _uowService.Group.GetByID(IDGroup);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new Group();
            }
        }


    }
}
