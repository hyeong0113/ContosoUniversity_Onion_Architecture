using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Courses.Command
{
    public class DeleteCourseCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
        {
            private readonly ICourseRepository _courseRepository;

            public DeleteCourseCommandHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            public async Task<Unit> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
            {
                await _courseRepository.DeleteAsync(command.Id);

                return Unit.Value;
            }
        }
    }
}
