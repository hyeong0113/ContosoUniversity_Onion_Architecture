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
    public class UpdateEnrollmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Grade Grade { get; set; }

        public class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand, Unit>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;

            public UpdateEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;
            }

            public async Task<Unit> Handle(UpdateEnrollmentCommand command, CancellationToken cancellationToken)
            {
                Enrollment enrollment = new Enrollment();
                enrollment.Id = command.Id;
                enrollment.StudentId = command.StudentId;
                enrollment.Grade = command.Grade;
                await _enrollmentRepository.UpdateAsync(enrollment);

                return Unit.Value;
            }
        }
    }
}
