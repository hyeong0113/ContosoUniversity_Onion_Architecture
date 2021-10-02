using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.OfficeAssignments.Command
{
    public class DeleteOfficeAssignmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteOfficeAssignmentCommandHandler : IRequestHandler<DeleteOfficeAssignmentCommand, Unit>
        {
            private readonly IOfficeAssignmentRepository _officeAssignmentRepository;

            public DeleteOfficeAssignmentCommandHandler(IOfficeAssignmentRepository officeAssignmentRepository)
            {
                _officeAssignmentRepository = officeAssignmentRepository;
            }

            public async Task<Unit> Handle(DeleteOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                await _officeAssignmentRepository.DeleteAsync(command.Id);

                return Unit.Value;
            }
        }
    }
}
