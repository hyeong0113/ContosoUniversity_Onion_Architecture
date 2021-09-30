using AutoMapper;
using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.Departments.Command
{
    public class UpdateDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int? InstructorId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }

        public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
            {
                Department input = _mapper.Map<Department>(command);
                await _departmentRepository.UpdateAsync(input);

                return Unit.Value;
            }
        }
    }
}
