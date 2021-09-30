using ContosoUniversity.Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Departments.Command
{
    public class DeleteDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
        {
            private readonly IDepartmentRepository _departmentRepository;

            public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
            {
                _departmentRepository = departmentRepository;
            }

            public async Task<Unit> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
            {
                await _departmentRepository.DeleteAsync(command.Id);

                return Unit.Value;
            }
        }
    }
}
