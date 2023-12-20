﻿using Abstraction;
using Abstraction.IServices;
using AutoMapper;
using Domain.Models.Chat;
using Domain.ViewModels;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        //private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public GroupController(IGroupService groupService,
            IMapper mapper)
        {
            _mapper = mapper;
            _groupService = groupService;
        }


        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public async Task<Group> Get(string id)
        {
            return await _groupService.GetByID(id);
        }

        // POST api/<GroupController>
        [HttpPut]
        public async Task<ServiceResult> Create(GroupView model, IEnumerable<UserView>? users)
        {
            var obj = _mapper.Map<Group>(model);
            return await _groupService.Create(obj);
        }
        // POST api/<GroupController>
        [HttpPost]
        [Authorize]
        public async Task<ServiceResult> Update(GroupView model)
        {
            var obj = _mapper.Map<Group>(model);
            return await _groupService.Update(obj);
        }
        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public async Task<ServiceResult> Delete(string id)
        {
            return await _groupService.Delete(id);
        }
        [HttpGet("{searchkey}")]
        public async Task<IActionResult> Search(string searchkey)
        {
            if(!string.IsNullOrEmpty(searchkey))
            {
                var result = await _groupService.Search(searchkey);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }
    }
}
