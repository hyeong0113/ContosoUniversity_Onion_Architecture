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
    public class GetByIdEnrollmentQuery : IRequest<EnrollmentDto>
    {
        public int Id { get; set; }
        public class GetByIdEnrollmentQueryHandler : IRequestHandler<GetByIdEnrollmentQuery, EnrollmentDto>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;
            private readonly IMapper _mapper;

            public GetByIdEnrollmentQueryHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper)
            {
                _enrollmentRepository = enrollmentRepository;
                _mapper = mapper;
            }

            public async Task<EnrollmentDto> Handle(GetByIdEnrollmentQuery query, CancellationToken cancellationToken)
            {
                var response = await _enrollmentRepository.GetEnrollmentById(query.Id);
                return _mapper.Map<EnrollmentDto>(response);
            }
        }
    }
}
