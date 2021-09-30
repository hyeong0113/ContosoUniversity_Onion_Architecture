using AutoMapper;
using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Features.OfficeAssignments.Command
{
    public class CreateOfficeAssignmentCommand : IRequest<int>
    {
        public int InstructorId { get; set; }
        public string Location { get; set; }

        public class CreateOfficeAssignmentCommandHandler : IRequestHandler<CreateOfficeAssignmentCommand, int>
        {
            private readonly IOfficeAssignmentRepository _officeAssignmentRepository;
            private readonly IMapper _mapper;

            public CreateOfficeAssignmentCommandHandler(IOfficeAssignmentRepository officeAssignmentRepository, IMapper mapper)
            {
                _officeAssignmentRepository = officeAssignmentRepository;
                _mapper = mapper;
            }

            public Task<int> Handle(CreateOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                OfficeAssignment input = _mapper.Map<OfficeAssignment>(command);
                var createdId = _officeAssignmentRepository.AddAsync(input);
                return createdId;
            }
        }
    }
}
