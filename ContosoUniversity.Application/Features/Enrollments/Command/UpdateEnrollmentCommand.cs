using AutoMapper;
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
            private readonly IMapper _mapper;

            public UpdateEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper)
            {
                _enrollmentRepository = enrollmentRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateEnrollmentCommand command, CancellationToken cancellationToken)
            {
                Enrollment input = _mapper.Map<Enrollment>(command);
                await _enrollmentRepository.UpdateAsync(input);

                return Unit.Value;
            }
        }
    }
}
