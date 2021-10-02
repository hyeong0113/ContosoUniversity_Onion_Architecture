using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Enrollments.Command
{
    public class DeleteEnrollmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteStudentCommandHandler : IRequestHandler<DeleteEnrollmentCommand, Unit>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;

            public DeleteStudentCommandHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;
            }

            public async Task<Unit> Handle(DeleteEnrollmentCommand command, CancellationToken cancellationToken)
            {
                await _enrollmentRepository.DeleteAsync(command.Id);

                return Unit.Value;
            }
        }
    }
}
