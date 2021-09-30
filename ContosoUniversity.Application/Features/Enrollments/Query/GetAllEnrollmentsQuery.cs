using AutoMapper;
using ContosoUniversity.Application.Dtos;
using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Enrollments.Query
{
    public class GetAllEnrollmentsQuery : IRequest<IEnumerable<EnrollmentDto>>
    {
        public class GetAllEnrollmentsQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, IEnumerable<EnrollmentDto>>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;
            private readonly IMapper _mapper;

            public GetAllEnrollmentsQueryHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper)
            {
                _enrollmentRepository = enrollmentRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<EnrollmentDto>> Handle(GetAllEnrollmentsQuery query, CancellationToken cancellationToken)
            {
                var response = await _enrollmentRepository.GetAllEnrollments();
                return _mapper.Map<IEnumerable<EnrollmentDto>>(response);
            }
        }
    }
}
