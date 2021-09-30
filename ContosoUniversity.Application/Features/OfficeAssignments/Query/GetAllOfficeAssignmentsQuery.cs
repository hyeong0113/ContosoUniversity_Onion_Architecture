using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.OfficeAssignments.Query
{
    public class GetAllOfficeAssignmentsQuery : IRequest<IEnumerable<OfficeAssignmentDto>>
    {
        public class GetAllOfficeAssignmentsQueryHandler : IRequestHandler<GetAllOfficeAssignmentsQuery, IEnumerable<OfficeAssignmentDto>>
        {
            private readonly IOfficeAssignmentRepository _officeAssignmentRepository;
            private readonly IMapper _mapper;

            public GetAllOfficeAssignmentsQueryHandler(IOfficeAssignmentRepository officeAssignmentRepository, IMapper mapper)
            {
                _officeAssignmentRepository = officeAssignmentRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<OfficeAssignmentDto>> Handle(GetAllOfficeAssignmentsQuery query, CancellationToken cancellationToken)
            {
                var response = await _officeAssignmentRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<OfficeAssignmentDto>>(response);
            }
        }
    }
}
