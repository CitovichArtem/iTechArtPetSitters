using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PetSitters.Application.Services.Queries.GetServiceDetails;
using PetSitters.Application.Services.Queries.GetServiceList;
using PetSitters.Application.Services.Commands.CreateService;
using PetSitters.Application.Services.Commands.DeleteService;
using PetSitters.WebApi.Models;



namespace PetSitters.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : BaseController
    {
        private readonly IMapper _mapper;

        public ServiceController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ServiceListVm>> GetAll()
        {
            var query = new GetServiceListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDetailsVm>> Get(Guid id)
        {
            var query = new GetServiceDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateServiceDto createServiceDto)
        {
            var command = _mapper.Map<CreateServiceCommand>(createServiceDto);
            command.UserId = UserId;
            var serviceId = await Mediator.Send(command);
            return Ok(serviceId);
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteServiceCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
