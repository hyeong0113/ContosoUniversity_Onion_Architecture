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
    public class GetByIdOfficeAssignmentQuery : IRequest<OfficeAssignmentDto>
    {
        public int Id { get; set; }
        public class GetByIdOfficeAssignmentQueryHandler : IRequestHandler<GetByIdOfficeAssignmentQuery, OfficeAssignmentDto>
        {
            private readonly IOfficeAssignmentRepository _officeAssignmentRepository;
            private readonly IMapper _mapper;

            public GetByIdOfficeAssignmentQueryHandler(IOfficeAssignmentRepository officeAssignmentRepository, IMapper mapper)
            {
                _officeAssignmentRepository = officeAssignmentRepository;
                _mapper = mapper;
            }

            public async Task<OfficeAssignmentDto> Handle(GetByIdOfficeAssignmentQuery query, CancellationToken cancellationToken)
            {
                var response = await _officeAssignmentRepository.GetByIdAsync(query.Id);

                return _mapper.Map<OfficeAssignmentDto>(response);
            }
        }
    }
}
