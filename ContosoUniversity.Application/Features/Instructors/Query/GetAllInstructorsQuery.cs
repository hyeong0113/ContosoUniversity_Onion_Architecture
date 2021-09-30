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
    public class GetAllInstructorsQuery : IRequest<IEnumerable<InstructorDto>>
    {
        public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<InstructorDto>>
        {
            private readonly IInstructorRepository _instructorRepository;
            private readonly IMapper _mapper;

            public GetAllInstructorsQueryHandler(IInstructorRepository instructorRepository, IMapper mapper)
            {
                _instructorRepository = instructorRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<InstructorDto>> Handle(GetAllInstructorsQuery query, CancellationToken cancellationToken)
            {
                var response = await _instructorRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<InstructorDto>>(response);
            }
        }
    }
}
