using ContosoUniversity.Application.Features.Enrollments.Command;
using ContosoUniversity.Application.Features.Enrollments.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Api.Controllers.Enrollments
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnrollmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllEnrollmentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdEnrollmentQuery { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEnrollmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteEnrollmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
