using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Courses.Query
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {
        public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
        {
            private readonly ICourseRepository _courseRepository;
            private readonly IMapper _mapper;

            public GetAllCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery query, CancellationToken cancellationToken)
            {
                var response = await _courseRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<CourseDto>>(response);
            }
        }
    }
}
