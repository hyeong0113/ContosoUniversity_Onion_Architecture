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
    public class GetByIdCourseQuery : IRequest<CourseDto>
    {
        public int Id { get; set; }
        public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQuery, CourseDto>
        {
            private readonly ICourseRepository _courseRepository;
            private readonly IMapper _mapper;

            public GetByIdCourseQueryHandler(ICourseRepository courseRepository, IMapper mapper)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
            }

            public async Task<CourseDto> Handle(GetByIdCourseQuery query, CancellationToken cancellationToken)
            {
                var response = await _courseRepository.GetByIdAsync(query.Id);
                return _mapper.Map<CourseDto>(response);
            }
        }
    }
}
