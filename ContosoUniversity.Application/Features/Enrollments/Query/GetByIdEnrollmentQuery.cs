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
    public class GetByIdEnrollmentQuery : IRequest<Enrollment>
    {
        public int Id { get; set; }
        public class GetByIdEnrollmentQueryHandler : IRequestHandler<GetByIdEnrollmentQuery, Enrollment>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;

            public GetByIdEnrollmentQueryHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;
            }

            public async Task<Enrollment> Handle(GetByIdEnrollmentQuery query, CancellationToken cancellationToken)
            {
                return await _enrollmentRepository.GetByIdAsync(query.Id);
            }
        }
    }
}
