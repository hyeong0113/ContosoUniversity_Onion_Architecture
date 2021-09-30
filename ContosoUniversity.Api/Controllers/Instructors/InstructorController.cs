using ContosoUniversity.Application.Features.Enrollments.Command;
using ContosoUniversity.Application.Features.Enrollments.Query;
using ContosoUniversity.Application.Features.Instructors.Command;
using ContosoUniversity.Application.Features.Instructors.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Api.Controllers.Instructors
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateInstructorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllInstructorsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdInstructorQuery { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateInstructorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteInstructorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
