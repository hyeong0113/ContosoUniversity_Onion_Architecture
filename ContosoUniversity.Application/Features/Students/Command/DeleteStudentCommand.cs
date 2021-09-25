using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Students.Command
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
        {
            private readonly IStudentRepository _studentRepository;

            public DeleteStudentCommandHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<Unit> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
            {
                await _studentRepository.DeleteAsync(command.Id);

                return Unit.Value;
            }
        }
    }
}
