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
    public class CreateEnrollmentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public Grade Grade { get; set; }

        public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, int>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;
            private readonly IMapper _mapper;

            public CreateEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper)
            {
                _enrollmentRepository = enrollmentRepository;
                _mapper = mapper;
            }

            public Task<int> Handle(CreateEnrollmentCommand command, CancellationToken cancellationToken)
            {
                Enrollment input = _mapper.Map<Enrollment>(command);
                var createdId = _enrollmentRepository.AddAsync(input);
                return createdId;
            }
        }
    }
}
