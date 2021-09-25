using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Enrollments.Command
{
    public class CreateEnrollmentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public Grade Grade { get; set; }

        public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, int>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;

            public CreateEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;
            }

            public Task<int> Handle(CreateEnrollmentCommand command, CancellationToken cancellationToken)
            {
                Enrollment enrollment = new Enrollment();
                enrollment.StudentId = command.StudentId;
                enrollment.Grade = command.Grade;

                var createdId = _enrollmentRepository.AddAsync(enrollment);
                return createdId;
            }
        }
    }
}
