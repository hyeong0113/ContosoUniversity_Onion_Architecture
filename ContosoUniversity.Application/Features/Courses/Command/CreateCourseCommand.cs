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
    public class CreateCourseCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
        {
            private readonly ICourseRepository _courseRepository;
            private readonly IMapper _mapper;
            public CreateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {
                Course input = _mapper.Map<Course>(command);
                return await _courseRepository.AddAsync(input);
            }
        }
    }
}
