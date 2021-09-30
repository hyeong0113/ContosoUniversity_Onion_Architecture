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
    public class UpdateOfficeAssignmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public string Location { get; set; }

        public class UpdateOfficeAssignmentCommandHandler : IRequestHandler<UpdateOfficeAssignmentCommand, Unit>
        {
            private readonly IOfficeAssignmentRepository _officeAssignmentRepository;
            private readonly IMapper _mapper;

            public UpdateOfficeAssignmentCommandHandler(IOfficeAssignmentRepository officeAssignmentRepository, IMapper mapper)
            {
                _officeAssignmentRepository = officeAssignmentRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                OfficeAssignment input = _mapper.Map<OfficeAssignment>(command);
                await _officeAssignmentRepository.UpdateAsync(input);

                return Unit.Value;
            }
        }
    }
}
