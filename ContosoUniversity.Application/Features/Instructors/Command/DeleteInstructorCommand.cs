using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Instructors.Command
{
    public class DeleteOfficeAssignmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteInstructorCommandHandler : IRequestHandler<DeleteOfficeAssignmentCommand, Unit>
        {
            private readonly IInstructorRepository _instructorRepository;

            public DeleteInstructorCommandHandler(IInstructorRepository instructorRepository)
            {
                _instructorRepository = instructorRepository;
            }

            public async Task<Unit> Handle(DeleteOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                await _instructorRepository.DeleteAsync(command.Id);

                return Unit.Value;
            }
        }
    }
}
