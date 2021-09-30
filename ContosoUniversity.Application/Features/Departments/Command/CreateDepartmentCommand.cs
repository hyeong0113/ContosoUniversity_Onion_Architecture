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
    public class CreateDepartmentCommand : IRequest<int>
    {
        public int? InstructorId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }

        public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public Task<int> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
            {
                Department input = _mapper.Map<Department>(command);
                var createdId = _departmentRepository.AddAsync(input);
                return createdId;
            }
        }
    }
}
