using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetSitters.WebApi.Models;
using System;
using System.Threading.Tasks;
using PetSitters.Application.Pets.Commands.CreatePet;
using PetSitters.Application.Pets.Commands.DeletePet;
using PetSitters.Application.Pets.Queries.GetPetList;


namespace PetSitters.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PetController : BaseController
    {
        private readonly IMapper _mapper;

        public PetController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PetListVm>> GetAll()
        {
            var query = new GetPetListQuery
            {
                UserId = UserId,
            };
            var vm1 = await Mediator.Send(query);
            return Ok(vm1);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePetDto createPetDto)
        {
            var command = _mapper.Map<CreatePetCommand>(createPetDto);
            command.UserId = UserId;
            var serviceId = await Mediator.Send(command);
            return Ok(serviceId);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePetCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
