using ContosoUniversity.Application.Features.Departments.Command;
using ContosoUniversity.Application.Features.Departments.Query;
using ContosoUniversity.Application.Features.Enrollments.Command;
using ContosoUniversity.Application.Features.Enrollments.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Api.Controllers.Departments
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllDepartmentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdDepartmentQuery { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
