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
    public class GetAllEnrollmentsQuery : IRequest<IEnumerable<Enrollment>>
    {
        public class GetAllEnrollmentsQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, IEnumerable<Enrollment>>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;

            public GetAllEnrollmentsQueryHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;
            }

            public async Task<IEnumerable<Enrollment>> Handle(GetAllEnrollmentsQuery query, CancellationToken cancellationToken)
            {
                return await _enrollmentRepository.GetAllAsync();
            }
        }
    }
}
