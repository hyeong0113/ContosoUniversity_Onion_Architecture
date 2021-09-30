using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Instructors.Query
{
    public class GetByIdOfficeAssignmentQuery : IRequest<InstructorDto>
    {
        public int Id { get; set; }
        public class GetByIdInstructorQueryHandler : IRequestHandler<GetByIdOfficeAssignmentQuery, InstructorDto>
        {
            private readonly IInstructorRepository _instructorRepository;
            private readonly IMapper _mapper;

            public GetByIdInstructorQueryHandler(IInstructorRepository instructorRepository, IMapper mapper)
            {
                _instructorRepository = instructorRepository;
                _mapper = mapper;
            }

            public async Task<InstructorDto> Handle(GetByIdOfficeAssignmentQuery query, CancellationToken cancellationToken)
            {
                var response = await _instructorRepository.GetByIdAsync(query.Id);

                return _mapper.Map<InstructorDto>(response);
            }
        }
    }
}
