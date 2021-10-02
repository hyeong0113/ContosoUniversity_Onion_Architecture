using AutoMapper;
using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Courses.Command
{
    public class UpdateCourseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
        {
            private readonly ICourseRepository _courseRepository;
            private readonly IMapper _mapper;

            public UpdateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
            {
                Course input = _mapper.Map<Course>(command);
                await _courseRepository.UpdateAsync(input);

                return Unit.Value;
            }
        }
    }
}
