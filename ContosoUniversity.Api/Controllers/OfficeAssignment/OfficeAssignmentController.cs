using ContosoUniversity.Application.Features.Enrollments.Command;
using ContosoUniversity.Application.Features.Enrollments.Query;
using ContosoUniversity.Application.Features.Instructors.Command;
using ContosoUniversity.Application.Features.Instructors.Query;
using ContosoUniversity.Application.Features.OfficeAssignments.Command;
using ContosoUniversity.Application.Features.OfficeAssignments.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Api.Controllers.OfficeAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeAssignmentController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfficeAssignmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllOfficeAssignmentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdOfficeAssignmentQuery { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOfficeAssignmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteOfficeAssignmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
