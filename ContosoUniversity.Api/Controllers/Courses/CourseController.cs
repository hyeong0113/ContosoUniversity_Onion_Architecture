using ContosoUniversity.Application.Features.Courses.Command;
using ContosoUniversity.Application.Features.Courses.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Api.Controllers.Courses
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCoursesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdCourseQuery { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCourseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
